namespace FAQ_Net
{
  partial class AppSettingsForm
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
      this.tvSettings = new System.Windows.Forms.TreeView();
      this.toolStrip1 = new System.Windows.Forms.ToolStrip();
      this.tsbSave = new System.Windows.Forms.ToolStripButton();
      this.tsbCancel = new System.Windows.Forms.ToolStripButton();
      this.toolStrip1.SuspendLayout();
      this.SuspendLayout();
      // 
      // tvSettings
      // 
      this.tvSettings.Dock = System.Windows.Forms.DockStyle.Left;
      this.tvSettings.FullRowSelect = true;
      this.tvSettings.HideSelection = false;
      this.tvSettings.Location = new System.Drawing.Point(0, 25);
      this.tvSettings.Name = "tvSettings";
      this.tvSettings.ShowLines = false;
      this.tvSettings.ShowRootLines = false;
      this.tvSettings.Size = new System.Drawing.Size(184, 286);
      this.tvSettings.TabIndex = 0;
      this.tvSettings.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvSettings_AfterSelect);
      // 
      // toolStrip1
      // 
      this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbSave,
            this.tsbCancel});
      this.toolStrip1.Location = new System.Drawing.Point(0, 0);
      this.toolStrip1.Name = "toolStrip1";
      this.toolStrip1.Size = new System.Drawing.Size(404, 25);
      this.toolStrip1.TabIndex = 2;
      this.toolStrip1.Text = "toolStrip1";
      // 
      // tsbSave
      // 
      this.tsbSave.Enabled = false;
      this.tsbSave.Image = global::FAQ_Net.Properties.Resources.SaveSml;
      this.tsbSave.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.tsbSave.Name = "tsbSave";
      this.tsbSave.Size = new System.Drawing.Size(85, 22);
      this.tsbSave.Text = "Сохранить";
      this.tsbSave.Click += new System.EventHandler(this.tsbSave_Click);
      // 
      // tsbCancel
      // 
      this.tsbCancel.Enabled = false;
      this.tsbCancel.Image = global::FAQ_Net.Properties.Resources.No;
      this.tsbCancel.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.tsbCancel.Name = "tsbCancel";
      this.tsbCancel.Size = new System.Drawing.Size(69, 22);
      this.tsbCancel.Text = "Отмена";
      this.tsbCancel.Click += new System.EventHandler(this.tsbCancel_Click);
      // 
      // AppSettingsForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(404, 311);
      this.Controls.Add(this.tvSettings);
      this.Controls.Add(this.toolStrip1);
      this.MinimumSize = new System.Drawing.Size(420, 350);
      this.Name = "AppSettingsForm";
      this.ShowIcon = false;
      this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
      this.Text = "Настройки внешнего вида";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AppSettingsForm_FormClosing);
      this.Shown += new System.EventHandler(this.AppSettingsForm_Shown);
      this.toolStrip1.ResumeLayout(false);
      this.toolStrip1.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.TreeView tvSettings;
    private System.Windows.Forms.ToolStrip toolStrip1;
    private System.Windows.Forms.ToolStripButton tsbSave;
    private System.Windows.Forms.ToolStripButton tsbCancel;
  }
}