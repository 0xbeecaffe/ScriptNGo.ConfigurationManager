namespace Scriptngo.ConfigurationManager
{
  partial class ConfigManager
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigManager));
      this.configTargetsTA = new Scriptngo.ConfigurationManager.ConfigDSTableAdapters.ConfigTargetsTableAdapter();
      this.configSetTargetsTA = new Scriptngo.ConfigurationManager.ConfigDSTableAdapters.ConfigSetTargetsTableAdapter();
      this.configDS = new Scriptngo.ConfigurationManager.ConfigDS();
      this.configSetsTA = new Scriptngo.ConfigurationManager.ConfigDSTableAdapters.ConfigSetsTableAdapter();
      this.setTargetsTA = new Scriptngo.ConfigurationManager.ConfigDSTableAdapters.SetTargetsTableAdapter();
      this.configLinesTA = new Scriptngo.ConfigurationManager.ConfigDSTableAdapters.ConfigLinesTableAdapter();
      this.qTA = new Scriptngo.ConfigurationManager.ConfigDSTableAdapters.QueriesTableAdapter();
      this.panel1 = new System.Windows.Forms.Panel();
      this.tabControl1 = new System.Windows.Forms.CustomTabControl();
      this.tpConfigSets = new System.Windows.Forms.TabPage();
      this.cbxTargetGroupFilter = new System.Windows.Forms.ComboBox();
      this.label7 = new System.Windows.Forms.Label();
      this.btnEditSet = new System.Windows.Forms.Button();
      this.btnPullConfig = new System.Windows.Forms.Button();
      this.label3 = new System.Windows.Forms.Label();
      this.lvTargetsNotInSet = new System.Windows.Forms.ListView();
      this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.btnDeleteSet = new System.Windows.Forms.Button();
      this.btnCreateSet = new System.Windows.Forms.Button();
      this.label2 = new System.Windows.Forms.Label();
      this.label1 = new System.Windows.Forms.Label();
      this.lvSets = new System.Windows.Forms.ListView();
      this.chSetName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.chSetNote = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.lvTargetsInSet = new System.Windows.Forms.ListView();
      this.chSetTargetGroup = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.chSetTargetName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.btnRemoveSetTarget = new System.Windows.Forms.Button();
      this.btnDeploySet = new System.Windows.Forms.Button();
      this.btnAddSetTarget = new System.Windows.Forms.Button();
      this.tpConfigurations = new System.Windows.Forms.TabPage();
      this.btnApplyToOtherTargets = new System.Windows.Forms.Button();
      this.btnLoadFromFile = new System.Windows.Forms.Button();
      this.btnSaveToFile = new System.Windows.Forms.Button();
      this.btnSaveConfiguration = new System.Windows.Forms.Button();
      this.label6 = new System.Windows.Forms.Label();
      this.tbConfigurationLines = new System.Windows.Forms.TextBox();
      this.cbxConfigSetTargets = new System.Windows.Forms.ComboBox();
      this.label5 = new System.Windows.Forms.Label();
      this.label4 = new System.Windows.Forms.Label();
      this.cbxConfigSets = new System.Windows.Forms.ComboBox();
      this.tpConfigTargets = new System.Windows.Forms.TabPage();
      this.btnConnectToTarget = new System.Windows.Forms.Button();
      this.btnImportTargets = new System.Windows.Forms.Button();
      this.btnEditTarget = new System.Windows.Forms.Button();
      this.btnDeleteTarget = new System.Windows.Forms.Button();
      this.btnAddTarget = new System.Windows.Forms.Button();
      this.lvTargets = new System.Windows.Forms.ListView();
      this.chTargetGroup = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.chTagetName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.chTargetIP = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.chTargetVendor = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.chTargetJumpServer = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.chTargetProtocol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.chTargetPort = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.chTargetNote = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.cmTargets = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.cmTargetsConnect = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
      this.cmTargetsAddNew = new System.Windows.Forms.ToolStripMenuItem();
      this.cmTargetsEdit = new System.Windows.Forms.ToolStripMenuItem();
      this.cmTargetsDelete = new System.Windows.Forms.ToolStripMenuItem();
      this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
      this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
      this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
      this.statusStrip1 = new System.Windows.Forms.StatusStrip();
      this.tsslSQLServer = new System.Windows.Forms.ToolStripStatusLabel();
      ((System.ComponentModel.ISupportInitialize)(this.configDS)).BeginInit();
      this.panel1.SuspendLayout();
      this.tabControl1.SuspendLayout();
      this.tpConfigSets.SuspendLayout();
      this.tpConfigurations.SuspendLayout();
      this.tpConfigTargets.SuspendLayout();
      this.cmTargets.SuspendLayout();
      this.statusStrip1.SuspendLayout();
      this.SuspendLayout();
      // 
      // configTargetsTA
      // 
      this.configTargetsTA.ClearBeforeFill = true;
      // 
      // configSetTargetsTA
      // 
      this.configSetTargetsTA.ClearBeforeFill = true;
      // 
      // configDS
      // 
      this.configDS.DataSetName = "ConfigDS";
      this.configDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
      // 
      // configSetsTA
      // 
      this.configSetsTA.ClearBeforeFill = true;
      // 
      // setTargetsTA
      // 
      this.setTargetsTA.ClearBeforeFill = true;
      // 
      // configLinesTA
      // 
      this.configLinesTA.ClearBeforeFill = true;
      // 
      // panel1
      // 
      this.panel1.Controls.Add(this.tabControl1);
      this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.panel1.Location = new System.Drawing.Point(0, 0);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(952, 511);
      this.panel1.TabIndex = 2;
      this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.DrawGradientBackground);
      // 
      // tabControl1
      // 
      this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.tabControl1.Controls.Add(this.tpConfigSets);
      this.tabControl1.Controls.Add(this.tpConfigurations);
      this.tabControl1.Controls.Add(this.tpConfigTargets);
      this.tabControl1.DisplayStyle = System.Windows.Forms.TabStyle.VisualStudio;
      // 
      // 
      // 
      this.tabControl1.DisplayStyleProvider.BorderColor = System.Drawing.SystemColors.ControlDark;
      this.tabControl1.DisplayStyleProvider.BorderColorHot = System.Drawing.SystemColors.ControlDark;
      this.tabControl1.DisplayStyleProvider.BorderColorSelected = System.Drawing.Color.DeepSkyBlue;
      this.tabControl1.DisplayStyleProvider.CloserColor = System.Drawing.Color.DarkGray;
      this.tabControl1.DisplayStyleProvider.FocusTrack = false;
      this.tabControl1.DisplayStyleProvider.HotTrack = true;
      this.tabControl1.DisplayStyleProvider.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
      this.tabControl1.DisplayStyleProvider.Opacity = 1F;
      this.tabControl1.DisplayStyleProvider.Overlap = 7;
      this.tabControl1.DisplayStyleProvider.Padding = new System.Drawing.Point(14, 1);
      this.tabControl1.DisplayStyleProvider.ShowTabCloser = false;
      this.tabControl1.DisplayStyleProvider.TextColor = System.Drawing.Color.DimGray;
      this.tabControl1.DisplayStyleProvider.TextColorSelected = System.Drawing.Color.SeaShell;
      this.tabControl1.DisplayStyleProvider.USeTabColor = true;
      this.tabControl1.HotTrack = true;
      this.tabControl1.Location = new System.Drawing.Point(12, 12);
      this.tabControl1.Name = "tabControl1";
      this.tabControl1.SelectedIndex = 0;
      this.tabControl1.Size = new System.Drawing.Size(920, 486);
      this.tabControl1.TabIndex = 0;
      // 
      // tpConfigSets
      // 
      this.tpConfigSets.BackColor = System.Drawing.Color.DodgerBlue;
      this.tpConfigSets.Controls.Add(this.cbxTargetGroupFilter);
      this.tpConfigSets.Controls.Add(this.label7);
      this.tpConfigSets.Controls.Add(this.btnEditSet);
      this.tpConfigSets.Controls.Add(this.btnPullConfig);
      this.tpConfigSets.Controls.Add(this.label3);
      this.tpConfigSets.Controls.Add(this.lvTargetsNotInSet);
      this.tpConfigSets.Controls.Add(this.btnDeleteSet);
      this.tpConfigSets.Controls.Add(this.btnCreateSet);
      this.tpConfigSets.Controls.Add(this.label2);
      this.tpConfigSets.Controls.Add(this.label1);
      this.tpConfigSets.Controls.Add(this.lvSets);
      this.tpConfigSets.Controls.Add(this.lvTargetsInSet);
      this.tpConfigSets.Controls.Add(this.btnRemoveSetTarget);
      this.tpConfigSets.Controls.Add(this.btnDeploySet);
      this.tpConfigSets.Controls.Add(this.btnAddSetTarget);
      this.tpConfigSets.Location = new System.Drawing.Point(4, 21);
      this.tpConfigSets.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
      this.tpConfigSets.Name = "tpConfigSets";
      this.tpConfigSets.Padding = new System.Windows.Forms.Padding(3);
      this.tpConfigSets.Size = new System.Drawing.Size(912, 461);
      this.tpConfigSets.TabIndex = 1;
      this.tpConfigSets.Text = "Configuration Sets";
      this.tpConfigSets.Paint += new System.Windows.Forms.PaintEventHandler(this.DrawGradientBackground);
      // 
      // cbxTargetGroupFilter
      // 
      this.cbxTargetGroupFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.cbxTargetGroupFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbxTargetGroupFilter.FormattingEnabled = true;
      this.cbxTargetGroupFilter.Location = new System.Drawing.Point(642, 282);
      this.cbxTargetGroupFilter.Name = "cbxTargetGroupFilter";
      this.cbxTargetGroupFilter.Size = new System.Drawing.Size(246, 21);
      this.cbxTargetGroupFilter.TabIndex = 53;
      this.cbxTargetGroupFilter.DropDownClosed += new System.EventHandler(this.cbxTargetGroupFilter_DropDownClosed);
      // 
      // label7
      // 
      this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.label7.AutoSize = true;
      this.label7.Location = new System.Drawing.Point(517, 285);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(113, 13);
      this.label7.TabIndex = 52;
      this.label7.Text = "Show targes in group :";
      // 
      // btnEditSet
      // 
      this.btnEditSet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.btnEditSet.BackColor = System.Drawing.Color.SandyBrown;
      this.btnEditSet.Location = new System.Drawing.Point(117, 426);
      this.btnEditSet.Name = "btnEditSet";
      this.btnEditSet.Size = new System.Drawing.Size(105, 30);
      this.btnEditSet.TabIndex = 51;
      this.btnEditSet.Text = "Edit Set";
      this.btnEditSet.UseVisualStyleBackColor = false;
      this.btnEditSet.Click += new System.EventHandler(this.btnEditSet_Click);
      // 
      // btnPullConfig
      // 
      this.btnPullConfig.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.btnPullConfig.BackColor = System.Drawing.Color.CornflowerBlue;
      this.btnPullConfig.Location = new System.Drawing.Point(783, 426);
      this.btnPullConfig.Name = "btnPullConfig";
      this.btnPullConfig.Size = new System.Drawing.Size(105, 30);
      this.btnPullConfig.TabIndex = 50;
      this.btnPullConfig.Text = "Pull configuration";
      this.btnPullConfig.UseVisualStyleBackColor = false;
      this.btnPullConfig.Click += new System.EventHandler(this.btnPullConfig_Click);
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(518, 240);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(89, 13);
      this.label3.TabIndex = 49;
      this.label3.Text = "Available Targets";
      // 
      // lvTargetsNotInSet
      // 
      this.lvTargetsNotInSet.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.lvTargetsNotInSet.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
      this.lvTargetsNotInSet.FullRowSelect = true;
      this.lvTargetsNotInSet.HideSelection = false;
      this.lvTargetsNotInSet.Location = new System.Drawing.Point(521, 304);
      this.lvTargetsNotInSet.Name = "lvTargetsNotInSet";
      this.lvTargetsNotInSet.Size = new System.Drawing.Size(367, 116);
      this.lvTargetsNotInSet.TabIndex = 48;
      this.lvTargetsNotInSet.UseCompatibleStateImageBehavior = false;
      this.lvTargetsNotInSet.View = System.Windows.Forms.View.Details;
      // 
      // columnHeader1
      // 
      this.columnHeader1.Text = "Target Name";
      this.columnHeader1.Width = 367;
      // 
      // btnDeleteSet
      // 
      this.btnDeleteSet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.btnDeleteSet.BackColor = System.Drawing.Color.IndianRed;
      this.btnDeleteSet.Location = new System.Drawing.Point(228, 426);
      this.btnDeleteSet.Name = "btnDeleteSet";
      this.btnDeleteSet.Size = new System.Drawing.Size(105, 30);
      this.btnDeleteSet.TabIndex = 47;
      this.btnDeleteSet.Text = "Delete Set";
      this.btnDeleteSet.UseVisualStyleBackColor = false;
      this.btnDeleteSet.Click += new System.EventHandler(this.btnDeleteSet_Click);
      // 
      // btnCreateSet
      // 
      this.btnCreateSet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.btnCreateSet.BackColor = System.Drawing.Color.Tan;
      this.btnCreateSet.Location = new System.Drawing.Point(6, 426);
      this.btnCreateSet.Name = "btnCreateSet";
      this.btnCreateSet.Size = new System.Drawing.Size(105, 30);
      this.btnCreateSet.TabIndex = 46;
      this.btnCreateSet.Text = "Create Set";
      this.btnCreateSet.UseVisualStyleBackColor = false;
      this.btnCreateSet.Click += new System.EventHandler(this.btnCreateSet_Click);
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(518, 19);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(181, 13);
      this.label2.TabIndex = 45;
      this.label2.Text = "Targets included in Configuration Set";
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(7, 19);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(88, 13);
      this.label1.TabIndex = 44;
      this.label1.Text = "Configuration Set";
      // 
      // lvSets
      // 
      this.lvSets.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
      this.lvSets.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chSetName,
            this.chSetNote});
      this.lvSets.FullRowSelect = true;
      this.lvSets.HideSelection = false;
      this.lvSets.Location = new System.Drawing.Point(6, 38);
      this.lvSets.Name = "lvSets";
      this.lvSets.Size = new System.Drawing.Size(495, 382);
      this.lvSets.TabIndex = 43;
      this.lvSets.UseCompatibleStateImageBehavior = false;
      this.lvSets.View = System.Windows.Forms.View.Details;
      this.lvSets.SelectedIndexChanged += new System.EventHandler(this.lvSets_SelectedIndexChanged);
      this.lvSets.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lvSets_MouseDoubleClick);
      // 
      // chSetName
      // 
      this.chSetName.Text = "Set Name";
      this.chSetName.Width = 162;
      // 
      // chSetNote
      // 
      this.chSetNote.Text = "Note";
      this.chSetNote.Width = 355;
      // 
      // lvTargetsInSet
      // 
      this.lvTargetsInSet.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.lvTargetsInSet.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chSetTargetGroup,
            this.chSetTargetName});
      this.lvTargetsInSet.FullRowSelect = true;
      this.lvTargetsInSet.HideSelection = false;
      this.lvTargetsInSet.Location = new System.Drawing.Point(521, 38);
      this.lvTargetsInSet.Name = "lvTargetsInSet";
      this.lvTargetsInSet.Size = new System.Drawing.Size(367, 187);
      this.lvTargetsInSet.TabIndex = 42;
      this.lvTargetsInSet.UseCompatibleStateImageBehavior = false;
      this.lvTargetsInSet.View = System.Windows.Forms.View.Details;
      // 
      // chSetTargetGroup
      // 
      this.chSetTargetGroup.Text = "Target Group";
      this.chSetTargetGroup.Width = 75;
      // 
      // chSetTargetName
      // 
      this.chSetTargetName.Text = "Target Name";
      this.chSetTargetName.Width = 292;
      // 
      // btnRemoveSetTarget
      // 
      this.btnRemoveSetTarget.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnRemoveSetTarget.BackColor = System.Drawing.Color.IndianRed;
      this.btnRemoveSetTarget.Location = new System.Drawing.Point(783, 231);
      this.btnRemoveSetTarget.Name = "btnRemoveSetTarget";
      this.btnRemoveSetTarget.Size = new System.Drawing.Size(105, 30);
      this.btnRemoveSetTarget.TabIndex = 41;
      this.btnRemoveSetTarget.Text = "Remove Target";
      this.btnRemoveSetTarget.UseVisualStyleBackColor = false;
      this.btnRemoveSetTarget.Click += new System.EventHandler(this.btnRemoveSetTarget_Click);
      // 
      // btnDeploySet
      // 
      this.btnDeploySet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.btnDeploySet.BackColor = System.Drawing.Color.SlateBlue;
      this.btnDeploySet.Location = new System.Drawing.Point(672, 426);
      this.btnDeploySet.Name = "btnDeploySet";
      this.btnDeploySet.Size = new System.Drawing.Size(105, 30);
      this.btnDeploySet.TabIndex = 40;
      this.btnDeploySet.Text = "Deploy Set";
      this.btnDeploySet.UseVisualStyleBackColor = false;
      this.btnDeploySet.Click += new System.EventHandler(this.btnDeploySet_Click);
      // 
      // btnAddSetTarget
      // 
      this.btnAddSetTarget.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnAddSetTarget.BackColor = System.Drawing.Color.DarkSeaGreen;
      this.btnAddSetTarget.Location = new System.Drawing.Point(672, 231);
      this.btnAddSetTarget.Name = "btnAddSetTarget";
      this.btnAddSetTarget.Size = new System.Drawing.Size(105, 30);
      this.btnAddSetTarget.TabIndex = 39;
      this.btnAddSetTarget.Text = "Add target";
      this.btnAddSetTarget.UseVisualStyleBackColor = false;
      this.btnAddSetTarget.Click += new System.EventHandler(this.btnAddSetTarget_Click);
      // 
      // tpConfigurations
      // 
      this.tpConfigurations.BackColor = System.Drawing.Color.SlateGray;
      this.tpConfigurations.Controls.Add(this.btnApplyToOtherTargets);
      this.tpConfigurations.Controls.Add(this.btnLoadFromFile);
      this.tpConfigurations.Controls.Add(this.btnSaveToFile);
      this.tpConfigurations.Controls.Add(this.btnSaveConfiguration);
      this.tpConfigurations.Controls.Add(this.label6);
      this.tpConfigurations.Controls.Add(this.tbConfigurationLines);
      this.tpConfigurations.Controls.Add(this.cbxConfigSetTargets);
      this.tpConfigurations.Controls.Add(this.label5);
      this.tpConfigurations.Controls.Add(this.label4);
      this.tpConfigurations.Controls.Add(this.cbxConfigSets);
      this.tpConfigurations.Location = new System.Drawing.Point(4, 21);
      this.tpConfigurations.Name = "tpConfigurations";
      this.tpConfigurations.Size = new System.Drawing.Size(912, 461);
      this.tpConfigurations.TabIndex = 2;
      this.tpConfigurations.Text = "Configurations";
      this.tpConfigurations.Paint += new System.Windows.Forms.PaintEventHandler(this.DrawGradientBackground);
      this.tpConfigurations.Enter += new System.EventHandler(this.tpConfigurations_Enter);
      // 
      // btnApplyToOtherTargets
      // 
      this.btnApplyToOtherTargets.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.btnApplyToOtherTargets.BackColor = System.Drawing.Color.Orchid;
      this.btnApplyToOtherTargets.Location = new System.Drawing.Point(391, 404);
      this.btnApplyToOtherTargets.Name = "btnApplyToOtherTargets";
      this.btnApplyToOtherTargets.Size = new System.Drawing.Size(121, 30);
      this.btnApplyToOtherTargets.TabIndex = 43;
      this.btnApplyToOtherTargets.Text = "Copy configuation";
      this.btnApplyToOtherTargets.UseVisualStyleBackColor = false;
      this.btnApplyToOtherTargets.Click += new System.EventHandler(this.btnApplyToOtherTargets_Click);
      // 
      // btnLoadFromFile
      // 
      this.btnLoadFromFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.btnLoadFromFile.BackColor = System.Drawing.Color.Aquamarine;
      this.btnLoadFromFile.Location = new System.Drawing.Point(518, 404);
      this.btnLoadFromFile.Name = "btnLoadFromFile";
      this.btnLoadFromFile.Size = new System.Drawing.Size(121, 30);
      this.btnLoadFromFile.TabIndex = 42;
      this.btnLoadFromFile.Text = "Load from file";
      this.btnLoadFromFile.UseVisualStyleBackColor = false;
      this.btnLoadFromFile.Click += new System.EventHandler(this.btnLoadFromFile_Click);
      // 
      // btnSaveToFile
      // 
      this.btnSaveToFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.btnSaveToFile.BackColor = System.Drawing.Color.DarkSeaGreen;
      this.btnSaveToFile.Location = new System.Drawing.Point(645, 404);
      this.btnSaveToFile.Name = "btnSaveToFile";
      this.btnSaveToFile.Size = new System.Drawing.Size(121, 30);
      this.btnSaveToFile.TabIndex = 41;
      this.btnSaveToFile.Text = "Save to file";
      this.btnSaveToFile.UseVisualStyleBackColor = false;
      this.btnSaveToFile.Click += new System.EventHandler(this.btnSaveToFile_Click);
      // 
      // btnSaveConfiguration
      // 
      this.btnSaveConfiguration.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.btnSaveConfiguration.BackColor = System.Drawing.Color.Gold;
      this.btnSaveConfiguration.Location = new System.Drawing.Point(772, 404);
      this.btnSaveConfiguration.Name = "btnSaveConfiguration";
      this.btnSaveConfiguration.Size = new System.Drawing.Size(121, 30);
      this.btnSaveConfiguration.TabIndex = 40;
      this.btnSaveConfiguration.Text = "Save to database";
      this.toolTip1.SetToolTip(this.btnSaveConfiguration, "Saves changes to database");
      this.btnSaveConfiguration.UseVisualStyleBackColor = false;
      this.btnSaveConfiguration.Click += new System.EventHandler(this.btnSaveConfiguration_Click);
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.Location = new System.Drawing.Point(13, 48);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(108, 13);
      this.label6.TabIndex = 5;
      this.label6.Text = "Stored configuration :";
      // 
      // tbConfigurationLines
      // 
      this.tbConfigurationLines.AllowDrop = true;
      this.tbConfigurationLines.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.tbConfigurationLines.Location = new System.Drawing.Point(16, 64);
      this.tbConfigurationLines.Multiline = true;
      this.tbConfigurationLines.Name = "tbConfigurationLines";
      this.tbConfigurationLines.ScrollBars = System.Windows.Forms.ScrollBars.Both;
      this.tbConfigurationLines.Size = new System.Drawing.Size(880, 334);
      this.tbConfigurationLines.TabIndex = 4;
      this.toolTip1.SetToolTip(this.tbConfigurationLines, "You can drag  & drop text files to this area to update configuration");
      this.tbConfigurationLines.TextChanged += new System.EventHandler(this.tbConfigurationLines_TextChanged);
      this.tbConfigurationLines.DragDrop += new System.Windows.Forms.DragEventHandler(this.tbConfigurationLines_DragDrop);
      this.tbConfigurationLines.DragEnter += new System.Windows.Forms.DragEventHandler(this.tbConfigurationLines_DragEnter);
      this.tbConfigurationLines.DragOver += new System.Windows.Forms.DragEventHandler(this.tbConfigurationLines_DragOver);
      // 
      // cbxConfigSetTargets
      // 
      this.cbxConfigSetTargets.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.cbxConfigSetTargets.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbxConfigSetTargets.FormattingEnabled = true;
      this.cbxConfigSetTargets.Location = new System.Drawing.Point(635, 16);
      this.cbxConfigSetTargets.Name = "cbxConfigSetTargets";
      this.cbxConfigSetTargets.Size = new System.Drawing.Size(261, 21);
      this.cbxConfigSetTargets.TabIndex = 3;
      this.cbxConfigSetTargets.DropDownClosed += new System.EventHandler(this.cbxConfigSetTargets_DropDownClosed);
      this.cbxConfigSetTargets.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.cbxConfigSetTargets_Format);
      // 
      // label5
      // 
      this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.label5.AutoSize = true;
      this.label5.Location = new System.Drawing.Point(519, 19);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(109, 13);
      this.label5.TabIndex = 2;
      this.label5.Text = "Configuration Target :";
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(13, 19);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(94, 13);
      this.label4.TabIndex = 1;
      this.label4.Text = "Configuration Set :";
      // 
      // cbxConfigSets
      // 
      this.cbxConfigSets.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.cbxConfigSets.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbxConfigSets.FormattingEnabled = true;
      this.cbxConfigSets.Location = new System.Drawing.Point(113, 16);
      this.cbxConfigSets.Name = "cbxConfigSets";
      this.cbxConfigSets.Size = new System.Drawing.Size(381, 21);
      this.cbxConfigSets.TabIndex = 0;
      this.cbxConfigSets.DropDownClosed += new System.EventHandler(this.cbxConfigSets_DropDownClosed);
      this.cbxConfigSets.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.cbxConfigSets_Format);
      // 
      // tpConfigTargets
      // 
      this.tpConfigTargets.BackColor = System.Drawing.Color.DarkSlateGray;
      this.tpConfigTargets.Controls.Add(this.btnConnectToTarget);
      this.tpConfigTargets.Controls.Add(this.btnImportTargets);
      this.tpConfigTargets.Controls.Add(this.btnEditTarget);
      this.tpConfigTargets.Controls.Add(this.btnDeleteTarget);
      this.tpConfigTargets.Controls.Add(this.btnAddTarget);
      this.tpConfigTargets.Controls.Add(this.lvTargets);
      this.tpConfigTargets.Location = new System.Drawing.Point(4, 21);
      this.tpConfigTargets.Name = "tpConfigTargets";
      this.tpConfigTargets.Padding = new System.Windows.Forms.Padding(3);
      this.tpConfigTargets.Size = new System.Drawing.Size(912, 461);
      this.tpConfigTargets.TabIndex = 0;
      this.tpConfigTargets.Text = "Configuration Targets";
      this.tpConfigTargets.Paint += new System.Windows.Forms.PaintEventHandler(this.DrawGradientBackground);
      // 
      // btnConnectToTarget
      // 
      this.btnConnectToTarget.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.btnConnectToTarget.BackColor = System.Drawing.Color.ForestGreen;
      this.btnConnectToTarget.Location = new System.Drawing.Point(807, 405);
      this.btnConnectToTarget.Name = "btnConnectToTarget";
      this.btnConnectToTarget.Size = new System.Drawing.Size(97, 30);
      this.btnConnectToTarget.TabIndex = 40;
      this.btnConnectToTarget.Text = "Connect to target";
      this.btnConnectToTarget.UseVisualStyleBackColor = false;
      this.btnConnectToTarget.EnabledChanged += new System.EventHandler(this.ColoredButtonEnabledChanged);
      this.btnConnectToTarget.Click += new System.EventHandler(this.btnConnectToTarget_Click);
      // 
      // btnImportTargets
      // 
      this.btnImportTargets.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.btnImportTargets.BackColor = System.Drawing.Color.RoyalBlue;
      this.btnImportTargets.Location = new System.Drawing.Point(315, 405);
      this.btnImportTargets.Name = "btnImportTargets";
      this.btnImportTargets.Size = new System.Drawing.Size(97, 30);
      this.btnImportTargets.TabIndex = 39;
      this.btnImportTargets.Text = "Import targets";
      this.btnImportTargets.UseVisualStyleBackColor = false;
      this.btnImportTargets.Click += new System.EventHandler(this.btnImportTargets_Click);
      // 
      // btnEditTarget
      // 
      this.btnEditTarget.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.btnEditTarget.BackColor = System.Drawing.Color.SandyBrown;
      this.btnEditTarget.Location = new System.Drawing.Point(109, 405);
      this.btnEditTarget.Name = "btnEditTarget";
      this.btnEditTarget.Size = new System.Drawing.Size(97, 30);
      this.btnEditTarget.TabIndex = 38;
      this.btnEditTarget.Text = "Edit target";
      this.btnEditTarget.UseVisualStyleBackColor = false;
      this.btnEditTarget.Click += new System.EventHandler(this.btnEditTarget_Click);
      // 
      // btnDeleteTarget
      // 
      this.btnDeleteTarget.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.btnDeleteTarget.BackColor = System.Drawing.Color.IndianRed;
      this.btnDeleteTarget.Location = new System.Drawing.Point(212, 405);
      this.btnDeleteTarget.Name = "btnDeleteTarget";
      this.btnDeleteTarget.Size = new System.Drawing.Size(97, 30);
      this.btnDeleteTarget.TabIndex = 37;
      this.btnDeleteTarget.Text = "Delete target";
      this.btnDeleteTarget.UseVisualStyleBackColor = false;
      this.btnDeleteTarget.Click += new System.EventHandler(this.btnDeleteTarget_Click);
      // 
      // btnAddTarget
      // 
      this.btnAddTarget.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.btnAddTarget.BackColor = System.Drawing.Color.Tan;
      this.btnAddTarget.Location = new System.Drawing.Point(6, 405);
      this.btnAddTarget.Name = "btnAddTarget";
      this.btnAddTarget.Size = new System.Drawing.Size(97, 30);
      this.btnAddTarget.TabIndex = 36;
      this.btnAddTarget.Text = "Add target";
      this.btnAddTarget.UseVisualStyleBackColor = false;
      this.btnAddTarget.Click += new System.EventHandler(this.btnAddTarget_Click);
      // 
      // lvTargets
      // 
      this.lvTargets.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.lvTargets.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chTargetGroup,
            this.chTagetName,
            this.chTargetIP,
            this.chTargetVendor,
            this.chTargetJumpServer,
            this.chTargetProtocol,
            this.chTargetPort,
            this.chTargetNote});
      this.lvTargets.ContextMenuStrip = this.cmTargets;
      this.lvTargets.FullRowSelect = true;
      this.lvTargets.HideSelection = false;
      this.lvTargets.Location = new System.Drawing.Point(6, 6);
      this.lvTargets.Name = "lvTargets";
      this.lvTargets.Size = new System.Drawing.Size(898, 391);
      this.lvTargets.TabIndex = 0;
      this.lvTargets.UseCompatibleStateImageBehavior = false;
      this.lvTargets.View = System.Windows.Forms.View.Details;
      this.lvTargets.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvTargets_ColumnClick);
      this.lvTargets.SelectedIndexChanged += new System.EventHandler(this.lvTargets_SelectedIndexChanged);
      this.lvTargets.DoubleClick += new System.EventHandler(this.lvTargets_DoubleClick);
      // 
      // chTargetGroup
      // 
      this.chTargetGroup.Text = "Group";
      this.chTargetGroup.Width = 25;
      // 
      // chTagetName
      // 
      this.chTagetName.Text = "Name";
      // 
      // chTargetIP
      // 
      this.chTargetIP.Text = "IP Address";
      this.chTargetIP.Width = 81;
      // 
      // chTargetVendor
      // 
      this.chTargetVendor.Text = "Vendor";
      this.chTargetVendor.Width = 76;
      // 
      // chTargetJumpServer
      // 
      this.chTargetJumpServer.Text = "Jump server";
      this.chTargetJumpServer.Width = 73;
      // 
      // chTargetProtocol
      // 
      this.chTargetProtocol.Text = "Protocol";
      // 
      // chTargetPort
      // 
      this.chTargetPort.Text = "Port";
      // 
      // chTargetNote
      // 
      this.chTargetNote.Text = "Note";
      this.chTargetNote.Width = 463;
      // 
      // cmTargets
      // 
      this.cmTargets.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmTargetsConnect,
            this.toolStripMenuItem1,
            this.cmTargetsAddNew,
            this.cmTargetsEdit,
            this.cmTargetsDelete});
      this.cmTargets.Name = "cmTargets";
      this.cmTargets.Size = new System.Drawing.Size(171, 98);
      this.cmTargets.Opening += new System.ComponentModel.CancelEventHandler(this.cmTargets_Opening);
      // 
      // cmTargetsConnect
      // 
      this.cmTargetsConnect.Name = "cmTargetsConnect";
      this.cmTargetsConnect.Size = new System.Drawing.Size(170, 22);
      this.cmTargetsConnect.Text = "Connect to Target";
      this.cmTargetsConnect.Click += new System.EventHandler(this.cmTargetsConnect_Click);
      // 
      // toolStripMenuItem1
      // 
      this.toolStripMenuItem1.Name = "toolStripMenuItem1";
      this.toolStripMenuItem1.Size = new System.Drawing.Size(167, 6);
      // 
      // cmTargetsAddNew
      // 
      this.cmTargetsAddNew.Name = "cmTargetsAddNew";
      this.cmTargetsAddNew.Size = new System.Drawing.Size(170, 22);
      this.cmTargetsAddNew.Text = "Add new";
      this.cmTargetsAddNew.Click += new System.EventHandler(this.cmTargetsAddNew_Click);
      // 
      // cmTargetsEdit
      // 
      this.cmTargetsEdit.Name = "cmTargetsEdit";
      this.cmTargetsEdit.Size = new System.Drawing.Size(170, 22);
      this.cmTargetsEdit.Text = "Edit";
      this.cmTargetsEdit.Click += new System.EventHandler(this.cmTargetsEdit_Click);
      // 
      // cmTargetsDelete
      // 
      this.cmTargetsDelete.Name = "cmTargetsDelete";
      this.cmTargetsDelete.Size = new System.Drawing.Size(170, 22);
      this.cmTargetsDelete.Text = "Delete";
      this.cmTargetsDelete.Click += new System.EventHandler(this.cmTargetsDelete_Click);
      // 
      // openFileDialog
      // 
      this.openFileDialog.FileName = "openFileDialog1";
      // 
      // statusStrip1
      // 
      this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslSQLServer});
      this.statusStrip1.Location = new System.Drawing.Point(0, 511);
      this.statusStrip1.Name = "statusStrip1";
      this.statusStrip1.Size = new System.Drawing.Size(952, 22);
      this.statusStrip1.TabIndex = 1;
      this.statusStrip1.Text = "statusStrip1";
      // 
      // tsslSQLServer
      // 
      this.tsslSQLServer.BackColor = System.Drawing.Color.Transparent;
      this.tsslSQLServer.Image = global::Scriptngo.ConfigurationManager.Resource1.DatabaseProject_7342_16x_32;
      this.tsslSQLServer.ImageTransparentColor = System.Drawing.Color.Black;
      this.tsslSQLServer.Name = "tsslSQLServer";
      this.tsslSQLServer.Size = new System.Drawing.Size(108, 17);
      this.tsslSQLServer.Text = "Server/Database";
      // 
      // ConfigManager
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.DimGray;
      this.ClientSize = new System.Drawing.Size(952, 533);
      this.Controls.Add(this.panel1);
      this.Controls.Add(this.statusStrip1);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.MinimumSize = new System.Drawing.Size(968, 572);
      this.Name = "ConfigManager";
      this.ShowIcon = false;
      this.Text = "Configuration Manager";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ConfigManager_FormClosing);
      this.Load += new System.EventHandler(this.ConfigManager_Load);
      this.Paint += new System.Windows.Forms.PaintEventHandler(this.DrawGradientBackground);
      ((System.ComponentModel.ISupportInitialize)(this.configDS)).EndInit();
      this.panel1.ResumeLayout(false);
      this.tabControl1.ResumeLayout(false);
      this.tpConfigSets.ResumeLayout(false);
      this.tpConfigSets.PerformLayout();
      this.tpConfigurations.ResumeLayout(false);
      this.tpConfigurations.PerformLayout();
      this.tpConfigTargets.ResumeLayout(false);
      this.cmTargets.ResumeLayout(false);
      this.statusStrip1.ResumeLayout(false);
      this.statusStrip1.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.CustomTabControl tabControl1;
    private System.Windows.Forms.TabPage tpConfigTargets;
    private System.Windows.Forms.ListView lvTargets;
    private System.Windows.Forms.ColumnHeader chTagetName;
    private System.Windows.Forms.ColumnHeader chTargetIP;
    private System.Windows.Forms.ColumnHeader chTargetVendor;
    private System.Windows.Forms.ColumnHeader chTargetJumpServer;
    private System.Windows.Forms.ColumnHeader chTargetProtocol;
    private System.Windows.Forms.ColumnHeader chTargetPort;
    private System.Windows.Forms.ColumnHeader chTargetNote;
    private System.Windows.Forms.TabPage tpConfigSets;
    private ConfigDSTableAdapters.ConfigTargetsTableAdapter configTargetsTA;
    private ConfigDSTableAdapters.ConfigSetTargetsTableAdapter configSetTargetsTA;
    private ConfigDS configDS;
    private ConfigDSTableAdapters.ConfigSetsTableAdapter configSetsTA;
    private System.Windows.Forms.Button btnAddTarget;
    private System.Windows.Forms.Button btnDeleteTarget;
    private System.Windows.Forms.Button btnEditTarget;
    private System.Windows.Forms.Button btnDeleteSet;
    private System.Windows.Forms.Button btnCreateSet;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.ListView lvSets;
    private System.Windows.Forms.ColumnHeader chSetName;
    private System.Windows.Forms.ColumnHeader chSetNote;
    private System.Windows.Forms.ListView lvTargetsInSet;
    private System.Windows.Forms.ColumnHeader chSetTargetName;
    private System.Windows.Forms.Button btnRemoveSetTarget;
    private System.Windows.Forms.Button btnDeploySet;
    private System.Windows.Forms.Button btnAddSetTarget;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.ListView lvTargetsNotInSet;
    private System.Windows.Forms.ColumnHeader columnHeader1;
    private ConfigDSTableAdapters.SetTargetsTableAdapter setTargetsTA;
    private System.Windows.Forms.TabPage tpConfigurations;
    private System.Windows.Forms.ComboBox cbxConfigSetTargets;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.ComboBox cbxConfigSets;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.TextBox tbConfigurationLines;
    private ConfigDSTableAdapters.ConfigLinesTableAdapter configLinesTA;
    private System.Windows.Forms.Button btnSaveConfiguration;
    private ConfigDSTableAdapters.QueriesTableAdapter qTA;
    private System.Windows.Forms.Button btnPullConfig;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.ToolTip toolTip1;
    private System.Windows.Forms.Button btnLoadFromFile;
    private System.Windows.Forms.Button btnSaveToFile;
    private System.Windows.Forms.SaveFileDialog saveFileDialog;
    private System.Windows.Forms.OpenFileDialog openFileDialog;
    private System.Windows.Forms.Button btnEditSet;
    private System.Windows.Forms.StatusStrip statusStrip1;
    private System.Windows.Forms.ToolStripStatusLabel tsslSQLServer;
    private System.Windows.Forms.Button btnImportTargets;
    private System.Windows.Forms.ColumnHeader chTargetGroup;
    private System.Windows.Forms.ComboBox cbxTargetGroupFilter;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.Button btnApplyToOtherTargets;
    private System.Windows.Forms.ColumnHeader chSetTargetGroup;
    private System.Windows.Forms.Button btnConnectToTarget;
    private System.Windows.Forms.ContextMenuStrip cmTargets;
    private System.Windows.Forms.ToolStripMenuItem cmTargetsConnect;
    private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
    private System.Windows.Forms.ToolStripMenuItem cmTargetsAddNew;
    private System.Windows.Forms.ToolStripMenuItem cmTargetsEdit;
    private System.Windows.Forms.ToolStripMenuItem cmTargetsDelete;
  }
}