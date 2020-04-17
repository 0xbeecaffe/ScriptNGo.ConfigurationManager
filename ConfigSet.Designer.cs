namespace Scriptngo.ConfigurationManager
{
  partial class ConfigSet
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
      System.Windows.Forms.Label configSetNameLabel;
      System.Windows.Forms.Label noteLabel;
      this.configDS = new Scriptngo.ConfigurationManager.ConfigDS();
      this.configSetsTableAdapter = new Scriptngo.ConfigurationManager.ConfigDSTableAdapters.ConfigSetsTableAdapter();
      this.tbConfigSetName = new System.Windows.Forms.TextBox();
      this.configSetsBindingSource = new System.Windows.Forms.BindingSource(this.components);
      this.tbNote = new System.Windows.Forms.TextBox();
      this.btnCancel = new System.Windows.Forms.Button();
      this.btnOK = new System.Windows.Forms.Button();
      this.tableAdapterManager = new Scriptngo.ConfigurationManager.ConfigDSTableAdapters.TableAdapterManager();
      this.textBox1 = new System.Windows.Forms.TextBox();
      this.cbxCreateSetFrom = new System.Windows.Forms.ComboBox();
      this.qTA = new Scriptngo.ConfigurationManager.ConfigDSTableAdapters.QueriesTableAdapter();
      this.label1 = new System.Windows.Forms.Label();
      configSetNameLabel = new System.Windows.Forms.Label();
      noteLabel = new System.Windows.Forms.Label();
      ((System.ComponentModel.ISupportInitialize)(this.configDS)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.configSetsBindingSource)).BeginInit();
      this.SuspendLayout();
      // 
      // configSetNameLabel
      // 
      configSetNameLabel.AutoSize = true;
      configSetNameLabel.Location = new System.Drawing.Point(25, 94);
      configSetNameLabel.Name = "configSetNameLabel";
      configSetNameLabel.Size = new System.Drawing.Size(90, 13);
      configSetNameLabel.TabIndex = 1;
      configSetNameLabel.Text = "Config Set Name:";
      // 
      // noteLabel
      // 
      noteLabel.AutoSize = true;
      noteLabel.Location = new System.Drawing.Point(24, 120);
      noteLabel.Name = "noteLabel";
      noteLabel.Size = new System.Drawing.Size(33, 13);
      noteLabel.TabIndex = 2;
      noteLabel.Text = "Note:";
      // 
      // configDS
      // 
      this.configDS.DataSetName = "ConfigDS";
      this.configDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
      // 
      // configSetsTableAdapter
      // 
      this.configSetsTableAdapter.ClearBeforeFill = true;
      // 
      // tbConfigSetName
      // 
      this.tbConfigSetName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.configSetsBindingSource, "ConfigSetName", true));
      this.tbConfigSetName.Location = new System.Drawing.Point(121, 91);
      this.tbConfigSetName.Name = "tbConfigSetName";
      this.tbConfigSetName.Size = new System.Drawing.Size(287, 20);
      this.tbConfigSetName.TabIndex = 2;
      // 
      // configSetsBindingSource
      // 
      this.configSetsBindingSource.DataMember = "ConfigSets";
      this.configSetsBindingSource.DataSource = this.configDS;
      // 
      // tbNote
      // 
      this.tbNote.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.configSetsBindingSource, "Note", true));
      this.tbNote.Location = new System.Drawing.Point(121, 121);
      this.tbNote.Multiline = true;
      this.tbNote.Name = "tbNote";
      this.tbNote.Size = new System.Drawing.Size(287, 81);
      this.tbNote.TabIndex = 3;
      // 
      // btnCancel
      // 
      this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.btnCancel.Location = new System.Drawing.Point(27, 212);
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.Size = new System.Drawing.Size(75, 23);
      this.btnCancel.TabIndex = 20;
      this.btnCancel.Text = "Cancel";
      this.btnCancel.UseVisualStyleBackColor = true;
      // 
      // btnOK
      // 
      this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.btnOK.Location = new System.Drawing.Point(333, 212);
      this.btnOK.Name = "btnOK";
      this.btnOK.Size = new System.Drawing.Size(75, 23);
      this.btnOK.TabIndex = 19;
      this.btnOK.Text = "OK";
      this.btnOK.UseVisualStyleBackColor = true;
      this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
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
      // textBox1
      // 
      this.textBox1.Location = new System.Drawing.Point(121, 13);
      this.textBox1.Multiline = true;
      this.textBox1.Name = "textBox1";
      this.textBox1.ReadOnly = true;
      this.textBox1.Size = new System.Drawing.Size(287, 34);
      this.textBox1.TabIndex = 21;
      this.textBox1.Text = "A Configuration Set is  a collection  of Configuration Targets\r\nfor  which a disc" +
    "rete device configuration can be specified.";
      // 
      // cbxCreateSetFrom
      // 
      this.cbxCreateSetFrom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbxCreateSetFrom.FormattingEnabled = true;
      this.cbxCreateSetFrom.Location = new System.Drawing.Point(121, 62);
      this.cbxCreateSetFrom.Name = "cbxCreateSetFrom";
      this.cbxCreateSetFrom.Size = new System.Drawing.Size(287, 21);
      this.cbxCreateSetFrom.TabIndex = 23;
      this.cbxCreateSetFrom.DropDownClosed += new System.EventHandler(this.cbxCreateSetFrom_DropDownClosed);
      this.cbxCreateSetFrom.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.cbxCreateSetFrom_Format);
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(24, 65);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(89, 13);
      this.label1.TabIndex = 24;
      this.label1.Text = "Create Set From :";
      // 
      // ConfigSet
      // 
      this.AcceptButton = this.btnOK;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.btnCancel;
      this.ClientSize = new System.Drawing.Size(443, 251);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.cbxCreateSetFrom);
      this.Controls.Add(this.textBox1);
      this.Controls.Add(this.btnCancel);
      this.Controls.Add(this.btnOK);
      this.Controls.Add(noteLabel);
      this.Controls.Add(this.tbNote);
      this.Controls.Add(configSetNameLabel);
      this.Controls.Add(this.tbConfigSetName);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.Name = "ConfigSet";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "Configuration Set";
      ((System.ComponentModel.ISupportInitialize)(this.configDS)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.configSetsBindingSource)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private ConfigDS configDS;
    private System.Windows.Forms.BindingSource configSetsBindingSource;
    private ConfigDSTableAdapters.ConfigSetsTableAdapter configSetsTableAdapter;
    private ConfigDSTableAdapters.TableAdapterManager tableAdapterManager;
    private System.Windows.Forms.TextBox tbConfigSetName;
    private System.Windows.Forms.TextBox tbNote;
    private System.Windows.Forms.Button btnCancel;
    private System.Windows.Forms.Button btnOK;
    private System.Windows.Forms.TextBox textBox1;
    private System.Windows.Forms.ComboBox cbxCreateSetFrom;
    private ConfigDSTableAdapters.QueriesTableAdapter qTA;
    private System.Windows.Forms.Label label1;
  }
}