namespace FAQ_Net
{
  partial class DictionaryEditor
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
      this.splitContainer1 = new System.Windows.Forms.SplitContainer();
      this.tsSearch = new System.Windows.Forms.ToolStrip();
      this.tstbSearch = new System.Windows.Forms.ToolStripTextBox();
      this.tsbSearch = new System.Windows.Forms.ToolStripButton();
      this.tsHeader = new System.Windows.Forms.ToolStrip();
      this.tsbAdd = new System.Windows.Forms.ToolStripButton();
      this.tsbEdit = new System.Windows.Forms.ToolStripButton();
      this.tsbCopy = new System.Windows.Forms.ToolStripButton();
      this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
      this.tsbDelete = new System.Windows.Forms.ToolStripButton();
      this.cmbGroup = new System.Windows.Forms.ComboBox();
      this.lblGroup = new System.Windows.Forms.Label();
      this.cmbForeColor = new System.Windows.Forms.ComboBox();
      this.lblForeColor = new System.Windows.Forms.Label();
      this.txbUrl = new System.Windows.Forms.TextBox();
      this.lblUrl = new System.Windows.Forms.Label();
      this.btnSelectQuestion = new System.Windows.Forms.Button();
      this.txbQuestion = new System.Windows.Forms.TextBox();
      this.lblQuestion = new System.Windows.Forms.Label();
      this.txbComment = new System.Windows.Forms.TextBox();
      this.lblComment = new System.Windows.Forms.Label();
      this.cmbToolTipType = new System.Windows.Forms.ComboBox();
      this.label3 = new System.Windows.Forms.Label();
      this.txbWord = new System.Windows.Forms.TextBox();
      this.lblWord = new System.Windows.Forms.Label();
      this.cmbCategoryWord = new System.Windows.Forms.ComboBox();
      this.label2 = new System.Windows.Forms.Label();
      this.tsEditor = new System.Windows.Forms.ToolStrip();
      this.tsbSave = new System.Windows.Forms.ToolStripButton();
      this.tsbCancel = new System.Windows.Forms.ToolStripButton();
      this.lblHeader = new System.Windows.Forms.Label();
      this.splitContainer1.Panel1.SuspendLayout();
      this.splitContainer1.Panel2.SuspendLayout();
      this.splitContainer1.SuspendLayout();
      this.tsSearch.SuspendLayout();
      this.tsHeader.SuspendLayout();
      this.tsEditor.SuspendLayout();
      this.SuspendLayout();
      // 
      // splitContainer1
      // 
      this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.splitContainer1.Location = new System.Drawing.Point(0, 21);
      this.splitContainer1.Name = "splitContainer1";
      this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
      // 
      // splitContainer1.Panel1
      // 
      this.splitContainer1.Panel1.Controls.Add(this.tsSearch);
      this.splitContainer1.Panel1.Controls.Add(this.tsHeader);
      // 
      // splitContainer1.Panel2
      // 
      this.splitContainer1.Panel2.Controls.Add(this.cmbGroup);
      this.splitContainer1.Panel2.Controls.Add(this.lblGroup);
      this.splitContainer1.Panel2.Controls.Add(this.cmbForeColor);
      this.splitContainer1.Panel2.Controls.Add(this.lblForeColor);
      this.splitContainer1.Panel2.Controls.Add(this.txbUrl);
      this.splitContainer1.Panel2.Controls.Add(this.lblUrl);
      this.splitContainer1.Panel2.Controls.Add(this.btnSelectQuestion);
      this.splitContainer1.Panel2.Controls.Add(this.txbQuestion);
      this.splitContainer1.Panel2.Controls.Add(this.lblQuestion);
      this.splitContainer1.Panel2.Controls.Add(this.txbComment);
      this.splitContainer1.Panel2.Controls.Add(this.lblComment);
      this.splitContainer1.Panel2.Controls.Add(this.cmbToolTipType);
      this.splitContainer1.Panel2.Controls.Add(this.label3);
      this.splitContainer1.Panel2.Controls.Add(this.txbWord);
      this.splitContainer1.Panel2.Controls.Add(this.lblWord);
      this.splitContainer1.Panel2.Controls.Add(this.cmbCategoryWord);
      this.splitContainer1.Panel2.Controls.Add(this.label2);
      this.splitContainer1.Panel2.Controls.Add(this.tsEditor);
      this.splitContainer1.Size = new System.Drawing.Size(270, 545);
      this.splitContainer1.SplitterDistance = 159;
      this.splitContainer1.TabIndex = 0;
      // 
      // tsSearch
      // 
      this.tsSearch.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
      this.tsSearch.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tstbSearch,
            this.tsbSearch});
      this.tsSearch.Location = new System.Drawing.Point(0, 25);
      this.tsSearch.Name = "tsSearch";
      this.tsSearch.Size = new System.Drawing.Size(270, 25);
      this.tsSearch.TabIndex = 1;
      this.tsSearch.Text = "toolStrip3";
      // 
      // tstbSearch
      // 
      this.tstbSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.tstbSearch.ForeColor = System.Drawing.Color.Gray;
      this.tstbSearch.Name = "tstbSearch";
      this.tstbSearch.Size = new System.Drawing.Size(200, 25);
      this.tstbSearch.Text = "Поиск слова...";
      this.tstbSearch.ToolTipText = "Нажмите Enter для начала и продолжения поиска";
      this.tstbSearch.Enter += new System.EventHandler(this.tstbSearch_Enter);
      this.tstbSearch.Leave += new System.EventHandler(this.tstbSearch_Leave);
      this.tstbSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tstbSearch_KeyDown);
      this.tstbSearch.TextChanged += new System.EventHandler(this.tstbSearch_TextChanged);
      // 
      // tsbSearch
      // 
      this.tsbSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.tsbSearch.Image = global::FAQ_Net.Properties.Resources.search;
      this.tsbSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.tsbSearch.Name = "tsbSearch";
      this.tsbSearch.Size = new System.Drawing.Size(23, 22);
      this.tsbSearch.Text = "Поиск";
      this.tsbSearch.Click += new System.EventHandler(this.tsbSearch_Click);
      // 
      // tsHeader
      // 
      this.tsHeader.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
      this.tsHeader.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbAdd,
            this.tsbEdit,
            this.tsbCopy,
            this.toolStripSeparator1,
            this.tsbDelete});
      this.tsHeader.Location = new System.Drawing.Point(0, 0);
      this.tsHeader.Name = "tsHeader";
      this.tsHeader.Size = new System.Drawing.Size(270, 25);
      this.tsHeader.TabIndex = 0;
      this.tsHeader.Text = "toolStrip1";
      // 
      // tsbAdd
      // 
      this.tsbAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.tsbAdd.Image = global::FAQ_Net.Properties.Resources.NewSml;
      this.tsbAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.tsbAdd.Name = "tsbAdd";
      this.tsbAdd.Size = new System.Drawing.Size(23, 22);
      this.tsbAdd.Text = "Создать всплывающую подсказку";
      this.tsbAdd.Click += new System.EventHandler(this.tsbAdd_Click);
      // 
      // tsbEdit
      // 
      this.tsbEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.tsbEdit.Enabled = false;
      this.tsbEdit.Image = global::FAQ_Net.Properties.Resources.Edit;
      this.tsbEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.tsbEdit.Name = "tsbEdit";
      this.tsbEdit.Size = new System.Drawing.Size(23, 22);
      this.tsbEdit.Text = "Изменить";
      this.tsbEdit.Click += new System.EventHandler(this.tsbEdit_Click);
      // 
      // tsbCopy
      // 
      this.tsbCopy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.tsbCopy.Enabled = false;
      this.tsbCopy.Image = global::FAQ_Net.Properties.Resources.copy_16x16;
      this.tsbCopy.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.tsbCopy.Name = "tsbCopy";
      this.tsbCopy.Size = new System.Drawing.Size(23, 22);
      this.tsbCopy.Text = "Копировать";
      this.tsbCopy.Click += new System.EventHandler(this.tsbCopy_Click);
      // 
      // toolStripSeparator1
      // 
      this.toolStripSeparator1.Name = "toolStripSeparator1";
      this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
      // 
      // tsbDelete
      // 
      this.tsbDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.tsbDelete.Enabled = false;
      this.tsbDelete.Image = global::FAQ_Net.Properties.Resources.DelOrClose;
      this.tsbDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.tsbDelete.Name = "tsbDelete";
      this.tsbDelete.Size = new System.Drawing.Size(23, 22);
      this.tsbDelete.Text = "Удалить всплывающую подсказку";
      this.tsbDelete.Click += new System.EventHandler(this.tsbDelete_Click);
      // 
      // cmbGroup
      // 
      this.cmbGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.cmbGroup.FormattingEnabled = true;
      this.cmbGroup.Location = new System.Drawing.Point(11, 349);
      this.cmbGroup.Name = "cmbGroup";
      this.cmbGroup.Size = new System.Drawing.Size(249, 21);
      this.cmbGroup.TabIndex = 36;
      // 
      // lblGroup
      // 
      this.lblGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.lblGroup.AutoSize = true;
      this.lblGroup.Location = new System.Drawing.Point(10, 333);
      this.lblGroup.Name = "lblGroup";
      this.lblGroup.Size = new System.Drawing.Size(42, 13);
      this.lblGroup.TabIndex = 35;
      this.lblGroup.Text = "Группа";
      // 
      // cmbForeColor
      // 
      this.cmbForeColor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.cmbForeColor.FormattingEnabled = true;
      this.cmbForeColor.Location = new System.Drawing.Point(11, 309);
      this.cmbForeColor.Name = "cmbForeColor";
      this.cmbForeColor.Size = new System.Drawing.Size(249, 21);
      this.cmbForeColor.TabIndex = 34;
      this.cmbForeColor.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.cmbForeColor_DrawItem);
      // 
      // lblForeColor
      // 
      this.lblForeColor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.lblForeColor.AutoSize = true;
      this.lblForeColor.Location = new System.Drawing.Point(8, 293);
      this.lblForeColor.Name = "lblForeColor";
      this.lblForeColor.Size = new System.Drawing.Size(74, 13);
      this.lblForeColor.TabIndex = 33;
      this.lblForeColor.Text = "Цвет шрифта";
      // 
      // txbUrl
      // 
      this.txbUrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.txbUrl.Location = new System.Drawing.Point(11, 270);
      this.txbUrl.Name = "txbUrl";
      this.txbUrl.Size = new System.Drawing.Size(249, 20);
      this.txbUrl.TabIndex = 32;
      // 
      // lblUrl
      // 
      this.lblUrl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.lblUrl.AutoSize = true;
      this.lblUrl.Location = new System.Drawing.Point(8, 254);
      this.lblUrl.Name = "lblUrl";
      this.lblUrl.Size = new System.Drawing.Size(62, 13);
      this.lblUrl.TabIndex = 31;
      this.lblUrl.Text = "URL-адрес";
      // 
      // btnSelectQuestion
      // 
      this.btnSelectQuestion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.btnSelectQuestion.Location = new System.Drawing.Point(235, 229);
      this.btnSelectQuestion.Name = "btnSelectQuestion";
      this.btnSelectQuestion.Size = new System.Drawing.Size(25, 24);
      this.btnSelectQuestion.TabIndex = 30;
      this.btnSelectQuestion.Text = "...";
      this.btnSelectQuestion.UseVisualStyleBackColor = true;
      this.btnSelectQuestion.Click += new System.EventHandler(this.btnSelectQuestion_Click);
      // 
      // txbQuestion
      // 
      this.txbQuestion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.txbQuestion.Location = new System.Drawing.Point(11, 231);
      this.txbQuestion.Name = "txbQuestion";
      this.txbQuestion.Size = new System.Drawing.Size(218, 20);
      this.txbQuestion.TabIndex = 29;
      // 
      // lblQuestion
      // 
      this.lblQuestion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.lblQuestion.AutoSize = true;
      this.lblQuestion.Location = new System.Drawing.Point(8, 215);
      this.lblQuestion.Name = "lblQuestion";
      this.lblQuestion.Size = new System.Drawing.Size(63, 13);
      this.lblQuestion.TabIndex = 28;
      this.lblQuestion.Text = "ID вопроса";
      // 
      // txbComment
      // 
      this.txbComment.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.txbComment.Location = new System.Drawing.Point(11, 165);
      this.txbComment.Multiline = true;
      this.txbComment.Name = "txbComment";
      this.txbComment.Size = new System.Drawing.Size(249, 47);
      this.txbComment.TabIndex = 27;
      // 
      // lblComment
      // 
      this.lblComment.AutoSize = true;
      this.lblComment.Location = new System.Drawing.Point(8, 149);
      this.lblComment.Name = "lblComment";
      this.lblComment.Size = new System.Drawing.Size(77, 13);
      this.lblComment.TabIndex = 26;
      this.lblComment.Text = "Комментарий";
      // 
      // cmbToolTipType
      // 
      this.cmbToolTipType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.cmbToolTipType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cmbToolTipType.FormattingEnabled = true;
      this.cmbToolTipType.Location = new System.Drawing.Point(11, 125);
      this.cmbToolTipType.Name = "cmbToolTipType";
      this.cmbToolTipType.Size = new System.Drawing.Size(249, 21);
      this.cmbToolTipType.TabIndex = 25;
      this.cmbToolTipType.SelectedIndexChanged += new System.EventHandler(this.cmbToolTipType_SelectedIndexChanged);
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(8, 109);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(83, 13);
      this.label3.TabIndex = 24;
      this.label3.Text = "Тип подсказки";
      // 
      // txbWord
      // 
      this.txbWord.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.txbWord.Location = new System.Drawing.Point(11, 86);
      this.txbWord.Name = "txbWord";
      this.txbWord.Size = new System.Drawing.Size(249, 20);
      this.txbWord.TabIndex = 23;
      this.txbWord.TextChanged += new System.EventHandler(this.txbWord_TextChanged);
      this.txbWord.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txbWord_KeyPress);
      // 
      // lblWord
      // 
      this.lblWord.AutoSize = true;
      this.lblWord.Location = new System.Drawing.Point(8, 70);
      this.lblWord.Name = "lblWord";
      this.lblWord.Size = new System.Drawing.Size(38, 13);
      this.lblWord.TabIndex = 22;
      this.lblWord.Text = "Слово";
      // 
      // cmbCategoryWord
      // 
      this.cmbCategoryWord.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.cmbCategoryWord.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cmbCategoryWord.FormattingEnabled = true;
      this.cmbCategoryWord.Location = new System.Drawing.Point(11, 46);
      this.cmbCategoryWord.Name = "cmbCategoryWord";
      this.cmbCategoryWord.Size = new System.Drawing.Size(249, 21);
      this.cmbCategoryWord.TabIndex = 21;
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(8, 30);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(60, 13);
      this.label2.TabIndex = 20;
      this.label2.Text = "Категория";
      // 
      // tsEditor
      // 
      this.tsEditor.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbSave,
            this.tsbCancel});
      this.tsEditor.Location = new System.Drawing.Point(0, 0);
      this.tsEditor.Name = "tsEditor";
      this.tsEditor.Size = new System.Drawing.Size(270, 25);
      this.tsEditor.TabIndex = 18;
      this.tsEditor.Text = "toolStrip2";
      // 
      // tsbSave
      // 
      this.tsbSave.Image = global::FAQ_Net.Properties.Resources.SaveSml;
      this.tsbSave.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.tsbSave.Name = "tsbSave";
      this.tsbSave.Size = new System.Drawing.Size(85, 22);
      this.tsbSave.Text = "Сохранить";
      this.tsbSave.Click += new System.EventHandler(this.tsbSave_Click);
      // 
      // tsbCancel
      // 
      this.tsbCancel.Image = global::FAQ_Net.Properties.Resources.No;
      this.tsbCancel.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.tsbCancel.Name = "tsbCancel";
      this.tsbCancel.Size = new System.Drawing.Size(69, 22);
      this.tsbCancel.Text = "Отмена";
      this.tsbCancel.Click += new System.EventHandler(this.tsbCancel_Click);
      // 
      // lblHeader
      // 
      this.lblHeader.BackColor = System.Drawing.Color.SkyBlue;
      this.lblHeader.Dock = System.Windows.Forms.DockStyle.Top;
      this.lblHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.lblHeader.Location = new System.Drawing.Point(0, 0);
      this.lblHeader.Name = "lblHeader";
      this.lblHeader.Size = new System.Drawing.Size(270, 21);
      this.lblHeader.TabIndex = 2;
      this.lblHeader.Text = "Словарь подсказок";
      this.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // DictionaryEditor
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.splitContainer1);
      this.Controls.Add(this.lblHeader);
      this.Name = "DictionaryEditor";
      this.Size = new System.Drawing.Size(270, 566);
      this.splitContainer1.Panel1.ResumeLayout(false);
      this.splitContainer1.Panel1.PerformLayout();
      this.splitContainer1.Panel2.ResumeLayout(false);
      this.splitContainer1.Panel2.PerformLayout();
      this.splitContainer1.ResumeLayout(false);
      this.tsSearch.ResumeLayout(false);
      this.tsSearch.PerformLayout();
      this.tsHeader.ResumeLayout(false);
      this.tsHeader.PerformLayout();
      this.tsEditor.ResumeLayout(false);
      this.tsEditor.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.SplitContainer splitContainer1;
    private System.Windows.Forms.ToolStripButton tsbAdd;
    private System.Windows.Forms.ToolStripButton tsbEdit;
    private System.Windows.Forms.ToolStripButton tsbDelete;
    private System.Windows.Forms.ToolStripButton tsbCopy;
    private System.Windows.Forms.ToolStripButton tsbSave;
    private System.Windows.Forms.ToolStripButton tsbCancel;
    private System.Windows.Forms.ComboBox cmbCategoryWord;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.TextBox txbWord;
    private System.Windows.Forms.Label lblWord;
    private System.Windows.Forms.ComboBox cmbToolTipType;
    private System.Windows.Forms.Label lblQuestion;
    private System.Windows.Forms.TextBox txbComment;
    private System.Windows.Forms.Label lblComment;
    private System.Windows.Forms.TextBox txbUrl;
    private System.Windows.Forms.Label lblUrl;
    private System.Windows.Forms.TextBox txbQuestion;
    private System.Windows.Forms.ComboBox cmbGroup;
    private System.Windows.Forms.Label lblGroup;
    private System.Windows.Forms.ComboBox cmbForeColor;
    private System.Windows.Forms.Label lblForeColor;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    private System.Windows.Forms.Button btnSelectQuestion;
    private System.Windows.Forms.ToolStripButton tsbSearch;
    public System.Windows.Forms.ToolStrip tsHeader;
    public System.Windows.Forms.ToolStrip tsEditor;
    public System.Windows.Forms.Label lblHeader;
    public System.Windows.Forms.ToolStrip tsSearch;
    private System.Windows.Forms.ToolStripTextBox tstbSearch;
  }
}
