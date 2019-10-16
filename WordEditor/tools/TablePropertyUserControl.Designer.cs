namespace FAQ_Net.tools
{
  partial class TablePropertyUserControl
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
      this.btnCreateTable = new System.Windows.Forms.Button();
      this.label1 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.numCountRows = new System.Windows.Forms.NumericUpDown();
      this.numCountColumns = new System.Windows.Forms.NumericUpDown();
      this._btnClose = new System.Windows.Forms.Button();
      this._lblHeader = new System.Windows.Forms.Label();
      ((System.ComponentModel.ISupportInitialize)(this.numCountRows)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.numCountColumns)).BeginInit();
      this.SuspendLayout();
      // 
      // btnCreateTable
      // 
      this.btnCreateTable.BackColor = System.Drawing.SystemColors.Control;
      this.btnCreateTable.Location = new System.Drawing.Point(174, 32);
      this.btnCreateTable.Name = "btnCreateTable";
      this.btnCreateTable.Size = new System.Drawing.Size(60, 46);
      this.btnCreateTable.TabIndex = 0;
      this.btnCreateTable.Text = "Создать таблицу";
      this.btnCreateTable.UseVisualStyleBackColor = false;
      this.btnCreateTable.Click += new System.EventHandler(this.btnCreateTable_Click);
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(7, 60);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(73, 13);
      this.label1.TabIndex = 1;
      this.label1.Text = "Кол-во строк";
      this.label1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Control_MouseDown);
      this.label1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Control_MouseMove);
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(7, 34);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(91, 13);
      this.label2.TabIndex = 2;
      this.label2.Text = "Кол-во столбцов";
      // 
      // numCountRows
      // 
      this.numCountRows.Location = new System.Drawing.Point(104, 56);
      this.numCountRows.Name = "numCountRows";
      this.numCountRows.Size = new System.Drawing.Size(64, 20);
      this.numCountRows.TabIndex = 3;
      // 
      // numCountColumns
      // 
      this.numCountColumns.Location = new System.Drawing.Point(104, 32);
      this.numCountColumns.Name = "numCountColumns";
      this.numCountColumns.Size = new System.Drawing.Size(64, 20);
      this.numCountColumns.TabIndex = 4;
      // 
      // _btnClose
      // 
      this._btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this._btnClose.FlatStyle = System.Windows.Forms.FlatStyle.System;
      this._btnClose.Location = new System.Drawing.Point(214, 4);
      this._btnClose.Name = "_btnClose";
      this._btnClose.Size = new System.Drawing.Size(20, 20);
      this._btnClose.TabIndex = 56;
      this._btnClose.Text = "X";
      this._btnClose.UseVisualStyleBackColor = true;
      this._btnClose.Click += new System.EventHandler(this._btnClose_Click);
      // 
      // _lblHeader
      // 
      this._lblHeader.BackColor = System.Drawing.Color.SkyBlue;
      this._lblHeader.Dock = System.Windows.Forms.DockStyle.Top;
      this._lblHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this._lblHeader.Location = new System.Drawing.Point(0, 0);
      this._lblHeader.Name = "_lblHeader";
      this._lblHeader.Size = new System.Drawing.Size(237, 28);
      this._lblHeader.TabIndex = 55;
      this._lblHeader.Text = "Создание таблицы";
      this._lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      this._lblHeader.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Control_MouseDown);
      this._lblHeader.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Control_MouseMove);
      // 
      // TablePropertyUserControl
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
      this.Controls.Add(this._btnClose);
      this.Controls.Add(this._lblHeader);
      this.Controls.Add(this.numCountColumns);
      this.Controls.Add(this.numCountRows);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.btnCreateTable);
      this.Name = "TablePropertyUserControl";
      this.Size = new System.Drawing.Size(237, 82);
      this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Control_MouseDown);
      this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Control_MouseMove);
      ((System.ComponentModel.ISupportInitialize)(this.numCountRows)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.numCountColumns)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button btnCreateTable;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.NumericUpDown numCountRows;
    private System.Windows.Forms.NumericUpDown numCountColumns;
    private System.Windows.Forms.Button _btnClose;
    private System.Windows.Forms.Label _lblHeader;
  }
}
