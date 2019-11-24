namespace FAQ_Net
{
  partial class IntellisenseUserControl
  {
    /// <summary> 
    /// Обязательная переменная конструктора.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary> 
    /// Освободить все используемые ресурсы.
    /// </summary>
    /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Код, автоматически созданный конструктором компонентов

    /// <summary> 
    /// Требуемый метод для поддержки конструктора — не изменяйте 
    /// содержимое этого метода с помощью редактора кода.
    /// </summary>
    private void InitializeComponent()
    {
      this.dgvHelp = new System.Windows.Forms.DataGridView();
      ((System.ComponentModel.ISupportInitialize)(this.dgvHelp)).BeginInit();
      this.SuspendLayout();
      // 
      // dgvHelp
      // 
      this.dgvHelp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dgvHelp.Dock = System.Windows.Forms.DockStyle.Fill;
      this.dgvHelp.Location = new System.Drawing.Point(0, 0);
      this.dgvHelp.Name = "dgvHelp";
      this.dgvHelp.Size = new System.Drawing.Size(285, 150);
      this.dgvHelp.TabIndex = 0;
      this.dgvHelp.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgvHelp_MouseDoubleClick);
      // 
      // IntellisenseUserControl
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.dgvHelp);
      this.Name = "IntellisenseUserControl";
      this.Size = new System.Drawing.Size(285, 150);
      ((System.ComponentModel.ISupportInitialize)(this.dgvHelp)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.DataGridView dgvHelp;
  }
}
