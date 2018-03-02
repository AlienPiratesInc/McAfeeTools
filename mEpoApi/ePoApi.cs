/*

 * User: "Alien Pirates Inc"
 * Date: 9/12/2012
 * Updated: 2/22/2013
 * Email: alienpiratesinc@gmail.com

 */


using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using System.Collections;
namespace mEpoApi
{
    public class McAfeeApi
    {
        private NetworkCredential _Creds;
        private string _HTTPSTRING = "";
		public enum Output {xml=0,verbose=1,terse=2,json=3}
        private int _Batchsize = 25;

		
        /// <summary>
        /// This object is used to interact with the
        /// McAfee ePO API
        /// </summary>
        /// <param name="username">ePO Username</param>
        /// <param name="password">ePO Password</param>
        /// <param name="ServerAndPort">Server and port information
        /// The default port used by ePO is 8443
        /// </param>
        public McAfeeApi(string username, string password, string ServerAndPort)
        {
            //Sets the configuration needed to connect to the ePO Server.
            this._Creds = new NetworkCredential(username, password);
            this._HTTPSTRING = ServerAndPort;
            
        }
        
        /// <summary>
        /// This object is used to interact with the
        /// McAfee ePO API 
        /// </summary>
        /// <param name="creds">Network Credential object created from
        /// ePO Username and Password
        /// </param>
        /// <param name="ServerAndPort">Server and port information
        /// The default port used by ePO is 8443
        /// </param>
        public McAfeeApi(NetworkCredential creds, string ServerAndPort)
        {
            //Sets the configuration needed to connect to the ePO Server.
            this._Creds = creds;
            this._HTTPSTRING = ServerAndPort;
            
        }

        public int Batchsize
        {
            get { return _Batchsize; }
            set { _Batchsize=value ; }
        }
        
        /// <summary>
        /// Returns a status of ok or failed depending on if the object is able to make
        /// a successful connection to the specified ePO server.
        /// </summary>
        public string status { 
            get {
                string myData = this.ProcessApiCallGet(@"epo.getVersion?", Output.terse).Status;
                return  myData == "#ERROR#" ? "failed" : "ok";
                }
        }

        /// <summary>
        /// Creates a basic tag in ePO
        /// </summary>
        /// <param name="TagName">Name of the tag to be created</param>
        /// <param name="TagNote">A brief note about what the tag is for.</param>
        /// <returns>Number of tags created</returns>
        public int CreateTag(string TagName, string TagNote = "Script Addition")
        {
            string myUrl = "system.importTag";
            string divideString = DateTime.Now.Ticks.ToString("x");
            string ContentType = string.Format("multipart/form-data; boundary=----------{0}", divideString);
            string PostData = string.Format("------------{0}", divideString);
            PostData += "\r\n" + @"Content-Disposition: form-data; name=""uploadFile""; filename=""tricked.xml""";
            PostData += "\r\n" + @"Content-Type: multipart/form-data" + "\r\n\r\n";

            PostData += string.Format(@"<?xml version=""1.0"" encoding=""UTF-8""?>
                <epo:EPOTagSchema xmlns:epo=""mcafee-epo-policyassignmentrule"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"">
                <EPOTag name=""{0}"" id=""99"" notes=""{1}"" uniquekey=""null"" family=""EPO"" criteria="""" whereclause="""" executeonasci=""false"">
                </EPOTag>
                </epo:EPOTagSchema>", TagName, TagNote) + "\r\n";

            PostData += "------------" + divideString + "--";

            apiReturn myReturn = ProcessApiCallPOST(myUrl, ContentType, PostData);
            if (myReturn.Status != "#ERROR#") {
	            if (myReturn.Data.ToUpper().Contains("TRUE"))
	            {
	                return 1;
	            }
	            else
	            {
	                return 0;
	            }
            }else{return -99;}
        }

        /// <summary>
        /// Returns the version of ePO server if the connection is successful
        /// otherwise it returns 0.0.0
        /// </summary>
        public string ePoVersion{

            get{
                //Gets the version of the ePO Server and returns it as a string
                apiReturn myData = this.ProcessApiCallGet(@"epo.getVersion?", Output.terse);
                return myData.Status != "#ERROR#" ? myData.Data.Replace("\r\n","") : "0.0.0";
            }
            
        }
        
        /// <summary>
        /// Returns bool expression 
        /// true if Tag exist
        /// false if tag does not exist
        /// </summary>
        /// <param name="tag">String representing the name of the tag to check</param>
        /// <returns>true or false</returns>
         public bool doesTagExist(string tag){
        	List<Tag> tags = GetTags().Where(t=>t.name.ToUpper().Equals(tag.ToUpper())).ToList();
			
            if (tags.Count !=0)
            {
                return true;
            }
            else { return false; }
        }

        /// <summary>
        /// Applies the tag to a system.
        /// </summary>
        /// <param name="system">Name or ID of system</param>
        /// <param name="tag">Tag to be applied to the system.</param>
        /// <returns>Number of systems tagged</returns>
        public int ApplyTag(string system, string tag)
        {
            //Tags a system with the tag supplied

            string mySearch = string.Format("system.applyTag?names={0}&tagName={1}", system, tag);
            apiReturn myReturn = this.ProcessApiCallGet(mySearch);            
            if (myReturn.Status != "#ERROR#")
            {
                XDocument xDoc = XDocument.Parse(myReturn.Data);
                IEnumerable<XElement> results = xDoc.Descendants("result");
                return Int32.Parse(results.First().Value);
            }
            else
            {
                return -99;
            }

        }
        
        /// <summary>
        /// Applies the tag to a list of system.
        /// </summary>
        /// <param name="systems">List of System names or IDs</param>
        /// <param name="tag">Tag to be applied to the system</param>
        /// <returns>Number of systems tagged</returns>
        public int ApplyTag(List<string> systems, string tag)
        {
            //Tags a list of systems with the tag specified

            List<IEnumerable<string>> L = this.Group(systems);
            int countOfAdditions = 0;
            foreach (var x in L)
            {
                string sysString = string.Join(",", x.ToArray());
                string mySearch = string.Format("system.applyTag?&tagName={0}&names={1}", tag, sysString);
                apiReturn myReturn = this.ProcessApiCallGet(mySearch);
                if (myReturn.Status != "#ERROR#") {
	                XDocument xDoc = XDocument.Parse(myReturn.Data);
	                IEnumerable<XElement> results = xDoc.Descendants("result");
	                countOfAdditions += Int32.Parse(results.First().Value);
                }
            }
            return countOfAdditions;
        }

        /// <summary>
        /// Issue Wakeup Call to a list of system.
        /// </summary>
        /// <param name="systems">List of System names or IDs</param>
        /// <param name="tag">Tag to be applied to the system</param>
        /// <returns>Number of systems tagged</returns>
        public string Wakeup(List<string> systems,
            string fullProps = "true", string superAgent = "true",
            string RandomMinutes = "0", string forceFullPolicyUpdate = "true",
            string useAllHandlers = "true", string retryIntervalSeconds = "60",
            string attempts = "0", string abortAfterMinutes = "20")
        {
            //Wakes up a list of systems
            List<IEnumerable<string>> L = this.Group(systems);
            string myValue = "";
            foreach (var x in L)
            {
                string sysString = string.Join(",", x.ToArray());
                string mySearch = string.Format("system.wakeupAgent?names={0}&fullProps={1}&superAgent={2}&randomMinutes={3}&forceFullPolicyUpdate={4}&useAllHandlers={5}&retryIntervalSeconds={6}&attempts={7}&abortAfterMinutes={8}", 
                    sysString,fullProps,superAgent,RandomMinutes,forceFullPolicyUpdate,useAllHandlers,retryIntervalSeconds,attempts,abortAfterMinutes);
                apiReturn myReturn = this.ProcessApiCallGet(mySearch,Output.verbose);
                myValue += myReturn.Data + "\n";
            }

            return myValue;
            
        }

        /// <summary>
        /// Clears the tag from a system
        /// </summary>
        /// <param name="system">Name or ID of system</param>
        /// <param name="tag">Tag to be cleared to the system.</param>
        /// <returns>Number of systems the tag was cleared from</returns>
        public int ClearTag(string system, string tag)
        {
            //Clears the specified tag from the system 
            string mySearch = string.Format("system.clearTag?names={0}&tagName={1}", system, tag);
            apiReturn myReturn = this.ProcessApiCallGet(mySearch);
            if (myReturn.Status != "#ERROR#") {
	            XDocument xDoc = XDocument.Parse(myReturn.Data);
	            IEnumerable<XElement> results = xDoc.Descendants("result");
	            return Int32.Parse(results.First().Value);
            }else{return -99;}
        }

        /// <summary>
        /// Clears the tag from a system
        /// </summary>
        /// <param name="systems">List of system by name or ID</param>
        /// <param name="tag">Tag to be cleared to the systems</param>
        /// <returns>Number of systems the tag was cleared from</returns>
        public int ClearTag(List<string> systems, string tag)
        {
            //Clears the specified tag from a list of system 
            List<IEnumerable<string>> L = this.Group(systems);
            int countOfAdditions = 0;
            foreach (var x in L)
            {
                string sysString = string.Join(",", x.ToArray());
                string mySearch = string.Format("system.clearTag?&tagName={0}&names={1}", tag, sysString);                
                apiReturn myReturn = this.ProcessApiCallGet(mySearch);
                 if (myReturn.Status != "#ERROR#") {
                	XDocument xDoc = XDocument.Parse(myReturn.Data);
	                IEnumerable<XElement> results = xDoc.Descendants("result");
	                countOfAdditions += Int32.Parse(results.First().Value);
                }                
            }
            return countOfAdditions;
        }

        /// <summary>
        /// This allows you to create your own query and
        /// will run it against the ePO server.
        /// </summary>
        /// <param name="CustomQuery">Query string to be run</param>
        /// <param name="oFormat">The format for the return.  Uses an Output object</param>
        /// <returns>Returns the results of the query as a string.  Defaults to verbose.</returns>
        public string RunQueryGet(string CustomQuery, Output oFormat = Output.verbose)
        {
            //Runs query that is specified
            apiReturn aR = this.ProcessApiCallGet(CustomQuery, oFormat);
            return aR.Data;
        }

        /// <summary>
        /// Gets the system that have a specified tag
        /// </summary>
        /// <param name="tag">Tag used in query</param>        
        /// <returns>Returns a list of Machine objects. </returns>
        public List<Machine> GetTaggedSystems(string tag)
        {
            //Gets all the systems that have the specified tag
            string mySearch = string.Format("core.executeQuery?target=EPOLeafNode&select=(select+EPOLeafNode.AgentGUID+EPOLeafNode.AutoID+EPOLeafNode.NodeName+EPOLeafNode.LastUpdate+EPOLeafNode.Tags+EPOLeafNode.AgentVersion+EPOBranchNode.NodeTextPath2+EPOComputerProperties.DomainName+EPOComputerProperties.OSType+EPOComputerProperties.OSVersion+EPOComputerProperties.OSServicePackVer+EPOComputerProperties.UserProperty1+EPOComputerProperties.UserProperty2+EPOComputerProperties.UserProperty3+EPOComputerProperties.UserProperty4+EPOComputerProperties.Description)&where=(where(contains+EPOLeafNode.Tags+%22{0}%22))", tag);
            apiReturn myReturn = this.ProcessApiCallGet(mySearch, Output.xml);
            
            List<Machine> systemList = new List<Machine>();
            
             if (myReturn.Status != "#ERROR#") {
	            XDocument xDoc = XDocument.Parse(myReturn.Data);
	            IEnumerable<XElement> Systems = xDoc.Descendants("row");
	            foreach (XElement systemz in Systems)
	            {
	                Machine newSystem = new Machine(systemz.Element("EPOLeafNode.AgentGUID").Value, systemz.Element("EPOLeafNode.AutoID").Value,
	                                              systemz.Element("EPOLeafNode.NodeName").Value, systemz.Element("EPOLeafNode.LastUpdate").Value,
	                                              systemz.Element("EPOLeafNode.Tags").Value, systemz.Element("EPOLeafNode.AgentVersion").Value,
	                                              systemz.Element("EPOBranchNode.NodeTextPath2").Value, systemz.Element("EPOComputerProperties.DomainName").Value,
	                                              systemz.Element("EPOComputerProperties.OSType").Value, systemz.Element("EPOComputerProperties.OSVersion").Value,
	                                              systemz.Element("EPOComputerProperties.OSServicePackVer").Value, systemz.Element("EPOComputerProperties.UserProperty1").Value,
	                                              systemz.Element("EPOComputerProperties.UserProperty2").Value, systemz.Element("EPOComputerProperties.UserProperty3").Value,
	                                              systemz.Element("EPOComputerProperties.UserProperty4").Value, systemz.Element("EPOComputerProperties.Description").Value
	                                              );
	
	                systemList.Add(newSystem);
	            }
            }
            return systemList;
        }

        /// <summary>
        /// Gets a list of tags located in the ePo server
        /// </summary>
        /// <returns>List of of Tag objects </returns>
        public List<Tag> GetTags()
        {
            //Gets the list of tags located in the ePO Server and returns it
            //as a dictionary.
            List<Tag> tagList = new List<Tag>();
            try
            {
                //Gets a list of tags located in the ePO Server.                    
                string mySearch = string.Format("system.findTag?");
				
                apiReturn myReturn = this.ProcessApiCallGet(mySearch);
                
                if (myReturn.Status != "#ERROR#") {
                	XDocument xDoc = XDocument.Parse(myReturn.Data);
                	IEnumerable<XElement> Tags = xDoc.Descendants("TagEPO");
	                foreach (XElement Tag in Tags)
	                {
	                    Tag newTag = new Tag(Tag.Element("tagId").Value, Tag.Element("tagName").Value, Tag.Element("tagNotes").Value);
	
	                    tagList.Add(newTag);
	                }
                }
                
            }
            catch (Exception)
            {
                //If an error is received it clears out the dictionary
                //so that a empty dictionary is returned.
                tagList.Clear();
            }
            return tagList;
        }

        /// <summary>
        /// Used to set the custom fields and the description fields of
        /// a system in ePo.
        /// </summary>
        /// <param name="systemName">Name or Id of system to set the properties of </param>
        /// <param name="description">Value to set the description field</param>
        /// <param name="cust1">Value to set the CustomField1</param>
        /// <param name="cust2">Value to set the CustomField2</param>
        /// <param name="cust3">Value to set the CustomField3</param>
        /// <param name="cust4">Value to set the CustomField4</param>
        /// <returns>Returns string out from the setUserProperties method.</returns>
        public string setSystemProps(string systemName, string description = "", string cust1 = "", string cust2 = "", string cust3 = "", string cust4 = "")
        {

            string props = "";
            props += description != "" ? "&description=" + description : "";
            props += cust1 != "" ? "&customField1=" + cust1 : "";
            props += cust2 != "" ? "&customField2=" + cust2 : "";
            props += cust3 != "" ? "&customField3=" + cust3 : "";
            props += cust4 != "" ? "&customField4=" + cust4 : "";
            
            string mySearch = string.Format("system.setUserProperties?names={0}{1}", systemName, props);
            apiReturn myReturn = this.ProcessApiCallGet(mySearch);
            if (myReturn.Status != "#ERROR#") {
            	XDocument xDoc = XDocument.Parse(myReturn.Data);
            	IEnumerable<XElement> results = xDoc.Descendants("message");
            	return results.First().Value;
            }else{
            	return myReturn.Data;
            }
        }


        /// <summary>
        /// Used to set the custom fields and the description fields of
        /// a system in ePo.
        /// </summary>
        /// <param name="systemNames">List of systems to set the properties on</param>
        /// <param name="description">Value to set the description field</param>
        /// <param name="cust1">Value to set the CustomField1</param>
        /// <param name="cust2">Value to set the CustomField2</param>
        /// <param name="cust3">Value to set the CustomField3</param>
        /// <param name="cust4">Value to set the CustomField4</param>
        /// <returns>Returns a dictionary object with the key being the system name
        /// and the value being the inner message of success or failure.
        /// </returns>
        public Dictionary<string,string> setSystemProps(List<string> systemNames, string description = "", string cust1 = "", string cust2 = "", string cust3 = "", string cust4 = "")
        {
           
            string props = "";
            props += description != "" ? "&description=" + description : "";
            props += cust1 != "" ? "&customField1=" + cust1 : "";
            props += cust2 != "" ? "&customField2=" + cust2 : "";
            props += cust3 != "" ? "&customField3=" + cust3 : "";
            props += cust4 != "" ? "&customField4=" + cust4 : "";

            Dictionary<string, string> sysDict = new Dictionary<string, string>();

            List<IEnumerable<string>> L = this.Group(systemNames);
            foreach (var x in L)
            {
                string sysString = string.Join(",",x.ToArray());
                
                string mySearch = string.Format("system.setUserProperties?names={0}{1}", sysString, props);
                apiReturn myReturn = this.ProcessApiCallGet(mySearch);
                XDocument xDoc = XDocument.Parse(myReturn.Data);
                IEnumerable<XElement> results = xDoc.Descendants("CmdReturnStatus");

                foreach (XElement r in results)
                {
                    sysDict.Add(r.Element("name").Value,r.Element("message").Value);
                }

            }

            return sysDict;
            

        }
        
        /// <summary>
        /// Gets the information for the system specified
        /// </summary>
        /// <param name="SystemName">System to get the information from.</param>
        /// <returns>Returns a List of machine objects.  This allows the ability to account for 
        /// multiple entries with the same name.
        /// </returns>
        public List<Machine> SystemInfo(string SystemName)
        {
            //Gets basic information from system            
            string mySearch = string.Format("core.executeQuery?target=EPOLeafNode&select=(select+EPOLeafNode.AgentGUID+EPOLeafNode.AutoID+EPOLeafNode.NodeName+EPOLeafNode.LastUpdate+EPOLeafNode.Tags+EPOLeafNode.AgentVersion+EPOBranchNode.NodeTextPath2+EPOComputerProperties.DomainName+EPOComputerProperties.OSType+EPOComputerProperties.OSVersion+EPOComputerProperties.OSServicePackVer+EPOComputerProperties.UserProperty1+EPOComputerProperties.UserProperty2+EPOComputerProperties.UserProperty3+EPOComputerProperties.UserProperty4+EPOComputerProperties.Description)&where=(where(contains+EPOLeafNode.NodeName+%22{0}%22))", SystemName);
            List<Machine> systemList = new List<Machine>();
            apiReturn myReturn = this.ProcessApiCallGet(mySearch);
            XDocument xDoc = XDocument.Parse(myReturn.Data);
            IEnumerable<XElement> Systems = xDoc.Descendants("row");

            foreach (XElement systemz in Systems)
            {
                Machine newSystem = new Machine(systemz.Element("EPOLeafNode.AgentGUID").Value, systemz.Element("EPOLeafNode.AutoID").Value,
                                              systemz.Element("EPOLeafNode.NodeName").Value, systemz.Element("EPOLeafNode.LastUpdate").Value,
                                              systemz.Element("EPOLeafNode.Tags").Value, systemz.Element("EPOLeafNode.AgentVersion").Value,
                                              systemz.Element("EPOBranchNode.NodeTextPath2").Value, systemz.Element("EPOComputerProperties.DomainName").Value,
                                              systemz.Element("EPOComputerProperties.OSType").Value, systemz.Element("EPOComputerProperties.OSVersion").Value,
                                              systemz.Element("EPOComputerProperties.OSServicePackVer").Value, systemz.Element("EPOComputerProperties.UserProperty1").Value,
                                              systemz.Element("EPOComputerProperties.UserProperty2").Value, systemz.Element("EPOComputerProperties.UserProperty3").Value,
                                              systemz.Element("EPOComputerProperties.UserProperty4").Value, systemz.Element("EPOComputerProperties.Description").Value
                                              );

                systemList.Add(newSystem);
            }
            return systemList;
        }

        /// <summary>
        /// Returns the object as a string
        /// </summary>
        /// <returns>
        /// <para>Username: [Value]</para>       
        /// <para>Password: ********</para>
        /// <para>Server: [SERVER:PORT]</para>
        /// </returns>
         public override string ToString()
        {
            string myself = "";
            myself += string.Format("Username: {0}\n", this._Creds.UserName);
            myself += string.Format("Password: {0}\n", new string('*',this._Creds.UserName.Length));
            myself += string.Format("Server:   {0}", this._HTTPSTRING);

            return myself;
        }
         
        private bool AcceptAllCertifications(object sender, X509Certificate certification, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            //Tells it to except and SSL cert since the ePO
            //Server uses self signed certs
            return true;
        }

        private apiReturn ProcessApiCallGet(string myURL,Output oFormat = Output.xml){
			apiReturn myReturn = new apiReturn();
			try {
					
					ServicePointManager.ServerCertificateValidationCallback +=  AcceptAllCertifications;
					string myConnection = string.Format("https://{0}/remote/",this._HTTPSTRING);
					string outPutFormat = string.Format("&:output={0}", oFormat.ToString());
									
					//Builds the request to pass to the ePO Server
					Uri myLink = new Uri(myConnection+myURL+outPutFormat);
					HttpWebRequest hwr = (HttpWebRequest)WebRequest.Create(myLink);
					hwr.Credentials = this._Creds;
					hwr.PreAuthenticate = true;
					hwr.Method="Get";
					
					//Gets the responce from the API
					HttpWebResponse hwResponse = (HttpWebResponse)hwr.GetResponse();
					Stream myStream = hwResponse.GetResponseStream();
					
					//Reads the first line which it the status.
					//If it passes the API query it returns OK:
					StreamReader sr = new StreamReader(myStream);
					
					
					
					//Reads the Key information into a variable
					myReturn.Status = sr.ReadLine();
					myReturn.Data = sr.ReadToEnd();
					
					sr.Close();
					myStream.Close();
					hwResponse.Close();
				}
						
				catch (WebException ex) {
					//Displays a message if a web based error is returned
					//also populates the myReturn object
					if(ex.Status == WebExceptionStatus.NameResolutionFailure) {
						//MessageBox.Show("Server could not be located please verify correct name and port","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
						myReturn.Status = "#ERROR#";
						myReturn.Data="Server could not be located please verify correct server name and port";
					}else{
						//MessageBox.Show(ex.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
						myReturn.Status = "#ERROR#";
						myReturn.Data="Web based error!\n" + ex.Message ;
					}
					
				}
				catch (Exception ex){
					//Displays a message if a non-web based error is returned
					//also populates the myReturn object
					//MessageBox.Show(ex.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);					
					myReturn.Status = "#ERROR#";
					myReturn.Data="Non-Web based!\n" + ex.Message ;
				}
				
			return myReturn;
		}
        
       	private apiReturn ProcessApiCallPOST(string myURL,string ContentType, string PostData)
        {
            apiReturn myReturn = new apiReturn();
            try
            {

                ServicePointManager.ServerCertificateValidationCallback += AcceptAllCertifications;
                string myConnection = string.Format("https://{0}/remote/", this._HTTPSTRING);

                //Builds the request to pass to the ePO Server
                Uri myLink = new Uri(myConnection + myURL);
                HttpWebRequest hwr = (HttpWebRequest)WebRequest.Create(myLink);
                hwr.PreAuthenticate = true;
                hwr.Credentials = this._Creds;

                
                hwr.Method = "Post";
                hwr.ContentType = ContentType;

                byte[] byteArray = Encoding.UTF8.GetBytes(PostData);                
                hwr.ContentLength = byteArray.Length;

                Stream hr = hwr.GetRequestStream();
                hr.Write(byteArray, 0, byteArray.Length);
                hr.Close();
                //Gets the responce from the API
                HttpWebResponse hwResponse = (HttpWebResponse)hwr.GetResponse();
                Stream myStream = hwResponse.GetResponseStream();

                //Reads the first line which it the status.
                //If it passes the API query it returns OK:
                StreamReader sr = new StreamReader(myStream);

                //Reads the Key information into a variable
                myReturn.Status = sr.ReadLine();
                myReturn.Data = sr.ReadToEnd();

                sr.Close();
                myStream.Close();
                hwResponse.Close();
            }

            catch (WebException ex)
            {
                //Displays a message if a web based error is returned
                //also populates the myReturn object
                if (ex.Status == WebExceptionStatus.NameResolutionFailure)
                {
                    //MessageBox.Show("Server could not be located please verify correct name and port","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    myReturn.Status = "#ERROR#";
                    myReturn.Data = "Server could not be located please verify correct server name and port";
                }
                else
                {
                    //MessageBox.Show(ex.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    myReturn.Status = "#ERROR#";
                    myReturn.Data = "Web based error!\n" + ex.Message;
                }

            }
            catch (Exception ex)
            {
                //Displays a message if a non-web based error is returned
                //also populates the myReturn object
                //MessageBox.Show(ex.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);					
                myReturn.Status = "#ERROR#";
                myReturn.Data = "Non-Web based!\n" + ex.Message;
            }

            return myReturn;
        }

        private List<IEnumerable<string>> Group(List<string> grpObjects)
        {
            List<IEnumerable<string>> tempList = new List<IEnumerable<string>>();

            for (int i = 0; i < grpObjects.Count; i += this._Batchsize)
            {
                tempList.Add(grpObjects.Skip(i).Take(this._Batchsize));
            }

            return tempList;
        }


       


    }
}


