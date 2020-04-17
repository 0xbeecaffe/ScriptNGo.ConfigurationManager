namespace Scriptngo.ConfigurationManager
{
  partial class Deployer
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
      this.components = new System.ComponentModel.Container();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Deployer));
      this.label1 = new System.Windows.Forms.Label();
      this.tbSelConfigSetName = new System.Windows.Forms.TextBox();
      this.cbScriptPerHost = new System.Windows.Forms.CheckBox();
      this.btnDeploySet = new System.Windows.Forms.Button();
      this.deployTA = new Scriptngo.ConfigurationManager.ConfigDSTableAdapters.DeployTableAdapter();
      this.configDS = new Scriptngo.ConfigurationManager.ConfigDS();
      this.label2 = new System.Windows.Forms.Label();
      this.clbTargets = new System.Windows.Forms.CheckedListBox();
      this.cmTargets = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.cmTargetsSelectAll = new System.Windows.Forms.ToolStripMenuItem();
      this.cmTargetsClearAll = new System.Windows.Forms.ToolStripMenuItem();
      this.cmTargetsToggle = new System.Windows.Forms.ToolStripMenuItem();
      this.setTargetsTA = new Scriptngo.ConfigurationManager.ConfigDSTableAdapters.SetTargetsTableAdapter();
      this.label3 = new System.Windows.Forms.Label();
      this.numHostPerForm = new System.Windows.Forms.NumericUpDown();
      this.btnCancel = new System.Windows.Forms.Button();
      this.cbStartScripts = new System.Windows.Forms.CheckBox();
      ((System.ComponentModel.ISupportInitialize)(this.configDS)).BeginInit();
      this.cmTargets.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.numHostPerForm)).BeginInit();
      this.SuspendLayout();
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(13, 15);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(133, 13);
      this.label1.TabIndex = 0;
      this.label1.Text = "Selected Configration Set :";
      // 
      // tbSelConfigSetName
      // 
      this.tbSelConfigSetName.Enabled = false;
      this.tbSelConfigSetName.Location = new System.Drawing.Point(152, 12);
      this.tbSelConfigSetName.Name = "tbSelConfigSetName";
      this.tbSelConfigSetName.ReadOnly = true;
      this.tbSelConfigSetName.Size = new System.Drawing.Size(255, 20);
      this.tbSelConfigSetName.TabIndex = 1;
      // 
      // cbScriptPerHost
      // 
      this.cbScriptPerHost.AutoSize = true;
      this.cbScriptPerHost.Checked = global::Scriptngo.ConfigurationManager.Properties.Settings.Default.ConfigManager_Deployer_SeparateForms;
      this.cbScriptPerHost.CheckState = System.Windows.Forms.CheckState.Checked;
      this.cbScriptPerHost.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::Scriptngo.ConfigurationManager.Properties.Settings.Default, "ConfigManager_Deployer_SeparateForms", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
      this.cbScriptPerHost.Location = new System.Drawing.Point(12, 40);
      this.cbScriptPerHost.Name = "cbScriptPerHost";
      this.cbScriptPerHost.Size = new System.Drawing.Size(246, 17);
      this.cbScriptPerHost.TabIndex = 2;
      this.cbScriptPerHost.Text = "Create separate deployment script window per ";
      this.cbScriptPerHost.UseVisualStyleBackColor = true;
      // 
      // btnDeploySet
      // 
      this.btnDeploySet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.btnDeploySet.BackColor = System.Drawing.Color.DarkOrange;
      this.btnDeploySet.Location = new System.Drawing.Point(310, 257);
      this.btnDeploySet.Name = "btnDeploySet";
      this.btnDeploySet.Size = new System.Drawing.Size(97, 30);
      this.btnDeploySet.TabIndex = 41;
      this.btnDeploySet.Text = "Deploy now";
      this.btnDeploySet.UseVisualStyleBackColor = false;
      this.btnDeploySet.Click += new System.EventHandler(this.btnDeploySet_Click);
      // 
      // deployTA
      // 
      this.deployTA.ClearBeforeFill = true;
      // 
      // configDS
      // 
      this.configDS.DataSetName = "ConfigDS";
      this.configDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(10, 90);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(241, 13);
      this.label2.TabIndex = 47;
      this.label2.Text = "Deploy configuration to the following targets only :";
      // 
      // clbTargets
      // 
      this.clbTargets.CheckOnClick = true;
      this.clbTargets.ContextMenuStrip = this.cmTargets;
      this.clbTargets.FormattingEnabled = true;
      this.clbTargets.Location = new System.Drawing.Point(12, 107);
      this.clbTargets.MultiColumn = true;
      this.clbTargets.Name = "clbTargets";
      this.clbTargets.Size = new System.Drawing.Size(395, 139);
      this.clbTargets.TabIndex = 46;
      this.clbTargets.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.clbTargets_Format);
      // 
      // cmTargets
      // 
      this.cmTargets.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmTargetsSelectAll,
            this.cmTargetsClearAll,
            this.cmTargetsToggle});
      this.cmTargets.Name = "cmTargets";
      this.cmTargets.Size = new System.Drawing.Size(162, 70);
      // 
      // cmTargetsSelectAll
      // 
      this.cmTargetsSelectAll.Name = "cmTargetsSelectAll";
      this.cmTargetsSelectAll.Size = new System.Drawing.Size(161, 22);
      this.cmTargetsSelectAll.Text = "Select all";
      this.cmTargetsSelectAll.Click += new System.EventHandler(this.cmTargetsSelectAll_Click);
      // 
      // cmTargetsClearAll
      // 
      this.cmTargetsClearAll.Name = "cmTargetsClearAll";
      this.cmTargetsClearAll.Size = new System.Drawing.Size(161, 22);
      this.cmTargetsClearAll.Text = "Clear all";
      this.cmTargetsClearAll.Click += new System.EventHandler(this.cmTargetsClearAll_Click);
      // 
      // cmTargetsToggle
      // 
      this.cmTargetsToggle.Name = "cmTargetsToggle";
      this.cmTargetsToggle.Size = new System.Drawing.Size(161, 22);
      this.cmTargetsToggle.Text = "Toggle selection";
      this.cmTargetsToggle.Click += new System.EventHandler(this.cmTargetsToggle_Click);
      // 
      // setTargetsTA
      // 
      this.setTargetsTA.ClearBeforeFill = true;
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(313, 41);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(32, 13);
      this.label3.TabIndex = 52;
      this.label3.Text = "hosts";
      // 
      // numHostPerForm
      // 
      this.numHostPerForm.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::Scriptngo.ConfigurationManager.Properties.Settings.Default, "ConfigManager_Deployer_HostPerForm", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
      this.numHostPerForm.Location = new System.Drawing.Point(254, 39);
      this.numHostPerForm.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
      this.numHostPerForm.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
      this.numHostPerForm.Name = "numHostPerForm";
      this.numHostPerForm.Size = new System.Drawing.Size(54, 20);
      this.numHostPerForm.TabIndex = 51;
      this.numHostPerForm.Value = global::Scriptngo.ConfigurationManager.Properties.Settings.Default.ConfigManager_Deployer_HostPerForm;
      // 
      // btnCancel
      // 
      this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.btnCancel.BackColor = System.Drawing.Color.CornflowerBlue;
      this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.btnCancel.Location = new System.Drawing.Point(12, 257);
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.Size = new System.Drawing.Size(97, 30);
      this.btnCancel.TabIndex = 54;
      this.btnCancel.Text = "Cancel";
      this.btnCancel.UseVisualStyleBackColor = false;
      // 
      // cbStartScripts
      // 
      this.cbStartScripts.AutoSize = true;
      this.cbStartScripts.Checked = global::Scriptngo.ConfigurationManager.Properties.Settings.Default.ConfigManager_Deployer_StartScripts;
      this.cbStartScripts.CheckState = System.Windows.Forms.CheckState.Checked;
      this.cbStartScripts.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::Scriptngo.ConfigurationManager.Properties.Settings.Default, "ConfigManager_Deployer_StartScripts", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
      this.cbStartScripts.Location = new System.Drawing.Point(12, 65);
      this.cbStartScripts.Name = "cbStartScripts";
      this.cbStartScripts.Size = new System.Drawing.Size(143, 17);
      this.cbStartScripts.TabIndex = 55;
      this.cbStartScripts.Text = "Starts scripts immediately";
      this.cbStartScripts.UseVisualStyleBackColor = true;
      // 
      // Deployer
      // 
      this.AcceptButton = this.btnDeploySet;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.SlateBlue;
      this.CancelButton = this.btnCancel;
      this.ClientSize = new System.Drawing.Size(422, 295);
      this.Controls.Add(this.cbStartScripts);
      this.Controls.Add(this.btnCancel);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.numHostPerForm);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.clbTargets);
      this.Controls.Add(this.btnDeploySet);
      this.Controls.Add(this.cbScriptPerHost);
      this.Controls.Add(this.tbSelConfigSetName);
      this.Controls.Add(this.label1);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "Deployer";
      this.ShowInTaskbar = false;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "Configuration Deployer";
      this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Deployer_FormClosed);
      this.Load += new System.EventHandler(this.Deployer_Load);
      this.Paint += new System.Windows.Forms.PaintEventHandler(this.DrawGradientBackground);
      ((System.ComponentModel.ISupportInitialize)(this.configDS)).EndInit();
      this.cmTargets.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.numHostPerForm)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox tbSelConfigSetName;
    private System.Windows.Forms.CheckBox cbScriptPerHost;
    private System.Windows.Forms.Button btnDeploySet;
    private ConfigDSTableAdapters.DeployTableAdapter deployTA;
    private ConfigDS configDS;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.CheckedListBox clbTargets;
    private ConfigDSTableAdapters.SetTargetsTableAdapter setTargetsTA;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.NumericUpDown numHostPerForm;
    private System.Windows.Forms.ContextMenuStrip cmTargets;
    private System.Windows.Forms.ToolStripMenuItem cmTargetsSelectAll;
    private System.Windows.Forms.ToolStripMenuItem cmTargetsClearAll;
    private System.Windows.Forms.ToolStripMenuItem cmTargetsToggle;
    private System.Windows.Forms.Button btnCancel;
    private System.Windows.Forms.CheckBox cbStartScripts;
  }
}