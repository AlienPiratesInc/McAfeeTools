namespace APISystemTagger
{
    partial class frmSettings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSettings));
            this.lblBatchSize = new System.Windows.Forms.Label();
            this.grpGeneral = new System.Windows.Forms.GroupBox();
            this.txtBatchSize = new System.Windows.Forms.TextBox();
            this.grpWakup = new System.Windows.Forms.GroupBox();
            this.txtAbortMinutes = new System.Windows.Forms.TextBox();
            this.txtRetry = new System.Windows.Forms.TextBox();
            this.txtAttempts = new System.Windows.Forms.TextBox();
            this.txtRandomizeMinutes = new System.Windows.Forms.TextBox();
            this.cboAllAgentHandlers = new System.Windows.Forms.ComboBox();
            this.cboFullPolicy = new System.Windows.Forms.ComboBox();
            this.cboSuperAgent = new System.Windows.Forms.ComboBox();
            this.cboFullProp = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.grpLogin = new System.Windows.Forms.GroupBox();
            this.cboServers = new System.Windows.Forms.ComboBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.lblServer = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.grpGeneral.SuspendLayout();
            this.grpWakup.SuspendLayout();
            this.grpLogin.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblBatchSize
            // 
            this.lblBatchSize.AutoSize = true;
            this.lblBatchSize.Location = new System.Drawing.Point(15, 22);
            this.lblBatchSize.Name = "lblBatchSize";
            this.lblBatchSize.Size = new System.Drawing.Size(58, 13);
            this.lblBatchSize.TabIndex = 1;
            this.lblBatchSize.Text = "Batch Size";
            // 
            // grpGeneral
            // 
            this.grpGeneral.Controls.Add(this.txtBatchSize);
            this.grpGeneral.Controls.Add(this.lblBatchSize);
            this.grpGeneral.Location = new System.Drawing.Point(6, 114);
            this.grpGeneral.Name = "grpGeneral";
            this.grpGeneral.Size = new System.Drawing.Size(169, 50);
            this.grpGeneral.TabIndex = 2;
            this.grpGeneral.TabStop = false;
            this.grpGeneral.Text = "General";
            // 
            // txtBatchSize
            // 
            this.txtBatchSize.Location = new System.Drawing.Point(79, 19);
            this.txtBatchSize.Name = "txtBatchSize";
            this.txtBatchSize.Size = new System.Drawing.Size(72, 20);
            this.txtBatchSize.TabIndex = 15;
            // 
            // grpWakup
            // 
            this.grpWakup.Controls.Add(this.txtAbortMinutes);
            this.grpWakup.Controls.Add(this.txtRetry);
            this.grpWakup.Controls.Add(this.txtAttempts);
            this.grpWakup.Controls.Add(this.txtRandomizeMinutes);
            this.grpWakup.Controls.Add(this.cboAllAgentHandlers);
            this.grpWakup.Controls.Add(this.cboFullPolicy);
            this.grpWakup.Controls.Add(this.cboSuperAgent);
            this.grpWakup.Controls.Add(this.cboFullProp);
            this.grpWakup.Controls.Add(this.label8);
            this.grpWakup.Controls.Add(this.label7);
            this.grpWakup.Controls.Add(this.label6);
            this.grpWakup.Controls.Add(this.label5);
            this.grpWakup.Controls.Add(this.label4);
            this.grpWakup.Controls.Add(this.label3);
            this.grpWakup.Controls.Add(this.label2);
            this.grpWakup.Controls.Add(this.label1);
            this.grpWakup.Location = new System.Drawing.Point(6, 170);
            this.grpWakup.Name = "grpWakup";
            this.grpWakup.Size = new System.Drawing.Size(388, 137);
            this.grpWakup.TabIndex = 3;
            this.grpWakup.TabStop = false;
            this.grpWakup.Text = "Agent Wakeup Settings";
            // 
            // txtAbortMinutes
            // 
            this.txtAbortMinutes.Location = new System.Drawing.Point(303, 108);
            this.txtAbortMinutes.Name = "txtAbortMinutes";
            this.txtAbortMinutes.Size = new System.Drawing.Size(72, 20);
            this.txtAbortMinutes.TabIndex = 17;
            // 
            // txtRetry
            // 
            this.txtRetry.Location = new System.Drawing.Point(303, 79);
            this.txtRetry.Name = "txtRetry";
            this.txtRetry.Size = new System.Drawing.Size(72, 20);
            this.txtRetry.TabIndex = 16;
            // 
            // txtAttempts
            // 
            this.txtAttempts.Location = new System.Drawing.Point(303, 53);
            this.txtAttempts.Name = "txtAttempts";
            this.txtAttempts.Size = new System.Drawing.Size(72, 20);
            this.txtAttempts.TabIndex = 15;
            // 
            // txtRandomizeMinutes
            // 
            this.txtRandomizeMinutes.Location = new System.Drawing.Point(303, 27);
            this.txtRandomizeMinutes.Name = "txtRandomizeMinutes";
            this.txtRandomizeMinutes.Size = new System.Drawing.Size(72, 20);
            this.txtRandomizeMinutes.TabIndex = 14;
            // 
            // cboAllAgentHandlers
            // 
            this.cboAllAgentHandlers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAllAgentHandlers.FormattingEnabled = true;
            this.cboAllAgentHandlers.Items.AddRange(new object[] {
            "True",
            "False"});
            this.cboAllAgentHandlers.Location = new System.Drawing.Point(106, 105);
            this.cboAllAgentHandlers.Name = "cboAllAgentHandlers";
            this.cboAllAgentHandlers.Size = new System.Drawing.Size(84, 21);
            this.cboAllAgentHandlers.TabIndex = 13;
            // 
            // cboFullPolicy
            // 
            this.cboFullPolicy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFullPolicy.FormattingEnabled = true;
            this.cboFullPolicy.Items.AddRange(new object[] {
            "True",
            "False"});
            this.cboFullPolicy.Location = new System.Drawing.Point(106, 79);
            this.cboFullPolicy.Name = "cboFullPolicy";
            this.cboFullPolicy.Size = new System.Drawing.Size(84, 21);
            this.cboFullPolicy.TabIndex = 11;
            // 
            // cboSuperAgent
            // 
            this.cboSuperAgent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSuperAgent.FormattingEnabled = true;
            this.cboSuperAgent.Items.AddRange(new object[] {
            "True",
            "False"});
            this.cboSuperAgent.Location = new System.Drawing.Point(106, 53);
            this.cboSuperAgent.Name = "cboSuperAgent";
            this.cboSuperAgent.Size = new System.Drawing.Size(84, 21);
            this.cboSuperAgent.TabIndex = 10;
            // 
            // cboFullProp
            // 
            this.cboFullProp.DisplayMember = "True";
            this.cboFullProp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFullProp.FormattingEnabled = true;
            this.cboFullProp.Items.AddRange(new object[] {
            "True",
            "False"});
            this.cboFullProp.Location = new System.Drawing.Point(106, 27);
            this.cboFullProp.Name = "cboFullProp";
            this.cboFullProp.Size = new System.Drawing.Size(84, 21);
            this.cboFullProp.TabIndex = 9;
            this.cboFullProp.ValueMember = "True";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(197, 108);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(105, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "Abort After (minutes) ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(197, 56);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Attempts";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(197, 82);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Retry (Seconds)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 108);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "All Agent Handlers";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 82);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Full Policy Update";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(197, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Randomize Minutes";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Super Agent";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Full Props";
            // 
            // grpLogin
            // 
            this.grpLogin.Controls.Add(this.cboServers);
            this.grpLogin.Controls.Add(this.txtPassword);
            this.grpLogin.Controls.Add(this.txtUsername);
            this.grpLogin.Controls.Add(this.lblServer);
            this.grpLogin.Controls.Add(this.lblPassword);
            this.grpLogin.Controls.Add(this.lblUsername);
            this.grpLogin.Location = new System.Drawing.Point(6, 13);
            this.grpLogin.Name = "grpLogin";
            this.grpLogin.Size = new System.Drawing.Size(388, 97);
            this.grpLogin.TabIndex = 4;
            this.grpLogin.TabStop = false;
            this.grpLogin.Text = "Login Information";
            // 
            // cboServers
            // 
            this.cboServers.FormattingEnabled = true;
            this.cboServers.Location = new System.Drawing.Point(70, 66);
            this.cboServers.Name = "cboServers";
            this.cboServers.Size = new System.Drawing.Size(285, 21);
            this.cboServers.TabIndex = 12;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(70, 41);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(285, 20);
            this.txtPassword.TabIndex = 11;
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(70, 16);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(285, 20);
            this.txtUsername.TabIndex = 10;
            // 
            // lblServer
            // 
            this.lblServer.AutoSize = true;
            this.lblServer.Location = new System.Drawing.Point(9, 70);
            this.lblServer.Name = "lblServer";
            this.lblServer.Size = new System.Drawing.Size(60, 13);
            this.lblServer.TabIndex = 9;
            this.lblServer.Text = "Server:Port";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(9, 45);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(56, 13);
            this.lblPassword.TabIndex = 8;
            this.lblPassword.Text = "Password:";
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(9, 20);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(57, 13);
            this.lblUsername.TabIndex = 7;
            this.lblUsername.Text = "UserName";
            // 
            // frmSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(403, 314);
            this.Controls.Add(this.grpLogin);
            this.Controls.Add(this.grpWakup);
            this.Controls.Add(this.grpGeneral);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmSettings";
            this.Text = "Settings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmSettings_FormClosing);
            this.grpGeneral.ResumeLayout(false);
            this.grpGeneral.PerformLayout();
            this.grpWakup.ResumeLayout(false);
            this.grpWakup.PerformLayout();
            this.grpLogin.ResumeLayout(false);
            this.grpLogin.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblBatchSize;
        private System.Windows.Forms.GroupBox grpGeneral;
        private System.Windows.Forms.GroupBox grpWakup;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtBatchSize;
        private System.Windows.Forms.TextBox txtAbortMinutes;
        private System.Windows.Forms.TextBox txtRetry;
        private System.Windows.Forms.TextBox txtAttempts;
        private System.Windows.Forms.TextBox txtRandomizeMinutes;
        private System.Windows.Forms.ComboBox cboAllAgentHandlers;
        private System.Windows.Forms.ComboBox cboFullPolicy;
        private System.Windows.Forms.ComboBox cboSuperAgent;
        private System.Windows.Forms.ComboBox cboFullProp;
        private System.Windows.Forms.GroupBox grpLogin;
        private System.Windows.Forms.ComboBox cboServers;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label lblServer;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblUsername;
    }
}