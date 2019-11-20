namespace FAQ_Net
{
  partial class TooltipUserControl
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
      this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
      this.lblHeader = new System.Windows.Forms.Label();
      this.lblDescription = new System.Windows.Forms.Label();
      this.lblFooter = new System.Windows.Forms.Label();
      this.tableLayoutPanel1.SuspendLayout();
      this.SuspendLayout();
      // 
      // tableLayoutPanel1
      // 
      this.tableLayoutPanel1.AutoSize = true;
      this.tableLayoutPanel1.BackgroundImage = global::FAQ_Net.Properties.Resources.Bg;
      this.tableLayoutPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
      this.tableLayoutPanel1.ColumnCount = 1;
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.tableLayoutPanel1.Controls.Add(this.lblHeader, 0, 0);
      this.tableLayoutPanel1.Controls.Add(this.lblDescription, 0, 1);
      this.tableLayoutPanel1.Controls.Add(this.lblFooter, 0, 2);
      this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
      this.tableLayoutPanel1.Name = "tableLayoutPanel1";
      this.tableLayoutPanel1.RowCount = 3;
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
      this.tableLayoutPanel1.Size = new System.Drawing.Size(64, 63);
      this.tableLayoutPanel1.TabIndex = 0;
      // 
      // lblHeader
      // 
      this.lblHeader.AutoSize = true;
      this.lblHeader.BackColor = System.Drawing.Color.Transparent;
      this.lblHeader.Dock = System.Windows.Forms.DockStyle.Fill;
      this.lblHeader.ForeColor = System.Drawing.Color.Blue;
      this.lblHeader.Location = new System.Drawing.Point(3, 0);
      this.lblHeader.Name = "lblHeader";
      this.lblHeader.Size = new System.Drawing.Size(58, 25);
      this.lblHeader.TabIndex = 0;
      this.lblHeader.Text = "header";
      this.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // lblDescription
      // 
      this.lblDescription.AutoSize = true;
      this.lblDescription.BackColor = System.Drawing.Color.Transparent;
      this.lblDescription.Location = new System.Drawing.Point(3, 25);
      this.lblDescription.Name = "lblDescription";
      this.lblDescription.Size = new System.Drawing.Size(58, 13);
      this.lblDescription.TabIndex = 1;
      this.lblDescription.Text = "description";
      // 
      // lblFooter
      // 
      this.lblFooter.AutoSize = true;
      this.lblFooter.BackColor = System.Drawing.Color.Transparent;
      this.lblFooter.Dock = System.Windows.Forms.DockStyle.Fill;
      this.lblFooter.ForeColor = System.Drawing.Color.DimGray;
      this.lblFooter.Location = new System.Drawing.Point(3, 38);
      this.lblFooter.Name = "lblFooter";
      this.lblFooter.Size = new System.Drawing.Size(58, 25);
      this.lblFooter.TabIndex = 2;
      this.lblFooter.Text = "footer";
      this.lblFooter.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // TooltipUserControl
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.AutoSize = true;
      this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.Controls.Add(this.tableLayoutPanel1);
      this.Name = "TooltipUserControl";
      this.Size = new System.Drawing.Size(64, 63);
      this.tableLayoutPanel1.ResumeLayout(false);
      this.tableLayoutPanel1.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    private System.Windows.Forms.Label lblHeader;
    private System.Windows.Forms.Label lblDescription;
    private System.Windows.Forms.Label lblFooter;
  }
}
