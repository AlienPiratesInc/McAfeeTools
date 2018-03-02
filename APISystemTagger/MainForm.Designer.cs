/*

 * User: "S1L3ntCr@ck3r"
 * Date: 2/20/2013

 */
namespace APISystemTagger
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.cboTags = new System.Windows.Forms.ComboBox();
            this.rtbSystems = new System.Windows.Forms.RichTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnWakeupSystems = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnGetSystems = new System.Windows.Forms.Button();
            this.btnApply = new System.Windows.Forms.Button();
            this.tsTools = new System.Windows.Forms.ToolStrip();
            this.tsbSettings = new System.Windows.Forms.ToolStripButton();
            this.chkVerify = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            this.tsTools.SuspendLayout();
            this.SuspendLayout();
            // 
            // cboTags
            // 
            this.cboTags.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cboTags.FormattingEnabled = true;
            this.cboTags.Location = new System.Drawing.Point(13, 36);
            this.cboTags.Name = "cboTags";
            this.cboTags.Size = new System.Drawing.Size(425, 21);
            this.cboTags.TabIndex = 0;
            // 
            // rtbSystems
            // 
            this.rtbSystems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbSystems.Location = new System.Drawing.Point(13, 85);
            this.rtbSystems.Name = "rtbSystems";
            this.rtbSystems.Size = new System.Drawing.Size(425, 435);
            this.rtbSystems.TabIndex = 1;
            this.rtbSystems.Text = "";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.btnWakeupSystems);
            this.panel1.Controls.Add(this.btnClear);
            this.panel1.Controls.Add(this.btnGetSystems);
            this.panel1.Controls.Add(this.btnApply);
            this.panel1.Location = new System.Drawing.Point(13, 519);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(425, 38);
            this.panel1.TabIndex = 2;
            // 
            // btnWakeupSystems
            // 
            this.btnWakeupSystems.Location = new System.Drawing.Point(312, 3);
            this.btnWakeupSystems.Name = "btnWakeupSystems";
            this.btnWakeupSystems.Size = new System.Drawing.Size(99, 32);
            this.btnWakeupSystems.TabIndex = 3;
            this.btnWakeupSystems.Text = "Wakeup Systems";
            this.btnWakeupSystems.UseVisualStyleBackColor = true;
            this.btnWakeupSystems.Click += new System.EventHandler(this.btnWakeupSystems_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(114, 3);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(99, 32);
            this.btnClear.TabIndex = 2;
            this.btnClear.Text = "Clear Tag";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.BtnClearClick);
            // 
            // btnGetSystems
            // 
            this.btnGetSystems.Location = new System.Drawing.Point(213, 3);
            this.btnGetSystems.Name = "btnGetSystems";
            this.btnGetSystems.Size = new System.Drawing.Size(99, 32);
            this.btnGetSystems.TabIndex = 1;
            this.btnGetSystems.Text = "Get Systems";
            this.btnGetSystems.UseVisualStyleBackColor = true;
            this.btnGetSystems.Click += new System.EventHandler(this.BtnGetSystemsClick);
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(15, 3);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(99, 32);
            this.btnApply.TabIndex = 0;
            this.btnApply.Text = "Apply Tag";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.BtnApplyClick);
            // 
            // tsTools
            // 
            this.tsTools.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsTools.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbSettings});
            this.tsTools.Location = new System.Drawing.Point(0, 0);
            this.tsTools.Name = "tsTools";
            this.tsTools.Size = new System.Drawing.Size(450, 25);
            this.tsTools.TabIndex = 3;
            this.tsTools.Text = "toolStrip1";
            // 
            // tsbSettings
            // 
            this.tsbSettings.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbSettings.Image = ((System.Drawing.Image)(resources.GetObject("tsbSettings.Image")));
            this.tsbSettings.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSettings.Name = "tsbSettings";
            this.tsbSettings.Size = new System.Drawing.Size(130, 22);
            this.tsbSettings.Text = "Configuration Settings";
            this.tsbSettings.Click += new System.EventHandler(this.tsbSettings_Click);
            // 
            // chkVerify
            // 
            this.chkVerify.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkVerify.AutoSize = true;
            this.chkVerify.Location = new System.Drawing.Point(319, 62);
            this.chkVerify.Name = "chkVerify";
            this.chkVerify.Size = new System.Drawing.Size(127, 17);
            this.chkVerify.TabIndex = 4;
            this.chkVerify.Text = "Verify Tagging Action";
            this.chkVerify.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 559);
            this.Controls.Add(this.chkVerify);
            this.Controls.Add(this.tsTools);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.rtbSystems);
            this.Controls.Add(this.cboTags);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "APISystemTagger";
            this.panel1.ResumeLayout(false);
            this.tsTools.ResumeLayout(false);
            this.tsTools.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
        private System.Windows.Forms.CheckBox chkVerify;
		private System.Windows.Forms.ToolStrip tsTools;
		private System.Windows.Forms.RichTextBox rtbSystems;
		private System.Windows.Forms.ComboBox cboTags;
		private System.Windows.Forms.Button btnApply;
		private System.Windows.Forms.Button btnGetSystems;
		private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnWakeupSystems;
        private System.Windows.Forms.ToolStripButton tsbSettings;
	}
}
