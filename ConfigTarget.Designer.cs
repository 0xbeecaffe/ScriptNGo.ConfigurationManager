namespace Scriptngo.ConfigurationManager
{
  partial class ConfigTarget
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
      System.Windows.Forms.Label targetNameLabel;
      System.Windows.Forms.Label targetIPLabel;
      System.Windows.Forms.Label deviceVendorLabel;
      System.Windows.Forms.Label jumpServerIPLabel;
      System.Windows.Forms.Label protocolLabel;
      System.Windows.Forms.Label portLabel;
      System.Windows.Forms.Label noteLabel;
      System.Windows.Forms.Label label1;
      this.configDS = new Scriptngo.ConfigurationManager.ConfigDS();
      this.configTargetsBS = new System.Windows.Forms.BindingSource(this.components);
      this.configTargetsTableAdapter = new Scriptngo.ConfigurationManager.ConfigDSTableAdapters.ConfigTargetsTableAdapter();
      this.tableAdapterManager = new Scriptngo.ConfigurationManager.ConfigDSTableAdapters.TableAdapterManager();
      this.targetNameTextBox = new System.Windows.Forms.TextBox();
      this.targetIPTextBox = new System.Windows.Forms.TextBox();
      this.portTextBox = new System.Windows.Forms.TextBox();
      this.noteTextBox = new System.Windows.Forms.TextBox();
      this.cbxVendors = new System.Windows.Forms.ComboBox();
      this.cbxJumpServers = new System.Windows.Forms.ComboBox();
      this.cbxProtocols = new System.Windows.Forms.ComboBox();
      this.qTA = new Scriptngo.ConfigurationManager.ConfigDSTableAdapters.QueriesTableAdapter();
      this.cbxTargetGroup = new System.Windows.Forms.ComboBox();
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.btnCancel = new System.Windows.Forms.Button();
      this.btnSave = new System.Windows.Forms.Button();
      this.distinctTargetGroupsTableAdapter = new Scriptngo.ConfigurationManager.ConfigDSTableAdapters.DistinctTargetGroupsTableAdapter();
      targetNameLabel = new System.Windows.Forms.Label();
      targetIPLabel = new System.Windows.Forms.Label();
      deviceVendorLabel = new System.Windows.Forms.Label();
      jumpServerIPLabel = new System.Windows.Forms.Label();
      protocolLabel = new System.Windows.Forms.Label();
      portLabel = new System.Windows.Forms.Label();
      noteLabel = new System.Windows.Forms.Label();
      label1 = new System.Windows.Forms.Label();
      ((System.ComponentModel.ISupportInitialize)(this.configDS)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.configTargetsBS)).BeginInit();
      this.groupBox1.SuspendLayout();
      this.SuspendLayout();
      // 
      // targetNameLabel
      // 
      targetNameLabel.AutoSize = true;
      targetNameLabel.Location = new System.Drawing.Point(251, 34);
      targetNameLabel.Name = "targetNameLabel";
      targetNameLabel.Size = new System.Drawing.Size(72, 13);
      targetNameLabel.TabIndex = 1;
      targetNameLabel.Text = "Target Name:";
      // 
      // targetIPLabel
      // 
      targetIPLabel.AutoSize = true;
      targetIPLabel.Location = new System.Drawing.Point(17, 59);
      targetIPLabel.Name = "targetIPLabel";
      targetIPLabel.Size = new System.Drawing.Size(54, 13);
      targetIPLabel.TabIndex = 2;
      targetIPLabel.Text = "Target IP:";
      // 
      // deviceVendorLabel
      // 
      deviceVendorLabel.AutoSize = true;
      deviceVendorLabel.Location = new System.Drawing.Point(17, 85);
      deviceVendorLabel.Name = "deviceVendorLabel";
      deviceVendorLabel.Size = new System.Drawing.Size(81, 13);
      deviceVendorLabel.TabIndex = 4;
      deviceVendorLabel.Text = "Device Vendor:";
      // 
      // jumpServerIPLabel
      // 
      jumpServerIPLabel.AutoSize = true;
      jumpServerIPLabel.Location = new System.Drawing.Point(251, 60);
      jumpServerIPLabel.Name = "jumpServerIPLabel";
      jumpServerIPLabel.Size = new System.Drawing.Size(82, 13);
      jumpServerIPLabel.TabIndex = 6;
      jumpServerIPLabel.Text = "Jump Server IP:";
      // 
      // protocolLabel
      // 
      protocolLabel.AutoSize = true;
      protocolLabel.Location = new System.Drawing.Point(17, 112);
      protocolLabel.Name = "protocolLabel";
      protocolLabel.Size = new System.Drawing.Size(49, 13);
      protocolLabel.TabIndex = 8;
      protocolLabel.Text = "Protocol:";
      // 
      // portLabel
      // 
      portLabel.AutoSize = true;
      portLabel.Location = new System.Drawing.Point(251, 113);
      portLabel.Name = "portLabel";
      portLabel.Size = new System.Drawing.Size(29, 13);
      portLabel.TabIndex = 10;
      portLabel.Text = "Port:";
      // 
      // noteLabel
      // 
      noteLabel.AutoSize = true;
      noteLabel.Location = new System.Drawing.Point(17, 138);
      noteLabel.Name = "noteLabel";
      noteLabel.Size = new System.Drawing.Size(33, 13);
      noteLabel.TabIndex = 12;
      noteLabel.Text = "Note:";
      // 
      // label1
      // 
      label1.AutoSize = true;
      label1.Location = new System.Drawing.Point(17, 33);
      label1.Name = "label1";
      label1.Size = new System.Drawing.Size(73, 13);
      label1.TabIndex = 19;
      label1.Text = "Target Group:";
      // 
      // configDS
      // 
      this.configDS.DataSetName = "ConfigDS";
      this.configDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
      // 
      // configTargetsBS
      // 
      this.configTargetsBS.DataMember = "ConfigTargets";
      this.configTargetsBS.DataSource = this.configDS;
      // 
      // configTargetsTableAdapter
      // 
      this.configTargetsTableAdapter.ClearBeforeFill = true;
      // 
      // tableAdapterManager
      // 
      this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
      this.tableAdapterManager.ConfigLinesTableAdapter = null;
      this.tableAdapterManager.ConfigSetsTableAdapter = null;
      this.tableAdapterManager.ConfigSetTargetsTableAdapter = null;
      this.tableAdapterManager.ConfigTargetsTableAdapter = null;
      this.tableAdapterManager.Connection = null;
      this.tableAdapterManager.UpdateOrder = Scriptngo.ConfigurationManager.ConfigDSTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
      // 
      // targetNameTextBox
      // 
      this.targetNameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.configTargetsBS, "TargetName", true));
      this.targetNameTextBox.Location = new System.Drawing.Point(355, 30);
      this.targetNameTextBox.MaxLength = 100;
      this.targetNameTextBox.Name = "targetNameTextBox";
      this.targetNameTextBox.Size = new System.Drawing.Size(121, 20);
      this.targetNameTextBox.TabIndex = 2;
      // 
      // targetIPTextBox
      // 
      this.targetIPTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.configTargetsBS, "TargetIP", true));
      this.targetIPTextBox.Location = new System.Drawing.Point(121, 55);
      this.targetIPTextBox.MaxLength = 15;
      this.targetIPTextBox.Name = "targetIPTextBox";
      this.targetIPTextBox.Size = new System.Drawing.Size(121, 20);
      this.targetIPTextBox.TabIndex = 3;
      // 
      // portTextBox
      // 
      this.portTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.configTargetsBS, "Port", true));
      this.portTextBox.Location = new System.Drawing.Point(355, 109);
      this.portTextBox.MaxLength = 5;
      this.portTextBox.Name = "portTextBox";
      this.portTextBox.Size = new System.Drawing.Size(121, 20);
      this.portTextBox.TabIndex = 11;
      // 
      // noteTextBox
      // 
      this.noteTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.configTargetsBS, "Note", true));
      this.noteTextBox.Location = new System.Drawing.Point(121, 135);
      this.noteTextBox.MaxLength = 500;
      this.noteTextBox.Multiline = true;
      this.noteTextBox.Name = "noteTextBox";
      this.noteTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
      this.noteTextBox.Size = new System.Drawing.Size(355, 64);
      this.noteTextBox.TabIndex = 13;
      // 
      // cbxVendors
      // 
      this.cbxVendors.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.configTargetsBS, "DeviceVendor", true));
      this.cbxVendors.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbxVendors.FormattingEnabled = true;
      this.cbxVendors.Location = new System.Drawing.Point(121, 81);
      this.cbxVendors.Name = "cbxVendors";
      this.cbxVendors.Size = new System.Drawing.Size(121, 21);
      this.cbxVendors.TabIndex = 14;
      // 
      // cbxJumpServers
      // 
      this.cbxJumpServers.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.configTargetsBS, "JumpServerIP", true));
      this.cbxJumpServers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbxJumpServers.FormattingEnabled = true;
      this.cbxJumpServers.Location = new System.Drawing.Point(355, 56);
      this.cbxJumpServers.Name = "cbxJumpServers";
      this.cbxJumpServers.Size = new System.Drawing.Size(121, 21);
      this.cbxJumpServers.TabIndex = 15;
      this.cbxJumpServers.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.cbxJumpServers_Format);
      // 
      // cbxProtocols
      // 
      this.cbxProtocols.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.configTargetsBS, "Protocol", true));
      this.cbxProtocols.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbxProtocols.FormattingEnabled = true;
      this.cbxProtocols.Items.AddRange(new object[] {
            "Telnet",
            "SSH2",
            "SSH1"});
      this.cbxProtocols.Location = new System.Drawing.Point(121, 108);
      this.cbxProtocols.Name = "cbxProtocols";
      this.cbxProtocols.Size = new System.Drawing.Size(121, 21);
      this.cbxProtocols.TabIndex = 16;
      // 
      // cbxTargetGroup
      // 
      this.cbxTargetGroup.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.configTargetsBS, "TargetGroup", true));
      this.cbxTargetGroup.Location = new System.Drawing.Point(121, 29);
      this.cbxTargetGroup.MaxLength = 100;
      this.cbxTargetGroup.Name = "cbxTargetGroup";
      this.cbxTargetGroup.Size = new System.Drawing.Size(121, 21);
      this.cbxTargetGroup.TabIndex = 20;
      // 
      // groupBox1
      // 
      this.groupBox1.BackColor = System.Drawing.Color.Transparent;
      this.groupBox1.Controls.Add(this.cbxTargetGroup);
      this.groupBox1.Controls.Add(label1);
      this.groupBox1.Controls.Add(this.targetNameTextBox);
      this.groupBox1.Controls.Add(targetNameLabel);
      this.groupBox1.Controls.Add(this.targetIPTextBox);
      this.groupBox1.Controls.Add(targetIPLabel);
      this.groupBox1.Controls.Add(this.cbxProtocols);
      this.groupBox1.Controls.Add(deviceVendorLabel);
      this.groupBox1.Controls.Add(this.cbxJumpServers);
      this.groupBox1.Controls.Add(jumpServerIPLabel);
      this.groupBox1.Controls.Add(this.cbxVendors);
      this.groupBox1.Controls.Add(protocolLabel);
      this.groupBox1.Controls.Add(noteLabel);
      this.groupBox1.Controls.Add(this.portTextBox);
      this.groupBox1.Controls.Add(this.noteTextBox);
      this.groupBox1.Controls.Add(portLabel);
      this.groupBox1.Location = new System.Drawing.Point(17, 12);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(498, 209);
      this.groupBox1.TabIndex = 21;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = " Target data ";
      // 
      // btnCancel
      // 
      this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.btnCancel.BackColor = System.Drawing.Color.MintCream;
      this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.btnCancel.Location = new System.Drawing.Point(18, 227);
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.Size = new System.Drawing.Size(97, 30);
      this.btnCancel.TabIndex = 49;
      this.btnCancel.Text = "Cancel";
      this.btnCancel.UseVisualStyleBackColor = false;
      // 
      // btnSave
      // 
      this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.btnSave.BackColor = System.Drawing.Color.SandyBrown;
      this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.btnSave.Location = new System.Drawing.Point(418, 227);
      this.btnSave.Name = "btnSave";
      this.btnSave.Size = new System.Drawing.Size(97, 30);
      this.btnSave.TabIndex = 48;
      this.btnSave.Text = "Save";
      this.btnSave.UseVisualStyleBackColor = false;
      this.btnSave.Click += new System.EventHandler(this.btnOK_Click);
      // 
      // distinctTargetGroupsTableAdapter
      // 
      this.distinctTargetGroupsTableAdapter.ClearBeforeFill = true;
      // 
      // ConfigTarget
      // 
      this.AcceptButton = this.btnSave;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.ForestGreen;
      this.CancelButton = this.btnCancel;
      this.ClientSize = new System.Drawing.Size(535, 264);
      this.Controls.Add(this.btnCancel);
      this.Controls.Add(this.btnSave);
      this.Controls.Add(this.groupBox1);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "ConfigTarget";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "Edit Configuration Target";
      this.Load += new System.EventHandler(this.ConfigTarget_Load);
      this.Paint += new System.Windows.Forms.PaintEventHandler(this.DrawGradientBackground);
      ((System.ComponentModel.ISupportInitialize)(this.configDS)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.configTargetsBS)).EndInit();
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private ConfigDS configDS;
    private System.Windows.Forms.BindingSource configTargetsBS;
    private ConfigDSTableAdapters.ConfigTargetsTableAdapter configTargetsTableAdapter;
    private ConfigDSTableAdapters.TableAdapterManager tableAdapterManager;
    private System.Windows.Forms.TextBox targetNameTextBox;
    private System.Windows.Forms.TextBox targetIPTextBox;
    private System.Windows.Forms.TextBox portTextBox;
    private System.Windows.Forms.TextBox noteTextBox;
    private System.Windows.Forms.ComboBox cbxVendors;
    private System.Windows.Forms.ComboBox cbxJumpServers;
    private System.Windows.Forms.ComboBox cbxProtocols;
    private ConfigDSTableAdapters.QueriesTableAdapter qTA;
    private System.Windows.Forms.ComboBox cbxTargetGroup;
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.Button btnCancel;
    private System.Windows.Forms.Button btnSave;
    private ConfigDSTableAdapters.DistinctTargetGroupsTableAdapter distinctTargetGroupsTableAdapter;
  }
}