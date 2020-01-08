namespace FAQ_Net
{
  partial class EditImageForm
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditImageForm));
      this.toolStrip1 = new System.Windows.Forms.ToolStrip();
      this.tsbSave = new System.Windows.Forms.ToolStripButton();
      this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
      this.tscmbScaleImagePersent = new System.Windows.Forms.ToolStripComboBox();
      this.tsbMaxWidthFormatA4 = new System.Windows.Forms.ToolStripButton();
      this.pictureBoxImage = new System.Windows.Forms.PictureBox();
      this.toolStrip1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImage)).BeginInit();
      this.SuspendLayout();
      // 
      // toolStrip1
      // 
      this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbSave,
            this.toolStripLabel1,
            this.tscmbScaleImagePersent,
            this.tsbMaxWidthFormatA4});
      this.toolStrip1.Location = new System.Drawing.Point(0, 0);
      this.toolStrip1.Name = "toolStrip1";
      this.toolStrip1.Size = new System.Drawing.Size(668, 25);
      this.toolStrip1.TabIndex = 3;
      this.toolStrip1.Text = "toolStrip1";
      // 
      // tsbSave
      // 
      this.tsbSave.Image = global::FAQ_Net.Properties.Resources.OK;
      this.tsbSave.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.tsbSave.Name = "tsbSave";
      this.tsbSave.Size = new System.Drawing.Size(85, 22);
      this.tsbSave.Text = "Сохранить";
      this.tsbSave.Click += new System.EventHandler(this.tsbSave_Click);
      // 
      // toolStripLabel1
      // 
      this.toolStripLabel1.Name = "toolStripLabel1";
      this.toolStripLabel1.Size = new System.Drawing.Size(59, 22);
      this.toolStripLabel1.Text = "Масштаб";
      // 
      // tscmbScaleImagePersent
      // 
      this.tscmbScaleImagePersent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.tscmbScaleImagePersent.Items.AddRange(new object[] {
            "10%",
            "20%",
            "50%",
            "80%",
            "100%"});
      this.tscmbScaleImagePersent.Name = "tscmbScaleImagePersent";
      this.tscmbScaleImagePersent.Size = new System.Drawing.Size(75, 25);
      this.tscmbScaleImagePersent.SelectedIndexChanged += new System.EventHandler(this.tscmbScaleImagePersent_SelectedIndexChanged);
      // 
      // tsbMaxWidthFormatA4
      // 
      this.tsbMaxWidthFormatA4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
      this.tsbMaxWidthFormatA4.Image = ((System.Drawing.Image)(resources.GetObject("tsbMaxWidthFormatA4.Image")));
      this.tsbMaxWidthFormatA4.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.tsbMaxWidthFormatA4.Name = "tsbMaxWidthFormatA4";
      this.tsbMaxWidthFormatA4.Size = new System.Drawing.Size(289, 22);
      this.tsbMaxWidthFormatA4.Text = "Ограничить ширину рисунка по ширине листа A4";
      this.tsbMaxWidthFormatA4.Click += new System.EventHandler(this.tsbMaxWidthFormatA4_Click);
      // 
      // pictureBoxImage
      // 
      this.pictureBoxImage.BackColor = System.Drawing.SystemColors.ButtonHighlight;
      this.pictureBoxImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
      this.pictureBoxImage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
      this.pictureBoxImage.Dock = System.Windows.Forms.DockStyle.Fill;
      this.pictureBoxImage.Location = new System.Drawing.Point(0, 25);
      this.pictureBoxImage.Margin = new System.Windows.Forms.Padding(0);
      this.pictureBoxImage.Name = "pictureBoxImage";
      this.pictureBoxImage.Size = new System.Drawing.Size(668, 381);
      this.pictureBoxImage.TabIndex = 8;
      this.pictureBoxImage.TabStop = false;
      // 
      // EditImageForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(668, 406);
      this.Controls.Add(this.pictureBoxImage);
      this.Controls.Add(this.toolStrip1);
      this.MinimumSize = new System.Drawing.Size(16, 100);
      this.Name = "EditImageForm";
      this.ShowIcon = false;
      this.Text = "Настройка размера изображения";
      this.Resize += new System.EventHandler(this.EditImageForm_Resize);
      this.toolStrip1.ResumeLayout(false);
      this.toolStrip1.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImage)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion
    private System.Windows.Forms.ToolStrip toolStrip1;
    private System.Windows.Forms.ToolStripButton tsbSave;
    public System.Windows.Forms.PictureBox pictureBoxImage;
    private System.Windows.Forms.ToolStripComboBox tscmbScaleImagePersent;
    private System.Windows.Forms.ToolStripLabel toolStripLabel1;
    private System.Windows.Forms.ToolStripButton tsbMaxWidthFormatA4;
  }
}