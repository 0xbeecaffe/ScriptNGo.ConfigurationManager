namespace Scriptngo.ConfigurationManager
{
  partial class ConfigPuller
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigPuller));
      this.label1 = new System.Windows.Forms.Label();
      this.tbSelConfigSetName = new System.Windows.Forms.TextBox();
      this.cbScriptPerHost = new System.Windows.Forms.CheckBox();
      this.btnPullConfig = new System.Windows.Forms.Button();
      this.configDS = new Scriptngo.ConfigurationManager.ConfigDS();
      this.cbCreateNewSet = new System.Windows.Forms.CheckBox();
      this.setTargetsTA = new Scriptngo.ConfigurationManager.ConfigDSTableAdapters.SetTargetsTableAdapter();
      this.cbAutoSave = new System.Windows.Forms.CheckBox();
      this.qTA = new Scriptngo.ConfigurationManager.ConfigDSTableAdapters.QueriesTableAdapter();
      this.configLinesTA = new Scriptngo.ConfigurationManager.ConfigDSTableAdapters.ConfigLinesTableAdapter();
      this.clbTargets = new System.Windows.Forms.CheckedListBox();
      this.cmTargets = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.cmTargetsSelectAll = new System.Windows.Forms.ToolStripMenuItem();
      this.cmTargetsClearAll = new System.Windows.Forms.ToolStripMenuItem();
      this.cmTargetsToggle = new System.Windows.Forms.ToolStripMenuItem();
      this.label2 = new System.Windows.Forms.Label();
      this.pbPullProgress = new System.Windows.Forms.ProgressBar();
      this.btnCancelPull = new System.Windows.Forms.Button();
      this.lblOperationInProgress = new System.Windows.Forms.Label();
      this.numHostPerForm = new System.Windows.Forms.NumericUpDown();
      this.label3 = new System.Windows.Forms.Label();
      ((System.ComponentModel.ISupportInitialize)(this.configDS)).BeginInit();
      this.cmTargets.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.numHostPerForm)).BeginInit();
      this.SuspendLayout();
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(13, 21);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(133, 13);
      this.label1.TabIndex = 0;
      this.label1.Text = "Selected Configration Set :";
      // 
      // tbSelConfigSetName
      // 
      this.tbSelConfigSetName.Enabled = false;
      this.tbSelConfigSetName.Location = new System.Drawing.Point(152, 18);
      this.tbSelConfigSetName.Name = "tbSelConfigSetName";
      this.tbSelConfigSetName.ReadOnly = true;
      this.tbSelConfigSetName.Size = new System.Drawing.Size(259, 20);
      this.tbSelConfigSetName.TabIndex = 1;
      // 
      // cbScriptPerHost
      // 
      this.cbScriptPerHost.AutoSize = true;
      this.cbScriptPerHost.Checked = global::Scriptngo.ConfigurationManager.Properties.Settings.Default.ConfigManager_Puller_SeparateWindow;
      this.cbScriptPerHost.CheckState = System.Windows.Forms.CheckState.Checked;
      this.cbScriptPerHost.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::Scriptngo.ConfigurationManager.Properties.Settings.Default, "ConfigManager_Puller_SeparateWindow", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
      this.cbScriptPerHost.Location = new System.Drawing.Point(16, 67);
      this.cbScriptPerHost.Name = "cbScriptPerHost";
      this.cbScriptPerHost.Size = new System.Drawing.Size(189, 17);
      this.cbScriptPerHost.TabIndex = 2;
      this.cbScriptPerHost.Text = "Create separate script window per ";
      this.cbScriptPerHost.UseVisualStyleBackColor = true;
      // 
      // btnPullConfig
      // 
      this.btnPullConfig.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.btnPullConfig.BackColor = System.Drawing.Color.DarkOrange;
      this.btnPullConfig.Location = new System.Drawing.Point(314, 258);
      this.btnPullConfig.Name = "btnPullConfig";
      this.btnPullConfig.Size = new System.Drawing.Size(97, 30);
      this.btnPullConfig.TabIndex = 41;
      this.btnPullConfig.Text = "Pull now";
      this.btnPullConfig.UseVisualStyleBackColor = false;
      this.btnPullConfig.EnabledChanged += new System.EventHandler(this.ColoredButtonEnabledChanged);
      this.btnPullConfig.Click += new System.EventHandler(this.btnPullconfig_Click);
      // 
      // configDS
      // 
      this.configDS.DataSetName = "ConfigDS";
      this.configDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
      // 
      // cbCreateNewSet
      // 
      this.cbCreateNewSet.AutoSize = true;
      this.cbCreateNewSet.Checked = global::Scriptngo.ConfigurationManager.Properties.Settings.Default.ConfigManager_Puller_CreateNewSet;
      this.cbCreateNewSet.CheckState = System.Windows.Forms.CheckState.Checked;
      this.cbCreateNewSet.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::Scriptngo.ConfigurationManager.Properties.Settings.Default, "ConfigManager_Puller_CreateNewSet", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
      this.cbCreateNewSet.Location = new System.Drawing.Point(16, 44);
      this.cbCreateNewSet.Name = "cbCreateNewSet";
      this.cbCreateNewSet.Size = new System.Drawing.Size(280, 17);
      this.cbCreateNewSet.TabIndex = 42;
      this.cbCreateNewSet.Text = "Create a new Configuration Set with the same Targets";
      this.cbCreateNewSet.UseVisualStyleBackColor = true;
      // 
      // setTargetsTA
      // 
      this.setTargetsTA.ClearBeforeFill = true;
      // 
      // cbAutoSave
      // 
      this.cbAutoSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.cbAutoSave.AutoSize = true;
      this.cbAutoSave.Checked = global::Scriptngo.ConfigurationManager.Properties.Settings.Default.ConfigManager_Puller_AutoSave;
      this.cbAutoSave.CheckState = System.Windows.Forms.CheckState.Checked;
      this.cbAutoSave.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::Scriptngo.ConfigurationManager.Properties.Settings.Default, "ConfigManager_Puller_AutoSave", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
      this.cbAutoSave.Location = new System.Drawing.Point(16, 264);
      this.cbAutoSave.Name = "cbAutoSave";
      this.cbAutoSave.Size = new System.Drawing.Size(194, 17);
      this.cbAutoSave.TabIndex = 43;
      this.cbAutoSave.Text = "Auto save script results to database";
      this.cbAutoSave.UseVisualStyleBackColor = true;
      // 
      // configLinesTA
      // 
      this.configLinesTA.ClearBeforeFill = true;
      // 
      // clbTargets
      // 
      this.clbTargets.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.clbTargets.CheckOnClick = true;
      this.clbTargets.ContextMenuStrip = this.cmTargets;
      this.clbTargets.FormattingEnabled = true;
      this.clbTargets.Location = new System.Drawing.Point(16, 109);
      this.clbTargets.MultiColumn = true;
      this.clbTargets.Name = "clbTargets";
      this.clbTargets.Size = new System.Drawing.Size(395, 124);
      this.clbTargets.TabIndex = 44;
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
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(16, 91);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(236, 13);
      this.label2.TabIndex = 45;
      this.label2.Text = "Pull configuration from the following targets only :";
      // 
      // pbPullProgress
      // 
      this.pbPullProgress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.pbPullProgress.Location = new System.Drawing.Point(128, 241);
      this.pbPullProgress.Name = "pbPullProgress";
      this.pbPullProgress.Size = new System.Drawing.Size(283, 10);
      this.pbPullProgress.TabIndex = 46;
      this.pbPullProgress.Visible = false;
      this.pbPullProgress.VisibleChanged += new System.EventHandler(this.pbPullProgress_VisibleChanged);
      // 
      // btnCancelPull
      // 
      this.btnCancelPull.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.btnCancelPull.BackColor = System.Drawing.Color.OrangeRed;
      this.btnCancelPull.Location = new System.Drawing.Point(211, 258);
      this.btnCancelPull.Name = "btnCancelPull";
      this.btnCancelPull.Size = new System.Drawing.Size(97, 30);
      this.btnCancelPull.TabIndex = 47;
      this.btnCancelPull.Text = "Cancel operation";
      this.btnCancelPull.UseVisualStyleBackColor = false;
      this.btnCancelPull.Visible = false;
      this.btnCancelPull.Click += new System.EventHandler(this.btnCancelPull_Click);
      // 
      // lblOperationInProgress
      // 
      this.lblOperationInProgress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.lblOperationInProgress.AutoSize = true;
      this.lblOperationInProgress.Location = new System.Drawing.Point(16, 238);
      this.lblOperationInProgress.Name = "lblOperationInProgress";
      this.lblOperationInProgress.Size = new System.Drawing.Size(102, 13);
      this.lblOperationInProgress.TabIndex = 48;
      this.lblOperationInProgress.Text = "Pulling configuration";
      this.lblOperationInProgress.Visible = false;
      // 
      // numHostPerForm
      // 
      this.numHostPerForm.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::Scriptngo.ConfigurationManager.Properties.Settings.Default, "ConfigManager_Puller_HostPerForm", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
      this.numHostPerForm.Location = new System.Drawing.Point(198, 66);
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
      this.numHostPerForm.TabIndex = 49;
      this.numHostPerForm.Value = global::Scriptngo.ConfigurationManager.Properties.Settings.Default.ConfigManager_Puller_HostPerForm;
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(258, 68);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(32, 13);
      this.label3.TabIndex = 50;
      this.label3.Text = "hosts";
      // 
      // ConfigPuller
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.CornflowerBlue;
      this.ClientSize = new System.Drawing.Size(432, 295);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.numHostPerForm);
      this.Controls.Add(this.lblOperationInProgress);
      this.Controls.Add(this.btnCancelPull);
      this.Controls.Add(this.pbPullProgress);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.clbTargets);
      this.Controls.Add(this.cbAutoSave);
      this.Controls.Add(this.cbCreateNewSet);
      this.Controls.Add(this.btnPullConfig);
      this.Controls.Add(this.cbScriptPerHost);
      this.Controls.Add(this.tbSelConfigSetName);
      this.Controls.Add(this.label1);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Name = "ConfigPuller";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "Pull Configuration from Set Targets";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ConfigPuller_FormClosing);
      this.Load += new System.EventHandler(this.ConfigPuller_Load);
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
    private System.Windows.Forms.Button btnPullConfig;
    private ConfigDS configDS;
    private System.Windows.Forms.CheckBox cbCreateNewSet;
    private ConfigDSTableAdapters.SetTargetsTableAdapter setTargetsTA;
    private System.Windows.Forms.CheckBox cbAutoSave;
    private ConfigDSTableAdapters.QueriesTableAdapter qTA;
    private ConfigDSTableAdapters.ConfigLinesTableAdapter configLinesTA;
    private System.Windows.Forms.CheckedListBox clbTargets;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.ProgressBar pbPullProgress;
    private System.Windows.Forms.Button btnCancelPull;
    private System.Windows.Forms.Label lblOperationInProgress;
    private System.Windows.Forms.ContextMenuStrip cmTargets;
    private System.Windows.Forms.ToolStripMenuItem cmTargetsSelectAll;
    private System.Windows.Forms.ToolStripMenuItem cmTargetsClearAll;
    private System.Windows.Forms.ToolStripMenuItem cmTargetsToggle;
    private System.Windows.Forms.NumericUpDown numHostPerForm;
    private System.Windows.Forms.Label label3;
  }
}