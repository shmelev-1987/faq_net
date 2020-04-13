using System;
using System.Windows.Forms;

namespace FAQ_Net
{
    partial class MainForm
    {
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
      this.CategoriesContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.CreateQuestionTSMI = new System.Windows.Forms.ToolStripMenuItem();
      this.CreateCategoryTSMI = new System.Windows.Forms.ToolStripMenuItem();
      this.CreateSubcategoryTSMI = new System.Windows.Forms.ToolStripMenuItem();
      this.DelRazdelMainTSMI = new System.Windows.Forms.ToolStripMenuItem();
      this.DelRazdelTSMI = new System.Windows.Forms.ToolStripMenuItem();
      this.DelRazdelWithReplaceTSMI = new System.Windows.Forms.ToolStripMenuItem();
      this.фToolStripMenuItem = new System.Windows.Forms.ToolStripSeparator();
      this.LastQuestionsTSMI = new System.Windows.Forms.ToolStripMenuItem();
      this.RefreshTSMI = new System.Windows.Forms.ToolStripMenuItem();
      this.SearchTSMI = new System.Windows.Forms.ToolStripMenuItem();
      this.ChangeNameCategoryTSMI = new System.Windows.Forms.ToolStripMenuItem();
      this.CreateBackupTSMI = new System.Windows.Forms.ToolStripMenuItem();
      this.splitContainer1 = new System.Windows.Forms.SplitContainer();
      this.statusStrip3 = new GradientControls.StatusStripGradient();
      this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
      this.CountQuestionsVal = new System.Windows.Forms.ToolStripStatusLabel();
      this.statusStrip1 = new GradientControls.StatusStripGradient();
      this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
      this.ID_ContentTSSL = new System.Windows.Forms.ToolStripStatusLabel();
      this.tsslCountCharsHeader = new System.Windows.Forms.ToolStripStatusLabel();
      this.tsslCountCharsValue = new System.Windows.Forms.ToolStripStatusLabel();
      this.toolsTop = new GradientControls.ToolStripGradient();
      this.saveFile = new System.Windows.Forms.ToolStripButton();
      this.sep0 = new System.Windows.Forms.ToolStripSeparator();
      this.printText = new System.Windows.Forms.ToolStripButton();
      this.printPrevText = new System.Windows.Forms.ToolStripButton();
      this.sep1 = new System.Windows.Forms.ToolStripSeparator();
      this.findText = new System.Windows.Forms.ToolStripButton();
      this.sep2 = new System.Windows.Forms.ToolStripSeparator();
      this.cutText = new System.Windows.Forms.ToolStripButton();
      this.copyText = new System.Windows.Forms.ToolStripButton();
      this.pasteText = new System.Windows.Forms.ToolStripButton();
      this.sep3 = new System.Windows.Forms.ToolStripSeparator();
      this.undoText = new System.Windows.Forms.ToolStripButton();
      this.redoText = new System.Windows.Forms.ToolStripButton();
      this.sep4 = new System.Windows.Forms.ToolStripSeparator();
      this.selFont = new System.Windows.Forms.ToolStripComboBox();
      this.size = new System.Windows.Forms.ToolStripComboBox();
      this.sep5 = new System.Windows.Forms.ToolStripSeparator();
      this.bold = new System.Windows.Forms.ToolStripButton();
      this.italic = new System.Windows.Forms.ToolStripButton();
      this.under = new System.Windows.Forms.ToolStripButton();
      this.strikeout = new System.Windows.Forms.ToolStripButton();
      this.sep6 = new System.Windows.Forms.ToolStripSeparator();
      this.zoom = new System.Windows.Forms.ToolStripComboBox();
      this.alignLeft = new System.Windows.Forms.ToolStripButton();
      this.alignCenter = new System.Windows.Forms.ToolStripButton();
      this.alignRight = new System.Windows.Forms.ToolStripButton();
      this.alignJustify = new System.Windows.Forms.ToolStripButton();
      this.lineSpacing = new System.Windows.Forms.ToolStripSplitButton();
      this.lineSpace1 = new System.Windows.Forms.ToolStripMenuItem();
      this.lineSpace1pt5 = new System.Windows.Forms.ToolStripMenuItem();
      this.lineSpace2 = new System.Windows.Forms.ToolStripMenuItem();
      this.sep7 = new System.Windows.Forms.ToolStripSeparator();
      this.bullet = new GradientControls.ToolStripSplitCheckButton();
      this.tsmiNormalBullet = new System.Windows.Forms.ToolStripMenuItem();
      this.tsmiNumberBullet = new System.Windows.Forms.ToolStripMenuItem();
      this.selectColor = new System.Windows.Forms.ToolStripSplitButton();
      this.colors = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.black = new System.Windows.Forms.ToolStripMenuItem();
      this.maroon = new System.Windows.Forms.ToolStripMenuItem();
      this.orange = new System.Windows.Forms.ToolStripMenuItem();
      this.green = new System.Windows.Forms.ToolStripMenuItem();
      this.olive = new System.Windows.Forms.ToolStripMenuItem();
      this.navy = new System.Windows.Forms.ToolStripMenuItem();
      this.magenta = new System.Windows.Forms.ToolStripMenuItem();
      this.purple = new System.Windows.Forms.ToolStripMenuItem();
      this.teal = new System.Windows.Forms.ToolStripMenuItem();
      this.gray = new System.Windows.Forms.ToolStripMenuItem();
      this.silver = new System.Windows.Forms.ToolStripMenuItem();
      this.red = new System.Windows.Forms.ToolStripMenuItem();
      this.lime = new System.Windows.Forms.ToolStripMenuItem();
      this.yellow = new System.Windows.Forms.ToolStripMenuItem();
      this.blue = new System.Windows.Forms.ToolStripMenuItem();
      this.white = new System.Windows.Forms.ToolStripMenuItem();
      this.highLight = new System.Windows.Forms.ToolStripSplitButton();
      this.sep8 = new System.Windows.Forms.ToolStripSeparator();
      this.tsddbInsertTable = new System.Windows.Forms.ToolStripDropDownButton();
      this.tsbAddImage = new System.Windows.Forms.ToolStripButton();
      this.AddInFavoritesTSB = new System.Windows.Forms.ToolStripButton();
      this.menuTop = new GradientControls.MenuStripZ();
      this.file = new System.Windows.Forms.ToolStripMenuItem();
      this.open = new System.Windows.Forms.ToolStripMenuItem();
      this.s0 = new System.Windows.Forms.ToolStripSeparator();
      this.save = new System.Windows.Forms.ToolStripMenuItem();
      this.saveAs = new System.Windows.Forms.ToolStripMenuItem();
      this.s1 = new System.Windows.Forms.ToolStripSeparator();
      this.pageSet = new System.Windows.Forms.ToolStripMenuItem();
      this.printPrev = new System.Windows.Forms.ToolStripMenuItem();
      this.print = new System.Windows.Forms.ToolStripMenuItem();
      this.edit = new System.Windows.Forms.ToolStripMenuItem();
      this.undo = new System.Windows.Forms.ToolStripMenuItem();
      this.redo = new System.Windows.Forms.ToolStripMenuItem();
      this.s4 = new System.Windows.Forms.ToolStripSeparator();
      this.cut = new System.Windows.Forms.ToolStripMenuItem();
      this.copy = new System.Windows.Forms.ToolStripMenuItem();
      this.paste = new System.Windows.Forms.ToolStripMenuItem();
      this.s5 = new System.Windows.Forms.ToolStripSeparator();
      this.selectAll = new System.Windows.Forms.ToolStripMenuItem();
      this.s6 = new System.Windows.Forms.ToolStripSeparator();
      this.find = new System.Windows.Forms.ToolStripMenuItem();
      this.replace = new System.Windows.Forms.ToolStripMenuItem();
      this.view = new System.Windows.Forms.ToolStripMenuItem();
      this.tsmiDictionary = new System.Windows.Forms.ToolStripMenuItem();
      this.formatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.font = new System.Windows.Forms.ToolStripMenuItem();
      this.superscript = new System.Windows.Forms.ToolStripMenuItem();
      this.noSuperscript = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
      this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripMenuItem11 = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripMenuItem12 = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripMenuItem13 = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripMenuItem14 = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripMenuItem15 = new System.Windows.Forms.ToolStripMenuItem();
      this.subscript = new System.Windows.Forms.ToolStripMenuItem();
      this.noSubscript = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
      this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripMenuItem8 = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripMenuItem9 = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripMenuItem10 = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripMenuItem16 = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripMenuItem17 = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripMenuItem19 = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripMenuItem18 = new System.Windows.Forms.ToolStripMenuItem();
      this.кодировкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.ASCII_TSMI = new System.Windows.Forms.ToolStripMenuItem();
      this.тестToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.tsmiTable = new System.Windows.Forms.ToolStripMenuItem();
      this.tsmiAddTable = new System.Windows.Forms.ToolStripMenuItem();
      this.справкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.tsmiAboutProgram = new System.Windows.Forms.ToolStripMenuItem();
      this.QuestionsCMS = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.AddQuestionTSMI = new System.Windows.Forms.ToolStripMenuItem();
      this.ShowAnswerTSMI = new System.Windows.Forms.ToolStripMenuItem();
      this.EditQuestionTSMI = new System.Windows.Forms.ToolStripMenuItem();
      this.DeleteQuestionTSMI = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
      this.SortAscTSMI = new System.Windows.Forms.ToolStripMenuItem();
      this.SortDescTSMI = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
      this.tsmiGridView = new System.Windows.Forms.ToolStripMenuItem();
      this.tsmiListView = new System.Windows.Forms.ToolStripMenuItem();
      this.richMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.cutRichText = new System.Windows.Forms.ToolStripMenuItem();
      this.copyRichText = new System.Windows.Forms.ToolStripMenuItem();
      this.pasteRichText = new System.Windows.Forms.ToolStripMenuItem();
      this.sep_0 = new System.Windows.Forms.ToolStripSeparator();
      this.fontRichText = new System.Windows.Forms.ToolStripMenuItem();
      this.sep_1 = new System.Windows.Forms.ToolStripSeparator();
      this.superscriptRichText = new System.Windows.Forms.ToolStripMenuItem();
      this.normalOffset = new System.Windows.Forms.ToolStripMenuItem();
      this.subscriptRichText = new System.Windows.Forms.ToolStripMenuItem();
      this.sep_2 = new System.Windows.Forms.ToolStripSeparator();
      this.printRichText = new System.Windows.Forms.ToolStripMenuItem();
      this.toolTip = new System.Windows.Forms.ToolTip(this.components);
      this.BackBtn = new PulseButton.PulseButton();
      this.btnNextQuestion = new PulseButton.PulseButton();
      this.splitContainer2 = new System.Windows.Forms.SplitContainer();
      this.splitter1 = new System.Windows.Forms.Splitter();
      this.panel3 = new GradientControls.PanelGradient();
      this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
      this.btnSelectQuestion = new PulseButton.PulseButton();
      this.SelectedPathLbl = new System.Windows.Forms.Label();
      this.splitter2 = new System.Windows.Forms.Splitter();
      this.TabControl = new GradientControls.TabControlGradient();
      this.CategoriesTP = new GradientControls.TabPageGradient();
      this.TV1 = new System.Windows.Forms.TreeView();
      this.statusStrip2 = new GradientControls.StatusStripGradient();
      this.CountSubcategoryLbl = new System.Windows.Forms.ToolStripStatusLabel();
      this.CountSubcategoryVal = new System.Windows.Forms.ToolStripStatusLabel();
      this.SearchPanel = new System.Windows.Forms.Panel();
      this.SearchCategoryBtn = new PulseButton.PulseButton();
      this.SearchCategoryCmbBox = new System.Windows.Forms.ComboBox();
      this.toolStrip1 = new GradientControls.ToolStripGradient();
      this.CreateQuestionTSB = new System.Windows.Forms.ToolStripButton();
      this.CreateCategoryTSB = new System.Windows.Forms.ToolStripButton();
      this.CreateSubcategoryTSB = new System.Windows.Forms.ToolStripButton();
      this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
      this.RefreshTSB = new System.Windows.Forms.ToolStripButton();
      this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
      this.CollapseAllTSB = new System.Windows.Forms.ToolStripButton();
      this.ExpandAllNodesTSB = new System.Windows.Forms.ToolStripButton();
      this.SearchTP = new GradientControls.TabPageGradient();
      this.DGVResultSearch = new System.Windows.Forms.DataGridView();
      this.id_content_search = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.QuestionSearchColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.SearchFavoriteDateColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.panel1 = new System.Windows.Forms.Panel();
      this.searchUp = new PulseButton.PulseButton();
      this.searchDown = new PulseButton.PulseButton();
      this.SearchTxtBox = new System.Windows.Forms.TextBox();
      this.lblSearchDescription = new System.Windows.Forms.Label();
      this.SearchAnswRB = new System.Windows.Forms.RadioButton();
      this.SearchQuestRB = new System.Windows.Forms.RadioButton();
      this.SearchAllRB = new System.Windows.Forms.RadioButton();
      this.SearchBtn = new PulseButton.PulseButton();
      this.label1 = new System.Windows.Forms.Label();
      this.FavoritesTP = new GradientControls.TabPageGradient();
      this.FavoriteDGV = new System.Windows.Forms.DataGridView();
      this.Favorites_id_content = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Favorites_question = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.FavoritesFavoriteDateColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.JournalTP = new GradientControls.TabPageGradient();
      this.JournalDGV = new System.Windows.Forms.DataGridView();
      this.panel4 = new System.Windows.Forms.Panel();
      this.status = new GradientControls.StatusStripGradient();
      this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
      this.tsmiSaveNodeSelect = new System.Windows.Forms.ToolStripMenuItem();
      this.tsmiReplaceFontControlToMenu = new System.Windows.Forms.ToolStripMenuItem();
      this.tsmiSmoothScrollingDocument = new System.Windows.Forms.ToolStripMenuItem();
      this.tsmiDesignSettings = new System.Windows.Forms.ToolStripMenuItem();
      this.CountQuestTitLbl = new System.Windows.Forms.ToolStripStatusLabel();
      this.CountQuestLbl = new System.Windows.Forms.ToolStripStatusLabel();
      this.CountAnswTitLbl = new System.Windows.Forms.ToolStripStatusLabel();
      this.CountAnswLbl = new System.Windows.Forms.ToolStripStatusLabel();
      this.CountCategoriesLbl = new System.Windows.Forms.ToolStripStatusLabel();
      this.CountCategoriesVal = new System.Windows.Forms.ToolStripStatusLabel();
      this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
      this.tsslStatus = new System.Windows.Forms.ToolStripStatusLabel();
      this.openFile = new System.Windows.Forms.ToolStripButton();
      this.JournalIdColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.JournalQuestionColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.JournalFavoriteDateColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.CategoriesContextMenu.SuspendLayout();
      this.splitContainer1.Panel1.SuspendLayout();
      this.splitContainer1.Panel2.SuspendLayout();
      this.splitContainer1.SuspendLayout();
      this.statusStrip3.SuspendLayout();
      this.statusStrip1.SuspendLayout();
      this.toolsTop.SuspendLayout();
      this.colors.SuspendLayout();
      this.menuTop.SuspendLayout();
      this.QuestionsCMS.SuspendLayout();
      this.richMenu.SuspendLayout();
      this.splitContainer2.Panel1.SuspendLayout();
      this.splitContainer2.SuspendLayout();
      this.panel3.SuspendLayout();
      this.tableLayoutPanel1.SuspendLayout();
      this.TabControl.SuspendLayout();
      this.CategoriesTP.SuspendLayout();
      this.statusStrip2.SuspendLayout();
      this.SearchPanel.SuspendLayout();
      this.toolStrip1.SuspendLayout();
      this.SearchTP.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.DGVResultSearch)).BeginInit();
      this.panel1.SuspendLayout();
      this.FavoritesTP.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.FavoriteDGV)).BeginInit();
      this.JournalTP.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.JournalDGV)).BeginInit();
      this.panel4.SuspendLayout();
      this.status.SuspendLayout();
      this.SuspendLayout();
      // 
      // CategoriesContextMenu
      // 
      this.CategoriesContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CreateQuestionTSMI,
            this.CreateCategoryTSMI,
            this.CreateSubcategoryTSMI,
            this.DelRazdelMainTSMI,
            this.фToolStripMenuItem,
            this.LastQuestionsTSMI,
            this.RefreshTSMI,
            this.SearchTSMI,
            this.ChangeNameCategoryTSMI,
            this.CreateBackupTSMI});
      this.CategoriesContextMenu.Name = "CategoriesContextMenu";
      this.CategoriesContextMenu.Size = new System.Drawing.Size(259, 208);
      this.CategoriesContextMenu.Opening += new System.ComponentModel.CancelEventHandler(this.CategoriesContextMenu_Opening);
      // 
      // CreateQuestionTSMI
      // 
      this.CreateQuestionTSMI.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
      this.CreateQuestionTSMI.Name = "CreateQuestionTSMI";
      this.CreateQuestionTSMI.Size = new System.Drawing.Size(258, 22);
      this.CreateQuestionTSMI.Text = "Добавить вопрос";
      this.CreateQuestionTSMI.Click += new System.EventHandler(this.CreateQuestionTSB_Click);
      // 
      // CreateCategoryTSMI
      // 
      this.CreateCategoryTSMI.Name = "CreateCategoryTSMI";
      this.CreateCategoryTSMI.Size = new System.Drawing.Size(258, 22);
      this.CreateCategoryTSMI.Text = "Добавить раздел";
      this.CreateCategoryTSMI.Click += new System.EventHandler(this.CreateCategory_Click);
      // 
      // CreateSubcategoryTSMI
      // 
      this.CreateSubcategoryTSMI.Name = "CreateSubcategoryTSMI";
      this.CreateSubcategoryTSMI.Size = new System.Drawing.Size(258, 22);
      this.CreateSubcategoryTSMI.Text = "Добавить подраздел";
      this.CreateSubcategoryTSMI.Click += new System.EventHandler(this.CreateSubcategoryTSB_Click);
      // 
      // DelRazdelMainTSMI
      // 
      this.DelRazdelMainTSMI.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DelRazdelTSMI,
            this.DelRazdelWithReplaceTSMI});
      this.DelRazdelMainTSMI.Name = "DelRazdelMainTSMI";
      this.DelRazdelMainTSMI.Size = new System.Drawing.Size(258, 22);
      this.DelRazdelMainTSMI.Text = "Удалить раздел";
      // 
      // DelRazdelTSMI
      // 
      this.DelRazdelTSMI.Name = "DelRazdelTSMI";
      this.DelRazdelTSMI.Size = new System.Drawing.Size(314, 22);
      this.DelRazdelTSMI.Text = "вместе с содержимым";
      this.DelRazdelTSMI.Click += new System.EventHandler(this.DelRazdelTSMI_Click);
      // 
      // DelRazdelWithReplaceTSMI
      // 
      this.DelRazdelWithReplaceTSMI.Name = "DelRazdelWithReplaceTSMI";
      this.DelRazdelWithReplaceTSMI.Size = new System.Drawing.Size(314, 22);
      this.DelRazdelWithReplaceTSMI.Text = "с переносом содержимого в другой раздел";
      this.DelRazdelWithReplaceTSMI.Click += new System.EventHandler(this.DelRazdelWithReplaceTSMI_Click);
      // 
      // фToolStripMenuItem
      // 
      this.фToolStripMenuItem.Name = "фToolStripMenuItem";
      this.фToolStripMenuItem.Size = new System.Drawing.Size(255, 6);
      // 
      // LastQuestionsTSMI
      // 
      this.LastQuestionsTSMI.Name = "LastQuestionsTSMI";
      this.LastQuestionsTSMI.Size = new System.Drawing.Size(258, 22);
      this.LastQuestionsTSMI.Text = "Последние добавления";
      this.LastQuestionsTSMI.Click += new System.EventHandler(this.LastQuestionsTSMI_Click);
      // 
      // RefreshTSMI
      // 
      this.RefreshTSMI.Image = global::FAQ_Net.Properties.Resources.Refresh;
      this.RefreshTSMI.Name = "RefreshTSMI";
      this.RefreshTSMI.Size = new System.Drawing.Size(258, 22);
      this.RefreshTSMI.Text = "Обновить список";
      this.RefreshTSMI.Click += new System.EventHandler(this.RefreshTSB_Click);
      // 
      // SearchTSMI
      // 
      this.SearchTSMI.Name = "SearchTSMI";
      this.SearchTSMI.Size = new System.Drawing.Size(258, 22);
      this.SearchTSMI.Text = "Поиск";
      this.SearchTSMI.Click += new System.EventHandler(this.SearchTSMI_Click);
      // 
      // ChangeNameCategoryTSMI
      // 
      this.ChangeNameCategoryTSMI.Name = "ChangeNameCategoryTSMI";
      this.ChangeNameCategoryTSMI.Size = new System.Drawing.Size(258, 22);
      this.ChangeNameCategoryTSMI.Text = "Изменить наименование раздела";
      this.ChangeNameCategoryTSMI.Click += new System.EventHandler(this.ChangeNameCategoryTSMI_Click);
      // 
      // CreateBackupTSMI
      // 
      this.CreateBackupTSMI.Image = global::FAQ_Net.Properties.Resources.SaveSml;
      this.CreateBackupTSMI.Name = "CreateBackupTSMI";
      this.CreateBackupTSMI.Size = new System.Drawing.Size(258, 22);
      this.CreateBackupTSMI.Text = "Создать резервную копию БД";
      this.CreateBackupTSMI.Click += new System.EventHandler(this.CreateBackupTSMI_Click);
      // 
      // splitContainer1
      // 
      this.splitContainer1.BackColor = System.Drawing.Color.Transparent;
      this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
      this.splitContainer1.Location = new System.Drawing.Point(242, 34);
      this.splitContainer1.Name = "splitContainer1";
      this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
      // 
      // splitContainer1.Panel1
      // 
      this.splitContainer1.Panel1.Controls.Add(this.statusStrip3);
      // 
      // splitContainer1.Panel2
      // 
      this.splitContainer1.Panel2.Controls.Add(this.statusStrip1);
      this.splitContainer1.Panel2.Controls.Add(this.toolsTop);
      this.splitContainer1.Panel2.Controls.Add(this.menuTop);
      this.splitContainer1.Panel2.Leave += new System.EventHandler(this.splitContainer1_Panel2_Leave);
      this.splitContainer1.Size = new System.Drawing.Size(749, 368);
      this.splitContainer1.SplitterDistance = 93;
      this.splitContainer1.TabIndex = 29;
      // 
      // statusStrip3
      // 
      this.statusStrip3.BackColor = System.Drawing.SystemColors.Control;
      this.statusStrip3.BackColorBottom = System.Drawing.Color.Empty;
      this.statusStrip3.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
      this.statusStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel2,
            this.CountQuestionsVal});
      this.statusStrip3.Location = new System.Drawing.Point(0, 69);
      this.statusStrip3.Name = "statusStrip3";
      this.statusStrip3.Size = new System.Drawing.Size(747, 22);
      this.statusStrip3.TabIndex = 2;
      this.statusStrip3.Text = "statusStrip3";
      // 
      // toolStripStatusLabel2
      // 
      this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
      this.toolStripStatusLabel2.Size = new System.Drawing.Size(105, 17);
      this.toolStripStatusLabel2.Text = "Кол-во вопросов:";
      // 
      // CountQuestionsVal
      // 
      this.CountQuestionsVal.Name = "CountQuestionsVal";
      this.CountQuestionsVal.Size = new System.Drawing.Size(37, 17);
      this.CountQuestionsVal.Text = "0 из 0";
      // 
      // statusStrip1
      // 
      this.statusStrip1.BackColor = System.Drawing.SystemColors.Control;
      this.statusStrip1.BackColorBottom = System.Drawing.Color.Empty;
      this.statusStrip1.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
      this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.ID_ContentTSSL,
            this.tsslCountCharsHeader,
            this.tsslCountCharsValue});
      this.statusStrip1.Location = new System.Drawing.Point(0, 247);
      this.statusStrip1.Name = "statusStrip1";
      this.statusStrip1.Size = new System.Drawing.Size(747, 22);
      this.statusStrip1.TabIndex = 13;
      this.statusStrip1.Text = "statusStrip1";
      // 
      // toolStripStatusLabel1
      // 
      this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
      this.toolStripStatusLabel1.Size = new System.Drawing.Size(70, 17);
      this.toolStripStatusLabel1.Text = "ID вопроса:";
      // 
      // ID_ContentTSSL
      // 
      this.ID_ContentTSSL.Name = "ID_ContentTSSL";
      this.ID_ContentTSSL.Size = new System.Drawing.Size(71, 17);
      this.ID_ContentTSSL.Text = "Неизвестно";
      // 
      // tsslCountCharsHeader
      // 
      this.tsslCountCharsHeader.Name = "tsslCountCharsHeader";
      this.tsslCountCharsHeader.Size = new System.Drawing.Size(139, 17);
      this.tsslCountCharsHeader.Text = "  Количество символов:";
      // 
      // tsslCountCharsValue
      // 
      this.tsslCountCharsValue.Name = "tsslCountCharsValue";
      this.tsslCountCharsValue.Size = new System.Drawing.Size(13, 17);
      this.tsslCountCharsValue.Text = "0";
      // 
      // toolsTop
      // 
      this.toolsTop.BackColor = System.Drawing.Color.Gray;
      this.toolsTop.BackColorBottom = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
      this.toolsTop.FillColorType = GradientControls.GradientEnums.FillColorMode.Gradient;
      this.toolsTop.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
      this.toolsTop.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
      this.toolsTop.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveFile,
            this.sep0,
            this.printText,
            this.printPrevText,
            this.sep1,
            this.findText,
            this.sep2,
            this.cutText,
            this.copyText,
            this.pasteText,
            this.sep3,
            this.undoText,
            this.redoText,
            this.sep4,
            this.selFont,
            this.size,
            this.sep5,
            this.bold,
            this.italic,
            this.under,
            this.strikeout,
            this.sep6,
            this.zoom,
            this.alignLeft,
            this.alignCenter,
            this.alignRight,
            this.alignJustify,
            this.lineSpacing,
            this.sep7,
            this.bullet,
            this.selectColor,
            this.highLight,
            this.sep8,
            this.tsddbInsertTable,
            this.tsbAddImage,
            this.AddInFavoritesTSB});
      this.toolsTop.Location = new System.Drawing.Point(0, 24);
      this.toolsTop.Name = "toolsTop";
      this.toolsTop.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
      this.toolsTop.Size = new System.Drawing.Size(747, 28);
      this.toolsTop.TabIndex = 6;
      // 
      // saveFile
      // 
      this.saveFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.saveFile.Enabled = false;
      this.saveFile.Image = global::FAQ_Net.Properties.Resources.SaveSml;
      this.saveFile.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
      this.saveFile.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.saveFile.Margin = new System.Windows.Forms.Padding(0, 2, 0, 2);
      this.saveFile.Name = "saveFile";
      this.saveFile.Size = new System.Drawing.Size(23, 24);
      this.saveFile.ToolTipText = "Сохранить";
      this.saveFile.Click += new System.EventHandler(this.Tools_Click);
      // 
      // sep0
      // 
      this.sep0.Margin = new System.Windows.Forms.Padding(0, 1, 0, 1);
      this.sep0.Name = "sep0";
      this.sep0.Size = new System.Drawing.Size(6, 26);
      // 
      // printText
      // 
      this.printText.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.printText.Image = global::FAQ_Net.Properties.Resources.PrintSml;
      this.printText.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
      this.printText.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.printText.Margin = new System.Windows.Forms.Padding(0, 2, 0, 2);
      this.printText.Name = "printText";
      this.printText.Size = new System.Drawing.Size(23, 24);
      this.printText.ToolTipText = "Печать...";
      this.printText.Click += new System.EventHandler(this.Tools_Click);
      // 
      // printPrevText
      // 
      this.printPrevText.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.printPrevText.Image = global::FAQ_Net.Properties.Resources.Prev;
      this.printPrevText.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
      this.printPrevText.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.printPrevText.Margin = new System.Windows.Forms.Padding(0, 2, 0, 2);
      this.printPrevText.Name = "printPrevText";
      this.printPrevText.Size = new System.Drawing.Size(23, 24);
      this.printPrevText.ToolTipText = "Предварительный просмотр";
      this.printPrevText.Click += new System.EventHandler(this.Tools_Click);
      // 
      // sep1
      // 
      this.sep1.Margin = new System.Windows.Forms.Padding(0, 1, 0, 1);
      this.sep1.Name = "sep1";
      this.sep1.Size = new System.Drawing.Size(6, 26);
      // 
      // findText
      // 
      this.findText.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.findText.Image = global::FAQ_Net.Properties.Resources.binoculars;
      this.findText.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
      this.findText.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.findText.Margin = new System.Windows.Forms.Padding(0, 2, 0, 2);
      this.findText.Name = "findText";
      this.findText.Size = new System.Drawing.Size(23, 24);
      this.findText.ToolTipText = "Найти";
      this.findText.Click += new System.EventHandler(this.Tools_Click);
      // 
      // sep2
      // 
      this.sep2.Margin = new System.Windows.Forms.Padding(0, 1, 0, 1);
      this.sep2.Name = "sep2";
      this.sep2.Size = new System.Drawing.Size(6, 26);
      // 
      // cutText
      // 
      this.cutText.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.cutText.Image = global::FAQ_Net.Properties.Resources.Cut;
      this.cutText.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
      this.cutText.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.cutText.Name = "cutText";
      this.cutText.Size = new System.Drawing.Size(23, 25);
      this.cutText.Text = "Вы&резать";
      this.cutText.Click += new System.EventHandler(this.Cut_Click);
      // 
      // copyText
      // 
      this.copyText.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.copyText.Image = global::FAQ_Net.Properties.Resources.Copy;
      this.copyText.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
      this.copyText.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.copyText.Name = "copyText";
      this.copyText.Size = new System.Drawing.Size(23, 25);
      this.copyText.Text = "&Копировать";
      this.copyText.Click += new System.EventHandler(this.Copy_Click);
      // 
      // pasteText
      // 
      this.pasteText.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.pasteText.Image = global::FAQ_Net.Properties.Resources.Paste;
      this.pasteText.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
      this.pasteText.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.pasteText.Name = "pasteText";
      this.pasteText.Size = new System.Drawing.Size(23, 25);
      this.pasteText.Text = "&Вставить";
      this.pasteText.Click += new System.EventHandler(this.Paste_Click);
      // 
      // sep3
      // 
      this.sep3.Margin = new System.Windows.Forms.Padding(0, 1, 0, 1);
      this.sep3.Name = "sep3";
      this.sep3.Size = new System.Drawing.Size(6, 26);
      // 
      // undoText
      // 
      this.undoText.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.undoText.Enabled = false;
      this.undoText.Image = global::FAQ_Net.Properties.Resources.UndoSml;
      this.undoText.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
      this.undoText.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.undoText.Margin = new System.Windows.Forms.Padding(0, 2, 0, 2);
      this.undoText.Name = "undoText";
      this.undoText.Size = new System.Drawing.Size(23, 24);
      this.undoText.ToolTipText = "Назад";
      this.undoText.Click += new System.EventHandler(this.Tools_Click);
      // 
      // redoText
      // 
      this.redoText.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.redoText.Enabled = false;
      this.redoText.Image = global::FAQ_Net.Properties.Resources.RedoSml;
      this.redoText.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
      this.redoText.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.redoText.Margin = new System.Windows.Forms.Padding(0, 2, 0, 2);
      this.redoText.Name = "redoText";
      this.redoText.Size = new System.Drawing.Size(23, 24);
      this.redoText.ToolTipText = "Вперед";
      this.redoText.Click += new System.EventHandler(this.Tools_Click);
      // 
      // sep4
      // 
      this.sep4.Margin = new System.Windows.Forms.Padding(0, 1, 0, 1);
      this.sep4.Name = "sep4";
      this.sep4.Size = new System.Drawing.Size(6, 26);
      // 
      // selFont
      // 
      this.selFont.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
      this.selFont.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
      this.selFont.BackColor = System.Drawing.SystemColors.Window;
      this.selFont.DropDownWidth = 230;
      this.selFont.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.selFont.Margin = new System.Windows.Forms.Padding(2, 1, 2, 2);
      this.selFont.MaxDropDownItems = 20;
      this.selFont.Name = "selFont";
      this.selFont.Size = new System.Drawing.Size(120, 25);
      this.selFont.Text = "Times New Roman";
      this.selFont.ToolTipText = "Шрифт";
      this.selFont.DropDownClosed += new System.EventHandler(this.SelFont_DropDownClosed);
      this.selFont.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelFont_KeyDown);
      // 
      // size
      // 
      this.size.AutoSize = false;
      this.size.Items.AddRange(new object[] {
            "8",
            "9",
            "10",
            "11",
            "12",
            "14",
            "16",
            "18",
            "20",
            "22",
            "24",
            "26",
            "28",
            "36",
            "48",
            "72"});
      this.size.Margin = new System.Windows.Forms.Padding(2, 3, 2, 2);
      this.size.MaxDropDownItems = 12;
      this.size.Name = "size";
      this.size.Size = new System.Drawing.Size(52, 23);
      this.size.Text = "12";
      this.size.ToolTipText = "Размер шрифта";
      this.size.DropDownClosed += new System.EventHandler(this.Size_DropDownClosed);
      this.size.SelectedIndexChanged += new System.EventHandler(this.Size_SelectedIndexChanged);
      this.size.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Size_KeyDown);
      // 
      // sep5
      // 
      this.sep5.Margin = new System.Windows.Forms.Padding(0, 1, 0, 1);
      this.sep5.Name = "sep5";
      this.sep5.Size = new System.Drawing.Size(6, 26);
      // 
      // bold
      // 
      this.bold.CheckOnClick = true;
      this.bold.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.bold.Image = global::FAQ_Net.Properties.Resources.BoldSml;
      this.bold.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
      this.bold.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.bold.Margin = new System.Windows.Forms.Padding(0, 2, 0, 2);
      this.bold.Name = "bold";
      this.bold.Size = new System.Drawing.Size(23, 24);
      this.bold.ToolTipText = "Жирный";
      this.bold.Click += new System.EventHandler(this.Tools_Click);
      // 
      // italic
      // 
      this.italic.CheckOnClick = true;
      this.italic.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.italic.Image = global::FAQ_Net.Properties.Resources.ItalSml;
      this.italic.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
      this.italic.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.italic.Margin = new System.Windows.Forms.Padding(0, 2, 0, 2);
      this.italic.Name = "italic";
      this.italic.Size = new System.Drawing.Size(23, 24);
      this.italic.ToolTipText = "Курсив";
      this.italic.Click += new System.EventHandler(this.Tools_Click);
      // 
      // under
      // 
      this.under.CheckOnClick = true;
      this.under.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.under.Image = global::FAQ_Net.Properties.Resources.UnderSml;
      this.under.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
      this.under.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.under.Margin = new System.Windows.Forms.Padding(0, 2, 0, 2);
      this.under.Name = "under";
      this.under.Size = new System.Drawing.Size(23, 24);
      this.under.ToolTipText = "Подчеркнутый";
      this.under.Click += new System.EventHandler(this.Tools_Click);
      // 
      // strikeout
      // 
      this.strikeout.CheckOnClick = true;
      this.strikeout.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.strikeout.Image = global::FAQ_Net.Properties.Resources.strikeout;
      this.strikeout.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.strikeout.Name = "strikeout";
      this.strikeout.Size = new System.Drawing.Size(23, 25);
      this.strikeout.Text = "Зачеркнутый";
      this.strikeout.Click += new System.EventHandler(this.Tools_Click);
      // 
      // sep6
      // 
      this.sep6.BackColor = System.Drawing.Color.Gray;
      this.sep6.Margin = new System.Windows.Forms.Padding(0, 1, 0, 1);
      this.sep6.Name = "sep6";
      this.sep6.Size = new System.Drawing.Size(6, 26);
      // 
      // zoom
      // 
      this.zoom.AutoSize = false;
      this.zoom.Items.AddRange(new object[] {
            "500%",
            "400%",
            "300%",
            "200%",
            "150%",
            "100%",
            "75%",
            "50%",
            "25%",
            "10%"});
      this.zoom.Margin = new System.Windows.Forms.Padding(2, 0, 4, 0);
      this.zoom.MaxDropDownItems = 11;
      this.zoom.Name = "zoom";
      this.zoom.Size = new System.Drawing.Size(65, 23);
      this.zoom.Text = "100%";
      this.zoom.ToolTipText = "Масштаб";
      this.zoom.SelectedIndexChanged += new System.EventHandler(this.zoom_SelectedIndexChanged);
      this.zoom.KeyDown += new System.Windows.Forms.KeyEventHandler(this.zoom_KeyDown);
      // 
      // alignLeft
      // 
      this.alignLeft.Checked = true;
      this.alignLeft.CheckOnClick = true;
      this.alignLeft.CheckState = System.Windows.Forms.CheckState.Checked;
      this.alignLeft.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.alignLeft.Image = global::FAQ_Net.Properties.Resources.LeftSml;
      this.alignLeft.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
      this.alignLeft.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.alignLeft.Margin = new System.Windows.Forms.Padding(2, 2, 0, 2);
      this.alignLeft.Name = "alignLeft";
      this.alignLeft.Size = new System.Drawing.Size(23, 24);
      this.alignLeft.ToolTipText = "Выровнять текст по левому краю";
      this.alignLeft.Click += new System.EventHandler(this.Tools_Click);
      // 
      // alignCenter
      // 
      this.alignCenter.Checked = true;
      this.alignCenter.CheckOnClick = true;
      this.alignCenter.CheckState = System.Windows.Forms.CheckState.Checked;
      this.alignCenter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.alignCenter.Image = global::FAQ_Net.Properties.Resources.CtrSml;
      this.alignCenter.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
      this.alignCenter.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.alignCenter.Margin = new System.Windows.Forms.Padding(0, 2, 0, 2);
      this.alignCenter.Name = "alignCenter";
      this.alignCenter.Size = new System.Drawing.Size(23, 24);
      this.alignCenter.ToolTipText = "Выровнять текст по центру";
      this.alignCenter.Click += new System.EventHandler(this.Tools_Click);
      // 
      // alignRight
      // 
      this.alignRight.Checked = true;
      this.alignRight.CheckOnClick = true;
      this.alignRight.CheckState = System.Windows.Forms.CheckState.Checked;
      this.alignRight.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.alignRight.Image = global::FAQ_Net.Properties.Resources.RightSml;
      this.alignRight.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
      this.alignRight.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.alignRight.Margin = new System.Windows.Forms.Padding(0, 2, 0, 2);
      this.alignRight.Name = "alignRight";
      this.alignRight.Size = new System.Drawing.Size(23, 24);
      this.alignRight.ToolTipText = "Выровнять текст по правому краю";
      this.alignRight.Click += new System.EventHandler(this.Tools_Click);
      // 
      // alignJustify
      // 
      this.alignJustify.Checked = true;
      this.alignJustify.CheckOnClick = true;
      this.alignJustify.CheckState = System.Windows.Forms.CheckState.Checked;
      this.alignJustify.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.alignJustify.Image = global::FAQ_Net.Properties.Resources.JustifySml;
      this.alignJustify.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
      this.alignJustify.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.alignJustify.Margin = new System.Windows.Forms.Padding(0, 2, 0, 2);
      this.alignJustify.Name = "alignJustify";
      this.alignJustify.Size = new System.Drawing.Size(23, 24);
      this.alignJustify.ToolTipText = "Выровнять текст по ширине";
      this.alignJustify.Click += new System.EventHandler(this.Tools_Click);
      // 
      // lineSpacing
      // 
      this.lineSpacing.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.lineSpacing.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lineSpace1,
            this.lineSpace1pt5,
            this.lineSpace2});
      this.lineSpacing.Image = global::FAQ_Net.Properties.Resources.LineSpSml;
      this.lineSpacing.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
      this.lineSpacing.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.lineSpacing.Name = "lineSpacing";
      this.lineSpacing.Size = new System.Drawing.Size(33, 25);
      this.lineSpacing.ToolTipText = "Межстрочный интервал (1)";
      this.lineSpacing.ButtonClick += new System.EventHandler(this.lineSpacing_ButtonClick);
      // 
      // lineSpace1
      // 
      this.lineSpace1.Checked = true;
      this.lineSpace1.CheckState = System.Windows.Forms.CheckState.Checked;
      this.lineSpace1.Name = "lineSpace1";
      this.lineSpace1.Size = new System.Drawing.Size(89, 22);
      this.lineSpace1.Text = "1.0";
      this.lineSpace1.Click += new System.EventHandler(this.lineSpace1_Click);
      // 
      // lineSpace1pt5
      // 
      this.lineSpace1pt5.Name = "lineSpace1pt5";
      this.lineSpace1pt5.Size = new System.Drawing.Size(89, 22);
      this.lineSpace1pt5.Text = "1.5";
      this.lineSpace1pt5.Click += new System.EventHandler(this.lineSpace1pt5_Click);
      // 
      // lineSpace2
      // 
      this.lineSpace2.Name = "lineSpace2";
      this.lineSpace2.Size = new System.Drawing.Size(89, 22);
      this.lineSpace2.Text = "2.0";
      this.lineSpace2.Click += new System.EventHandler(this.lineSpace2_Click);
      // 
      // sep7
      // 
      this.sep7.Margin = new System.Windows.Forms.Padding(0, 1, 0, 1);
      this.sep7.Name = "sep7";
      this.sep7.Size = new System.Drawing.Size(6, 26);
      // 
      // bullet
      // 
      this.bullet.Checked = false;
      this.bullet.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.bullet.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiNormalBullet,
            this.tsmiNumberBullet});
      this.bullet.Image = global::FAQ_Net.Properties.Resources.Bullets;
      this.bullet.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
      this.bullet.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.bullet.Margin = new System.Windows.Forms.Padding(0, 2, 0, 2);
      this.bullet.Name = "bullet";
      this.bullet.Size = new System.Drawing.Size(32, 20);
      this.bullet.ToolTipText = "Маркеры (Ctrl+Shift+L)";
      this.bullet.DropDownOpening += new System.EventHandler(this.bullet_DropDownOpening);
      this.bullet.Click += new System.EventHandler(this.Tools_Click);
      // 
      // tsmiNormalBullet
      // 
      this.tsmiNormalBullet.Name = "tsmiNormalBullet";
      this.tsmiNormalBullet.Size = new System.Drawing.Size(209, 22);
      this.tsmiNormalBullet.Text = "Маркированный список";
      this.tsmiNormalBullet.Click += new System.EventHandler(this.Tools_Click);
      // 
      // tsmiNumberBullet
      // 
      this.tsmiNumberBullet.Name = "tsmiNumberBullet";
      this.tsmiNumberBullet.Size = new System.Drawing.Size(209, 22);
      this.tsmiNumberBullet.Text = "Нумерованный список";
      this.tsmiNumberBullet.Click += new System.EventHandler(this.Tools_Click);
      // 
      // selectColor
      // 
      this.selectColor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.selectColor.DropDown = this.colors;
      this.selectColor.Image = global::FAQ_Net.Properties.Resources.ColorSml;
      this.selectColor.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
      this.selectColor.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.selectColor.Name = "selectColor";
      this.selectColor.Size = new System.Drawing.Size(32, 20);
      this.selectColor.ToolTipText = "Цвет текста (Black)";
      this.selectColor.ButtonClick += new System.EventHandler(this.SelectColor_ButtonClick);
      this.selectColor.Paint += new System.Windows.Forms.PaintEventHandler(this.SelectColor_Paint);
      // 
      // colors
      // 
      this.colors.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.black,
            this.maroon,
            this.orange,
            this.green,
            this.olive,
            this.navy,
            this.magenta,
            this.purple,
            this.teal,
            this.gray,
            this.silver,
            this.red,
            this.lime,
            this.yellow,
            this.blue,
            this.white});
      this.colors.Name = "RichMenu";
      this.colors.OwnerItem = this.selectColor;
      this.colors.Size = new System.Drawing.Size(122, 260);
      // 
      // black
      // 
      this.black.AutoSize = false;
      this.black.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.None;
      this.black.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.black.Name = "black";
      this.black.Size = new System.Drawing.Size(130, 16);
      this.black.Text = "Black";
      this.black.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
      this.black.Click += new System.EventHandler(this.HighLightColors_Click);
      // 
      // maroon
      // 
      this.maroon.AutoSize = false;
      this.maroon.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.None;
      this.maroon.Name = "maroon";
      this.maroon.Size = new System.Drawing.Size(130, 16);
      this.maroon.Text = "Maroon";
      this.maroon.Click += new System.EventHandler(this.HighLightColors_Click);
      // 
      // orange
      // 
      this.orange.AutoSize = false;
      this.orange.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.None;
      this.orange.Name = "orange";
      this.orange.Size = new System.Drawing.Size(130, 16);
      this.orange.Text = "Orange";
      this.orange.Click += new System.EventHandler(this.HighLightColors_Click);
      // 
      // green
      // 
      this.green.AutoSize = false;
      this.green.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.None;
      this.green.Name = "green";
      this.green.Size = new System.Drawing.Size(130, 16);
      this.green.Text = "Green";
      this.green.Click += new System.EventHandler(this.HighLightColors_Click);
      // 
      // olive
      // 
      this.olive.AutoSize = false;
      this.olive.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.None;
      this.olive.Name = "olive";
      this.olive.Size = new System.Drawing.Size(130, 16);
      this.olive.Text = "Olive";
      this.olive.Click += new System.EventHandler(this.HighLightColors_Click);
      // 
      // navy
      // 
      this.navy.AutoSize = false;
      this.navy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.None;
      this.navy.Name = "navy";
      this.navy.Size = new System.Drawing.Size(130, 16);
      this.navy.Text = "Navy";
      this.navy.Click += new System.EventHandler(this.HighLightColors_Click);
      // 
      // magenta
      // 
      this.magenta.AutoSize = false;
      this.magenta.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.None;
      this.magenta.Name = "magenta";
      this.magenta.Size = new System.Drawing.Size(130, 16);
      this.magenta.Text = "Magenta";
      this.magenta.Click += new System.EventHandler(this.HighLightColors_Click);
      // 
      // purple
      // 
      this.purple.AutoSize = false;
      this.purple.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.None;
      this.purple.Name = "purple";
      this.purple.Size = new System.Drawing.Size(130, 16);
      this.purple.Text = "Purple";
      this.purple.Click += new System.EventHandler(this.HighLightColors_Click);
      // 
      // teal
      // 
      this.teal.AutoSize = false;
      this.teal.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.None;
      this.teal.Name = "teal";
      this.teal.Size = new System.Drawing.Size(130, 16);
      this.teal.Text = "Teal";
      this.teal.Click += new System.EventHandler(this.HighLightColors_Click);
      // 
      // gray
      // 
      this.gray.AutoSize = false;
      this.gray.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.None;
      this.gray.Name = "gray";
      this.gray.Size = new System.Drawing.Size(130, 16);
      this.gray.Text = "Gray";
      this.gray.Click += new System.EventHandler(this.HighLightColors_Click);
      // 
      // silver
      // 
      this.silver.AutoSize = false;
      this.silver.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.None;
      this.silver.Name = "silver";
      this.silver.Size = new System.Drawing.Size(130, 16);
      this.silver.Text = "Silver";
      this.silver.Click += new System.EventHandler(this.HighLightColors_Click);
      // 
      // red
      // 
      this.red.AutoSize = false;
      this.red.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.None;
      this.red.Name = "red";
      this.red.Size = new System.Drawing.Size(130, 16);
      this.red.Text = "Red";
      this.red.Click += new System.EventHandler(this.HighLightColors_Click);
      // 
      // lime
      // 
      this.lime.AutoSize = false;
      this.lime.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.None;
      this.lime.Name = "lime";
      this.lime.Size = new System.Drawing.Size(130, 16);
      this.lime.Text = "Lime";
      this.lime.Click += new System.EventHandler(this.HighLightColors_Click);
      // 
      // yellow
      // 
      this.yellow.AutoSize = false;
      this.yellow.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.None;
      this.yellow.Name = "yellow";
      this.yellow.Size = new System.Drawing.Size(130, 16);
      this.yellow.Text = "Yellow";
      this.yellow.Click += new System.EventHandler(this.HighLightColors_Click);
      // 
      // blue
      // 
      this.blue.AutoSize = false;
      this.blue.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.None;
      this.blue.Name = "blue";
      this.blue.Size = new System.Drawing.Size(130, 16);
      this.blue.Text = "Blue";
      this.blue.Click += new System.EventHandler(this.HighLightColors_Click);
      // 
      // white
      // 
      this.white.AutoSize = false;
      this.white.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.None;
      this.white.Name = "white";
      this.white.Size = new System.Drawing.Size(130, 16);
      this.white.Text = "White";
      this.white.Click += new System.EventHandler(this.HighLightColors_Click);
      // 
      // highLight
      // 
      this.highLight.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.highLight.Image = global::FAQ_Net.Properties.Resources.HLiteSml;
      this.highLight.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
      this.highLight.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.highLight.Name = "highLight";
      this.highLight.Size = new System.Drawing.Size(34, 17);
      this.highLight.ToolTipText = "Цвет выделения текста (Yellow)";
      this.highLight.ButtonClick += new System.EventHandler(this.HighLight_ButtonClick);
      this.highLight.DropDownOpening += new System.EventHandler(this.HighLight_DropDownOpening);
      this.highLight.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.HighLight_DropDownItemClicked);
      this.highLight.Paint += new System.Windows.Forms.PaintEventHandler(this.Highlight_Paint);
      // 
      // sep8
      // 
      this.sep8.Margin = new System.Windows.Forms.Padding(4, 1, 4, 1);
      this.sep8.Name = "sep8";
      this.sep8.Size = new System.Drawing.Size(6, 26);
      // 
      // tsddbInsertTable
      // 
      this.tsddbInsertTable.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.tsddbInsertTable.Image = global::FAQ_Net.Properties.Resources.InsertTable;
      this.tsddbInsertTable.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.tsddbInsertTable.Name = "tsddbInsertTable";
      this.tsddbInsertTable.Size = new System.Drawing.Size(29, 20);
      this.tsddbInsertTable.Text = "Создать таблицу";
      // 
      // tsbAddImage
      // 
      this.tsbAddImage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.tsbAddImage.Image = ((System.Drawing.Image)(resources.GetObject("tsbAddImage.Image")));
      this.tsbAddImage.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.tsbAddImage.Name = "tsbAddImage";
      this.tsbAddImage.Size = new System.Drawing.Size(23, 20);
      this.tsbAddImage.Text = "Добавить изображение";
      this.tsbAddImage.Click += new System.EventHandler(this.tsbAddImage_Click);
      // 
      // AddInFavoritesTSB
      // 
      this.AddInFavoritesTSB.Checked = true;
      this.AddInFavoritesTSB.CheckOnClick = true;
      this.AddInFavoritesTSB.CheckState = System.Windows.Forms.CheckState.Checked;
      this.AddInFavoritesTSB.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.AddInFavoritesTSB.Image = global::FAQ_Net.Properties.Resources.Favorite;
      this.AddInFavoritesTSB.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.AddInFavoritesTSB.Name = "AddInFavoritesTSB";
      this.AddInFavoritesTSB.Size = new System.Drawing.Size(23, 20);
      this.AddInFavoritesTSB.Text = "Добавить в избранное";
      this.AddInFavoritesTSB.CheckedChanged += new System.EventHandler(this.AddInFavoritesTSB_CheckedChanged);
      this.AddInFavoritesTSB.Click += new System.EventHandler(this.AddInFavoritesTSB_Click);
      // 
      // menuTop
      // 
      this.menuTop.BackColor = System.Drawing.Color.DimGray;
      this.menuTop.BackColorBottom = System.Drawing.Color.Gray;
      this.menuTop.FillColorType = GradientControls.GradientEnums.FillColorMode.Gradient;
      this.menuTop.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
      this.menuTop.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.file,
            this.edit,
            this.view,
            this.formatToolStripMenuItem,
            this.кодировкаToolStripMenuItem,
            this.tsmiTable,
            this.справкаToolStripMenuItem});
      this.menuTop.Location = new System.Drawing.Point(0, 0);
      this.menuTop.MenuColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
      this.menuTop.MenuColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
      this.menuTop.MenuColor3 = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
      this.menuTop.MenuColor4 = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
      this.menuTop.MenuColor7 = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
      this.menuTop.Name = "menuTop";
      this.menuTop.Size = new System.Drawing.Size(747, 24);
      this.menuTop.TabIndex = 5;
      // 
      // file
      // 
      this.file.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.open,
            this.s0,
            this.save,
            this.saveAs,
            this.s1,
            this.pageSet,
            this.printPrev,
            this.print});
      this.file.ForeColor = System.Drawing.Color.White;
      this.file.Name = "file";
      this.file.Size = new System.Drawing.Size(48, 20);
      this.file.Text = "&Файл";
      // 
      // open
      // 
      this.open.ForeColor = System.Drawing.Color.White;
      this.open.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
      this.open.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.open.Name = "open";
      this.open.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
      this.open.Size = new System.Drawing.Size(233, 22);
      this.open.Text = "&Открыть";
      this.open.Click += new System.EventHandler(this.Open_Click);
      // 
      // s0
      // 
      this.s0.Name = "s0";
      this.s0.Size = new System.Drawing.Size(230, 6);
      // 
      // save
      // 
      this.save.Enabled = false;
      this.save.Image = global::FAQ_Net.Properties.Resources.SaveSml;
      this.save.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
      this.save.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.save.Name = "save";
      this.save.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
      this.save.Size = new System.Drawing.Size(233, 22);
      this.save.Text = "&Сохранить";
      this.save.Click += new System.EventHandler(this.Save_Click);
      // 
      // saveAs
      // 
      this.saveAs.ForeColor = System.Drawing.Color.White;
      this.saveAs.Name = "saveAs";
      this.saveAs.Size = new System.Drawing.Size(233, 22);
      this.saveAs.Text = "Сохранить &как...";
      this.saveAs.Click += new System.EventHandler(this.saveAs_Click);
      // 
      // s1
      // 
      this.s1.Name = "s1";
      this.s1.Size = new System.Drawing.Size(230, 6);
      // 
      // pageSet
      // 
      this.pageSet.ForeColor = System.Drawing.Color.White;
      this.pageSet.Name = "pageSet";
      this.pageSet.Size = new System.Drawing.Size(233, 22);
      this.pageSet.Text = "Настройка с&траницы...";
      this.pageSet.Click += new System.EventHandler(this.PageSet_Click);
      // 
      // printPrev
      // 
      this.printPrev.ForeColor = System.Drawing.Color.White;
      this.printPrev.Image = global::FAQ_Net.Properties.Resources.PrevSml;
      this.printPrev.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
      this.printPrev.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.printPrev.Name = "printPrev";
      this.printPrev.Size = new System.Drawing.Size(233, 22);
      this.printPrev.Text = "Предварительный прос&мотр";
      this.printPrev.Click += new System.EventHandler(this.PrintPrev_Click);
      // 
      // print
      // 
      this.print.ForeColor = System.Drawing.Color.White;
      this.print.Image = global::FAQ_Net.Properties.Resources.PrintSml;
      this.print.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
      this.print.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.print.Name = "print";
      this.print.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
      this.print.Size = new System.Drawing.Size(233, 22);
      this.print.Text = "&Печать...";
      this.print.Click += new System.EventHandler(this.Print_Click);
      // 
      // edit
      // 
      this.edit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.undo,
            this.redo,
            this.s4,
            this.cut,
            this.copy,
            this.paste,
            this.s5,
            this.selectAll,
            this.s6,
            this.find,
            this.replace});
      this.edit.ForeColor = System.Drawing.Color.White;
      this.edit.Name = "edit";
      this.edit.Size = new System.Drawing.Size(59, 20);
      this.edit.Text = "&Правка";
      // 
      // undo
      // 
      this.undo.Enabled = false;
      this.undo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
      this.undo.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.undo.Name = "undo";
      this.undo.Size = new System.Drawing.Size(158, 22);
      this.undo.Text = "&Назад";
      this.undo.Click += new System.EventHandler(this.Undo_Click);
      // 
      // redo
      // 
      this.redo.Enabled = false;
      this.redo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
      this.redo.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.redo.Name = "redo";
      this.redo.Size = new System.Drawing.Size(158, 22);
      this.redo.Text = "В&перед";
      this.redo.Click += new System.EventHandler(this.Redo_Click);
      // 
      // s4
      // 
      this.s4.Name = "s4";
      this.s4.Size = new System.Drawing.Size(155, 6);
      // 
      // cut
      // 
      this.cut.ForeColor = System.Drawing.Color.White;
      this.cut.Image = global::FAQ_Net.Properties.Resources.Cut;
      this.cut.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
      this.cut.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.cut.Name = "cut";
      this.cut.Size = new System.Drawing.Size(158, 22);
      this.cut.Text = "Вы&резать";
      this.cut.Click += new System.EventHandler(this.Cut_Click);
      // 
      // copy
      // 
      this.copy.ForeColor = System.Drawing.Color.White;
      this.copy.Image = global::FAQ_Net.Properties.Resources.Copy;
      this.copy.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
      this.copy.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.copy.Name = "copy";
      this.copy.Size = new System.Drawing.Size(158, 22);
      this.copy.Text = "&Копировать";
      this.copy.Click += new System.EventHandler(this.Copy_Click);
      // 
      // paste
      // 
      this.paste.ForeColor = System.Drawing.Color.White;
      this.paste.Image = global::FAQ_Net.Properties.Resources.Paste;
      this.paste.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
      this.paste.ImageTransparentColor = System.Drawing.Color.Fuchsia;
      this.paste.Name = "paste";
      this.paste.Size = new System.Drawing.Size(158, 22);
      this.paste.Text = "&Вставить";
      this.paste.Click += new System.EventHandler(this.Paste_Click);
      // 
      // s5
      // 
      this.s5.Name = "s5";
      this.s5.Size = new System.Drawing.Size(155, 6);
      // 
      // selectAll
      // 
      this.selectAll.ForeColor = System.Drawing.Color.White;
      this.selectAll.Name = "selectAll";
      this.selectAll.Size = new System.Drawing.Size(158, 22);
      this.selectAll.Text = "Выделить вс&ё";
      this.selectAll.Click += new System.EventHandler(this.selectAll_Click);
      // 
      // s6
      // 
      this.s6.Name = "s6";
      this.s6.Size = new System.Drawing.Size(155, 6);
      // 
      // find
      // 
      this.find.ForeColor = System.Drawing.Color.White;
      this.find.Image = global::FAQ_Net.Properties.Resources.binoculars;
      this.find.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
      this.find.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.find.Name = "find";
      this.find.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
      this.find.Size = new System.Drawing.Size(158, 22);
      this.find.Text = "&Поиск";
      this.find.Click += new System.EventHandler(this.Find_Click);
      // 
      // replace
      // 
      this.replace.ForeColor = System.Drawing.Color.White;
      this.replace.Name = "replace";
      this.replace.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.H)));
      this.replace.Size = new System.Drawing.Size(158, 22);
      this.replace.Text = "З&амена";
      this.replace.Click += new System.EventHandler(this.replace_Click);
      // 
      // view
      // 
      this.view.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiDictionary});
      this.view.ForeColor = System.Drawing.Color.White;
      this.view.Name = "view";
      this.view.Size = new System.Drawing.Size(39, 20);
      this.view.Text = "В&ид";
      // 
      // tsmiDictionary
      // 
      this.tsmiDictionary.ForeColor = System.Drawing.Color.White;
      this.tsmiDictionary.Name = "tsmiDictionary";
      this.tsmiDictionary.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
      this.tsmiDictionary.Size = new System.Drawing.Size(222, 22);
      this.tsmiDictionary.Text = "Словарь подсказок";
      this.tsmiDictionary.Click += new System.EventHandler(this.tsmiDictionary_Click);
      // 
      // formatToolStripMenuItem
      // 
      this.formatToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.font,
            this.superscript,
            this.subscript});
      this.formatToolStripMenuItem.ForeColor = System.Drawing.Color.White;
      this.formatToolStripMenuItem.Name = "formatToolStripMenuItem";
      this.formatToolStripMenuItem.Size = new System.Drawing.Size(62, 20);
      this.formatToolStripMenuItem.Text = "&Формат";
      // 
      // font
      // 
      this.font.ForeColor = System.Drawing.Color.White;
      this.font.Image = global::FAQ_Net.Properties.Resources.ColorSml;
      this.font.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
      this.font.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.font.Name = "font";
      this.font.Size = new System.Drawing.Size(196, 22);
      this.font.Text = "&Шрифт...";
      this.font.Click += new System.EventHandler(this.font_Click);
      // 
      // superscript
      // 
      this.superscript.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.noSuperscript,
            this.toolStripSeparator1,
            this.toolStripMenuItem2,
            this.toolStripMenuItem3,
            this.toolStripMenuItem5,
            this.toolStripMenuItem4,
            this.toolStripMenuItem11,
            this.toolStripMenuItem12,
            this.toolStripMenuItem13,
            this.toolStripMenuItem14,
            this.toolStripMenuItem15});
      this.superscript.ForeColor = System.Drawing.Color.White;
      this.superscript.Name = "superscript";
      this.superscript.Size = new System.Drawing.Size(196, 22);
      this.superscript.Text = "На&дстрочный символ";
      // 
      // noSuperscript
      // 
      this.noSuperscript.Name = "noSuperscript";
      this.noSuperscript.Size = new System.Drawing.Size(114, 22);
      this.noSuperscript.Text = "&Normal";
      this.noSuperscript.Click += new System.EventHandler(this.normalCharOffset_Click);
      // 
      // toolStripSeparator1
      // 
      this.toolStripSeparator1.Name = "toolStripSeparator1";
      this.toolStripSeparator1.Size = new System.Drawing.Size(111, 6);
      // 
      // toolStripMenuItem2
      // 
      this.toolStripMenuItem2.Name = "toolStripMenuItem2";
      this.toolStripMenuItem2.Size = new System.Drawing.Size(114, 22);
      this.toolStripMenuItem2.Text = "2";
      this.toolStripMenuItem2.Click += new System.EventHandler(this.superSubScript_Click);
      // 
      // toolStripMenuItem3
      // 
      this.toolStripMenuItem3.Name = "toolStripMenuItem3";
      this.toolStripMenuItem3.Size = new System.Drawing.Size(114, 22);
      this.toolStripMenuItem3.Text = "3";
      this.toolStripMenuItem3.Click += new System.EventHandler(this.superSubScript_Click);
      // 
      // toolStripMenuItem5
      // 
      this.toolStripMenuItem5.Name = "toolStripMenuItem5";
      this.toolStripMenuItem5.Size = new System.Drawing.Size(114, 22);
      this.toolStripMenuItem5.Text = "5";
      this.toolStripMenuItem5.Click += new System.EventHandler(this.superSubScript_Click);
      // 
      // toolStripMenuItem4
      // 
      this.toolStripMenuItem4.Name = "toolStripMenuItem4";
      this.toolStripMenuItem4.Size = new System.Drawing.Size(114, 22);
      this.toolStripMenuItem4.Text = "4";
      this.toolStripMenuItem4.Click += new System.EventHandler(this.superSubScript_Click);
      // 
      // toolStripMenuItem11
      // 
      this.toolStripMenuItem11.Checked = true;
      this.toolStripMenuItem11.CheckState = System.Windows.Forms.CheckState.Checked;
      this.toolStripMenuItem11.Name = "toolStripMenuItem11";
      this.toolStripMenuItem11.Size = new System.Drawing.Size(114, 22);
      this.toolStripMenuItem11.Text = "6";
      this.toolStripMenuItem11.Click += new System.EventHandler(this.superSubScript_Click);
      // 
      // toolStripMenuItem12
      // 
      this.toolStripMenuItem12.Name = "toolStripMenuItem12";
      this.toolStripMenuItem12.Size = new System.Drawing.Size(114, 22);
      this.toolStripMenuItem12.Text = "7";
      this.toolStripMenuItem12.Click += new System.EventHandler(this.superSubScript_Click);
      // 
      // toolStripMenuItem13
      // 
      this.toolStripMenuItem13.Name = "toolStripMenuItem13";
      this.toolStripMenuItem13.Size = new System.Drawing.Size(114, 22);
      this.toolStripMenuItem13.Text = "8";
      this.toolStripMenuItem13.Click += new System.EventHandler(this.superSubScript_Click);
      // 
      // toolStripMenuItem14
      // 
      this.toolStripMenuItem14.Name = "toolStripMenuItem14";
      this.toolStripMenuItem14.Size = new System.Drawing.Size(114, 22);
      this.toolStripMenuItem14.Text = "9";
      this.toolStripMenuItem14.Click += new System.EventHandler(this.superSubScript_Click);
      // 
      // toolStripMenuItem15
      // 
      this.toolStripMenuItem15.Name = "toolStripMenuItem15";
      this.toolStripMenuItem15.Size = new System.Drawing.Size(114, 22);
      this.toolStripMenuItem15.Text = "10";
      this.toolStripMenuItem15.Click += new System.EventHandler(this.superSubScript_Click);
      // 
      // subscript
      // 
      this.subscript.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.noSubscript,
            this.toolStripSeparator2,
            this.toolStripMenuItem6,
            this.toolStripMenuItem7,
            this.toolStripMenuItem8,
            this.toolStripMenuItem9,
            this.toolStripMenuItem10,
            this.toolStripMenuItem16,
            this.toolStripMenuItem17,
            this.toolStripMenuItem19,
            this.toolStripMenuItem18});
      this.subscript.ForeColor = System.Drawing.Color.White;
      this.subscript.Name = "subscript";
      this.subscript.Size = new System.Drawing.Size(196, 22);
      this.subscript.Text = "П&одстрочный символ";
      // 
      // noSubscript
      // 
      this.noSubscript.Name = "noSubscript";
      this.noSubscript.Size = new System.Drawing.Size(114, 22);
      this.noSubscript.Text = "&Normal";
      this.noSubscript.Click += new System.EventHandler(this.normalCharOffset_Click);
      // 
      // toolStripSeparator2
      // 
      this.toolStripSeparator2.Name = "toolStripSeparator2";
      this.toolStripSeparator2.Size = new System.Drawing.Size(111, 6);
      // 
      // toolStripMenuItem6
      // 
      this.toolStripMenuItem6.Name = "toolStripMenuItem6";
      this.toolStripMenuItem6.Size = new System.Drawing.Size(114, 22);
      this.toolStripMenuItem6.Text = "-2";
      this.toolStripMenuItem6.Click += new System.EventHandler(this.superSubScript_Click);
      // 
      // toolStripMenuItem7
      // 
      this.toolStripMenuItem7.Name = "toolStripMenuItem7";
      this.toolStripMenuItem7.Size = new System.Drawing.Size(114, 22);
      this.toolStripMenuItem7.Text = "-3";
      this.toolStripMenuItem7.Click += new System.EventHandler(this.superSubScript_Click);
      // 
      // toolStripMenuItem8
      // 
      this.toolStripMenuItem8.Name = "toolStripMenuItem8";
      this.toolStripMenuItem8.Size = new System.Drawing.Size(114, 22);
      this.toolStripMenuItem8.Text = "-4";
      this.toolStripMenuItem8.Click += new System.EventHandler(this.superSubScript_Click);
      // 
      // toolStripMenuItem9
      // 
      this.toolStripMenuItem9.Name = "toolStripMenuItem9";
      this.toolStripMenuItem9.Size = new System.Drawing.Size(114, 22);
      this.toolStripMenuItem9.Text = "-5";
      this.toolStripMenuItem9.Click += new System.EventHandler(this.superSubScript_Click);
      // 
      // toolStripMenuItem10
      // 
      this.toolStripMenuItem10.Checked = true;
      this.toolStripMenuItem10.CheckState = System.Windows.Forms.CheckState.Checked;
      this.toolStripMenuItem10.Name = "toolStripMenuItem10";
      this.toolStripMenuItem10.Size = new System.Drawing.Size(114, 22);
      this.toolStripMenuItem10.Text = "-6";
      this.toolStripMenuItem10.Click += new System.EventHandler(this.superSubScript_Click);
      // 
      // toolStripMenuItem16
      // 
      this.toolStripMenuItem16.Name = "toolStripMenuItem16";
      this.toolStripMenuItem16.Size = new System.Drawing.Size(114, 22);
      this.toolStripMenuItem16.Text = "-7";
      this.toolStripMenuItem16.Click += new System.EventHandler(this.superSubScript_Click);
      // 
      // toolStripMenuItem17
      // 
      this.toolStripMenuItem17.Name = "toolStripMenuItem17";
      this.toolStripMenuItem17.Size = new System.Drawing.Size(114, 22);
      this.toolStripMenuItem17.Text = "-8";
      this.toolStripMenuItem17.Click += new System.EventHandler(this.superSubScript_Click);
      // 
      // toolStripMenuItem19
      // 
      this.toolStripMenuItem19.Name = "toolStripMenuItem19";
      this.toolStripMenuItem19.Size = new System.Drawing.Size(114, 22);
      this.toolStripMenuItem19.Text = "-10";
      this.toolStripMenuItem19.Click += new System.EventHandler(this.superSubScript_Click);
      // 
      // toolStripMenuItem18
      // 
      this.toolStripMenuItem18.Name = "toolStripMenuItem18";
      this.toolStripMenuItem18.Size = new System.Drawing.Size(114, 22);
      this.toolStripMenuItem18.Text = "-9";
      this.toolStripMenuItem18.Click += new System.EventHandler(this.superSubScript_Click);
      // 
      // кодировкаToolStripMenuItem
      // 
      this.кодировкаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ASCII_TSMI,
            this.тестToolStripMenuItem});
      this.кодировкаToolStripMenuItem.ForeColor = System.Drawing.Color.White;
      this.кодировкаToolStripMenuItem.Name = "кодировкаToolStripMenuItem";
      this.кодировкаToolStripMenuItem.Size = new System.Drawing.Size(78, 20);
      this.кодировкаToolStripMenuItem.Text = "Кодировка";
      // 
      // ASCII_TSMI
      // 
      this.ASCII_TSMI.ForeColor = System.Drawing.Color.White;
      this.ASCII_TSMI.Name = "ASCII_TSMI";
      this.ASCII_TSMI.Size = new System.Drawing.Size(197, 22);
      this.ASCII_TSMI.Text = "Из WIN1252 в WIN1251";
      this.ASCII_TSMI.Click += new System.EventHandler(this.ASCII_TSMI_Click);
      // 
      // тестToolStripMenuItem
      // 
      this.тестToolStripMenuItem.ForeColor = System.Drawing.Color.White;
      this.тестToolStripMenuItem.Name = "тестToolStripMenuItem";
      this.тестToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
      this.тестToolStripMenuItem.Text = "По запросу";
      this.тестToolStripMenuItem.Visible = false;
      this.тестToolStripMenuItem.Click += new System.EventHandler(this.тестToolStripMenuItem_Click);
      // 
      // tsmiTable
      // 
      this.tsmiTable.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiAddTable});
      this.tsmiTable.ForeColor = System.Drawing.Color.White;
      this.tsmiTable.Name = "tsmiTable";
      this.tsmiTable.Size = new System.Drawing.Size(66, 20);
      this.tsmiTable.Text = "Таблица";
      this.tsmiTable.Visible = false;
      // 
      // tsmiAddTable
      // 
      this.tsmiAddTable.ForeColor = System.Drawing.Color.White;
      this.tsmiAddTable.Name = "tsmiAddTable";
      this.tsmiAddTable.Size = new System.Drawing.Size(126, 22);
      this.tsmiAddTable.Text = "Добавить";
      // 
      // справкаToolStripMenuItem
      // 
      this.справкаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiAboutProgram});
      this.справкаToolStripMenuItem.ForeColor = System.Drawing.Color.White;
      this.справкаToolStripMenuItem.Name = "справкаToolStripMenuItem";
      this.справкаToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
      this.справкаToolStripMenuItem.Text = "Справка";
      // 
      // tsmiAboutProgram
      // 
      this.tsmiAboutProgram.Name = "tsmiAboutProgram";
      this.tsmiAboutProgram.Size = new System.Drawing.Size(149, 22);
      this.tsmiAboutProgram.Text = "О программе";
      this.tsmiAboutProgram.Click += new System.EventHandler(this.tsmiAboutProgram_Click);
      // 
      // QuestionsCMS
      // 
      this.QuestionsCMS.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddQuestionTSMI,
            this.ShowAnswerTSMI,
            this.EditQuestionTSMI,
            this.DeleteQuestionTSMI,
            this.toolStripSeparator5,
            this.SortAscTSMI,
            this.SortDescTSMI,
            this.toolStripSeparator6,
            this.tsmiGridView,
            this.tsmiListView});
      this.QuestionsCMS.Name = "QuestionsCMS";
      this.QuestionsCMS.Size = new System.Drawing.Size(193, 192);
      this.QuestionsCMS.Opening += new System.ComponentModel.CancelEventHandler(this.QuestionsCMS_Opening);
      // 
      // AddQuestionTSMI
      // 
      this.AddQuestionTSMI.Name = "AddQuestionTSMI";
      this.AddQuestionTSMI.Size = new System.Drawing.Size(192, 22);
      this.AddQuestionTSMI.Text = "Добавить";
      this.AddQuestionTSMI.Click += new System.EventHandler(this.CreateQuestionTSB_Click);
      // 
      // ShowAnswerTSMI
      // 
      this.ShowAnswerTSMI.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
      this.ShowAnswerTSMI.Name = "ShowAnswerTSMI";
      this.ShowAnswerTSMI.Size = new System.Drawing.Size(192, 22);
      this.ShowAnswerTSMI.Text = "Посмотреть";
      this.ShowAnswerTSMI.Click += new System.EventHandler(this.ShowAnswerTSMI_Click);
      // 
      // EditQuestionTSMI
      // 
      this.EditQuestionTSMI.Name = "EditQuestionTSMI";
      this.EditQuestionTSMI.Size = new System.Drawing.Size(192, 22);
      this.EditQuestionTSMI.Text = "Изменить";
      this.EditQuestionTSMI.Click += new System.EventHandler(this.EditQuestionTSMI_Click);
      // 
      // DeleteQuestionTSMI
      // 
      this.DeleteQuestionTSMI.Name = "DeleteQuestionTSMI";
      this.DeleteQuestionTSMI.Size = new System.Drawing.Size(192, 22);
      this.DeleteQuestionTSMI.Text = "Удалить";
      this.DeleteQuestionTSMI.Click += new System.EventHandler(this.DeleteQuestionTSMI_Click);
      // 
      // toolStripSeparator5
      // 
      this.toolStripSeparator5.Name = "toolStripSeparator5";
      this.toolStripSeparator5.Size = new System.Drawing.Size(189, 6);
      // 
      // SortAscTSMI
      // 
      this.SortAscTSMI.Image = global::FAQ_Net.Properties.Resources.sort_asc;
      this.SortAscTSMI.Name = "SortAscTSMI";
      this.SortAscTSMI.Size = new System.Drawing.Size(192, 22);
      this.SortAscTSMI.Text = "Сортировка от &А до Я";
      this.SortAscTSMI.Click += new System.EventHandler(this.SortAscTSMI_Click);
      // 
      // SortDescTSMI
      // 
      this.SortDescTSMI.Image = global::FAQ_Net.Properties.Resources.sort_desc;
      this.SortDescTSMI.Name = "SortDescTSMI";
      this.SortDescTSMI.Size = new System.Drawing.Size(192, 22);
      this.SortDescTSMI.Text = "Сортировка от &Я до А";
      this.SortDescTSMI.Click += new System.EventHandler(this.SortDescTSMI_Click);
      // 
      // toolStripSeparator6
      // 
      this.toolStripSeparator6.Name = "toolStripSeparator6";
      this.toolStripSeparator6.Size = new System.Drawing.Size(189, 6);
      // 
      // tsmiGridView
      // 
      this.tsmiGridView.Name = "tsmiGridView";
      this.tsmiGridView.Size = new System.Drawing.Size(192, 22);
      this.tsmiGridView.Text = "Сетка";
      this.tsmiGridView.Click += new System.EventHandler(this.tsmiGridView_Click);
      // 
      // tsmiListView
      // 
      this.tsmiListView.Name = "tsmiListView";
      this.tsmiListView.Size = new System.Drawing.Size(192, 22);
      this.tsmiListView.Text = "Лист";
      this.tsmiListView.Click += new System.EventHandler(this.tsmiListView_Click);
      // 
      // richMenu
      // 
      this.richMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cutRichText,
            this.copyRichText,
            this.pasteRichText,
            this.sep_0,
            this.fontRichText,
            this.sep_1,
            this.superscriptRichText,
            this.normalOffset,
            this.subscriptRichText,
            this.sep_2,
            this.printRichText});
      this.richMenu.Name = "RichMenu";
      this.richMenu.Size = new System.Drawing.Size(219, 198);
      this.richMenu.Opening += new System.ComponentModel.CancelEventHandler(this.richMenu_Opening);
      // 
      // cutRichText
      // 
      this.cutRichText.Image = global::FAQ_Net.Properties.Resources.Cut;
      this.cutRichText.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
      this.cutRichText.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.cutRichText.Name = "cutRichText";
      this.cutRichText.Size = new System.Drawing.Size(218, 22);
      this.cutRichText.Text = "Вы&резать";
      this.cutRichText.Click += new System.EventHandler(this.Cut_Click);
      // 
      // copyRichText
      // 
      this.copyRichText.Image = global::FAQ_Net.Properties.Resources.Copy;
      this.copyRichText.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
      this.copyRichText.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.copyRichText.Name = "copyRichText";
      this.copyRichText.Size = new System.Drawing.Size(218, 22);
      this.copyRichText.Text = "&Копировать";
      this.copyRichText.Click += new System.EventHandler(this.Copy_Click);
      // 
      // pasteRichText
      // 
      this.pasteRichText.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
      this.pasteRichText.Image = global::FAQ_Net.Properties.Resources.Paste;
      this.pasteRichText.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
      this.pasteRichText.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.pasteRichText.Name = "pasteRichText";
      this.pasteRichText.Size = new System.Drawing.Size(218, 22);
      this.pasteRichText.Text = "&Вставить";
      this.pasteRichText.Click += new System.EventHandler(this.Paste_Click);
      // 
      // sep_0
      // 
      this.sep_0.Name = "sep_0";
      this.sep_0.Size = new System.Drawing.Size(215, 6);
      // 
      // fontRichText
      // 
      this.fontRichText.Image = global::FAQ_Net.Properties.Resources.ColorSml;
      this.fontRichText.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
      this.fontRichText.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.fontRichText.Name = "fontRichText";
      this.fontRichText.Size = new System.Drawing.Size(218, 22);
      this.fontRichText.Text = "&Шрифт...";
      this.fontRichText.Click += new System.EventHandler(this.RichMenu_Click);
      // 
      // sep_1
      // 
      this.sep_1.Name = "sep_1";
      this.sep_1.Size = new System.Drawing.Size(215, 6);
      // 
      // superscriptRichText
      // 
      this.superscriptRichText.Image = global::FAQ_Net.Properties.Resources.Super;
      this.superscriptRichText.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.superscriptRichText.Name = "superscriptRichText";
      this.superscriptRichText.Size = new System.Drawing.Size(218, 22);
      this.superscriptRichText.Text = "На&дстрочный символ (6)";
      this.superscriptRichText.Click += new System.EventHandler(this.superscriptRichText_Click);
      // 
      // normalOffset
      // 
      this.normalOffset.Image = global::FAQ_Net.Properties.Resources.Normal;
      this.normalOffset.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.normalOffset.Name = "normalOffset";
      this.normalOffset.Size = new System.Drawing.Size(218, 22);
      this.normalOffset.Text = "Обычный";
      this.normalOffset.Click += new System.EventHandler(this.normalOffset_Click);
      // 
      // subscriptRichText
      // 
      this.subscriptRichText.Image = global::FAQ_Net.Properties.Resources.Sub;
      this.subscriptRichText.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.subscriptRichText.Name = "subscriptRichText";
      this.subscriptRichText.Size = new System.Drawing.Size(218, 22);
      this.subscriptRichText.Text = "П&одстрочный символ (-6)";
      this.subscriptRichText.Click += new System.EventHandler(this.subscriptRichText_Click);
      // 
      // sep_2
      // 
      this.sep_2.Name = "sep_2";
      this.sep_2.Size = new System.Drawing.Size(215, 6);
      // 
      // printRichText
      // 
      this.printRichText.Image = global::FAQ_Net.Properties.Resources.PrintSml;
      this.printRichText.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
      this.printRichText.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.printRichText.Name = "printRichText";
      this.printRichText.Size = new System.Drawing.Size(218, 22);
      this.printRichText.Text = "&Печать...";
      this.printRichText.Click += new System.EventHandler(this.RichMenu_Click);
      // 
      // BackBtn
      // 
      this.BackBtn.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
      this.BackBtn.ButtonColorBottom = System.Drawing.Color.Yellow;
      this.BackBtn.ButtonColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
      this.BackBtn.CornerRadius = 5;
      this.BackBtn.Font = new System.Drawing.Font("Segoe UI", 8.25F);
      this.BackBtn.ForeColor = System.Drawing.SystemColors.ControlText;
      this.BackBtn.Image = global::FAQ_Net.Properties.Resources.arrow_left;
      this.BackBtn.Location = new System.Drawing.Point(3, 3);
      this.BackBtn.Name = "BackBtn";
      this.BackBtn.PulseSpeed = 0.3F;
      this.BackBtn.PulseWidth = 1;
      this.BackBtn.Size = new System.Drawing.Size(26, 25);
      this.BackBtn.TabIndex = 32;
      this.toolTip.SetToolTip(this.BackBtn, "Назад");
      this.BackBtn.UseVisualStyleBackColor = false;
      this.BackBtn.Visible = false;
      this.BackBtn.Click += new System.EventHandler(this.BackBtn_Click);
      // 
      // btnNextQuestion
      // 
      this.btnNextQuestion.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
      this.btnNextQuestion.ButtonColorBottom = System.Drawing.Color.Yellow;
      this.btnNextQuestion.ButtonColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
      this.btnNextQuestion.CornerRadius = 5;
      this.btnNextQuestion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnNextQuestion.Font = new System.Drawing.Font("Segoe UI", 8.25F);
      this.btnNextQuestion.ForeColor = System.Drawing.SystemColors.ControlText;
      this.btnNextQuestion.Image = global::FAQ_Net.Properties.Resources.arrow_right;
      this.btnNextQuestion.Location = new System.Drawing.Point(35, 3);
      this.btnNextQuestion.Name = "btnNextQuestion";
      this.btnNextQuestion.PulseSpeed = 0.3F;
      this.btnNextQuestion.PulseWidth = 1;
      this.btnNextQuestion.Size = new System.Drawing.Size(26, 25);
      this.btnNextQuestion.TabIndex = 34;
      this.toolTip.SetToolTip(this.btnNextQuestion, "Вперед");
      this.btnNextQuestion.UseVisualStyleBackColor = false;
      this.btnNextQuestion.Visible = false;
      this.btnNextQuestion.Click += new System.EventHandler(this.btnNextQuestion_Click);
      // 
      // splitContainer2
      // 
      this.splitContainer2.BackColor = System.Drawing.SystemColors.Window;
      this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
      this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
      this.splitContainer2.Location = new System.Drawing.Point(0, 0);
      this.splitContainer2.Name = "splitContainer2";
      // 
      // splitContainer2.Panel1
      // 
      this.splitContainer2.Panel1.Controls.Add(this.splitContainer1);
      this.splitContainer2.Panel1.Controls.Add(this.splitter1);
      this.splitContainer2.Panel1.Controls.Add(this.panel3);
      this.splitContainer2.Panel1.Controls.Add(this.splitter2);
      this.splitContainer2.Panel1.Controls.Add(this.TabControl);
      this.splitContainer2.Size = new System.Drawing.Size(1238, 402);
      this.splitContainer2.SplitterDistance = 991;
      this.splitContainer2.TabIndex = 9;
      // 
      // splitter1
      // 
      this.splitter1.BackColor = System.Drawing.Color.DimGray;
      this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
      this.splitter1.Location = new System.Drawing.Point(242, 30);
      this.splitter1.Name = "splitter1";
      this.splitter1.Size = new System.Drawing.Size(749, 4);
      this.splitter1.TabIndex = 31;
      this.splitter1.TabStop = false;
      // 
      // panel3
      // 
      this.panel3.BackColor = System.Drawing.Color.Black;
      this.panel3.BackColorBottom = System.Drawing.Color.DimGray;
      this.panel3.Controls.Add(this.tableLayoutPanel1);
      this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
      this.panel3.FillColorType = GradientControls.GradientEnums.FillColorMode.Gradient;
      this.panel3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.panel3.ForeColor = System.Drawing.Color.White;
      this.panel3.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
      this.panel3.Location = new System.Drawing.Point(242, 0);
      this.panel3.Name = "panel3";
      this.panel3.Size = new System.Drawing.Size(749, 30);
      this.panel3.TabIndex = 33;
      // 
      // tableLayoutPanel1
      // 
      this.tableLayoutPanel1.AutoSize = true;
      this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
      this.tableLayoutPanel1.ColumnCount = 4;
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 32F));
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 32F));
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
      this.tableLayoutPanel1.Controls.Add(this.btnSelectQuestion, 3, 0);
      this.tableLayoutPanel1.Controls.Add(this.BackBtn, 0, 0);
      this.tableLayoutPanel1.Controls.Add(this.btnNextQuestion, 1, 0);
      this.tableLayoutPanel1.Controls.Add(this.SelectedPathLbl, 2, 0);
      this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
      this.tableLayoutPanel1.Name = "tableLayoutPanel1";
      this.tableLayoutPanel1.RowCount = 1;
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
      this.tableLayoutPanel1.Size = new System.Drawing.Size(749, 30);
      this.tableLayoutPanel1.TabIndex = 35;
      // 
      // btnSelectQuestion
      // 
      this.btnSelectQuestion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnSelectQuestion.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
      this.btnSelectQuestion.ButtonColorBottom = System.Drawing.Color.Gold;
      this.btnSelectQuestion.ButtonColorTop = System.Drawing.SystemColors.Info;
      this.btnSelectQuestion.CornerRadius = 5;
      this.btnSelectQuestion.Enabled = false;
      this.btnSelectQuestion.Font = new System.Drawing.Font("Segoe UI", 8.25F);
      this.btnSelectQuestion.ForeColor = System.Drawing.SystemColors.ControlText;
      this.btnSelectQuestion.Location = new System.Drawing.Point(652, 3);
      this.btnSelectQuestion.Name = "btnSelectQuestion";
      this.btnSelectQuestion.NumberOfPulses = 1;
      this.btnSelectQuestion.PulseSpeed = 0.3F;
      this.btnSelectQuestion.PulseWidth = 1;
      this.btnSelectQuestion.ShapeType = PulseButton.PulseButton.Shape.Rectangle;
      this.btnSelectQuestion.Size = new System.Drawing.Size(94, 24);
      this.btnSelectQuestion.TabIndex = 33;
      this.btnSelectQuestion.Text = "Выбрать вопрос";
      this.btnSelectQuestion.UseVisualStyleBackColor = false;
      this.btnSelectQuestion.Visible = false;
      this.btnSelectQuestion.Click += new System.EventHandler(this.btnSelectQuestion_Click);
      // 
      // SelectedPathLbl
      // 
      this.SelectedPathLbl.Dock = System.Windows.Forms.DockStyle.Fill;
      this.SelectedPathLbl.Location = new System.Drawing.Point(67, 0);
      this.SelectedPathLbl.Name = "SelectedPathLbl";
      this.SelectedPathLbl.Size = new System.Drawing.Size(579, 31);
      this.SelectedPathLbl.TabIndex = 35;
      this.SelectedPathLbl.Text = "Последние добавленные вопросы";
      this.SelectedPathLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      this.SelectedPathLbl.DragEnter += new System.Windows.Forms.DragEventHandler(this.SelectedPathLbl_DragEnter);
      this.SelectedPathLbl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.SelectedPathLbl_MouseDown);
      // 
      // splitter2
      // 
      this.splitter2.Location = new System.Drawing.Point(238, 0);
      this.splitter2.Name = "splitter2";
      this.splitter2.Size = new System.Drawing.Size(4, 402);
      this.splitter2.TabIndex = 30;
      this.splitter2.TabStop = false;
      // 
      // TabControl
      // 
      this.TabControl.BackColorBottom = System.Drawing.Color.Empty;
      this.TabControl.Controls.Add(this.CategoriesTP);
      this.TabControl.Controls.Add(this.SearchTP);
      this.TabControl.Controls.Add(this.FavoritesTP);
      this.TabControl.Controls.Add(this.JournalTP);
      this.TabControl.Dock = System.Windows.Forms.DockStyle.Left;
      this.TabControl.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
      this.TabControl.Location = new System.Drawing.Point(0, 0);
      this.TabControl.Name = "TabControl";
      this.TabControl.SelectedIndex = 0;
      this.TabControl.Size = new System.Drawing.Size(238, 402);
      this.TabControl.TabIndex = 2;
      this.TabControl.SelectedIndexChanged += new System.EventHandler(this.TabControl_SelectedIndexChanged);
      // 
      // CategoriesTP
      // 
      this.CategoriesTP.BackColor = System.Drawing.SystemColors.Control;
      this.CategoriesTP.BackColorBottom = System.Drawing.Color.Empty;
      this.CategoriesTP.Controls.Add(this.TV1);
      this.CategoriesTP.Controls.Add(this.statusStrip2);
      this.CategoriesTP.Controls.Add(this.SearchPanel);
      this.CategoriesTP.Controls.Add(this.toolStrip1);
      this.CategoriesTP.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
      this.CategoriesTP.Location = new System.Drawing.Point(4, 22);
      this.CategoriesTP.Name = "CategoriesTP";
      this.CategoriesTP.Padding = new System.Windows.Forms.Padding(3);
      this.CategoriesTP.Size = new System.Drawing.Size(230, 376);
      this.CategoriesTP.TabIndex = 0;
      this.CategoriesTP.Text = "Разделы";
      // 
      // TV1
      // 
      this.TV1.AllowDrop = true;
      this.TV1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(220)))));
      this.TV1.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.TV1.ContextMenuStrip = this.CategoriesContextMenu;
      this.TV1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.TV1.HideSelection = false;
      this.TV1.Location = new System.Drawing.Point(3, 73);
      this.TV1.Name = "TV1";
      this.TV1.PathSeparator = " :: ";
      this.TV1.Size = new System.Drawing.Size(224, 278);
      this.TV1.TabIndex = 4;
      this.TV1.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.TV1_AfterExpand);
      this.TV1.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.TV1_ItemDrag);
      this.TV1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TV1_AfterSelect);
      this.TV1.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.TV1_NodeMouseClick);
      this.TV1.DragDrop += new System.Windows.Forms.DragEventHandler(this.TV1_DragDrop);
      this.TV1.DragEnter += new System.Windows.Forms.DragEventHandler(this.TV1_DragEnter);
      this.TV1.DragOver += new System.Windows.Forms.DragEventHandler(this.TV1_DragOver);
      this.TV1.DragLeave += new System.EventHandler(this.TV1_DragLeave);
      this.TV1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TV1_MouseDown);
      // 
      // statusStrip2
      // 
      this.statusStrip2.BackColor = System.Drawing.SystemColors.Control;
      this.statusStrip2.BackColorBottom = System.Drawing.Color.Empty;
      this.statusStrip2.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
      this.statusStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CountSubcategoryLbl,
            this.CountSubcategoryVal});
      this.statusStrip2.Location = new System.Drawing.Point(3, 351);
      this.statusStrip2.Name = "statusStrip2";
      this.statusStrip2.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
      this.statusStrip2.Size = new System.Drawing.Size(224, 22);
      this.statusStrip2.TabIndex = 3;
      this.statusStrip2.Text = "statusStrip2";
      // 
      // CountSubcategoryLbl
      // 
      this.CountSubcategoryLbl.Margin = new System.Windows.Forms.Padding(3, 3, 0, 2);
      this.CountSubcategoryLbl.Name = "CountSubcategoryLbl";
      this.CountSubcategoryLbl.Size = new System.Drawing.Size(148, 17);
      this.CountSubcategoryLbl.Text = "Количество подразделов:";
      // 
      // CountSubcategoryVal
      // 
      this.CountSubcategoryVal.Name = "CountSubcategoryVal";
      this.CountSubcategoryVal.Size = new System.Drawing.Size(13, 17);
      this.CountSubcategoryVal.Text = "0";
      // 
      // SearchPanel
      // 
      this.SearchPanel.Controls.Add(this.SearchCategoryBtn);
      this.SearchPanel.Controls.Add(this.SearchCategoryCmbBox);
      this.SearchPanel.Dock = System.Windows.Forms.DockStyle.Top;
      this.SearchPanel.Location = new System.Drawing.Point(3, 28);
      this.SearchPanel.Name = "SearchPanel";
      this.SearchPanel.Size = new System.Drawing.Size(224, 45);
      this.SearchPanel.TabIndex = 2;
      this.SearchPanel.Visible = false;
      // 
      // SearchCategoryBtn
      // 
      this.SearchCategoryBtn.ButtonColorBottom = System.Drawing.Color.LightCoral;
      this.SearchCategoryBtn.ButtonColorTop = System.Drawing.Color.MistyRose;
      this.SearchCategoryBtn.CornerRadius = 5;
      this.SearchCategoryBtn.Dock = System.Windows.Forms.DockStyle.Top;
      this.SearchCategoryBtn.ForeColor = System.Drawing.SystemColors.ControlText;
      this.SearchCategoryBtn.Location = new System.Drawing.Point(0, 21);
      this.SearchCategoryBtn.Name = "SearchCategoryBtn";
      this.SearchCategoryBtn.PulseSpeed = 0.3F;
      this.SearchCategoryBtn.PulseWidth = 1;
      this.SearchCategoryBtn.ShapeType = PulseButton.PulseButton.Shape.Rectangle;
      this.SearchCategoryBtn.Size = new System.Drawing.Size(224, 23);
      this.SearchCategoryBtn.TabIndex = 1;
      this.SearchCategoryBtn.Text = "Найти";
      this.SearchCategoryBtn.UseVisualStyleBackColor = true;
      this.SearchCategoryBtn.Click += new System.EventHandler(this.SearchCategoryBtn_Click);
      // 
      // SearchCategoryCmbBox
      // 
      this.SearchCategoryCmbBox.Dock = System.Windows.Forms.DockStyle.Top;
      this.SearchCategoryCmbBox.FormattingEnabled = true;
      this.SearchCategoryCmbBox.Location = new System.Drawing.Point(0, 0);
      this.SearchCategoryCmbBox.Name = "SearchCategoryCmbBox";
      this.SearchCategoryCmbBox.Size = new System.Drawing.Size(224, 21);
      this.SearchCategoryCmbBox.TabIndex = 0;
      this.SearchCategoryCmbBox.Text = "---Поиск по разделам---";
      // 
      // toolStrip1
      // 
      this.toolStrip1.BackColor = System.Drawing.SystemColors.Control;
      this.toolStrip1.BackColorBottom = System.Drawing.Color.Empty;
      this.toolStrip1.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
      this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
      this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CreateQuestionTSB,
            this.CreateCategoryTSB,
            this.CreateSubcategoryTSB,
            this.toolStripSeparator3,
            this.RefreshTSB,
            this.toolStripSeparator4,
            this.CollapseAllTSB,
            this.ExpandAllNodesTSB});
      this.toolStrip1.Location = new System.Drawing.Point(3, 3);
      this.toolStrip1.Name = "toolStrip1";
      this.toolStrip1.Size = new System.Drawing.Size(224, 25);
      this.toolStrip1.TabIndex = 0;
      this.toolStrip1.Text = "toolStrip1";
      // 
      // CreateQuestionTSB
      // 
      this.CreateQuestionTSB.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.CreateQuestionTSB.Enabled = false;
      this.CreateQuestionTSB.Image = global::FAQ_Net.Properties.Resources.NewSml;
      this.CreateQuestionTSB.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
      this.CreateQuestionTSB.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.CreateQuestionTSB.Name = "CreateQuestionTSB";
      this.CreateQuestionTSB.Size = new System.Drawing.Size(23, 22);
      this.CreateQuestionTSB.Text = "Создание вопроса";
      this.CreateQuestionTSB.Click += new System.EventHandler(this.CreateQuestionTSB_Click);
      // 
      // CreateCategoryTSB
      // 
      this.CreateCategoryTSB.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.CreateCategoryTSB.Image = global::FAQ_Net.Properties.Resources.Folder;
      this.CreateCategoryTSB.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
      this.CreateCategoryTSB.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.CreateCategoryTSB.Name = "CreateCategoryTSB";
      this.CreateCategoryTSB.Size = new System.Drawing.Size(23, 22);
      this.CreateCategoryTSB.Text = "Добавить раздел";
      this.CreateCategoryTSB.Click += new System.EventHandler(this.CreateCategory_Click);
      // 
      // CreateSubcategoryTSB
      // 
      this.CreateSubcategoryTSB.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.CreateSubcategoryTSB.Enabled = false;
      this.CreateSubcategoryTSB.Image = global::FAQ_Net.Properties.Resources.NewFolder2;
      this.CreateSubcategoryTSB.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.CreateSubcategoryTSB.Name = "CreateSubcategoryTSB";
      this.CreateSubcategoryTSB.Size = new System.Drawing.Size(23, 22);
      this.CreateSubcategoryTSB.Text = "Добавить подраздел";
      this.CreateSubcategoryTSB.Click += new System.EventHandler(this.CreateSubcategoryTSB_Click);
      // 
      // toolStripSeparator3
      // 
      this.toolStripSeparator3.Name = "toolStripSeparator3";
      this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
      // 
      // RefreshTSB
      // 
      this.RefreshTSB.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.RefreshTSB.Image = global::FAQ_Net.Properties.Resources.Refresh;
      this.RefreshTSB.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.RefreshTSB.Name = "RefreshTSB";
      this.RefreshTSB.Size = new System.Drawing.Size(23, 22);
      this.RefreshTSB.Text = "Обновить";
      this.RefreshTSB.Click += new System.EventHandler(this.RefreshTSB_Click);
      // 
      // toolStripSeparator4
      // 
      this.toolStripSeparator4.Name = "toolStripSeparator4";
      this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
      // 
      // CollapseAllTSB
      // 
      this.CollapseAllTSB.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.CollapseAllTSB.Image = global::FAQ_Net.Properties.Resources.collapse;
      this.CollapseAllTSB.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.CollapseAllTSB.Name = "CollapseAllTSB";
      this.CollapseAllTSB.Size = new System.Drawing.Size(23, 22);
      this.CollapseAllTSB.Text = "Свернуть все узлы";
      this.CollapseAllTSB.Click += new System.EventHandler(this.CollapseAllTSB_Click);
      // 
      // ExpandAllNodesTSB
      // 
      this.ExpandAllNodesTSB.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.ExpandAllNodesTSB.Image = global::FAQ_Net.Properties.Resources.expand;
      this.ExpandAllNodesTSB.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.ExpandAllNodesTSB.Name = "ExpandAllNodesTSB";
      this.ExpandAllNodesTSB.Size = new System.Drawing.Size(23, 22);
      this.ExpandAllNodesTSB.Text = "Развернуть все узлы";
      this.ExpandAllNodesTSB.Click += new System.EventHandler(this.ExpandAllNodesTSB_Click);
      // 
      // SearchTP
      // 
      this.SearchTP.BackColor = System.Drawing.SystemColors.Control;
      this.SearchTP.BackColorBottom = System.Drawing.Color.Empty;
      this.SearchTP.Controls.Add(this.DGVResultSearch);
      this.SearchTP.Controls.Add(this.panel1);
      this.SearchTP.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
      this.SearchTP.Location = new System.Drawing.Point(4, 22);
      this.SearchTP.Name = "SearchTP";
      this.SearchTP.Padding = new System.Windows.Forms.Padding(3);
      this.SearchTP.Size = new System.Drawing.Size(230, 376);
      this.SearchTP.TabIndex = 1;
      this.SearchTP.Text = "Поиск";
      // 
      // DGVResultSearch
      // 
      this.DGVResultSearch.AllowUserToAddRows = false;
      this.DGVResultSearch.AllowUserToResizeRows = false;
      dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
      dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
      dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
      dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
      dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
      dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
      this.DGVResultSearch.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
      this.DGVResultSearch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.DGVResultSearch.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_content_search,
            this.QuestionSearchColumn,
            this.SearchFavoriteDateColumn});
      dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
      dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
      dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
      dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
      dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
      dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
      this.DGVResultSearch.DefaultCellStyle = dataGridViewCellStyle2;
      this.DGVResultSearch.Dock = System.Windows.Forms.DockStyle.Fill;
      this.DGVResultSearch.EnableHeadersVisualStyles = false;
      this.DGVResultSearch.Location = new System.Drawing.Point(3, 128);
      this.DGVResultSearch.MultiSelect = false;
      this.DGVResultSearch.Name = "DGVResultSearch";
      this.DGVResultSearch.ReadOnly = true;
      dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
      dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
      dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
      dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
      dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
      dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
      this.DGVResultSearch.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
      this.DGVResultSearch.RowHeadersVisible = false;
      this.DGVResultSearch.Size = new System.Drawing.Size(224, 245);
      this.DGVResultSearch.TabIndex = 5;
      this.DGVResultSearch.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVResultSearch_CellClick);
      // 
      // id_content_search
      // 
      this.id_content_search.DataPropertyName = "id_content";
      this.id_content_search.HeaderText = "id_content";
      this.id_content_search.Name = "id_content_search";
      this.id_content_search.ReadOnly = true;
      this.id_content_search.Visible = false;
      // 
      // QuestionSearchColumn
      // 
      this.QuestionSearchColumn.DataPropertyName = "question";
      this.QuestionSearchColumn.HeaderText = "Результаты";
      this.QuestionSearchColumn.Name = "QuestionSearchColumn";
      this.QuestionSearchColumn.ReadOnly = true;
      // 
      // SearchFavoriteDateColumn
      // 
      this.SearchFavoriteDateColumn.DataPropertyName = "favorite_date";
      this.SearchFavoriteDateColumn.HeaderText = "favorite_date";
      this.SearchFavoriteDateColumn.Name = "SearchFavoriteDateColumn";
      this.SearchFavoriteDateColumn.ReadOnly = true;
      this.SearchFavoriteDateColumn.Visible = false;
      // 
      // panel1
      // 
      this.panel1.Controls.Add(this.searchUp);
      this.panel1.Controls.Add(this.searchDown);
      this.panel1.Controls.Add(this.SearchTxtBox);
      this.panel1.Controls.Add(this.lblSearchDescription);
      this.panel1.Controls.Add(this.SearchAnswRB);
      this.panel1.Controls.Add(this.SearchQuestRB);
      this.panel1.Controls.Add(this.SearchAllRB);
      this.panel1.Controls.Add(this.SearchBtn);
      this.panel1.Controls.Add(this.label1);
      this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
      this.panel1.Location = new System.Drawing.Point(3, 3);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(224, 125);
      this.panel1.TabIndex = 4;
      // 
      // searchUp
      // 
      this.searchUp.ButtonColorBottom = System.Drawing.Color.LightSkyBlue;
      this.searchUp.ButtonColorTop = System.Drawing.Color.LightCyan;
      this.searchUp.CornerRadius = 5;
      this.searchUp.Enabled = false;
      this.searchUp.ForeColor = System.Drawing.SystemColors.ControlText;
      this.searchUp.Location = new System.Drawing.Point(181, 93);
      this.searchUp.Name = "searchUp";
      this.searchUp.PulseSpeed = 0.3F;
      this.searchUp.PulseWidth = 1;
      this.searchUp.ShapeType = PulseButton.PulseButton.Shape.Rectangle;
      this.searchUp.Size = new System.Drawing.Size(15, 25);
      this.searchUp.TabIndex = 12;
      this.searchUp.Text = "↑";
      this.searchUp.UseVisualStyleBackColor = true;
      this.searchUp.Click += new System.EventHandler(this.searchUp_Click);
      // 
      // searchDown
      // 
      this.searchDown.ButtonColorBottom = System.Drawing.Color.LightSkyBlue;
      this.searchDown.ButtonColorTop = System.Drawing.Color.LightCyan;
      this.searchDown.CornerRadius = 5;
      this.searchDown.Enabled = false;
      this.searchDown.ForeColor = System.Drawing.SystemColors.ControlText;
      this.searchDown.Location = new System.Drawing.Point(160, 93);
      this.searchDown.Name = "searchDown";
      this.searchDown.PulseSpeed = 0.3F;
      this.searchDown.PulseWidth = 1;
      this.searchDown.ShapeType = PulseButton.PulseButton.Shape.Rectangle;
      this.searchDown.Size = new System.Drawing.Size(15, 25);
      this.searchDown.TabIndex = 11;
      this.searchDown.Text = "↓";
      this.searchDown.UseVisualStyleBackColor = true;
      this.searchDown.Click += new System.EventHandler(this.searchDown_Click);
      // 
      // SearchTxtBox
      // 
      this.SearchTxtBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.SearchTxtBox.Location = new System.Drawing.Point(3, 21);
      this.SearchTxtBox.Name = "SearchTxtBox";
      this.SearchTxtBox.Size = new System.Drawing.Size(218, 20);
      this.SearchTxtBox.TabIndex = 1;
      this.SearchTxtBox.TextChanged += new System.EventHandler(this.SearchTxtBox_TextChanged);
      this.SearchTxtBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SearchTxtBox_KeyPress);
      // 
      // lblSearchDescription
      // 
      this.lblSearchDescription.AutoSize = true;
      this.lblSearchDescription.ForeColor = System.Drawing.Color.Red;
      this.lblSearchDescription.Location = new System.Drawing.Point(13, 42);
      this.lblSearchDescription.Name = "lblSearchDescription";
      this.lblSearchDescription.Size = new System.Drawing.Size(198, 26);
      this.lblSearchDescription.TabIndex = 10;
      this.lblSearchDescription.Text = "|| - ИЛИ, &&&& - И, пробел - разделитель,\r\n% - любые символы";
      this.lblSearchDescription.FontChanged += new System.EventHandler(this.lblSearchDescription_FontChanged);
      // 
      // SearchAnswRB
      // 
      this.SearchAnswRB.AutoSize = true;
      this.SearchAnswRB.Location = new System.Drawing.Point(148, 70);
      this.SearchAnswRB.Name = "SearchAnswRB";
      this.SearchAnswRB.Size = new System.Drawing.Size(73, 17);
      this.SearchAnswRB.TabIndex = 9;
      this.SearchAnswRB.Text = "в ответах";
      this.SearchAnswRB.UseVisualStyleBackColor = true;
      // 
      // SearchQuestRB
      // 
      this.SearchQuestRB.AutoSize = true;
      this.SearchQuestRB.Location = new System.Drawing.Point(59, 70);
      this.SearchQuestRB.Name = "SearchQuestRB";
      this.SearchQuestRB.Size = new System.Drawing.Size(92, 17);
      this.SearchQuestRB.TabIndex = 8;
      this.SearchQuestRB.Text = "в заголовках";
      this.SearchQuestRB.UseVisualStyleBackColor = true;
      // 
      // SearchAllRB
      // 
      this.SearchAllRB.AutoSize = true;
      this.SearchAllRB.Checked = true;
      this.SearchAllRB.Location = new System.Drawing.Point(4, 70);
      this.SearchAllRB.Name = "SearchAllRB";
      this.SearchAllRB.Size = new System.Drawing.Size(56, 17);
      this.SearchAllRB.TabIndex = 7;
      this.SearchAllRB.TabStop = true;
      this.SearchAllRB.Text = "Везде";
      this.SearchAllRB.UseVisualStyleBackColor = true;
      // 
      // SearchBtn
      // 
      this.SearchBtn.ButtonColorBottom = System.Drawing.Color.LightSkyBlue;
      this.SearchBtn.ButtonColorTop = System.Drawing.Color.LightCyan;
      this.SearchBtn.CornerRadius = 5;
      this.SearchBtn.ForeColor = System.Drawing.SystemColors.ControlText;
      this.SearchBtn.Location = new System.Drawing.Point(74, 93);
      this.SearchBtn.Name = "SearchBtn";
      this.SearchBtn.PulseSpeed = 0.3F;
      this.SearchBtn.PulseWidth = 1;
      this.SearchBtn.ShapeType = PulseButton.PulseButton.Shape.Rectangle;
      this.SearchBtn.Size = new System.Drawing.Size(77, 25);
      this.SearchBtn.TabIndex = 4;
      this.SearchBtn.Text = "Поиск";
      this.SearchBtn.UseVisualStyleBackColor = true;
      this.SearchBtn.Click += new System.EventHandler(this.SearchBtn_Click);
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(5, 6);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(61, 13);
      this.label1.TabIndex = 0;
      this.label1.Text = "Что ищем:";
      // 
      // FavoritesTP
      // 
      this.FavoritesTP.BackColor = System.Drawing.SystemColors.Control;
      this.FavoritesTP.BackColorBottom = System.Drawing.Color.Empty;
      this.FavoritesTP.Controls.Add(this.FavoriteDGV);
      this.FavoritesTP.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
      this.FavoritesTP.Location = new System.Drawing.Point(4, 22);
      this.FavoritesTP.Name = "FavoritesTP";
      this.FavoritesTP.Padding = new System.Windows.Forms.Padding(3);
      this.FavoritesTP.Size = new System.Drawing.Size(230, 376);
      this.FavoritesTP.TabIndex = 2;
      this.FavoritesTP.Text = "Избранное";
      // 
      // FavoriteDGV
      // 
      this.FavoriteDGV.AllowUserToAddRows = false;
      this.FavoriteDGV.AllowUserToResizeRows = false;
      dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
      dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
      dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
      dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
      dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
      dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
      this.FavoriteDGV.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
      this.FavoriteDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.FavoriteDGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Favorites_id_content,
            this.Favorites_question,
            this.FavoritesFavoriteDateColumn});
      dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
      dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
      dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
      dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
      dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
      dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
      this.FavoriteDGV.DefaultCellStyle = dataGridViewCellStyle5;
      this.FavoriteDGV.Dock = System.Windows.Forms.DockStyle.Fill;
      this.FavoriteDGV.EnableHeadersVisualStyles = false;
      this.FavoriteDGV.Location = new System.Drawing.Point(3, 3);
      this.FavoriteDGV.MultiSelect = false;
      this.FavoriteDGV.Name = "FavoriteDGV";
      this.FavoriteDGV.ReadOnly = true;
      dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
      dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
      dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
      dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
      dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
      dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
      this.FavoriteDGV.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
      this.FavoriteDGV.RowHeadersVisible = false;
      this.FavoriteDGV.Size = new System.Drawing.Size(224, 370);
      this.FavoriteDGV.TabIndex = 6;
      this.FavoriteDGV.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.FavoriteDGV_CellClick);
      // 
      // Favorites_id_content
      // 
      this.Favorites_id_content.DataPropertyName = "id_content";
      this.Favorites_id_content.HeaderText = "id_content";
      this.Favorites_id_content.Name = "Favorites_id_content";
      this.Favorites_id_content.ReadOnly = true;
      this.Favorites_id_content.Visible = false;
      // 
      // Favorites_question
      // 
      this.Favorites_question.DataPropertyName = "question";
      this.Favorites_question.HeaderText = "Результаты";
      this.Favorites_question.Name = "Favorites_question";
      this.Favorites_question.ReadOnly = true;
      // 
      // FavoritesFavoriteDateColumn
      // 
      this.FavoritesFavoriteDateColumn.DataPropertyName = "favorite_date";
      this.FavoritesFavoriteDateColumn.HeaderText = "favorite_date";
      this.FavoritesFavoriteDateColumn.Name = "FavoritesFavoriteDateColumn";
      this.FavoritesFavoriteDateColumn.ReadOnly = true;
      this.FavoritesFavoriteDateColumn.Visible = false;
      // 
      // JournalTP
      // 
      this.JournalTP.BackColor = System.Drawing.SystemColors.Control;
      this.JournalTP.BackColorBottom = System.Drawing.Color.Empty;
      this.JournalTP.Controls.Add(this.JournalDGV);
      this.JournalTP.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
      this.JournalTP.Location = new System.Drawing.Point(4, 22);
      this.JournalTP.Name = "JournalTP";
      this.JournalTP.Padding = new System.Windows.Forms.Padding(3);
      this.JournalTP.Size = new System.Drawing.Size(230, 376);
      this.JournalTP.TabIndex = 3;
      this.JournalTP.Text = "Журнал";
      // 
      // JournalDGV
      // 
      this.JournalDGV.AllowUserToAddRows = false;
      this.JournalDGV.AllowUserToResizeRows = false;
      dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
      dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
      dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
      dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
      dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
      dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
      this.JournalDGV.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
      this.JournalDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.JournalDGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.JournalIdColumn,
            this.JournalQuestionColumn,
            this.JournalFavoriteDateColumn});
      dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
      dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
      dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
      dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
      dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
      dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
      this.JournalDGV.DefaultCellStyle = dataGridViewCellStyle8;
      this.JournalDGV.Dock = System.Windows.Forms.DockStyle.Fill;
      this.JournalDGV.EnableHeadersVisualStyles = false;
      this.JournalDGV.Location = new System.Drawing.Point(3, 3);
      this.JournalDGV.MultiSelect = false;
      this.JournalDGV.Name = "JournalDGV";
      this.JournalDGV.ReadOnly = true;
      dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
      dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
      dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
      dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
      dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
      dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
      this.JournalDGV.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
      this.JournalDGV.RowHeadersVisible = false;
      this.JournalDGV.Size = new System.Drawing.Size(224, 370);
      this.JournalDGV.TabIndex = 7;
      this.JournalDGV.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.JournalDGV_CellClick);
      // 
      // panel4
      // 
      this.panel4.Controls.Add(this.splitContainer2);
      this.panel4.Controls.Add(this.status);
      this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
      this.panel4.Location = new System.Drawing.Point(0, 0);
      this.panel4.Name = "panel4";
      this.panel4.Size = new System.Drawing.Size(1238, 422);
      this.panel4.TabIndex = 11;
      // 
      // status
      // 
      this.status.AutoSize = false;
      this.status.BackColor = System.Drawing.SystemColors.Control;
      this.status.BackColorBottom = System.Drawing.Color.Empty;
      this.status.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
      this.status.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton1,
            this.CountQuestTitLbl,
            this.CountQuestLbl,
            this.CountAnswTitLbl,
            this.CountAnswLbl,
            this.CountCategoriesLbl,
            this.CountCategoriesVal,
            this.toolStripStatusLabel3,
            this.tsslStatus});
      this.status.Location = new System.Drawing.Point(0, 402);
      this.status.Name = "status";
      this.status.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
      this.status.Size = new System.Drawing.Size(1238, 20);
      this.status.TabIndex = 11;
      // 
      // toolStripDropDownButton1
      // 
      this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiSaveNodeSelect,
            this.tsmiReplaceFontControlToMenu,
            this.tsmiSmoothScrollingDocument,
            this.tsmiDesignSettings});
      this.toolStripDropDownButton1.Image = global::FAQ_Net.Properties.Resources.settings2;
      this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
      this.toolStripDropDownButton1.Size = new System.Drawing.Size(29, 18);
      this.toolStripDropDownButton1.Text = "toolStripDropDownButton1";
      // 
      // tsmiSaveNodeSelect
      // 
      this.tsmiSaveNodeSelect.Name = "tsmiSaveNodeSelect";
      this.tsmiSaveNodeSelect.Size = new System.Drawing.Size(425, 22);
      this.tsmiSaveNodeSelect.Text = "Запоминать переходы по разделам";
      this.tsmiSaveNodeSelect.Click += new System.EventHandler(this.tsmiSaveNodeSelect_Click);
      // 
      // tsmiReplaceFontControlToMenu
      // 
      this.tsmiReplaceFontControlToMenu.Name = "tsmiReplaceFontControlToMenu";
      this.tsmiReplaceFontControlToMenu.Size = new System.Drawing.Size(425, 22);
      this.tsmiReplaceFontControlToMenu.Text = "Переместить компоненты выбора шрифта и масштаба в меню";
      this.tsmiReplaceFontControlToMenu.Click += new System.EventHandler(this.tsmiReplaceFontControlToMenu_Click);
      // 
      // tsmiSmoothScrollingDocument
      // 
      this.tsmiSmoothScrollingDocument.Checked = true;
      this.tsmiSmoothScrollingDocument.CheckState = System.Windows.Forms.CheckState.Checked;
      this.tsmiSmoothScrollingDocument.Name = "tsmiSmoothScrollingDocument";
      this.tsmiSmoothScrollingDocument.Size = new System.Drawing.Size(425, 22);
      this.tsmiSmoothScrollingDocument.Text = "Плавный скроллинг документа";
      this.tsmiSmoothScrollingDocument.Click += new System.EventHandler(this.tsmiSmoothScrollingDocument_Click);
      // 
      // tsmiDesignSettings
      // 
      this.tsmiDesignSettings.Image = global::FAQ_Net.Properties.Resources.three_color_rectangle;
      this.tsmiDesignSettings.Name = "tsmiDesignSettings";
      this.tsmiDesignSettings.Size = new System.Drawing.Size(425, 22);
      this.tsmiDesignSettings.Text = "Настройки внешнего вида";
      this.tsmiDesignSettings.Click += new System.EventHandler(this.tsmiDesignSettings_Click);
      // 
      // CountQuestTitLbl
      // 
      this.CountQuestTitLbl.Name = "CountQuestTitLbl";
      this.CountQuestTitLbl.Size = new System.Drawing.Size(97, 15);
      this.CountQuestTitLbl.Text = "Всего вопросов:";
      // 
      // CountQuestLbl
      // 
      this.CountQuestLbl.BackColor = System.Drawing.SystemColors.Control;
      this.CountQuestLbl.BorderStyle = System.Windows.Forms.Border3DStyle.Bump;
      this.CountQuestLbl.Name = "CountQuestLbl";
      this.CountQuestLbl.Size = new System.Drawing.Size(13, 15);
      this.CountQuestLbl.Text = "0";
      // 
      // CountAnswTitLbl
      // 
      this.CountAnswTitLbl.Name = "CountAnswTitLbl";
      this.CountAnswTitLbl.Size = new System.Drawing.Size(92, 15);
      this.CountAnswTitLbl.Text = "  Всего ответов:";
      // 
      // CountAnswLbl
      // 
      this.CountAnswLbl.BackColor = System.Drawing.SystemColors.Control;
      this.CountAnswLbl.BorderStyle = System.Windows.Forms.Border3DStyle.Bump;
      this.CountAnswLbl.Name = "CountAnswLbl";
      this.CountAnswLbl.Size = new System.Drawing.Size(13, 15);
      this.CountAnswLbl.Text = "0";
      // 
      // CountCategoriesLbl
      // 
      this.CountCategoriesLbl.Name = "CountCategoriesLbl";
      this.CountCategoriesLbl.Size = new System.Drawing.Size(108, 15);
      this.CountCategoriesLbl.Text = "  Кол-во разделов:";
      this.CountCategoriesLbl.Visible = false;
      // 
      // CountCategoriesVal
      // 
      this.CountCategoriesVal.Name = "CountCategoriesVal";
      this.CountCategoriesVal.Size = new System.Drawing.Size(13, 15);
      this.CountCategoriesVal.Text = "0";
      this.CountCategoriesVal.Visible = false;
      // 
      // toolStripStatusLabel3
      // 
      this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
      this.toolStripStatusLabel3.Size = new System.Drawing.Size(217, 15);
      this.toolStripStatusLabel3.Text = "  Фоновый статус выполнения задачи:";
      // 
      // tsslStatus
      // 
      this.tsslStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
      this.tsslStatus.Name = "tsslStatus";
      this.tsslStatus.Size = new System.Drawing.Size(113, 15);
      this.tsslStatus.Text = "Нет фоновых задач";
      // 
      // openFile
      // 
      this.openFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.openFile.Image = global::FAQ_Net.Properties.Resources.OpenSml;
      this.openFile.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
      this.openFile.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.openFile.Margin = new System.Windows.Forms.Padding(0, 2, 0, 2);
      this.openFile.Name = "openFile";
      this.openFile.Size = new System.Drawing.Size(23, 24);
      this.openFile.ToolTipText = "Открыть";
      this.openFile.Click += new System.EventHandler(this.Tools_Click);
      // 
      // JournalIdColumn
      // 
      this.JournalIdColumn.DataPropertyName = "id_content";
      this.JournalIdColumn.HeaderText = "id_content";
      this.JournalIdColumn.Name = "JournalIdColumn";
      this.JournalIdColumn.ReadOnly = true;
      this.JournalIdColumn.Visible = false;
      // 
      // JournalQuestionColumn
      // 
      this.JournalQuestionColumn.DataPropertyName = "question";
      this.JournalQuestionColumn.HeaderText = "Результаты";
      this.JournalQuestionColumn.Name = "JournalQuestionColumn";
      this.JournalQuestionColumn.ReadOnly = true;
      // 
      // JournalFavoriteDateColumn
      // 
      this.JournalFavoriteDateColumn.DataPropertyName = "favorite_date";
      this.JournalFavoriteDateColumn.HeaderText = "favorite_date";
      this.JournalFavoriteDateColumn.Name = "JournalFavoriteDateColumn";
      this.JournalFavoriteDateColumn.ReadOnly = true;
      this.JournalFavoriteDateColumn.Visible = false;
      // 
      // MainForm
      // 
      this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(60)))), ((int)(((byte)(150)))));
      this.ClientSize = new System.Drawing.Size(1238, 422);
      this.Controls.Add(this.panel4);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.MinimumSize = new System.Drawing.Size(200, 400);
      this.Name = "MainForm";
      this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
      this.Text = "FAQ.Net v2.0";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
      this.Load += new System.EventHandler(this.MainForm_Load);
      this.Resize += new System.EventHandler(this.MainForm_Resize);
      this.CategoriesContextMenu.ResumeLayout(false);
      this.splitContainer1.Panel1.ResumeLayout(false);
      this.splitContainer1.Panel1.PerformLayout();
      this.splitContainer1.Panel2.ResumeLayout(false);
      this.splitContainer1.Panel2.PerformLayout();
      this.splitContainer1.ResumeLayout(false);
      this.statusStrip3.ResumeLayout(false);
      this.statusStrip3.PerformLayout();
      this.statusStrip1.ResumeLayout(false);
      this.statusStrip1.PerformLayout();
      this.toolsTop.ResumeLayout(false);
      this.toolsTop.PerformLayout();
      this.colors.ResumeLayout(false);
      this.menuTop.ResumeLayout(false);
      this.menuTop.PerformLayout();
      this.QuestionsCMS.ResumeLayout(false);
      this.richMenu.ResumeLayout(false);
      this.splitContainer2.Panel1.ResumeLayout(false);
      this.splitContainer2.ResumeLayout(false);
      this.panel3.ResumeLayout(false);
      this.panel3.PerformLayout();
      this.tableLayoutPanel1.ResumeLayout(false);
      this.TabControl.ResumeLayout(false);
      this.CategoriesTP.ResumeLayout(false);
      this.CategoriesTP.PerformLayout();
      this.statusStrip2.ResumeLayout(false);
      this.statusStrip2.PerformLayout();
      this.SearchPanel.ResumeLayout(false);
      this.toolStrip1.ResumeLayout(false);
      this.toolStrip1.PerformLayout();
      this.SearchTP.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.DGVResultSearch)).EndInit();
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      this.FavoritesTP.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.FavoriteDGV)).EndInit();
      this.JournalTP.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.JournalDGV)).EndInit();
      this.panel4.ResumeLayout(false);
      this.status.ResumeLayout(false);
      this.status.PerformLayout();
      this.ResumeLayout(false);

        }

        #endregion

        private GradientControls.MenuStripZ menuTop;
        private ToolStripMenuItem file;
        private ToolStripMenuItem edit;
        private GradientControls.ToolStripGradient toolsTop;
        private ToolStripButton saveFile;
        private ToolStripSeparator s0;
        private ToolStripMenuItem save;
        private ToolStripSeparator sep1;
        private ToolStripButton undoText;
        private ToolStripButton redoText;
        private ToolStripButton openFile;
        private ToolStripMenuItem open;
        private ToolStripSeparator sep2;
        private ToolStripComboBox selFont;
        private ToolStripButton bold;
        private ToolStripButton italic;
        private ToolStripSeparator sep3;
        private ToolStripButton under;
        private ToolStripComboBox size;
        private ComboBox fonts;
        private ToolStripSeparator s1;
        private ToolStripMenuItem find;
        private ToolStripMenuItem pageSet;
        private ToolStripMenuItem printPrev;
        private ToolStripMenuItem print;
        private ToolStripButton findText;
        private ToolStripMenuItem undo;
        private ToolStripMenuItem redo;
        private ToolStripSeparator s4;
        private ToolStripButton alignLeft;
        private ToolStripButton alignCenter;
        private ToolStripButton alignRight;
        private ContextMenuStrip colors;
        private ToolStripMenuItem black;
        private ToolStripMenuItem maroon;
        private ToolStripMenuItem green;
        private ToolStripMenuItem olive;
        private ToolStripMenuItem navy;
        private ToolStripMenuItem purple;
        private ToolStripMenuItem teal;
        private ToolStripMenuItem gray;
        private ToolStripMenuItem silver;
        private ToolStripMenuItem red;
        private ToolStripMenuItem lime;
        private ToolStripMenuItem yellow;
        private ToolStripMenuItem blue;
        private ToolStripSplitButton selectColor;
        private ToolStripMenuItem saveAs;
        private ContextMenuStrip richMenu;
        private ToolStripMenuItem cutRichText;
        private ToolStripMenuItem copyRichText;
        private ToolStripMenuItem pasteRichText;
        private ToolStripMenuItem cut;
        private ToolStripMenuItem copy;
        private ToolStripMenuItem paste;
        private ToolStripSeparator s5;
        private ToolStripMenuItem fontRichText;
        private ToolStripMenuItem printRichText;
        private ToolStripSplitButton lineSpacing;
        private ToolStripMenuItem lineSpace1;
        private ToolStripMenuItem lineSpace1pt5;
        private ToolStripMenuItem lineSpace2;
        private ToolStripButton copyText;
        private ToolStripButton pasteText;
        private ToolStripButton cutText;
        private ToolStripSeparator sep4;
        private ToolStripSeparator sep5;
        private ToolStripSeparator sep6;
        private ToolStripSplitButton highLight;
        private ToolStripMenuItem selectAll;
        private ToolStripSeparator s6;
        private ToolStripSeparator sep7;
        private ToolStripSeparator sep8;
        private ToolStripComboBox zoom;
        private ToolStripMenuItem white;
        private ToolStripSeparator sep_0;
        private ToolStripSeparator sep_1;
        private ToolStripMenuItem replace;
        private ToolStripMenuItem view;
        private ToolStripMenuItem formatToolStripMenuItem;
        private ToolStripMenuItem font;
        private ToolStripMenuItem superscript;
        private ToolStripMenuItem subscript;
        private ToolStripMenuItem toolStripMenuItem2;
        private ToolStripMenuItem toolStripMenuItem3;
        private ToolStripMenuItem toolStripMenuItem4;
        private ToolStripMenuItem toolStripMenuItem5;
        private ToolStripMenuItem toolStripMenuItem6;
        private ToolStripMenuItem toolStripMenuItem7;
        private ToolStripMenuItem toolStripMenuItem8;
        private ToolStripMenuItem toolStripMenuItem9;
        private ToolStripMenuItem toolStripMenuItem11;
        private ToolStripMenuItem toolStripMenuItem10;
        private ToolStripMenuItem toolStripMenuItem12;
        private ToolStripMenuItem toolStripMenuItem13;
        private ToolStripMenuItem toolStripMenuItem14;
        private ToolStripMenuItem toolStripMenuItem15;
        private ToolStripMenuItem toolStripMenuItem16;
        private ToolStripMenuItem toolStripMenuItem17;
        private ToolStripMenuItem toolStripMenuItem18;
        private ToolStripMenuItem toolStripMenuItem19;
        private ToolStripMenuItem noSuperscript;
        private ToolStripMenuItem noSubscript;
        private ToolStripMenuItem subscriptRichText;
        private ToolStripMenuItem superscriptRichText;
        private ToolStripMenuItem normalOffset;
        private ToolStripSeparator sep_2;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripSeparator toolStripSeparator2;
        private ToolTip toolTip;
        private GradientControls.TabControlGradient TabControl;
        private GradientControls.TabPageGradient CategoriesTP;
        private GradientControls.ToolStripGradient toolStrip1;
        private ToolStripButton CreateQuestionTSB;
        private ToolStripButton CreateCategoryTSB;
        private ToolStripButton CreateSubcategoryTSB;
        private ToolStripButton RefreshTSB;
        private GradientControls.TabPageGradient SearchTP;
        private GradientControls.TabPageGradient FavoritesTP;
        private GradientControls.TabPageGradient JournalTP;
        private ToolStripButton CollapseAllTSB;
        private ToolStripButton ExpandAllNodesTSB;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripSeparator toolStripSeparator4;
        private SplitContainer splitContainer1;
        private ContextMenuStrip QuestionsCMS;
        private ToolStripMenuItem ShowAnswerTSMI;
        private ToolStripMenuItem EditQuestionTSMI;
        private ToolStripMenuItem DeleteQuestionTSMI;
        private TextBox SearchTxtBox;
        private Label label1;
        private Panel panel1;
        private PulseButton.PulseButton SearchBtn;
        public DataGridView DGVResultSearch;
        private ToolStripButton AddInFavoritesTSB;
        private DataGridView FavoriteDGV;
        private DataGridView JournalDGV;
        private ToolStripStatusLabel CountSubcategoryLbl;
        private ToolStripStatusLabel CountSubcategoryVal;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private ToolStripStatusLabel toolStripStatusLabel2;
        private ToolStripStatusLabel CountQuestionsVal;
        private ContextMenuStrip CategoriesContextMenu;
        private ToolStripMenuItem CreateQuestionTSMI;
        private ToolStripMenuItem CreateCategoryTSMI;
        private ToolStripMenuItem CreateSubcategoryTSMI;
        private ToolStripMenuItem LastQuestionsTSMI;
        private ToolStripMenuItem RefreshTSMI;
        private ToolStripSeparator фToolStripMenuItem;
        private ToolStripMenuItem SearchTSMI;
        private ToolStripMenuItem ChangeNameCategoryTSMI;
        private TreeView TV1;
        private RadioButton SearchAnswRB;
        private RadioButton SearchQuestRB;
        private RadioButton SearchAllRB;
        private ToolStripButton strikeout;
        private ToolStripMenuItem CreateBackupTSMI;
        private DataGridViewTextBoxColumn id_content_search;
        private DataGridViewTextBoxColumn QuestionSearchColumn;
        private DataGridViewTextBoxColumn SearchFavoriteDateColumn;
        private DataGridViewTextBoxColumn Favorites_id_content;
        private DataGridViewTextBoxColumn Favorites_question;
        private DataGridViewTextBoxColumn FavoritesFavoriteDateColumn;
        private ToolStripMenuItem кодировкаToolStripMenuItem;
        private ToolStripMenuItem ASCII_TSMI;
        private Label lblSearchDescription;
        private ToolStripMenuItem orange;
        private ToolStripMenuItem тестToolStripMenuItem;
        private PulseButton.PulseButton BackBtn;
        private ToolStripSeparator toolStripSeparator5;
        private ToolStripMenuItem SortAscTSMI;
        private ToolStripMenuItem SortDescTSMI;
        private ToolStripMenuItem AddQuestionTSMI;
        private ToolStripMenuItem DelRazdelMainTSMI;
        private ToolStripMenuItem DelRazdelTSMI;
        private ToolStripMenuItem DelRazdelWithReplaceTSMI;
        private ToolStripMenuItem magenta;
        private ToolStripSeparator toolStripSeparator6;
        private ToolStripMenuItem tsmiGridView;
        private ToolStripMenuItem tsmiListView;
    private ToolStripDropDownButton tsddbInsertTable;
    private ToolStripMenuItem tsmiTable;
    private ToolStripMenuItem tsmiAddTable;
    private ToolStripMenuItem справкаToolStripMenuItem;
    private ToolStripMenuItem tsmiAboutProgram;
    private ToolStripMenuItem tsmiDictionary;
    private SplitContainer splitContainer2;
    private PulseButton.PulseButton btnSelectQuestion;
    private ToolStripStatusLabel ID_ContentTSSL;
    private PulseButton.PulseButton btnNextQuestion;
    private Panel SearchPanel;
    private PulseButton.PulseButton SearchCategoryBtn;
    private ComboBox SearchCategoryCmbBox;
    private GradientControls.StatusStripGradient statusStrip2;
    private GradientControls.StatusStripGradient statusStrip1;
    private GradientControls.StatusStripGradient statusStrip3;
    private GradientControls.PanelGradient panel3;
    private Splitter splitter2;
    private TableLayoutPanel tableLayoutPanel1;
    private Panel panel4;
    private GradientControls.StatusStripGradient status;
    private ToolStripDropDownButton toolStripDropDownButton1;
    private ToolStripMenuItem tsmiSaveNodeSelect;
    private ToolStripMenuItem tsmiDesignSettings;
    private ToolStripStatusLabel CountQuestTitLbl;
    private ToolStripStatusLabel CountQuestLbl;
    private ToolStripStatusLabel CountAnswTitLbl;
    private ToolStripStatusLabel CountAnswLbl;
    private ToolStripStatusLabel CountCategoriesLbl;
    private ToolStripStatusLabel CountCategoriesVal;
    private ToolStripStatusLabel toolStripStatusLabel3;
    private ToolStripStatusLabel tsslStatus;
    private ToolStripButton tsbAddImage;
    private Splitter splitter1;
    private ToolStripStatusLabel tsslCountCharsHeader;
    private ToolStripStatusLabel tsslCountCharsValue;
    private ToolStripSeparator sep0;
    private ToolStripButton printText;
    private ToolStripButton printPrevText;
    private ToolStripMenuItem tsmiReplaceFontControlToMenu;
    private Label SelectedPathLbl;
    private PulseButton.PulseButton searchDown;
    private PulseButton.PulseButton searchUp;
    private ToolStripMenuItem tsmiSmoothScrollingDocument;
    private GradientControls.ToolStripSplitCheckButton bullet;
    private ToolStripMenuItem tsmiNormalBullet;
    private ToolStripMenuItem tsmiNumberBullet;
    private DataGridViewTextBoxColumn JournalIdColumn;
    private DataGridViewTextBoxColumn JournalQuestionColumn;
    private DataGridViewTextBoxColumn JournalFavoriteDateColumn;
    private ToolStripButton alignJustify;
  }

}
