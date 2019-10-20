namespace FAQ_Net
{
  partial class UpdateUserControl
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
      this.lblHeader = new System.Windows.Forms.Label();
      this.btnGoToUpdateUrl = new System.Windows.Forms.Button();
      this.btnCancel = new System.Windows.Forms.Button();
      this.txbUpdateInfo = new System.Windows.Forms.TextBox();
      this.SuspendLayout();
      // 
      // lblHeader
      // 
      this.lblHeader.BackColor = System.Drawing.Color.GreenYellow;
      this.lblHeader.Dock = System.Windows.Forms.DockStyle.Top;
      this.lblHeader.Font = new System.Drawing.Font("Georgia", 14F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.lblHeader.Location = new System.Drawing.Point(0, 0);
      this.lblHeader.Name = "lblHeader";
      this.lblHeader.Size = new System.Drawing.Size(334, 28);
      this.lblHeader.TabIndex = 57;
      this.lblHeader.Text = "Новая версия FAQ.Net";
      this.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      this.lblHeader.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Control_MouseDown);
      this.lblHeader.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Control_MouseMove);
      // 
      // btnGoToUpdateUrl
      // 
      this.btnGoToUpdateUrl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
      this.btnGoToUpdateUrl.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
      this.btnGoToUpdateUrl.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnGoToUpdateUrl.Font = new System.Drawing.Font("Georgia", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.btnGoToUpdateUrl.Location = new System.Drawing.Point(63, 192);
      this.btnGoToUpdateUrl.Name = "btnGoToUpdateUrl";
      this.btnGoToUpdateUrl.Size = new System.Drawing.Size(162, 23);
      this.btnGoToUpdateUrl.TabIndex = 59;
      this.btnGoToUpdateUrl.Text = "Скачать обновление";
      this.btnGoToUpdateUrl.UseVisualStyleBackColor = false;
      this.btnGoToUpdateUrl.Click += new System.EventHandler(this.btnGoToUpdateUrl_Click);
      // 
      // btnCancel
      // 
      this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
      this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
      this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnCancel.Font = new System.Drawing.Font("Georgia", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.btnCancel.Location = new System.Drawing.Point(231, 192);
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.Size = new System.Drawing.Size(100, 23);
      this.btnCancel.TabIndex = 61;
      this.btnCancel.Text = "Отмена";
      this.btnCancel.UseVisualStyleBackColor = false;
      this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
      // 
      // txbUpdateInfo
      // 
      this.txbUpdateInfo.BackColor = System.Drawing.Color.Khaki;
      this.txbUpdateInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.txbUpdateInfo.Location = new System.Drawing.Point(4, 31);
      this.txbUpdateInfo.Multiline = true;
      this.txbUpdateInfo.Name = "txbUpdateInfo";
      this.txbUpdateInfo.Size = new System.Drawing.Size(327, 155);
      this.txbUpdateInfo.TabIndex = 62;
      // 
      // UpdateUserControl
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.Gold;
      this.Controls.Add(this.txbUpdateInfo);
      this.Controls.Add(this.btnCancel);
      this.Controls.Add(this.btnGoToUpdateUrl);
      this.Controls.Add(this.lblHeader);
      this.Name = "UpdateUserControl";
      this.Size = new System.Drawing.Size(334, 218);
      this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Control_MouseDown);
      this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Control_MouseMove);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion
    private System.Windows.Forms.Label lblHeader;
    private System.Windows.Forms.Button btnGoToUpdateUrl;
    private System.Windows.Forms.Button btnCancel;
    private System.Windows.Forms.TextBox txbUpdateInfo;
  }
}
