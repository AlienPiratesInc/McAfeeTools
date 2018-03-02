/*

 * User: "Alien Pirates Inc"
 * Date: 2/20/2013
 * Email: alienpiratesinc@gmail.com

 */
 
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;
using mEpoApi;
using System.Xml;
using System.Xml.Linq;
using System.Net;

namespace APISystemTagger
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		public McAfeeApi mcafeeApi;
		public MainForm()
		{
			
			InitializeComponent();
        }
		
		void BtnApplyClick(object sender, EventArgs e)
		{
			
			//Applies the tag to the systems in the list
			try {
				if (cboTags.Text != "" & this.mcafeeApi != null) {
					if (this.mcafeeApi.doesTagExist(cboTags.Text) == false) {						
						DialogResult createTag = MessageBox.Show(string.Format("Tag {0} does not exist.\n\nDo you want to create tag now?",cboTags.Text),
						                                         "Tag missing",MessageBoxButtons.YesNo,MessageBoxIcon.Exclamation,MessageBoxDefaultButton.Button2);
						
						if (createTag == DialogResult.Yes) {
							this.mcafeeApi.CreateTag(cboTags.Text);
						}else{return;}
						
					}
                    int numApplied = mcafeeApi.ApplyTag(rtbSystems.Lines.ToList(), cboTags.Text);
                    if (chkVerify.Checked ==true) {
                    	VerifyTag("Apply",cboTags.Text);
                    }
                    MessageBox.Show(string.Format("Tag {0} applied to {1} machine(s).", cboTags.Text, numApplied), string.Format("Applied: {0}", cboTags.Text), MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
			} catch (Exception ex) {
				
				MessageBox.Show(ex.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
			}
		}
		
		void BtnClearClick(object sender, EventArgs e)
		{
			//Clears tag from the systems in the list
			try {
				if (cboTags.Text != "" & this.mcafeeApi != null) {
					int numCleared = mcafeeApi.ClearTag(rtbSystems.Lines.ToList(),cboTags.Text);
					if (chkVerify.Checked ==true) {
                    	VerifyTag("Clear",cboTags.Text);
                    }
                    MessageBox.Show(string.Format("Tag {0} cleared from {1} machine(s).",cboTags.Text,numCleared),string.Format("Cleared: {0}", cboTags.Text),MessageBoxButtons.OK,MessageBoxIcon.Information);
				}
			} catch (Exception ex) {
				
				MessageBox.Show(ex.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
			}
		}
		
		void BtnGetSystemsClick(object sender, EventArgs e)
		{
			//Get systems with the specified tag
			try {
				if (cboTags.Text != "" & this.mcafeeApi != null) {
					
					List<Machine> systems = mcafeeApi.GetTaggedSystems(cboTags.Text);
               

	                foreach (Machine sys in systems)
	                {	
                        
	                	if (rtbSystems.Text == "") {
	                		rtbSystems.Text=sys.Name;
	                	}else{
	                		rtbSystems.Text +="\n" +sys.Name;						
	                	}
                                              
	                }
                    MessageBox.Show(string.Format("{0} tagged machine(s) retrieved.", systems.Count), "Retrieved", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
                
			} catch (Exception ex) {
				
				MessageBox.Show(ex.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
			}
		}
		
	
		void VerifyTag(string action,string tag){
			
			try {
				
				string[] TaggedSystems = 	mcafeeApi.GetTaggedSystems(tag).Select(machine => machine.Name.ToUpper()).ToArray();
				Color inList  = Color.Black;
				Color outList=Color.Black;
								
				if (action == "Clear") {
					
					inList = Color.Red;
					outList=Color.Green;
				}else if(action=="Apply"){
					
					inList = Color.Green;
					outList=Color.Red;
				}
									
				foreach (var line in rtbSystems.Lines) {
						rtbSystems.Select(rtbSystems.GetFirstCharIndexOfCurrentLine(),line.Length);
						if (TaggedSystems.Contains(line.ToUpper())) {
								rtbSystems.SelectionColor = inList;
						    }else{
						    	rtbSystems.SelectionColor = outList;
						    }						
				}					
				
				
				
			} catch (Exception ex) {
				
				MessageBox.Show(ex.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
			}
		
		}

        private void tsbSettings_Click(object sender, EventArgs e)
        {
            frmSettings frm = new frmSettings();
            frm.ShowDialog();

            if (PublicVariables.mcafeeApi != null)
            {

                mcafeeApi = PublicVariables.mcafeeApi;
                List<Tag> tags = mcafeeApi.GetTags().OrderBy(x => x.name).ToList();

                foreach (Tag tag in tags)
                {
                    cboTags.Items.Add(tag.name);
                }
            }
        }

        private void btnWakeupSystems_Click(object sender, EventArgs e)
        {
            try
            {
                if (cboTags.Text != "" & this.mcafeeApi != null)
                {

                    string myReturn = mcafeeApi.Wakeup(rtbSystems.Lines.ToList(), PublicVariables._fullProps, PublicVariables._allSuperAgents,
                                                                PublicVariables._randomizeMinutes, PublicVariables._fullPolicyUpdate,
                                                                PublicVariables._allAgentHandlers, PublicVariables._retrySeconds,
                                                                PublicVariables._attempts, PublicVariables._abortMinutes);
                    MessageBox.Show(myReturn, "Wakeup Statistics", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
	}
}
