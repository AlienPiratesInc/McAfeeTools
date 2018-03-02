/*

 * User: "Alien Pirates Inc"
 * Date: 9/12/2012
 * Updated: 2/22/2013
 * Email: alienpiratesinc@gmail.com

 */
 
using System;

namespace mEpoApi
{
	/// <summary>
	/// Description of System.
	/// </summary>
	public class Machine
	{
		private string _Guid="";
		private string _Id="";
		private string _Name="";
		private string _Lastupdate="";
		private string _Tags="";
		private string _AgentVersion="";
		private string _Path="";
		private string _Domain="";
		private string _OsType="";
		private string _OsVersion="";
		private string _OsServicePack="";
        private string _CustomProp1 = "";
        private string _CustomProp2 = "";
        private string _CustomProp3 = "";
        private string _CustomProp4 = "";
        private string _Description = "";
			
		public Machine(string guid,string id,string name,string lastupdate,
		              string tags,string agentversion,string path,string domain,
		              string ostype,string osversion,string osservicepack,
                      string customprop1, string customprop2, string customprop3,
                      string customprop4, string description)
		{
			this._Guid = guid;
			this._Id = id;
			this._Name=name;
			this._Lastupdate=lastupdate;
			this._Tags=tags;
			this._AgentVersion=agentversion;
			this._Path=path;
			this._Domain=domain;
			this._OsType=ostype;
			this._OsVersion=osversion;
			this._OsServicePack=osservicepack;
            this._CustomProp1 = customprop1;
            this._CustomProp2 = customprop2;
            this._CustomProp3 = customprop3;
            this._CustomProp4 = customprop4;
            this._Description = description;
		}
		
		public override string ToString()
		{
			return string.Format(@"Guid={0}, ID={1}, Name={2}, LastUpdate={3}, Tags={4}, AgentVersion={5}, Path={6}, Domain={7}, OsType={8}, OsVersion={9}, OsServicePack={10}, CustomProp1={11}, CustomProp2={12}, CustomProp3={13}, CustomProp4={14}, Description={15}", 
			                    this._Guid,this._Id,this._Name,this._Lastupdate,this._Tags,this._AgentVersion,this._Path,this._Domain,this._OsType,this._OsVersion,this._OsServicePack,this._CustomProp1,this._CustomProp2,this._CustomProp3,this._CustomProp4,this._Description);
		}
		
		
		public string Guid { get{return this._Guid;}}
		public string Id { get{return this._Id;}}
		public string Name { get{return this._Name; }}
		public string Lastupdate{ get{return this._Lastupdate;}}
		public string Tags{ get{return this._Tags;}}
		public string AgentVersion{ get{return this._AgentVersion;}}
		public string Path{ get{return this._Path;}}
		public string Domain{ get{return this._Domain;}}
		public string OsType{ get{return this._OsType;}}
		public string OsVersion{ get{return this._OsVersion;}}
		public string OsServicePack{ get{return this._OsServicePack;}}
        public string CustomProp1 { get { return this._CustomProp1; } }
        public string CustomProp2 { get { return this._CustomProp2; } }
        public string CustomProp3 { get { return this._CustomProp3; } }
        public string CustomProp4 { get { return this._CustomProp4; } }
        public string Description { get { return this._Description; } }
	}
}
