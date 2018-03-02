using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Windows.Forms;
using mEpoApi;
using System.Net;
using System.IO;
namespace APISystemTagger
{
    public partial class frmSettings : Form
    {
        public frmSettings()
        {
            InitializeComponent();
            this.txtBatchSize.Text = PublicVariables._batchFileSize;
            this.txtAbortMinutes.Text = PublicVariables._abortMinutes;
            this.txtAttempts.Text = PublicVariables._attempts;
            this.txtRandomizeMinutes.Text = PublicVariables._randomizeMinutes;
            this.txtRetry.Text = PublicVariables._retrySeconds;

            this.cboAllAgentHandlers.Text = PublicVariables._allAgentHandlers;
            this.cboFullPolicy.Text = PublicVariables._fullPolicyUpdate;
            this.cboFullProp.Text = PublicVariables._fullProps;
            this.cboSuperAgent.Text = PublicVariables._allSuperAgents;

            if (File.Exists("Servers.xml"))
            {
                XDocument xDoc = XDocument.Load("Servers.xml");
                IEnumerable<XElement> servers = xDoc.Descendants("Server");
                foreach (XElement server in servers)
                {
                    cboServers.Items.Add(server.Value);
                }
                cboServers.SelectedIndex = 0;
            }

        }

        private void frmSettings_FormClosing(object sender, FormClosingEventArgs e)
        {
            PublicVariables._batchFileSize = this.txtBatchSize.Text;
            PublicVariables._abortMinutes=this.txtAbortMinutes.Text ;
            PublicVariables._attempts = this.txtAttempts.Text;
            PublicVariables._randomizeMinutes = this.txtRandomizeMinutes.Text;
            PublicVariables._retrySeconds = this.txtRetry.Text;

            PublicVariables._allAgentHandlers = this.cboAllAgentHandlers.Text;
            PublicVariables._fullPolicyUpdate = this.cboFullPolicy.Text;
            PublicVariables._fullProps = this.cboFullProp.Text;
            PublicVariables._allSuperAgents = this.cboSuperAgent.Text;
            PublicVariables.mcafeeApi = new McAfeeApi(new NetworkCredential(txtUsername.Text, txtPassword.Text), cboServers.Text);
            
        }
    }
}
