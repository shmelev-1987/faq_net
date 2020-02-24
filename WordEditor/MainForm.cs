// Freeware. Written by Matt Fomich.
// matt.fomich@gmail.com

using System;
using System.Drawing;
using System.Windows.Forms;
//using System.Drawing.Printing;
using System.Text;
using System.IO;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;

namespace FAQ_Net
{
    public partial class MainForm : Form
    {
        private IViewQuestion _questionListControl;
        QuestionDgvControl _questionDgvControl;
        QuestionListViewControl _questionListViewControl;
        AppSettingsForm _appSettingForm;
        private RichTextBoxCustom richText;
        public static SharedLibrary.SettingsXml _settingsXml;
        private Format format;
        private System.Drawing.Printing.PageSettings pageSettings;
        private PrintRichText printRtf;
        private TwipsConverter tc;
        private const byte ONE_PIXEL = 1;
        private const byte NUMBER_POS = 8;
        private const byte HALF_POINT = 4;
        private const int PORTRAIT_RIGHT_LIMIT = 823;
        //private int riValue;
        //private int rightIndentVal;
        private int oldRightMarginX;
        //private int rightIndentOffset = 124;
        private int rightMarginMouseX;
        private Font selFnt;
        private ColorTable highlightColor;
        private HorizontalAlignment selAlign;
        //private bool saved = true;
        private string appFolder = @"\Word_Editor\";
        private string currentFile = "";
        //private string[] recentFiles;
        private bool zoomChanging;
        private int posLeft;
        private int posTop;
        private int formWidth;
        private int formHeight;
        private Color selectedColor = Color.Black;
        private Brush br;
        private delegate void AddFonts();
        private AddFonts delgAddFonts;
        private string[] ffNames;
        private SizeF fontSize;
        private string SelectedId_Razdel = null;
        private Timer Timer1 = new Timer();
        //TreeView TV1 = new TreeView();
        TreeNode StartNode = new TreeNode();    //����� ��� ���������� ��������� �����.
        bool DGVQuestionsDrag = false;          //������� �������� ������� �� DGVQuestions
        FindForm fnd;
        bool lastOrderByDesc = false;
    tools.TablePropertyUserControl _tablePropertyUserControl;
    /// <summary>
    /// ������� ������ ����������� ����������
    /// </summary>
    public static bool RestartApplicationCanceled = false;
    TooltipUserControl _richTextBoxToolTip;
    /// <summary>
    /// ��������� �������������� ����������� ���������
    /// </summary>
    DictionaryEditor _dictionaryEditor;
    public static System.Text.RegularExpressions.Regex IdContentUrlRegEx_v1 = new System.Text.RegularExpressions.Regex(@"^http://\d+$");
    public static System.Text.RegularExpressions.Regex IdContentUrlRegEx_v2 = new System.Text.RegularExpressions.Regex(@"^\\\\\d+$");
    /// <summary>
    /// ������� �������� �������� ���� ���������� ��� ������ �������
    /// </summary>
    public bool ModalDialogForSelectQuestion = false;
    private int _currentQuestionId = 0;
    private IntellisenseUserControl _intellisenseUserControl;

    #region ������������ / Constructors
    public MainForm()
    {
      Init();
    }

    public MainForm(bool modalDialogForSelectQuestion)
    {
      ModalDialogForSelectQuestion = modalDialogForSelectQuestion;
      Init();
    }

    public void Init()
    {
      // this.ruler = new TopRuler();
      InitializeComponent();
      splitContainer2.Panel2Collapsed = true;
      this.richText = new FAQ_Net.RichTextBoxCustom();
      this.splitContainer1.Panel2.Controls.Add(this.richText);
      this.richText.BringToFront();
      // ������������� richText
      this.richText.BackColor = Color.DarkGray;
      this.richText.AcceptsTab = true;
      this.richText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.richText.ContextMenuStrip = this.richMenu;
      this.richText.Dock = System.Windows.Forms.DockStyle.Fill;
      this.richText.Font = new System.Drawing.Font("Times New Roman", 12F);
      this.richText.HideSelection = false;
      this.richText.Location = new System.Drawing.Point(0, 50);
      this.richText.Name = "richText";
      this.richText.RightMargin = 700;
      this.richText.ShowSelectionMargin = true;
      this.richText.Size = new System.Drawing.Size(890, 76);
      this.richText.TabIndex = 12;
      this.richText.Text = string.Empty;
      this.richText.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.RichText_LinkClicked);
      this.richText.SelectionChanged += new System.EventHandler(this.RichText_SelectionChanged);
      this.richText.TextChanged += new System.EventHandler(this.RichText_TextChanged);
      this.richText.Enter += new System.EventHandler(this.richText_Enter);
      this.richText.KeyDown += richText_KeyDown;
      this.richText.MouseDown += richText_MouseDown;
      Constants.RtfToolStripName = this.toolsTop.Name;

      if (ModalDialogForSelectQuestion)
      {
        // �������� ��� �����, ����� ��������� ����� �� ������ ���������� �� ���������
        this.Name = "MainFormModal";
        btnSelectQuestion.FlatStyle = FlatStyle.Standard;
        btnSelectQuestion.Enabled = false;
      }

      // ���� �������� ��������� � ��������, ������ ����������� ����������
      string xmlFileNameSettings = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\" +
                           Application.ProductName + ".xml";
      _settingsXml = new SharedLibrary.SettingsXml(xmlFileNameSettings);
      _settingsXml.LoadFormPosition(this);
      _settingsXml.SaveFormPosition(this);

      // ��������� ���������� �������
      var dropDown = new tools.ToolStripTableSizeSelector();
      dropDown.Opening += DropDown_Opening;
      dropDown.Selector.TableSizeSelected += Selector_TableSizeSelected;
      tsddbInsertTable.DropDown = dropDown;
      var tsmiInsertTable = new ToolStripMenuItem
      {
        Name = "tsmiInsertTable",
        Size = new Size(152, 22),
        Text = "������� ������� �������",
        Tag = "InsertTable"
      };
      tsmiInsertTable.Click += tsmiInsertTable_Click;
      tsddbInsertTable.DropDownItems.Add(tsmiInsertTable);

      // ��������� ��� �������� ������ � ������������ �����������
      _tablePropertyUserControl = new tools.TablePropertyUserControl();
      _tablePropertyUserControl.OnCreateTableClickButton += Selector_TableSizeSelected;

      JournalDGV.Columns[JournalQuestionColumn.Name].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
      JournalDGV.Columns[JournalQuestionColumn.Name].FillWeight = 100;

      FavoriteDGV.Columns[Favorites_question.Name].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
      FavoriteDGV.Columns[Favorites_question.Name].FillWeight = 100;

      DGVResultSearch.Columns[QuestionSearchColumn.Name].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
      DGVResultSearch.Columns[QuestionSearchColumn.Name].FillWeight = 100;

      //richText.DetectUrls = false;
      //richText.MouseMove += richText_MouseMove;
      // Set Rich Textbox and right margin line.
      //ruler1.InitializeObjects(this.richText, this.rightMarginLine);
    }

    #endregion ������������ / Constructors

    #region �������� / Properties

    #region �������� ��������� ������

    public Image CreateQuestionImage
    {
      set
      {
        if (value == null)
          CreateQuestionTSB.Image = global::FAQ_Net.Properties.Resources.NewSml;
        else
          CreateQuestionTSB.Image = value;
        CreateQuestionTSB.ImageScaling = ToolStripItemImageScaling.None;
      }
    }

    public Image CreateCaregoryImage
    {
      set
      {
        if (value == null)
          CreateCategoryTSB.Image = global::FAQ_Net.Properties.Resources.Folder;
        else
          CreateCategoryTSB.Image = value;
        CreateCategoryTSB.ImageScaling = ToolStripItemImageScaling.None;
      }
    }

    public Image CreateSubcategoryImage
    {
      set
      {
        if (value == null)
          CreateSubcategoryTSB.Image = global::FAQ_Net.Properties.Resources.NewFolder2;
        else
          CreateSubcategoryTSB.Image = value;
        CreateSubcategoryTSB.ImageScaling = ToolStripItemImageScaling.None;
      }
    }

    public Image RefreshCategoryImage
    {
      set
      {
        if (value == null)
          RefreshTSB.Image = global::FAQ_Net.Properties.Resources.Refresh;
        else
          RefreshTSB.Image = value;
        RefreshTSB.ImageScaling = ToolStripItemImageScaling.None;
      }
    }

    public Image CollapseAllImage
    {
      set
      {
        if (value == null)
          CollapseAllTSB.Image = global::FAQ_Net.Properties.Resources.collapse;
        else
          CollapseAllTSB.Image = value;
        CollapseAllTSB.ImageScaling = ToolStripItemImageScaling.None;
      }
    }

    public Image ExpandAllImage
    {
      set
      {
        if (value == null)
          ExpandAllNodesTSB.Image = global::FAQ_Net.Properties.Resources.expand;
        else
          ExpandAllNodesTSB.Image = value;
        ExpandAllNodesTSB.ImageScaling = ToolStripItemImageScaling.None;
      }
    }

    /// <summary>
    /// ������ ������ "�������"
    /// </summary>
    public Image ImageOpenFile
    {
      set
      {
        if (value == null)
          openFile.Image = global::FAQ_Net.Properties.Resources.OpenSml;
        else
          openFile.Image = value;
        openFile.ImageScaling = ToolStripItemImageScaling.None;
      }
    }

    /// <summary>
    /// ������ ������ "���������"
    /// </summary>
    public Image ImageSaveFile
    {
      set
      {
        if (value == null)
          saveFile.Image = global::FAQ_Net.Properties.Resources.SaveSml;
        else
          saveFile.Image = value;
        saveFile.ImageScaling = ToolStripItemImageScaling.None;
      }
    }

    /// <summary>
    /// ������ ������ "������"
    /// </summary>
    public Image ImagePrint
    {
      set
      {
        Image result = value;
        if (value == null)
          result = global::FAQ_Net.Properties.Resources.PrintSml;
        print.Image = result;
        printText.Image = result;
        print.ImageScaling = ToolStripItemImageScaling.None;
        printText.ImageScaling = ToolStripItemImageScaling.None;
      }
    }

    /// <summary>
    /// ������ ������ "��������������� ��������"
    /// </summary>
    public Image ImagePrintPrev
    {
      set
      {
        Image result = value;
        if (value == null)
          result = global::FAQ_Net.Properties.Resources.PrevSml;
        printPrev.Image = result;
        printPrevText.Image = result;
        printPrev.ImageScaling = ToolStripItemImageScaling.None;
        printPrevText.ImageScaling = ToolStripItemImageScaling.None;
      }
    }

    /// <summary>
    /// ������ ������ "�����"
    /// </summary>
    public Image ImageFind
    {
      set
      {
        Image result = value;
        if (value == null)
          result = global::FAQ_Net.Properties.Resources.binoculars;
        find.Image = result;
        findText.Image = result;
        find.ImageScaling = ToolStripItemImageScaling.None;
        findText.ImageScaling = ToolStripItemImageScaling.None;
      }
    }

    /// <summary>
    /// ������ ������ "��������"
    /// </summary>
    public Image ImageCut
    {
      set
      {
        Image result = value;
        if (value == null)
          result = global::FAQ_Net.Properties.Resources.Cut;
        cut.Image = result;
        cutText.Image = result;
        cut.ImageScaling = ToolStripItemImageScaling.None;
        cutText.ImageScaling = ToolStripItemImageScaling.None;
      }
    }

    /// <summary>
    /// ������ ������ "����������"
    /// </summary>
    public Image ImageCopy
    {
      set
      {
        Image result = value;
        if (value == null)
          result = global::FAQ_Net.Properties.Resources.copy_16x16;
        copy.Image = result;
        copyText.Image = result;
        copy.ImageScaling = ToolStripItemImageScaling.None;
        copyText.ImageScaling = ToolStripItemImageScaling.None;
      }
    }

    /// <summary>
    /// ������ ������ "��������"
    /// </summary>
    public Image ImagePaste
    {
      set
      {
        Image result = value;
        if (value == null)
          result = global::FAQ_Net.Properties.Resources.Paste;
        paste.Image = result;
        pasteText.Image = result;
        paste.ImageScaling = ToolStripItemImageScaling.None;
        pasteText.ImageScaling = ToolStripItemImageScaling.None;
      }
    }

    /// <summary>
    /// ������ ������ "�����"
    /// </summary>
    public Image ImageUndo
    {
      set
      {
        Image result = value;
        if (value == null)
          result = global::FAQ_Net.Properties.Resources.UndoSml;
        undo.Image = result;
        undoText.Image = result;
        undo.ImageScaling = ToolStripItemImageScaling.None;
        undoText.ImageScaling = ToolStripItemImageScaling.None;
      }
    }

    /// <summary>
    /// ������ ������ "������"
    /// </summary>
    public Image ImageRedo
    {
      set
      {
        Image result = value;
        if (value == null)
          result = global::FAQ_Net.Properties.Resources.RedoSml;
        redo.Image = result;
        redoText.Image = result;
        redo.ImageScaling = ToolStripItemImageScaling.None;
        redoText.ImageScaling = ToolStripItemImageScaling.None;
      }
    }

    /// <summary>
    /// ������ ������ "������"
    /// </summary>
    public Image ImageBold
    {
      set
      {
        if (value == null)
          bold.Image = global::FAQ_Net.Properties.Resources.BoldSml;
        else
          bold.Image = value;
        bold.ImageScaling = ToolStripItemImageScaling.None;
      }
    }

    /// <summary>
    /// ������ ������ "������"
    /// </summary>
    public Image ImageItalic
    {
      set
      {
        if (value == null)
          italic.Image = global::FAQ_Net.Properties.Resources.ItalSml;
        else
          italic.Image = value;
        italic.ImageScaling = ToolStripItemImageScaling.None;
      }
    }

    /// <summary>
    /// ������ ������ "������������"
    /// </summary>
    public Image ImageUnder
    {
      set
      {
        if (value == null)
          under.Image = global::FAQ_Net.Properties.Resources.UnderSml;
        else
          under.Image = value;
        under.ImageScaling = ToolStripItemImageScaling.None;
      }
    }

    /// <summary>
    /// ������ ������ "�����������"
    /// </summary>
    public Image ImageStrikeout
    {
      set
      {
        if (value == null)
          strikeout.Image = global::FAQ_Net.Properties.Resources.strikeout;
        else
          strikeout.Image = value;
        strikeout.ImageScaling = ToolStripItemImageScaling.None;
      }
    }

    /// <summary>
    /// ������ ������ "��������� ����� �� ������ ����"
    /// </summary>
    public Image ImageAlignLeft
    {
      set
      {
        if (value == null)
          alignLeft.Image = global::FAQ_Net.Properties.Resources.LeftSml;
        else
          alignLeft.Image = value;
        alignLeft.ImageScaling = ToolStripItemImageScaling.None;
      }
    }

    /// <summary>
    /// ������ ������ "��������� ����� �� ������"
    /// </summary>
    public Image ImageAlignCenter
    {
      set
      {
        if (value == null)
          alignCenter.Image = global::FAQ_Net.Properties.Resources.CtrSml;
        else
          alignCenter.Image = value;
        alignCenter.ImageScaling = ToolStripItemImageScaling.None;
      }
    }

    /// <summary>
    /// ������ ������ "��������� ����� �� ������� ����"
    /// </summary>
    public Image ImageAlignRight
    {
      set
      {
        if (value == null)
          alignRight.Image = global::FAQ_Net.Properties.Resources.RightSml;
        else
          alignRight.Image = value;
        alignRight.ImageScaling = ToolStripItemImageScaling.None;
      }
    }

    ///// <summary>
    ///// ������ ������ "��������� ����� �� ������"
    ///// </summary>
    //public Image ImageAlignJustify
    //{
    //  set
    //  {
    //    if (value == null)
    //      alignJustify.Image = global::FAQ_Net.Properties.Resources.JustifySml;
    //    else
    //      alignJustify.Image = value;
    //    alignJustify.ImageScaling = ToolStripItemImageScaling.None;
    //  }
    //}

    /// <summary>
    /// ������ ������ "����������� ��������"
    /// </summary>
    public Image ImageLineSpacing
    {
      set
      {
        if (value == null)
          lineSpacing.Image = global::FAQ_Net.Properties.Resources.LineSpSml;
        else
          lineSpacing.Image = value;
        lineSpacing.ImageScaling = ToolStripItemImageScaling.None;
      }
    }

    /// <summary>
    /// ������ ������ "�������"
    /// </summary>
    public Image ImageBullet
    {
      set
      {
        if (value == null)
          bullet.Image = global::FAQ_Net.Properties.Resources.Bullets;
        else
          bullet.Image = value;
        bullet.ImageScaling = ToolStripItemImageScaling.None;
      }
    }

    /// <summary>
    /// ������ ������ "���� ������"
    /// </summary>
    public Image ImageSelectColor
    {
      set
      {
        //if (value == null)
        //  selectColor.Image = global::FAQ_Net.Properties.Resources.HLiteSml;
        //else
        //  selectColor.Image = value;

        Image result = value;
        if (value == null)
          result = global::FAQ_Net.Properties.Resources.ColorSml;
        selectColor.Image = result;
        selectColor.ImageScaling = ToolStripItemImageScaling.None;
        //selectColor.Width = 32;
        //selectColor.Height = 32;
        //selectColor.ImageScaling = ToolStripItemImageScaling.None;
      }
    }

    /// <summary>
    /// ������ ������ "���� ��������� ������"
    /// </summary>
    public Image ImageHighLight
    {
      set
      {
        if (value == null)
          highLight.Image = global::FAQ_Net.Properties.Resources.HLiteSml;
        else
          highLight.Image = value;
        highLight.ImageScaling = ToolStripItemImageScaling.None;
      }
    }

    /// <summary>
    /// ������ ������ "������� �������"
    /// </summary>
    public Image ImageInsertTable
    {
      set
      {
        if (value == null)
          tsddbInsertTable.Image = global::FAQ_Net.Properties.Resources.InsertTable;
        else
          tsddbInsertTable.Image = value;
        tsddbInsertTable.ImageScaling = ToolStripItemImageScaling.None;
      }
    }

    /// <summary>
    /// ������ ������ "�������� �����������"
    /// </summary>
    public Image ImageAddImage
    {
      set
      {
        if (value == null)
        {
          System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
          tsbAddImage.Image = ((System.Drawing.Image)(resources.GetObject("tsbAddImage.Image")));
        }
        else
          tsbAddImage.Image = value;
        tsbAddImage.ImageScaling = ToolStripItemImageScaling.None;
      }
    }

    /// <summary>
    /// ������ ������ "�������� � ���������"
    /// </summary>
    public Image ImageAddInFavorites
    {
      set
      {
        if (value == null)
          AddInFavoritesTSB.Image = global::FAQ_Net.Properties.Resources.Favorite;
        else
          AddInFavoritesTSB.Image = value;
        AddInFavoritesTSB.ImageScaling = ToolStripItemImageScaling.None;
      }
    }

    #endregion �������� ��������� ������

    #endregion �������� / Properties

    #region ������ / Methods

    private void tsmiInsertTable_Click(object sender, EventArgs e)
        {
          _tablePropertyUserControl.Parent = splitContainer1.Panel2;
          _tablePropertyUserControl.BringToFront();
          _tablePropertyUserControl.Location = new Point(TabControl.Width + 100, 100);
        }

        private void DropDown_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
          var c = tsddbInsertTable.DropDown as tools.ToolStripTableSizeSelector;
          if (c != null)
          {
            c.Selector.SelectedSize = new Size(0, 0);
            c.Selector.VisibleRange = new Size(10, 10);
          }
        }

        private void CreateRtfTable(int countRows, int countColumns)
        {
          richText.SelectedRtf = Rtf.InsertTableInRichTextBox(countRows, countColumns, 16000 / countColumns);
        }

        private void Selector_TableSizeSelected(object sender, tools.TableSizeEventArgs e)
        {
          CreateRtfTable(e.SelectedSize.Height, e.SelectedSize.Width);
        }

        //        �������� ����������� ������� �� user32 - SendMessage
        //        ��� ����� ���������� �� �������� �������� � ������ (using System.Runtime.InteropServices;)

        [DllImport("user32.dll")]
        public static extern int SendMessage(
               int hWnd,      // handle to destination window
               uint Msg,       // message
               long wParam,  // first message parameter
               long lParam   // second message parameter
               );

        //      ����� ��� ���������� - ��� ����� ���������� ���� �� ��������, � ����� ����������...
        public bool tree_go_down = false;
        public bool tree_go_up = false;

        //������ ���������� ��������� � TreeView
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (tree_go_down == true) //����� ���������� ��������� �� Scroll ����
            {
                SendMessage(TV1.Handle.ToInt32(), 277, 1, 0);

            }
            if (tree_go_up == true) //����� ���������� ��������� �� Scroll �����
            {
                SendMessage(TV1.Handle.ToInt32(), 277, 0, 0);
            }
        }

        private void LastQuestions()
        {
            G.ExecSQLiteQuery(@"SELECT id_content,id_category,question,create_date,modif_date,favorite_date
                       FROM vopros
                       ORDER BY create_date DESC
                       LIMIT 50");
            if (splitContainer1.Panel1Collapsed)
                splitContainer1.Panel1Collapsed = false;
            if (!splitContainer1.Panel2Collapsed)
                splitContainer1.Panel2Collapsed = true;
            _questionListControl.AddQuestionsIntoListControl(false);
            SelectedPathLbl.Text = "��������� ����������� �������";
            _questionListControl.Tag = SelectedPathLbl.Text;
            SelectedId_Razdel = null;
            CountQuestionsVal.Text = _questionListControl.CountItemsTotal.ToString();
            SetCurrentQuestionId();
        }

        private void RefreshCountQuestAndAnswers()
        {
            if (G.ExecSQLiteQuery(
                "SELECT COUNT(1) as CountQuestions FROM vopros"))
                CountQuestLbl.Text = G.DT.Rows[0][0].ToString();
            if (G.ExecSQLiteQuery(
                "SELECT COUNT(1) as CountAnswers FROM otvet"))
                CountAnswLbl.Text = G.DT.Rows[0][0].ToString();
        }

    /// <summary>
    /// ��������� ��������� �������� ���� �� �����
    /// </summary>
    public void ReloadStyleSettings(SharedLibrary.SettingsXml settingsXml)
    {
      //SharedLibrary.SettingsXml settingsXml = new SharedLibrary.SettingsXml(xmlFileName);
      Font headerBtnFont = BackBtn.Font;
      CustomDesignControl[] controlsForSettings = new CustomDesignControl[]
      {
               new CustomDesignControl() { SettingId = "MainFormTabControl", Description = "�������", ObjectControl = TabControl}
              ,new CustomDesignControl() { SettingId = "CategoryToolStrip", Description = "�������.������", ObjectControl = toolStrip1}
              ,new CustomDesignControl() { SettingId = "CategoryTreeView", Description = "�������.������", ObjectControl = TV1}
              ,new CustomDesignControl() { SettingId = "CategoryStatusControl", Description = "�������.��������� ������", ObjectControl = statusStrip2}
              ,new CustomDesignControl() { SettingId = "ResultSearchDataGridView", Description = "�����.���������", ObjectControl = DGVResultSearch}
              ,new CustomDesignControl() { SettingId = "FavoriteDataGridView", Description = "���������.���������", ObjectControl = FavoriteDGV}
              ,new CustomDesignControl() { SettingId = "JournalDataGridView", Description = "������.���������", ObjectControl = JournalDGV}

              ,new CustomDesignControl() { SettingId = "QuestionHeader", Description = "��������� (������)", ObjectControl = panel3}
              ,new CustomDesignControl() { SettingId = "QuestionSplitter", Description = "�����������", ObjectControl = splitter1}
              ,new CustomDesignControl() { SettingId = "QuestionDataGridView", Description = "������ �������� (�����)", ObjectControl = _questionDgvControl.DgvControl}
              ,new CustomDesignControl() { SettingId = "QuestionListView", Description = "������ �������� (����)", ObjectControl = _questionListViewControl.QuestionListView}
              ,new CustomDesignControl() { SettingId = "RtfDocMenu", Description = "��������.����", ObjectControl = menuTop}
              ,new CustomDesignControl() { SettingId = "RtfDocToolStrip", Description = "��������.�����������", ObjectControl = toolsTop}
              ,new CustomDesignControl() { SettingId = "RtfDocumentControl", Description = "RTF-��������", ObjectControl = richText}
              ,new CustomDesignControl() { SettingId = "RightStatusControl", Description = "������ ��������� ������", ObjectControl = statusStrip3}
              ,new CustomDesignControl() { SettingId = "DocumentStatusControl", Description = "RTF-��������.��������� ������", ObjectControl = statusStrip1}

              ,new CustomDesignControl() { SettingId = "FindControlUser", Description = "������ ������", ObjectControl = fnd.panelGradient}
              ,new CustomDesignControl() { SettingId = "MainStatusControl", Description = "������ ��������� ������", ObjectControl = status}

              ,new CustomDesignControl() { SettingId = "TooltipRtfTitle", Description = "����������� ���������.���������", ObjectControl = (_richTextBoxToolTip != null)?_richTextBoxToolTip.TitleLabel:null}
              ,new CustomDesignControl() { SettingId = "TooltipRtfDescription", Description = "����������� ���������.��������", ObjectControl = (_richTextBoxToolTip != null)?_richTextBoxToolTip.DescriptionLabel:null}
              ,new CustomDesignControl() { SettingId = "TooltipRtfFooter", Description = "����������� ���������.������", ObjectControl = (_richTextBoxToolTip != null)?_richTextBoxToolTip.FooterLabel:null}

              ,new CustomDesignControl() { SettingId = "TooltipEditorHeaderLabel", Description = "������� ���������.���������", ObjectControl = (_dictionaryEditor != null)?_dictionaryEditor.lblHeader:null}
              ,new CustomDesignControl() { SettingId = "TooltipEditorHeaderToolstrip", Description = "������� ���������.����������������������", ObjectControl = (_dictionaryEditor != null)?_dictionaryEditor.tsHeader:null}
              ,new CustomDesignControl() { SettingId = "TooltipEditorSearchToolstrip", Description = "������� ���������.������������", ObjectControl = (_dictionaryEditor != null)?_dictionaryEditor.tsSearch:null}
              ,new CustomDesignControl() { SettingId = "TooltipEditorTreeView", Description = "������� ���������.���������������", ObjectControl = (TooltipDictionary.TV_Dictionary != null)?TooltipDictionary.TV_Dictionary:null}
              ,new CustomDesignControl() { SettingId = "TooltipEditorEditToolstrip", Description = "������� ���������.��������������������������", ObjectControl = (_dictionaryEditor != null)?_dictionaryEditor.tsEditor:null}
              ,new CustomDesignControl() { SettingId = "TooltipEditorEditPanel", Description = "������� ���������.������ ��������������", ObjectControl = (_dictionaryEditor != null)?_dictionaryEditor.EditPanel:null}
              ,new CustomDesignControl() { SettingId = "IntelliSenseDataGridView", Description = "IntelliSense (Ctrl+Space)", ObjectControl = (_intellisenseUserControl != null)?_intellisenseUserControl.HelpDataGridView:null}

              //,new CustomDesignControl() { SettingId = "WordTooltip", Description = "����������� ���������", ObjectControl = _richTextBoxToolTip}
      };
      if (_appSettingForm == null)
        _appSettingForm = new AppSettingsForm(controlsForSettings, settingsXml);
      else
        _appSettingForm.ReloadStyleSettings(controlsForSettings, settingsXml, true);
      BackBtn.Font = headerBtnFont;
      btnNextQuestion.Font = headerBtnFont;
      btnSelectQuestion.Font = headerBtnFont;
      lblSearchDescription_FontChanged(null, null);
    }

        public System.Data.DataTable TransitionDT = new System.Data.DataTable();
        private int CurTransitionRow = 0;
    private void MainForm_Load(object sender, EventArgs e)
    {
      SqliteDatabase.Create();

      tsmiSaveNodeSelect.Checked = _settingsXml.GetSettingAsBool(Constants.SAVE_SECTION_NODE_SELECT, true);
      tsmiReplaceFontControlToMenu.Checked = _settingsXml.GetSettingAsBool(Constants.RTF_COMBOBOX_CONTROLS_REPLACE_TO_MENU, false);
      ReplaceFontControlToMenuOrBack();
      Constants.RtfSmoothScrolling
        = tsmiSmoothScrollingDocument.Checked = _settingsXml.GetSettingAsBool(Constants.RTF_SMOOTH_SCROLLING, true);
      
      _questionDgvControl = new QuestionDgvControl(splitContainer1.Panel1, QuestionsCMS, this);
      _questionListViewControl = new QuestionListViewControl(splitContainer1.Panel1, QuestionsCMS, this);
      _questionListControl = _questionDgvControl;

      // ������ ������
      fnd = new FindForm(ref richText);
      fnd.Dock = DockStyle.Bottom;
      fnd.Parent = splitContainer1.Panel2;
      fnd.BorderStyle = BorderStyle.FixedSingle;
      fnd.BringToFront();
      fnd.Hide();

      // ����������� ��������� ��� ��������� ���� �� �����
      if (ModalDialogForSelectQuestion)
      {
        tsmiDictionary.Enabled = false;
      }
      else
      {
        TooltipDictionary.InitializeToolTip();

        _dictionaryEditor = new DictionaryEditor();
        _dictionaryEditor.Dock = DockStyle.Right;

        _richTextBoxToolTip = new TooltipUserControl(richText);
        //_richTextBoxToolTip.TitleFont = new Font("Times New Roman", 12, FontStyle.Bold);
        //_richTextBoxToolTip.DescriptionFont = new Font("Times New Roman", 12);
        _richTextBoxToolTip.Dictionary = TooltipDictionary.eDictionary;
        _richTextBoxToolTip.TitleForeColor = Color.DarkBlue;
        _richTextBoxToolTip.DescriptionForeColor = Color.Black;
        _intellisenseUserControl = new IntellisenseUserControl(richText);
        _intellisenseUserControl.Parent = richText;
        _intellisenseUserControl.BringToFront();
      }

      ReloadStyleSettings(_settingsXml);

      TabControl.Width = _settingsXml.GetSettingAsInt(Constants.MAIN_SPLITTER_DISTANCE, TabControl.Width);

      string lastViewSetting = _settingsXml.GetSetting(Constants.LAST_VIEW);
      if (lastViewSetting == _questionListViewControl.ToString())
        tsmiListView_Click(sender, e);
      else
        tsmiGridView_Click(sender, e);

      // � ������, ���� �������� ������ ��� ���������� ��������� ��������, �� ��������� ������� - ���
      // 1) ���������� System.Data.SQLite.dll �������� 64-� ���������
      // 2) � ��������� ������� �� ������� "������" ������� �������� "�������� ���������" = x86
      G.CancelRunSecondaryApp();

      this.Text = "FAQ.Net v." + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
      string headerTitle = _settingsXml.GetSetting("HeaderTitle");
      if (!string.IsNullOrEmpty(headerTitle))
        this.Text = string.Format("{0} [{1}]", headerTitle, this.Text);

      if (TransitionDT.Columns.Count == 0)
      {
        TransitionDT.Columns.Add("type", typeof(Int16));
        TransitionDT.Columns.Add("id", typeof(String));
        TransitionDT.Columns.Add("TN", typeof(TreeNode));
        TransitionDT.Rows.Add(0, "", null);
      }
      //DGVQuestions.Columns["QuestionsColumn"].Width = System.Windows.Forms.SystemInformation.PrimaryMonitorSize.Width-600;
      //DGVQuestions.Columns["QuestionsColumn"].Width = System.Windows.Forms.SystemInformation.PrimaryMonitorSize.Width - MainSC.SplitterDistance - 50;

      LastQuestions();                  //����� ��������� ����������� ��������
      string lastSortingSetting = _settingsXml.GetSetting(Constants.LAST_SORTING);
      if (lastSortingSetting == SortOrder.Descending.ToString())
        SortDescTSMI_Click(sender, e);
      else
        SortAscTSMI_Click(sender, e);

      Timer1.Tick += new System.EventHandler(this.timer1_Tick);
      splitContainer1.Panel2Collapsed = true;
      //splitContainer1.SplitterDistance = 5;
      //��������� ������� �������� ������
      G.GetTreeNodes(TV1, null, false);
      RefreshCountQuestAndAnswers();    //������� ���-�� ������� � ��������
                                        // Set/Get form's size and location values.
      if (formWidth > 0 && formHeight > 0)
      {
        this.Left = posLeft;
        this.Top = posTop;
        this.Width = formWidth;
        this.Height = formHeight;
      }
      else
      {
        posLeft = this.Left;
        posTop = this.Top;
        formWidth = this.Width;
        formHeight = this.Height;
      }
      // Set tool tips for controls that don't have the ToolTipText property.
      //toolTip.SetToolTip(this.rightIndentGrip, "Right Indent");
      InitializeUserControls();
      highLight.DropDown = highlightColor;
      // Initialize text color menu renderer.
      colors.Renderer = new RenderColors();
      // Initialize Format class.
      format = new Format(richText.Handle);
      // Set default page settings.
      pageSettings = new System.Drawing.Printing.PageSettings();
      pageSettings.Landscape = false;
      pageSettings.Margins.Left = 50;
      pageSettings.Margins.Right = 50;
      pageSettings.Margins.Top = 100;
      pageSettings.Margins.Bottom = 100;
      //            ruler.RightLimit -= pageSettings.Margins.Left + pageSettings.Margins.Right;
      // Set the Combo Box used by the fonts ToolStripComboBox.
      fonts = selFont.ComboBox;
      // Set the DrawMode and add handler so that we can
      // manually draw each font name in its own font.
      fonts.DrawMode = DrawMode.OwnerDrawVariable;
      fonts.MeasureItem += Fonts_MeasureItem;
      fonts.DrawItem += Fonts_DrawItem;
      fonts.SelectionChangeCommitted += new EventHandler(Fonts_SelectionChangeCommitted);
      fonts.IntegralHeight = true;
      // Add event handler for zoom changed event.
      richText.ZoomChanged += new ZoomChangedEventHandler(richText_ZoomChanged);
      // Adding all available font names can cause a lot
      // of overhead, depending on how many fonts are
      // installed, so fill them in a background thread.
      System.Threading.Thread t = new System.Threading.Thread(GetFonts);
      // Thread-safe delegate to add the fonts when thread work is done.
      delgAddFonts = new AddFonts(delg_AddFonts);
      t.IsBackground = true;
      t.Priority = System.Threading.ThreadPriority.Highest;
      t.Start();
      CheckUpdate();

      //SetRoundedShape(TV1, 30);
      //SetRoundedShape(DGVResultSearch, 30);
    }

    //public string WinToHex(string s)
    //{
    //  byte[] bytes = Encoding.GetEncoding(1251).GetBytes(s);
    //  StringBuilder ByteString = new StringBuilder();
    //  foreach (byte b in bytes)
    //  {
    //    ByteString.Append(String.Format("\\\'{0:x2}", b));
    //  }
    //  return ByteString.ToString();
    //}



    /// <summary>
    /// ��������� ���������� ����������
    /// </summary>
    private void CheckUpdate()
    {
      try
      {
        System.Net.WebClient webCli = new System.Net.WebClient();
        using (Stream stream = webCli.OpenRead("https://raw.githubusercontent.com/shmelev-1987/faq_net/master/WordEditor/LastUpdateInfo.xml"))
        {
          using (StreamReader reader = new StreamReader(stream))
          {
            string xmlUpdateText = reader.ReadToEnd();
            System.Xml.XmlDocument xmlDocUpdate = new System.Xml.XmlDocument();
            xmlDocUpdate.LoadXml(xmlUpdateText);
            Version lastVersion = new Version(xmlDocUpdate.SelectSingleNode("//VersionConfig/LastVersion").InnerText);
            if (lastVersion > System.Reflection.Assembly.GetExecutingAssembly().GetName().Version)
            {
              // ���������� ���������� � ����� ������
              UpdateUserControl updateUserControl = new UpdateUserControl();
              updateUserControl.UpdateInfoText = xmlDocUpdate.SelectSingleNode("//VersionConfig/LatestChanges").InnerText.Replace("\n", Environment.NewLine);
              updateUserControl.DownloadReleaseUrl = "https://github.com/shmelev-1987/faq_net/releases";
              updateUserControl.Width = Convert.ToInt32(xmlDocUpdate.SelectSingleNode("//VersionConfig/Width").InnerText);
              updateUserControl.Height = Convert.ToInt32(xmlDocUpdate.SelectSingleNode("//VersionConfig/Height").InnerText);
              updateUserControl.Parent = this;
              updateUserControl.BringToFront();
            }
          }
        }
      }
      catch(Exception) { }
    }

    private void InitializeUserControls()
    {
      // Initialize twips converter.
      if (tc == null)
        tc = new TwipsConverter();

      // Initialize highlight color menu.
      if (highlightColor == null)
        highlightColor = new ColorTable();
    }

        private void delg_AddFonts()
        {
           // System.Threading.Thread.Sleep(50);
            if (ffNames != null)
            {
                // Duplicate the most commonly used fonts
                // in the list and add them to the top
                // of the drop down list.
                string[] CommonNames = new string[] { "Times New Roman", "Arial", "Courier New", "Microsoft Sans Serif", "Tahoma", "Verdana" };
                foreach (string name in CommonNames)
                {
                    if (Array.IndexOf(ffNames, name) > -1)
                    {
                        fonts.Items.Add(name);
                    }
                }
                // Add the available font family names to fonts combo box.
                // The font names that were placed first are duplicated,
                // in their alphabetic positions in the collection.
                fonts.Items.AddRange(ffNames);
                // Add event handlers to record size and location.
                this.LocationChanged += MainForm_LocationChanged;
                this.SizeChanged += MainForm_SizeChanged;
            }
        }

        private void GetFonts()
        {
            int idx = 0;
            foreach (FontFamily ff in FontFamily.Families)
            {
                // Only allow fonts that support Normal, Bold,
                // Italic, and Underline styles.
                if (ff.IsStyleAvailable(FontStyle.Regular) && ff.IsStyleAvailable(FontStyle.Bold)
                    && ff.IsStyleAvailable(FontStyle.Italic) && ff.IsStyleAvailable(FontStyle.Underline))
                {
                    idx += 1;
                    Array.Resize(ref ffNames, idx);
                    ffNames[idx - 1] = ff.Name;
                }
            }
            // Verify this form is still opened before adding
            // the font names.
            if (!this.IsDisposed && ffNames != null)
            {
                this.Invoke(this.delgAddFonts);
            }
        }

        /* The registry provides a robust store for application and user settings.
         * Most back-up programs automatically back up the registry settings, and
         * when you put information in the right place in the registry, you
         * automatically get user isolation when storing settings. Although users
         * can edit the registry, they generally tend not to, and this makes your
         * settings more stable. Overall, when Microsoft Windows� Logo guidelines
         * for registry usage are followed, it is a reasonable place to store
         * application settings.
         */

        public void GetSettings(object newLocation)
        {
            string userFolder = "";
            try
            {
                userFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\EditorPro\";
                if (Directory.Exists(userFolder))
                {
                    string userFile = userFolder + "Settings.txt";
                    if (File.Exists(userFile))
                    {
                        string[] s = new string[] { Environment.NewLine };
                        string[] settings = File.ReadAllText(userFile).Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                        RectangleConverter rConv = new RectangleConverter();
                        Rectangle rc;
                        rc = (Rectangle)rConv.ConvertFromString(settings[0]);
                        if (newLocation == null)
                        {
                            posLeft = rc.Left;
                            posTop = rc.Top;
                        }
                        else
                        {
                            Point pt = (Point)newLocation;
                            posLeft = pt.X;
                            posTop = pt.Y;
                        }
                        formWidth = rc.Width;
                        formHeight = rc.Height;
                        // Validate location.  Use designer form
                        // settings if form is cut off of the screen.
                        if (posLeft > 0 && posTop > 0)
                        {
                            Rectangle bounds = Screen.PrimaryScreen.Bounds;
                            if (posLeft + formWidth > bounds.Width ||
                                posTop + formHeight > bounds.Height)
                            {
                                formWidth = 0;
                            }
                        }
                        else
                        {
                            formWidth = 0;
                        }

                        if (settings[1] == "True")
                        {
                            WindowState = FormWindowState.Maximized;
                        }
                    }
                }
            }
            catch
            {
                try
                {
                    if (userFolder.Length > 0 && Directory.Exists(userFolder) && File.Exists(userFolder + "Settings.txt"))
                    {
                        File.Delete(userFolder + "Settings.txt");
                    }
                }
                catch { }
            }

        }

        private void saveSettings()
        {
            string userFolder = "";
            try
            {
                userFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + appFolder;
                if (!Directory.Exists(userFolder))
                {
                    Directory.CreateDirectory(userFolder);
                }
                string file = userFolder + "Settings.txt";
                string settings;
                RectangleConverter rConv = new RectangleConverter();
                Rectangle rc = new Rectangle(posLeft, posTop, formWidth, formHeight);

                settings = rConv.ConvertToString(new Rectangle(posLeft, posTop, formWidth, formHeight)) +
                    Environment.NewLine + (this.WindowState == FormWindowState.Maximized).ToString();
                File.WriteAllText(file, settings);
            }
            catch
            {
                try
                {
                    if (userFolder.Length > 0 && Directory.Exists(userFolder))
                    {
                        Directory.Delete(userFolder);
                    }
                }
                catch { }
            }

            return;

            //if (recentFiles != null)
            //{

            //}

            //// Store recent files in the Windows recent folder, so that
            //// theby Windows disk cleanup, and many freeware utility apps.
            //string recentDocs = Environment.GetFolderPath(Environment.SpecialFolder.Recent) + appFolder;
        }

        private void Fonts_MeasureItem(object sender, MeasureItemEventArgs e)
        {
            if (e.Index > -1)
            {
                using (Font fnt = new Font(fonts.Items[e.Index].ToString(), 12, FontStyle.Regular, GraphicsUnit.Point))
                {
                    fontSize = e.Graphics.MeasureString(fonts.Items[e.Index].ToString(), fnt);
                }
                e.ItemWidth = (int)fontSize.Width;
                e.ItemHeight = (int)fontSize.Height + 2;
                if (e.Index == 5)
                {
                    // Last item in the first 6 fonts that were
                    // added first.  Add extra height to account
                    // for double line drawn under this font name.
                    e.ItemHeight += 2;
                }
            }
        }

        private void Fonts_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index > -1)
            {
                if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
                {
                    e.DrawBackground();
                    br = Brushes.White;
                }
                else
                {
                    e.Graphics.FillRectangle(new SolidBrush(e.BackColor), e.Bounds);
                    br = Brushes.Black;
                }
                using (Font fnt = new Font(fonts.Items[e.Index].ToString(), 12, FontStyle.Regular, GraphicsUnit.Point))
                {
                    e.Graphics.DrawString(fonts.Items[e.Index].ToString(), fnt, br, e.Bounds, StringFormat.GenericDefault);
                }
                if (e.Index == 5)
                {
                    // Draw double-line separating first 6 fonts from the rest of them.
                    Pen p = new Pen(Color.Gray);
                    e.Graphics.DrawLine(p, new Point(e.Bounds.Left, e.Bounds.Y + e.Bounds.Height - 3),
                        new Point(e.Bounds.Left + e.Bounds.Width, e.Bounds.Y + e.Bounds.Height - 3));
                    e.Graphics.DrawLine(p, new Point(e.Bounds.Left, e.Bounds.Y + e.Bounds.Height - 1),
                       new Point(e.Bounds.Left + e.Bounds.Width, e.Bounds.Y + e.Bounds.Height - 1));
                    p.Dispose();
                }
            }
        }

        private void RichText_SelectionChanged(object sender, EventArgs e)
        {
            if (richText.SelectionFont != null)
            {
                // MessageBox.Show("selchanged");
                selFnt = richText.SelectionFont;
                selFont.Text = selFnt.FontFamily.Name;
                // SelectionFont.Size returns 13 when multiple
                // sizes are selected.
                float selSize = selFnt.Size;
                if (selSize != 13)
                {
                    size.Text = selSize.ToString();
                }
                else
                {
                    size.Text = "";
                }
                bold.Checked = selFnt.Bold;
                under.Checked = selFnt.Underline;
                italic.Checked = selFnt.Italic;
                strikeout.Checked = selFnt.Strikeout;
                bullet.Checked = richText.SelectionBullet;
            }
            else
            {
                fonts.Text = "";
                size.Text = "";
                bold.Checked = false;
                under.Checked = false;
                italic.Checked = false;
                strikeout.Checked = false;
                bullet.Checked = false;
            }
            // Set alignment controls.
            selAlign = richText.SelectionAlignment;
            alignCenter.Checked = (selAlign == HorizontalAlignment.Center);
            alignLeft.Checked = (selAlign == HorizontalAlignment.Left);
            alignRight.Checked = (selAlign == HorizontalAlignment.Right);
            //alignJustify.Checked = false;
            // Change right indent as needed.
            setFormRightIndent();
        }

        void rightIndentGrip_MouseDown(object sender, MouseEventArgs e)
        {
//            if (e.Button == MouseButtons.Left)
//            {
////                rightIndentLine.Visible = true;
//                rightMarginMouseX = Control.MousePosition.X - rightIndentGrip.Left;
//                oldRightMarginX = rightIndentGrip.Left;
//            }
//            else
//            {
//                //MessageBox.Show("this.rightMarginLine.Left: " + this.rightMarginLine.Left.ToString() + Environment.NewLine +
//                //    "rightIndentGrip.Left: " + rightIndentGrip.Left.ToString() + "Beta Message");
//            }
        }

        private void rightIdentGrip_MouseMove(object sender, MouseEventArgs e)
        {
//            if (e.Button == MouseButtons.Left)
//            {
//                if (Control.MousePosition.X - rightMarginMouseX > leftIndentGrip.Left + 3 && Control.MousePosition.X - rightMarginMouseX < ruler.Width)
//                {
//                    rightIndentGrip.Left = Control.MousePosition.X - rightMarginMouseX;
//                    this.rightIndentLine.Left = rightIndentGrip.Left + HALF_POINT;
//                }
//            }
        }

        void rightIndentGrip_MouseUp(object sender, MouseEventArgs e)
        {
//            if (e.Button == MouseButtons.Left)
//            {
//                if (rightIndentGrip.Left <= leftIndentGrip.Left + 6)
//                {
//                    rightIndentGrip.Left = leftIndentGrip.Left + 6;
                    //this.rightMarginLine.Hide();
                    //this.rightMarginLine.Left = rightIndentGrip.Left + HALF_POINT;
                    //this.Refresh();
                    //this.rightMarginLine.Show();
                    //this.rightMarginLine.Refresh();
                    //System.Threading.Thread.Sleep(50);
                    //setTextRightIndent();
                    //rightMarginLine.Hide();
                    //return;
//                }
//                else if (rightIndentGrip.Left >= ruler.RightLimit + 6)
//                {
//                    rightIndentGrip.Left = ruler.RightLimit + 6;
                    //this.rightMarginLine.Hide();
                    //this.rightMarginLine.Left = rightIndentGrip.Left + HALF_POINT;
                    //this.Refresh();
                    //this.rightMarginLine.Show();
                    //this.rightMarginLine.Refresh();
                    //System.Threading.Thread.Sleep(50);
                    //setTextRightIndent();
                    //rightMarginLine.Hide();
                    //return;
//                }
//                int tickMarkPointX;
//                int pointerX = rightIndentGrip.Left + 4;
//                for (int i = ruler.TotalTickMarks; i >= 0; i--)
//                {
//                    tickMarkPointX = (int)(i * ruler.SpacingMultiplier + ruler.Left + 3);
//                    if (Math.Abs(pointerX - tickMarkPointX) < 7)
//                    {
//                        rightIndentGrip.Left = tickMarkPointX - 4;
//                        this.rightIndentLine.Hide();
//                        this.rightIndentLine.Left = rightIndentGrip.Left + HALF_POINT;
//                        this.Refresh();
//                        this.rightIndentLine.Show();
//                        this.rightIndentLine.Refresh();
//                        System.Threading.Thread.Sleep(50);
//                        setTextRightIndent();
//                        rightIndentLine.Hide();
//                        return;
//                    }
//                }
//                MessageBox.Show("Error at rightIndentGrip_MouseUp().  Indent Location not found.", "Beta Error Message");
                // Unexpected.  Return to old location.
//                rightIndentGrip.Left = oldRightMarginX;
//                this.rightIndentLine.Hide();
//                this.rightIndentLine.Left = rightIndentGrip.Left + HALF_POINT;
//                this.Refresh();
//                this.rightIndentLine.Show();
//                this.rightIndentLine.Refresh();
//                System.Threading.Thread.Sleep(50);
//                rightIndentLine.Visible = false;
//            }
//            else
//            {
                // setFormRightIndent(format.SelectionRightIndentTwips);
//                MessageBox.Show("Right Indent in Twips = " + format.SelectionRightIndentTwips.ToString(), "Beta Message");
                //setFormRightIndent();
//            }
        }

        private void setTextRightIndent()
        {
//            riValue = tc.ConvertPixelsToHTwips((((int)ruler.RightMargin - this.rightIndentLine.Left) + (rightIndentOffset - pageSettings.Margins.Left - pageSettings.Margins.Right)));
//            format.SelectionRightIndentTwips = riValue;
        }

        private void setFormRightIndent()
        {
//            rightIndentVal = (int)ruler.RightMargin - tc.ConvertHTwipsToPixels(format.SelectionRightIndentTwips - rightIndentOffset) - pageSettings.Margins.Left - pageSettings.Margins.Right + rightIndentOffset + HALF_POINT - 1;
//            if (rightIndentLine.Left != rightIndentVal)
//            {
//                this.rightIndentLine.Left = rightIndentVal;
//                this.rightIndentGrip.Left = rightIndentLine.Left - HALF_POINT;
//            }
        }

        private void Fonts_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (fonts.SelectedItem != null)
            {
                format.SelectionFontName = fonts.SelectedItem.ToString();
                // Manually set the text because setting focus
                // to another control in _DropDownClosed prevents
                // the text from updating.
                selFont.Text = fonts.SelectedItem.ToString();
            }
        }

        private void SelFont_DropDownClosed(object sender, EventArgs e)
        {
            richText.Focus();
        }

        private void SelFont_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (fonts.FindStringExact(selFont.Text) > -1)
                {
                    format.SelectionFontName = selFont.Text;
                    richText.Focus();
                }
                else
                {
                    selFont.Text = "";
                }
            }
        }

        private void SaveAnswerToDB()
        {
            //string rtf = G.ConvertEncoding(richText.Rtf, 65001, 20127).Replace("'", "''");
            //string txt = G.ConvertEncoding(richText.Text, 65001, 20127).Replace("'","''");
            //string CurrentID_Content = G.ConvertEncoding(ID_ContentTSSL.Text, 65001, 20127).Replace("'","''");
            StringBuilder sbSql = new StringBuilder();
            if (G.ExecSQLiteQuery("SELECT COUNT(1) FROM otvet WHERE id_content=" + ID_ContentTSSL.Text) &&
                Convert.ToInt32(G.DT.Rows[0][0].ToString())==0)
            {
                #region �������� ����� � ��
                sbSql.AppendLine(string.Format("INSERT INTO otvet (id_content, answer_txt, answer_rtf, create_date, modif_date) VALUES ({0},'{1}','{2}','{3}',NULL);"
                    , ID_ContentTSSL.Text                          // id_content
                    , richText.Text.Replace("'", "''")             // answer_txt
                    , richText.Rtf.Replace("'", "''")              // answer_rtf
                    , DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") // create_date
                    ));
                if (G.ExecSQLiteQuery(sbSql.ToString()))                                                   //modif_date
                {
                    saveFile.Enabled = false;
                    save.Enabled = false;
                    CountAnswLbl.Text = (Convert.ToInt32(CountAnswLbl.Text)+1).ToString();
                }
                #endregion �������� ����� � ��
            }
            else
            {
                #region �������� ����� � ��
                sbSql.AppendLine(string.Format("UPDATE otvet SET answer_rtf='{0}',answer_txt='{1}',modif_date='{2}' WHERE id_content={3};update vopros set modif_date='{2}' where id_content={3};"
                  , richText.Rtf.Replace("'", "''")
                  , richText.Text.Replace("'", "''")
                  , DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                  , ID_ContentTSSL.Text
                  ));

                if (G.ExecSQLiteQuery(sbSql.ToString()))
                {
                    saveFile.Enabled = false;
                    save.Enabled = false;
                }
                #endregion �������� ����� � ��
            }
        }

        private void Tools_Click(object sender, EventArgs e)
        {
            switch (((ToolStripButton)sender).Name)
            {
                //case "newFile":
                //    newForm.PerformClick();
                //    break;
                case "openFile":
                    open.PerformClick();
                    break;
                case "saveFile":
                    /*if (currentFile.Length > 0)
                    {
                        saveCurrentFile();
                    }
                    else
                    {
                        saveAs.PerformClick();
                    }*/
                    SaveAnswerToDB();
                    break;
                case "printText":
                    print.PerformClick();
                    break;
                case "printPrevText":
                    printPrev.PerformClick();
                    break;
                case "findText":
                    find.PerformClick();
                    break;
                case "undoText":
                    undo.PerformClick();
                    break;
                case "redoText":
                    redo.PerformClick();
                    break;
                case "bold":
                    format.SetSelectionFontStyle(FontStyle.Bold, bold.Checked);
                    break;
                case "italic":
                    format.SetSelectionFontStyle(FontStyle.Italic, italic.Checked);
                    break;
                case "under":
                    format.SetSelectionFontStyle(FontStyle.Underline, under.Checked);
                    break;
                case "strikeout":
                    format.SetSelectionFontStyle(FontStyle.Strikeout, strikeout.Checked);
                    break;
                case "alignLeft":
                    alignCenter.Checked = false;
                    alignRight.Checked = false;
                    //alignJustify.Checked = false;
                    richText.SelectionAlignment = HorizontalAlignment.Left;
                    break;
                case "alignCenter":
                    alignLeft.Checked = false;
                    alignRight.Checked = false;
                    //alignJustify.Checked = false;
                    richText.SelectionAlignment = HorizontalAlignment.Center;
                    break;
                case "alignRight":
                    alignLeft.Checked = false;
                    alignCenter.Checked = false;
                    //alignJustify.Checked = false;
                    richText.SelectionAlignment = HorizontalAlignment.Right;
                    break;
                // ���� ��� �� �������� �� ���������� ��������, ������� ������ "������������ �� ������" ������
                // ������ ����� ��� ������� � ����������� �������� HorizontalAlignment.Justify � .NET
                //case "alignJustify":
                //    alignLeft.Checked = false;
                //    alignCenter.Checked = false;
                //    alignRight.Checked = false;
                //    richText_KeyDown(alignJustify, new KeyEventArgs(Keys.Control | Keys.J));                    
                //    break;
                case "bullet":
                    richText.SelectionBullet = bullet.Checked;
                    break;
            }
        }

        private void Size_SelectedIndexChanged(object sender, EventArgs e)
        {
            float selSize;
            if (float.TryParse(size.Text, out selSize))
            {
                format.SelectionFontSize = selSize;
            }
        }

        private void Size_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // Prevent annoying error noise that occurs when
                // pressing enter key in this control.
                e.SuppressKeyPress = true;
                // Validate user-entered text is a valid number.
                int selSize;
                if (int.TryParse(size.Text, out selSize))
                {
                    format.SelectionFontSize = selSize;
                    size.Text = selSize.ToString();
                    richText.Focus();
                }
                else
                {
                    MessageBox.Show("   This is not a valid number.   ", "Size not valid", MessageBoxButtons.OK);
                    // Reset font size display.
                    if (richText.SelectionFont != null)
                    {
                        selSize = (int)richText.SelectionFont.Size;
                        // If selection font has multiple sizes,
                        // SelectionFont.Size returns 13.
                        if (selSize != 13)
                        {
                            size.Text = selSize.ToString();
                        }
                        else
                        {
                            size.Text = "";
                        }
                        size.Text = selSize.ToString();
                        richText.Focus();
                    }
                }
            }
        }

        private void Size_DropDownClosed(object sender, EventArgs e)
        {
            richText.Focus();
        }

        private void Find_Click(object sender, EventArgs e)
        {
            fnd.rbSearch.Checked = true;
            if (richText.SelectedText.Length > 0)
                fnd.findText.Text = richText.SelectedText;
            richText.BringToFront();
            fnd.Show();
            fnd.findText.Focus();
        }

        private void PageSet_Click(object sender, EventArgs e)
        {
            if (printRtf == null)
            {
                printRtf = new PrintRichText(ref richText, pageSettings);
            }
            printRtf = new PrintRichText(ref richText, pageSettings);
            printRtf.PageSetupDlg();
//            ruler.RightLimit = PORTRAIT_RIGHT_LIMIT - pageSettings.Margins.Left - pageSettings.Margins.Right;
            setFormRightIndent();
        }

        private void PrintPrev_Click(object sender, EventArgs e)
        {
            if (printRtf == null)
            {
                printRtf = new PrintRichText(ref richText, pageSettings);
            }
            printRtf.PrintPreviewDlg();
        }

        private void Print_Click(object sender, EventArgs e)
        {
            if (printRtf == null)
            {
                printRtf = new PrintRichText(ref richText, pageSettings);
            }
            printRtf.PrintDialog();
        }

        private void RichText_TextChanged(object sender, EventArgs e)
        {
            SetUndoRedo();
            //saved = false;
            saveFile.Enabled = true;
            save.Enabled = true;
            tsslCountCharsValue.Text = richText.Text.Length.ToString();
        }

        private void Undo_Click(object sender, EventArgs e)
        {
            if (richText.CanUndo)
            {
                richText.Undo();
                RichText_SelectionChanged(null, null);
            }
        }

        private void Redo_Click(object sender, EventArgs e)
        {
            if (richText.CanRedo)
            {
                richText.Redo();
                RichText_SelectionChanged(null, null);
            }
        }

        void SetUndoRedo()
        {
            undoText.Enabled = richText.CanUndo;
            undo.Enabled = undoText.Enabled;

            redoText.Enabled = richText.CanRedo;
            redo.Enabled = redoText.Enabled;
        }
        /// <summary>
        /// Loads file into richtexbox.  Richtext stream type is used
        /// when ".rtf" extension found, otherwise file is load as plain
        /// text.
        /// </summary>
        /// <param name="fullpath">The full path of the file to load.</param>
        public void OpenFile(string fullpath)
        {
            try
            {
                if (Directory.Exists(Path.GetDirectoryName(fullpath)) &&
                    File.Exists(fullpath))
                {
                    string ext = Path.GetExtension(fullpath).ToLower();
                    if (ext == ".rtf")
                    {
                        richText.LoadFile(fullpath, RichTextBoxStreamType.RichText);
                    }
                    else
                    {
                        richText.LoadFile(fullpath, RichTextBoxStreamType.PlainText);
                    }
                    currentFile = fullpath;
                    //CountSubcategoryLbl.Text = "Current File:  " + currentFile;
                    //this.Text = Path.GetFileNameWithoutExtension(currentFile) + " - EditorPro";
                    //saved = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool saveCurrentFile()
        {
            try
            {
                string ext = Path.GetExtension(currentFile).ToLower();
                if (ext == ".rtf")
                {
                    richText.SaveFile(currentFile, RichTextBoxStreamType.RichText);
                }
                else
                {
                    richText.SaveFile(currentFile, RichTextBoxStreamType.PlainText);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                saveAs.PerformClick();
                return false;
            }
            //saved = true;
            return true;
        }

        private bool saveNewFile(string fullpath)
        {
            try
            {
                if (!Directory.Exists(fullpath))
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(fullpath));
                }
                string ext = Path.GetExtension(fullpath).ToLower();
                if (ext == ".rtf")
                {
                    richText.SaveFile(fullpath, RichTextBoxStreamType.RichText);
                }
                else
                {
                    richText.SaveFile(fullpath, RichTextBoxStreamType.PlainText);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            currentFile = fullpath;
            CountSubcategoryLbl.Text = "Current File:  " + currentFile;
            //saved = true;
            return true;
        }

        private void Open_Click(object sender, EventArgs e)
        {
            OpenFileDialog of = new OpenFileDialog();
            try
            {
                of.CheckFileExists = true;
                of.CheckPathExists = true;
                of.AddExtension = true;
                of.Filter = "Text Files and Rich Text Files (*.txt; *.rtf)|*.txt; *.rtf|Text Files (*.txt)|*.txt|Rich Text Format (*.rtf)|*.rtf|All Files (*.*)|*.*";
                if (of.ShowDialog() == DialogResult.OK)
                {
                    if (saveFile.Enabled)
                    {
                        DialogResult result = MessageBox.Show("��������� ��������� � ������ �� ������?",
                            "������������� ����������", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            Save_Click(sender, e);
                        }
                        else if (result == DialogResult.Cancel)
                        {
                            return;
                        }
                    }
                    OpenFile(of.FileName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            of.Dispose();
        }

        private void SelectColor_Paint(object sender, PaintEventArgs e)
        {
            using (Brush b = new SolidBrush(selectedColor))
            {
                e.Graphics.FillRectangle(b, new Rectangle(3, selectColor.Height - 8, selectColor.Width - 6 - 12, 6));
            }
        }

        private void Highlight_Paint(object sender, PaintEventArgs e)
        {
            InitializeUserControls();
            using (Brush b = new SolidBrush(highlightColor.SelectedColor))
            {
                e.Graphics.FillRectangle(b, new Rectangle(3, highLight.Height - 8, highLight.Width - 6 - 12, 6));
            }
        }

        private void HighLight_DropDownOpening(object sender, EventArgs e)
        {

        }

        private void HighLightColors_Click(object sender, EventArgs e)
        {
            selectedColor = Color.FromName(((ToolStripMenuItem)sender).Text);
            selectColor.ToolTipText = "���� ������ (" + selectedColor.Name + ")";
            richText.SelectionColor = selectedColor;
            toolsTop.Refresh();
            richText.Focus();
        }

        private void HighLight_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            richText.SelectionBackColor = highlightColor.SelectedColor;
            highLight.ToolTipText = "���� ��������� ������ (" + highlightColor.ToolTipText + ")";
        }

        private void HighLight_ButtonClick(object sender, EventArgs e)
        {
            if (highlightColor == null)
            {
                richText.SelectionBackColor = Color.Yellow;
            }
            else
            {
                richText.SelectionBackColor = highlightColor.SelectedColor;
            }
        }

    private void RichText_LinkClicked(object sender, LinkClickedEventArgs e)
    {
      try
      {
        if (IdContentUrlRegEx_v2.IsMatch(e.LinkText))
        {
          CheckAndSaveDocument();
          GetQuestionAndAnswer(e.LinkText.Substring(2));
          AddRowInHistory(2);
        }
        else
        {
          if (e.LinkText.StartsWith("http:") ||
              e.LinkText.StartsWith("https:"))
          {
            System.Diagnostics.Process browserProcess = new System.Diagnostics.Process();

            try
            {
              // true is the default, but it is important not to set it to false
              browserProcess.StartInfo.UseShellExecute = true;
              browserProcess.StartInfo.FileName = e.LinkText;
              browserProcess.Start();
            }
            catch (System.ComponentModel.Win32Exception noBrowser)
            {
              if (noBrowser.ErrorCode == -2147467259)
                MessageBox.Show("������ ��������", "������� �� ������: " + noBrowser.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception)
            {
              try
              {
                browserProcess.StartInfo.FileName = "iexplore.exe";
                browserProcess.StartInfo.Arguments = e.LinkText;
                browserProcess.Start();
              }
              catch (Exception ex)
              {
                MessageBox.Show("������ ��������", "������� �� ������: " + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
              }
            }
            browserProcess.Dispose();
          }
          else
            MessageBox.Show("URL-����� ������ ���������� � 'http:' ��� 'https:'", "�������� URL", MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

        }
      }
      catch (Exception ex)
      {
        MessageBox.Show("Error: " + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

        private void SelectColor_ButtonClick(object sender, EventArgs e)
        {
            richText.SelectionColor = selectedColor;
            richText.Focus();
        }

        private void saveAs_Click(object sender, EventArgs e)
        {
            SaveFileDialog sf = new SaveFileDialog();
            try
            {
                sf.CheckPathExists = true;
                sf.AddExtension = true;
                sf.Filter = "Text File (*.txt)|*.txt|Rich Text File (*.rtf)|*.rtf";
                if (currentFile.Length == 0 || currentFile.ToLower().EndsWith(".rtf"))
                {
                    // Filter index is one-based.
                    // select rtf filter index.
                    // If not set it defaults to
                    // 1 (in this case, txt).
                    sf.FilterIndex = 2;
                }
                if (sf.ShowDialog() == DialogResult.OK)
                {
                    saveNewFile(sf.FileName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            sf.Dispose();
        }

        private void Save_Click(object sender, EventArgs e)
        {
            SaveAnswerToDB();
        }

        /// <summary>
        /// This assumes document is not saved. Call this when
        /// saved is false.
        /// </summary>
        /// <returns>dialog result.</returns>

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            RestartApplicationCanceled = false;
            _settingsXml.SaveFormPosition(this);
            _settingsXml.SetSetting(Constants.MAIN_SPLITTER_DISTANCE, TabControl.Width.ToString());
            if (splitContainer1.Panel2Collapsed==false && saveFile.Enabled)
            {
                DialogResult res = MessageBox.Show("��������� ��������� ������ �� ������?", this.Text,
                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    Save_Click(sender, new EventArgs());
                }
                else
                    if (res == DialogResult.Cancel)
                    {
                        e.Cancel = true;
                        RestartApplicationCanceled = true;
                    }
            }
        }

        private void Cut_Click(object sender, EventArgs e)
        {
            richText.Cut();
        }

        private void Copy_Click(object sender, EventArgs e)
        {
            richText.Copy();
        }

        private void Paste_Click(object sender, EventArgs e)
        {
            richText.Paste();
        }

        private void font_Click(object sender, EventArgs e)
        {
            FontDialog fd = new FontDialog();
            fd.AllowScriptChange = false;
            fd.AllowSimulations = false;
            fd.ShowEffects = true;
            fd.MinSize = 8;
            fd.MaxSize = 72;
            if (richText.SelectionFont != null)
            {
                fd.Font = richText.SelectionFont;
            }
            // If selected text is all one color show
            // color box in font dialog.
            if (!richText.SelectionColor.IsEmpty)
            {
                fd.ShowColor = true;
                fd.Color = richText.SelectionColor;
            }
            else
            {
                fd.ShowColor = false;
            }
            if (fd.ShowDialog() == DialogResult.OK)
            {
                richText.SelectionFont = fd.Font;
                if (fd.ShowColor)
                {
                    richText.SelectionColor = fd.Color;
                }
            }
            fd.Dispose();
        }

    private void RichMenu_Click(object sender, EventArgs e)
    {
      switch (((ToolStripMenuItem)(sender)).Name)
      {
        case "fontRichText":
          font.PerformClick();
          break;
        case "printRichText":
          print.PerformClick();
          break;
      }
    }

        private void lineSpace1_Click(object sender, EventArgs e)
        {
            format.SetSelectionLineSpacing(Format.LineSpacing.Single);
            lineSpacing.ToolTipText = "Line Spacing (1)";
            lineSpace1.Checked = true;
            lineSpace1pt5.Checked = false;
            lineSpace2.Checked = false;
        }

        private void lineSpace1pt5_Click(object sender, EventArgs e)
        {
            format.SetSelectionLineSpacing(Format.LineSpacing.OneAndHalf);
            lineSpacing.ToolTipText = "Line Spacing (1.5)";
            lineSpace1pt5.Checked = true;
            lineSpace1.Checked = false;
            lineSpace2.Checked = false;
        }

        private void lineSpace2_Click(object sender, EventArgs e)
        {
            format.SetSelectionLineSpacing(Format.LineSpacing.Double);
            lineSpacing.ToolTipText = "Line Spacing (2)";
            lineSpace2.Checked = true;
            lineSpace1.Checked = false;
            lineSpace1pt5.Checked = false;
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    
        private void lineSpacing_ButtonClick(object sender, EventArgs e)
        {
            byte lineSp = 0;
            switch (lineSpacing.ToolTipText)
            {
                case "Line Spacing (1)":
                    lineSp = Format.LineSpacing.Single;
                    break;
                case "Line Spacing (1.5)":
                    lineSp = Format.LineSpacing.OneAndHalf;
                    break;
                case "Line Spacing (2)":
                    lineSp = Format.LineSpacing.Double;
                    break;
            }
            format.SetSelectionLineSpacing(lineSp);
        }

        private void selectAll_Click(object sender, EventArgs e)
        {
            richText.SelectAll();
        }

        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            // Keep record of form's size when window state is normal.
            if (this.WindowState == FormWindowState.Normal)
            {
                formWidth = this.Width;
                formHeight = this.Height;
            }
        }

        private void MainForm_LocationChanged(object sender, EventArgs e)
        {
            // Keep record of form's location when window state is normal.
            if (this.WindowState == FormWindowState.Normal)
            {
                posLeft = this.Left;
                posTop = this.Top;
            }
        }

        private void richText_ZoomChanged(object sender, ZoomChangedEventArgs e)
        {
            if (!zoomChanging)
            {
                zoomChanging = true;
                zoom.Text = (e.ZoomFactor * 100).ToString() + "%";
                //    ruler.AdjustRuler(e.ZoomFactor);
                zoomChanging = false;
            }
        }

        private void zoom_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (zoom.SelectedIndex > -1 && !zoomChanging)
            {
                zoomChanging = true;
                try
                {
                    string s = zoom.SelectedItem.ToString();
                    s = s.Remove(s.Length - 1, 1);
                    richText.ZoomFactor = float.Parse(s) / 100;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                richText.Focus();
                //  ruler.AdjustRuler(this.richText.ZoomFactor);
                zoomChanging = false;
            }
        }

        private void zoom_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                zoomChanging = true;
                float val;
                string rawVal = zoom.Text.Replace("%", "");
                if (float.TryParse(rawVal, out val))
                {
                    val = val / 100;
                    if (val >= 0.10 && val <= 5)
                    {
                        richText.ZoomFactor = val;
                        // zoom.Text = rawVal + "%";
                    }
                    else
                    {
                        MessageBox.Show("The value must be between 10 and 500.", "Value Not Valid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }

                }
                else
                {
                    MessageBox.Show("This is not a valid measurement.", "Value Not Valid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                richText.Focus();
                zoom.Text = (richText.ZoomFactor * 100).ToString() + "%";
                //  ruler.AdjustRuler(this.richText.ZoomFactor);
                zoomChanging = false;
            }
        }

        private void richText_Enter(object sender, EventArgs e)
        {
            if (!zoom.Text.StartsWith((richText.ZoomFactor * 100).ToString()))
            {
                zoom.Text = (richText.ZoomFactor * 100).ToString() + "%";
            }
        }

        private void replace_Click(object sender, EventArgs e)
        {
            fnd.rbReplace.Checked = true;
            if (richText.SelectedText.Length > 0)
                fnd.findText.Text = richText.SelectedText;
            //if (fnd.WindowState==FormWindowState.Minimized)
            fnd.Show();
            fnd.findText.Focus();
        }

        private void superSubScript_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;
            int val = int.Parse(item.Text);
            richText.SelectionCharOffset = val;
            if (item.OwnerItem == this.superscript)
            {
                // Un-check previously checked menu item.
                SuperScriptCheckedValue(true);
                superscriptRichText.Text = "Su&perscript (" + val.ToString() + ")";
            }
            else
            {
                // Un-check previously checked menu item.
                SubScriptCheckedValue(true);
                subscriptRichText.Text = "S&ubscript (" + val.ToString() + ")";
            }
            // Check this item.
            item.Checked = true;
        }

        private void normalCharOffset_Click(object sender, EventArgs e)
        {
            richText.SelectionCharOffset = 0;
            //ToolStripMenuItem item = (ToolStripMenuItem)sender;
            //if (item.OwnerItem == this.superscript)
            //{
            //    // Un-check previously checked menu item.
            //    SuperScriptCheckedValue(true);
            //}
            //else
            //{
            //    // Un-check previously checked menu item.
            //    SubScriptCheckedValue(true);
            //}
            //// Check this item.
            //item.Checked = true;
        }

        private int SuperScriptCheckedValue(bool uncheckItem)
        {
            foreach (object item in superscript.DropDownItems)
            {
                if (item is ToolStripMenuItem && ((ToolStripMenuItem)item).Checked)
                {
                    if (uncheckItem)
                    {
                        ((ToolStripMenuItem)item).Checked = false;
                        // we are simply unchecking the value,
                        // so no need to get the int value.
                        return 0;
                    }
                    return int.Parse(((ToolStripMenuItem)item).Text);
                }

            }
            // If nothing checked then "None" is checked.
            // return zero for no char offset.
            return 0;
        }

        private int SubScriptCheckedValue(bool uncheckItem)
        {
            foreach (object item in subscript.DropDownItems)
            {
                if (item is ToolStripMenuItem && ((ToolStripMenuItem)item).Checked)
                {
                    if (uncheckItem)
                    {
                        ((ToolStripMenuItem)item).Checked = false;
                        // we are simply unchecking the value,
                        // so no need to get the int value.
                        return 0;
                    }
                    return int.Parse(((ToolStripMenuItem)item).Text);
                }
            }
            // If nothing checked then "None" is checked.
            // return zero for no char offset.
            return 0;
        }

        private void superscriptRichText_Click(object sender, EventArgs e)
        {
            richText.SelectionCharOffset = SuperScriptCheckedValue(false);
        }

        private void subscriptRichText_Click(object sender, EventArgs e)
        {
            richText.SelectionCharOffset = SubScriptCheckedValue(false);
        }

        private void normalOffset_Click(object sender, EventArgs e)
        {
            richText.SelectionCharOffset = 0;
        }

        private void CreateCategory_Click(object sender, EventArgs e)
        {
            G.CreateCategory(TV1, null);
        }

        private void CreateSubcategoryTSB_Click(object sender, EventArgs e)
        {
            if (TV1.SelectedNode != null)
                G.CreateCategory(TV1, TV1.SelectedNode);
            else
                MessageBox.Show("�������� ������ � �������� ����� ������� ���������","�� ������ ������!",MessageBoxButtons.OK,MessageBoxIcon.Warning);
        }

        private void NodeSelect(TreeNode TN)
        {
            if (TN != null)
            {
                if (splitContainer1.Panel1Collapsed)
                    splitContainer1.Panel1Collapsed = false;
                if (!splitContainer1.Panel2Collapsed)
                    splitContainer1.Panel2Collapsed = true;

                CreateQuestionTSB.Enabled =
                    CreateSubcategoryTSB.Enabled = true;
                //string RazdelId = G.ConvertEncoding(e.Node.Name, 65001, 20127);
                string orderBySql = " ORDER BY question ASC";
                if (lastOrderByDesc)
                  orderBySql = " ORDER BY question DESC";
                G.ExecSQLiteQuery("SELECT id_content,id_category,question,create_date,modif_date,favorite_date FROM vopros WHERE id_category=" + TN.Name + orderBySql);
                _questionListControl.AddQuestionsIntoListControl(false);  //�������� ������ ��������
                //DGVQuestions.DataSource = G.DT;
                CountQuestionsVal.Text = G.DT.Rows.Count.ToString();
                SelectedPathLbl.Text = TN.FullPath;
                _questionListControl.Tag = SelectedPathLbl.Text;
                splitContainer1.Visible = true;
                SelectedPathLbl.Text = TN.FullPath;
                splitContainer1.Panel2Collapsed = true;
                CountSubcategoryVal.Text = TN.Tag.ToString();
                //BackBtn.Visible = false;
                CountQuestionsVal.Text = _questionListControl.CountItemsTotal.ToString();
                SelectedId_Razdel = TN.Name.Replace("'", "''");
            }
            SetCurrentQuestionId();
        }

    private void SetCurrentQuestionId(bool refreshAllData = true)
    {
      if (splitContainer1.Panel2Collapsed)
        _currentQuestionId = 0;// string.IsNullOrEmpty(_questionListControl.SelectedQuestionId) ? 0 : Convert.ToInt32(_questionListControl.SelectedQuestionId);
      else
        int.TryParse(ID_ContentTSSL.Text, out _currentQuestionId);
      if (_dictionaryEditor!= null && _dictionaryEditor.Parent != null && _dictionaryEditor.Visible && refreshAllData)
        _dictionaryEditor.RefreshAllData(_currentQuestionId);
      if (ModalDialogForSelectQuestion)
      {
        btnSelectQuestion.BackColor = SelectedPathLbl.BackColor;
        if (_currentQuestionId == 0)
        {
          btnSelectQuestion.Enabled = false;
        }
        else
        {
          btnSelectQuestion.Enabled = true;
        }
      }
    }

    public int GetCurrentQuestionId()
    {
      SetCurrentQuestionId(false);
      return _currentQuestionId;
    }

        private void TV1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            NodeSelect(TV1.SelectedNode);
            if (tsmiSaveNodeSelect.Checked)
              AddRowInHistory(1);
        }

        private void ExpandAllNodesTSB_Click(object sender, EventArgs e)
        {
            TV1.ExpandAll();
        }

        private void CollapseAllTSB_Click(object sender, EventArgs e)
        {
            TV1.CollapseAll();
        }

        private void TV1_AfterExpand(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Nodes[0].Name == "null")
                e.Node.Nodes.Clear();
            G.GetTreeNodes(TV1, e.Node,false);
        }

        private void CreateQuestionTSB_Click(object sender, EventArgs e)
        {
            if (G.MaxIdVopros == 0)
            {
                G.ExecSQLiteQuery("SELECT MAX(id_content)+1 FROM vopros WHERE id_content IS NOT NULL");
                if (G.DT.Rows.Count == 1 &&
                    G.DT.Rows[0][0].ToString() != "")
                    G.MaxIdVopros = Convert.ToInt32(G.DT.Rows[0][0].ToString());
                else
                    G.MaxIdVopros = 1;
            }
            //�������� �������
            if (SelectedId_Razdel != null)
            {
                G.Question = "";
                if (G.InputBox("�������� �������", "������������ �������", ref G.Question) == DialogResult.OK)
                {
                    //G.Question = G.ConvertEncoding(G.Question, 65001, 20127);
                    if (G.ExecSQLiteQuery(String.Format("INSERT INTO vopros (id_content,id_category,question,create_date) values ({0},{1},'{2}','{3}')",
                        G.MaxIdVopros.ToString(),                 //id_content
                        SelectedId_Razdel,                        //id_category
                        G.Question.Replace("'", "''"),            //question
                        DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                        )))
                    {
                        NodeSelect(TV1.SelectedNode);
                        //TV1_AfterSelect(sender, new TreeViewEventArgs(TV1.SelectedNode));
                        GetQuestionAndAnswer(G.MaxIdVopros.ToString());
                        G.MaxIdVopros += 1;
                        CountQuestLbl.Text = (Convert.ToInt32(CountQuestLbl.Text)+1).ToString();
                    }
                }
            }
            else
                MessageBox.Show("�������� ������ � ������� ����� ������� ������", "�� ������ ������!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void EditQuestionTSMI_Click(object sender, EventArgs e)
        {
            if (_questionListControl.CountItemsSelected == 1)
            {
                G.Question = _questionListControl.SelectedQuestionText;
                if (G.InputBox("�������������� �������", "������������ �������", ref G.Question) == DialogResult.OK)
                {
                    //G.Question = G.ConvertEncoding(G.Question, 65001, 20127);
                    if (G.ExecSQLiteQuery(
                        "UPDATE vopros " +
                        "SET question='" + G.Question.Replace("'", "''") + "' " +
                        "WHERE id_content='" + _questionListControl.SelectedQuestionId.ToString().Replace("'", "''") + "'"))
                    {
                        //G.Question = G.ConvertEncoding(G.Question, 20127, 65001);
                        _questionListControl.SelectedQuestionText = G.Question;
                    }
                }
            }
        }

        private void DeleteQuestionTSMI_Click(object sender, EventArgs e)
        {
            if (_questionListControl.CountItemsSelected == 1)
            {
                if (MessageBox.Show("�������� ������� �� ����� ������ �������� � �������� ����� � ������ �� ����! ����������", "������� ������ � �������", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (G.ExecSQLiteQuery("DELETE FROM otvet WHERE id_content=" + _questionListControl.SelectedQuestionId.ToString()) &&
                        G.ExecSQLiteQuery("DELETE FROM vopros WHERE id_content=" + _questionListControl.SelectedQuestionId.ToString()))
                    {
                        _questionListControl.RemoveFirstSelectedItem();
                        CountQuestLbl.Text = (Convert.ToInt32(CountQuestLbl.Text)-1).ToString();
                    }
                }
            }
        }

        private void RefreshTSB_Click(object sender, EventArgs e)
        {
            //����� �������� �����
            G.GetTreeNodes(TV1, null, false);
        }

        #region ����� ���������� ������� � �������
        //private void GetQuestionAndAnswer(string DGVSource, string QuestionColName, string ID_ContentColName, string FavoriteDateColumn)
        private void GetQuestionAndAnswer(string id_content)
        {
            if (_richTextBoxToolTip != null)
              _richTextBoxToolTip.Hide();
            G.ExecSQLiteQuery(
                "SELECT v.id_content, v.question, o.answer_rtf, v.favorite_date " +
                "FROM vopros v LEFT JOIN otvet o ON v.id_content = o.id_content WHERE v.id_content='" + id_content.Replace("'", "''") + "'");
            //if (DGVSource.GetType().Name == "DataGridView")
            //{
            //    SelectedPathLbl.Text = ((DataGridView)DGVSource).CurrentRow.Cells[QuestionColName].Value.ToString();
            //    CurrentId_Content = ((DataGridView)DGVSource).CurrentRow.Cells[ID_ContentColName].Value.ToString().Replace("'", "''");
            //}
            //else
            //{
            //    if (listView1.SelectedItems.Count == 1)
            //    {
            //        //SelectedPathLbl.Text = listView1.SelectedItems[0].Text;
            //        //CurrentId_Content = listView1.SelectedItems[0].TagCurrentRow.Cells[ID_ContentColName].Value.ToString().Replace("'", "''");
            //    }
            //}
            //CurrentId_Content = G.ConvertEncoding(CurrentId_Content, 65001, 20127);
            //DGVResultSearch.DataSource = G.DT;
            if (G.DT.Rows.Count == 1)
            {
                splitContainer1.Panel1Collapsed = true;
                splitContainer1.Panel2Collapsed = false;
                try
                {
                    richText.Rtf = G.DT.Rows[0]["answer_rtf"].ToString();
                }
                catch (ArgumentException)
                {
                    richText.Text = G.DT.Rows[0]["answer_rtf"].ToString();
                }
                SelectedPathLbl.Text = G.DT.Rows[0]["question"].ToString();
                ID_ContentTSSL.Text = id_content;
                AddInFavoritesTSB.Checked = !(G.DT.Rows[0]["favorite_date"] == DBNull.Value);
                saveFile.Enabled =
                save.Enabled = false;
                SetCurrentQuestionId();
                //BackBtn.Visible = false;
            }
      
      //CurrentId_Content = G.ConvertEncoding(CurrentId_Content, 20127, 65001);
    }
        #endregion ����� ���������� ������� � �������

        //private void DGVQuestions_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    if (DGVQuestions.Rows.Count > 0)
        //    {
        //        GetQuestionAndAnswer(
        //            DGVQuestions,
        //            "QuestionsColumn",
        //            "ID_ContentColumn",
        //            "QuestionsFavoriteDateColumn");
        //    }
        //    else
        //        MessageBox.Show("� ��������� ������� ��� ��������. �������� ������.");
        //}

        private void ShowAnswerTSMI_Click(object sender, EventArgs e)
        {
          int countItemsTotal = _questionListControl.CountItemsTotal;
          int countItemsSelected = _questionListControl.CountItemsSelected;
          string tag = _questionListControl.SelectedQuestionId.ToString();

          if (countItemsSelected == 1)
          {
            GetQuestionAndAnswer(tag);
            AddRowInHistory(2);
          }
          else if (countItemsTotal == 0)
            MessageBox.Show("� ��������� ������� ��� ��������. �������� ������.");
          else
            MessageBox.Show("�������� ������ �� ������.");
        }

        private string AddSelect(string Sql, string SearchText)
        {
            //SearchText = G.ConvertEncoding(SearchText,65001,20127);
            if (SearchAllRB.Checked)
                Sql += "(LOWER(question) LIKE '%" + SearchText + "%' OR LOWER(answer_txt) LIKE '%" + SearchText + "%')";
            else
                if (SearchQuestRB.Checked)
                    Sql += "(LOWER(question) LIKE '%" + SearchText + "%')";
                else
                    if (SearchAnswRB.Checked)
                        Sql += "(LOWER(COALESCE(answer_txt,answer_rtf)) LIKE '%" + SearchText + "%')";
            return Sql;
        }

        private void SearchBtn_Click(object sender, EventArgs e)
        {
            string Sql = "SELECT v.id_content,v.question,v.favorite_date FROM vopros v LEFT JOIN otvet o ON v.id_content = o.id_content WHERE 0=0 AND ";
            string SearchText = SearchTxtBox.Text.Trim().ToLower().Replace("'", "''");
            //string SearchText = G.ConvertEncoding(SearchTxtBox.Text.Trim().ToLower(), 65001, 65001).Replace("'", "''");
            //MessageBox.Show(SearchText);
            //Clipboard.SetText(SearchText);
            if (SearchText.IndexOf("||") >= 0 ||
                SearchText.IndexOf("&&") >= 0)
            {
                if (SearchText.IndexOf("||") >= 0)
                    Sql = AddSelect(Sql, SearchText.Substring(0, SearchText.IndexOf("||")));
                if (SearchText.IndexOf("&&") >= 0)
                    Sql = AddSelect(Sql, SearchText.Substring(0, SearchText.IndexOf("&&")));
                while (
                    SearchText.IndexOf("||") >= 0 ||
                    SearchText.IndexOf("&&") >= 0)
                {
                    if (SearchText.IndexOf("||") >= 0)
                    {
                        Sql += " OR ";
                        SearchText = SearchText.Substring(SearchText.IndexOf("||") + 2);
                    }
                    if (SearchText.IndexOf("&&") >= 0)
                    {
                        Sql += " AND ";
                        SearchText = SearchText.Substring(SearchText.IndexOf("&&") + 2);
                    }

                }
            }
            Sql = AddSelect(Sql, SearchText);
            G.ExecSQLiteQuery(Sql);
            DGVResultSearch.DataSource = G.DT;
            DGVResultSearch.Columns[QuestionSearchColumn.Name].HeaderText = string.Format("������� �������: {0}", G.DT.Rows.Count);
            searchDown.Enabled = searchUp.Enabled = (G.DT.Rows.Count > 0 && SearchTxtBox.Text.Length > 0);
        }

        private void DGVResultSearch_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DGVResultSearch.Rows.Count > 0)
            {
                GetQuestionAndAnswer(DGVResultSearch.CurrentRow.Cells["id_content_search"].Value.ToString());
                AddRowInHistory(2);
            }
        }
    
        private void AddInFavoritesTSB_Click(object sender, EventArgs e)
        {
            if (AddInFavoritesTSB.Checked)
            {
                G.ExecSQLiteQuery(
                    "UPDATE vopros SET favorite_date='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "'" +
                    "WHERE id_content='" + ID_ContentTSSL.Text.Replace("'", "''") + "'");
            }
            else
            {
                G.ExecSQLiteQuery(
                    "UPDATE vopros SET favorite_date=null " +
                    "WHERE id_content='" + ID_ContentTSSL.Text.Replace("'", "''") + "'");
            }
            if (TabControl.SelectedTab == TabControl.TabPages["FavoritesTP"])
            {
                GetFavoritesQuestions();
            }
        }

        private void GetFavoritesQuestions()
        {
            G.ExecSQLiteQuery(
                        "SELECT id_content, question, favorite_date " +
                        "FROM vopros " +
                        "WHERE favorite_date IS NOT NULL " +
                        "ORDER BY favorite_date DESC");
            FavoriteDGV.DataSource = G.DT;
        }

        private void TabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (TabControl.SelectedTab.Name)
            {
                case "FavoritesTP":
                    GetFavoritesQuestions();
                    break;
                case "JournalTP":
                    G.ExecSQLiteQuery(
                       "SELECT id_content, question,favorite_date " +
                       "FROM vopros ORDER BY COALESCE(modif_date,create_date) DESC LIMIT 50");
                    JournalDGV.DataSource = G.DT;
                    break;
            }
        }

        private void FavoriteDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (FavoriteDGV.Rows.Count > 0)
            {
                GetQuestionAndAnswer(FavoriteDGV.CurrentRow.Cells["Favorites_id_content"].Value.ToString());
                AddRowInHistory(2);
            }
        }

        private void JournalDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (JournalDGV.Rows.Count > 0)
            {
                GetQuestionAndAnswer(JournalDGV.CurrentRow.Cells["JournalIdColumn"].Value.ToString());
                AddRowInHistory(2);
        // save the right cursor for later
        
            // ����������� ������ � ���������� DetectUrl
        //this.defaultRichTextBoxCursor = richText.Cursor;

        //// Output some sample text, some of which contains
        //// the trigger string (HOT_TEXT)
        //richText.SelectionFont = new Font("Calibri", 11, FontStyle.Underline);
        //richText.SelectionColor = Color.Blue;
        //// output "click here" with blue underlined font
        //richText.SelectedText = HOT_TEXT + "\n";

        //richText.SelectionFont = new Font("Calibri", 11, FontStyle.Regular);
        //richText.SelectionColor = Color.Black;
        //richText.SelectedText = "Some regular text";
      }
        }

        private void ChangeNameCategoryTSMI_Click(object sender, EventArgs e)
        {
            if (TV1.SelectedNode != null)
            {
                string Category = TV1.SelectedNode.Text;
                if (G.InputBox("�������������� �������", "������������ �������", ref Category) == DialogResult.OK)
                {
                    //Category = G.ConvertEncoding(Category,65001,20127);
                    if (G.ExecSQLiteQuery(
                        "UPDATE category " +
                        "SET name_category='" + Category + "' " +
                        "WHERE id_category='" + TV1.SelectedNode.Name.Replace("'", "''") + "'"))
                        TV1.SelectedNode.Text = Category;
                }
            }
            else
                MessageBox.Show("�������� ������ �� ������");
        }

        private void TV1_ItemDrag(object sender, ItemDragEventArgs e)
        {
            // Move the dragged node when the left mouse button is used.
            if (e.Button == MouseButtons.Left)
            {
                //����� �������� ������������ �����.
                Timer1.Enabled = true;
                TreeNode aNode = (TreeNode)e.Item;
                StartNode = new TreeNode();
                StartNode.Text = aNode.Text;
                StartNode.Tag = aNode.Tag;

                StartNode = aNode;
                DoDragDrop(aNode, DragDropEffects.Copy);
            }
        }
        
        private void TV1_MouseDown(object sender, MouseEventArgs e)
        {
            Point pt = new Point(e.X, e.Y);
            TV1.SelectedNode = ((TreeView)sender).GetNodeAt(pt);
        }

        private void TV1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

    private void ResetTNDragOver(bool SelectTNDragOver)
    {
      if (TNDragOver != null)
      {
        TNDragOver.BackColor = TV1.BackColor;
        if (SelectTNDragOver)
          TV1.SelectedNode = TNDragOver;
        TNDragOver = null;
        DGVQuestionsDrag = false;
      }
    }

        private void TV1_DragDrop(object sender, DragEventArgs e)
        {
            Timer1.Enabled = false;
            // Retrieve the client coordinates of the drop location.
            Point targetPoint = TV1.PointToClient(new Point(e.X, e.Y));

            // Retrieve the node at the drop location.
            TreeNode targetNode = TV1.GetNodeAt(targetPoint);

            if (StartNode != null &&
                targetNode!= null)
            {
                // Retrieve the node that was dragged.
                TreeNode draggedNode = (TreeNode)e.Data.GetData(typeof(TreeNode));

                // Confirm that the node at the drop location is not 
                // the dragged node or a descendant of the dragged node.
                if (!draggedNode.Equals(targetNode) && !ContainsNode(draggedNode, targetNode))
                {
                    // If it is a move operation, remove the node from its current 
                    // location and add it to the node at the drop location.
                    if (MessageBox.Show("����������� ������ '" + draggedNode.Text + "' � '" + targetNode.Text + "'?", "������������� ����������� �������", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        StringBuilder sbSql = new StringBuilder();
                        sbSql.AppendLine(string.Format("UPDATE category SET parent_category='{0}' WHERE id_category='{1}';"
                          , targetNode.Name.Replace("'", "''")
                          , draggedNode.Name.Replace("'", "''")));
                        sbSql.AppendLine(GetUpdateCategoryCountChildSql(targetNode.Name.Replace("'", "''")));
                        if (G.ExecSQLiteQuery(sbSql.ToString()))
                        {
                            StartNode.Remove();
                            //targetNode.Nodes.Clear();
                            //targetNode.Nodes.Add("null","null");
                            targetNode.Nodes.Add(StartNode);
                            targetNode.Expand();
                        }
                        ResetTNDragOver(true);  //����� ������������ ����
                    }
                    else
                        ResetTNDragOver(false);  //����� ������������ ����
                }
                else
                    ResetTNDragOver(false);  //����� ������������ ����
            }
            else
                if (!DGVQuestionsDrag)
                {
                    if (MessageBox.Show("����������� ������ '" + SelectedPathLbl.Text + "' � ������ '" + targetNode.Text + "'?", "������������� ����������� �������", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        G.ExecSQLiteQuery("UPDATE vopros SET id_category='" + targetNode.Name.Replace("'", "''") + "' WHERE id_content='" + ID_ContentTSSL.Text.Replace("'", "''") + "'");
                        ResetTNDragOver(true);  //����� ������������ ����
                    }
                    else
                        ResetTNDragOver(false);  //����� ������������ ����
                }
                else
                {
                    if (_questionListControl.CountItemsSelected==1 &&
                        targetNode != null &&
                        MessageBox.Show("����������� ������ '" + _questionListControl.SelectedQuestionText + "' � ������ '" + targetNode.Text + "'?", "������������� ����������� �������", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        G.ExecSQLiteQuery("UPDATE vopros SET id_category='" + targetNode.Name.Replace("'", "''") + "' WHERE id_content='" + _questionListControl.SelectedQuestionId.ToString().Replace("'", "''") + "'");
                        ResetTNDragOver(true);  //����� ������������ ����
                    }
                    else
                        ResetTNDragOver(false);  //����� ������������ ����
                }
        }

        TreeNode TNDragOver;
        private void TV1_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Link;

            //���������� ��� ����� � ��������� ����������.

            int top_y = this.Top + 30;//30 - ������ ��������� �����.
            int top_x = this.Left;

            //������ �����.

            if (e.Y < 150 + top_y)
            {
                Timer1.Interval = 100;
                tree_go_up = true;
                tree_go_down = false;
            }
            if (e.Y < 100 + top_y)
            {
                Timer1.Interval = 50;
                tree_go_up = true;
                tree_go_down = false;
            }
            if (e.Y < 50 + top_y)
            {
                Timer1.Interval = 25;
                tree_go_up = true;
                tree_go_down = false;
            }

            //������ ����.
            if (e.Y > TV1.Height - 150)
            {
                Timer1.Interval = 100;
                tree_go_up = false;
                tree_go_down = true;
            }
            if (e.Y > TV1.Height - 100)
            {
                Timer1.Interval = 50;
                tree_go_up = false;
                tree_go_down = true;
            }
            if (e.Y > TV1.Height - 50)
            {
                Timer1.Interval = 25;
                tree_go_up = false;
                tree_go_down = true;
            }

            //���� ������!
            if (e.Y < TV1.Height - 150)
            {
                tree_go_down = false;
            }
            if (e.Y > 150 + top_y)
            {
                tree_go_up = false;
            }

            e.Effect = DragDropEffects.Copy;
            // Retrieve the client coordinates of the drop location.
            Point targetPoint = TV1.PointToClient(new Point(e.X, e.Y));

            // Retrieve the node at the drop location.
            TreeNode TN = TV1.GetNodeAt(targetPoint);

            if (TNDragOver != TN &&
                TN!=null)
            {
                if (TNDragOver!=null)
                    TNDragOver.BackColor = TV1.BackColor;
                TNDragOver = TN;
                TNDragOver.BackColor = System.Drawing.Color.LimeGreen;
                TNDragOver.Expand();
            }

            //TreeNode hoveringNode = ((TreeView)sender).GetNodeAt(new Point(e.X, e.Y));
            //TreeNode draggingNode = e.Data.GetData(typeof(TreeNode)) as TreeNode;
            //if (hoveringNode != null && hoveringNode != draggingNode && draggingNode != hoveringNode.Parent)
            //{
            //    e.Effect = DragDropEffects.Move;
            //    hoveringNode.TreeView.SelectedNode = hoveringNode;
            //}
            //else
            //{
            //    e.Effect = DragDropEffects.None;
            //}

            // Retrieve the client coordinates of the mouse position.
            //Point targetPoint = TV1.PointToClient(new Point(e.X, e.Y));

            // Select the node at the mouse position.
            //TV1.SelectedNode = TV1.GetNodeAt(targetPoint);
        }

        private bool ContainsNode(TreeNode node1, TreeNode node2)
        {
            // Check the parent node of the second node.
            if (node2.Parent == null) return false;
            if (node2.Parent.Equals(node1)) return true;

            // If the parent node is not null or equal to the first node, 
            // call the ContainsNode method recursively using the parent of 
            // the second node.
            return ContainsNode(node1, node2.Parent);
        }

        private void SelectedPathLbl_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void JournalTSMI_Click(object sender, EventArgs e)
        {
            TabControl.SelectedTab = TabControl.TabPages["JournalTP"];
        }

        private void SearchTSMI_Click(object sender, EventArgs e)
        {
            TabControl.SelectedTab = TabControl.TabPages["SearchTP"];
        }

        private void SelectedPathLbl_MouseDown(object sender, MouseEventArgs e)
        {
            if (!splitContainer1.Panel2Collapsed && e.Button == MouseButtons.Left)
            {
                if (e.Clicks == 2)
                {
                        G.Question = SelectedPathLbl.Text;
                        if (G.InputBox("�������������� �������", "������������ �������", ref G.Question) == DialogResult.OK)
                        {
                            //G.Question = G.ConvertEncoding(G.Question,65001,20127);
                            if (G.ExecSQLiteQuery(
                                "UPDATE vopros " +
                                "SET question='" + G.Question.Replace("'", "''") + "' " +
                                "WHERE id_content='" + ID_ContentTSSL.Text.Replace("'", "''") + "'"))
                            {
                                //G.Question = G.ConvertEncoding(G.Question, 20127, 65001);
                                SelectedPathLbl.Text = G.Question;
                            }
                        }
                }
                else
                {
                    StartNode = null;
                    DoDragDrop(SelectedPathLbl.Text, DragDropEffects.Copy);
                }
            }
        }

        private void TV1_DragLeave(object sender, EventArgs e)
        {
            if (TNDragOver != null)
            {
                TNDragOver.BackColor = TV1.BackColor;
                TV1.SelectedNode = TNDragOver;
                TNDragOver = null;
            }
        }

        private void LastQuestionsTSMI_Click(object sender, EventArgs e)
        {
            LastQuestions();

        }

        private void AddInFavoritesTSB_CheckedChanged(object sender, EventArgs e)
        {
            if (AddInFavoritesTSB.Checked)
                AddInFavoritesTSB.Text = "������ �� ����������";
            else
                AddInFavoritesTSB.Text = "�������� � ���������";
        }

    public void SetStatusLabel(string message)
    {
      string currentTime = DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss");
      this.Invoke((MethodInvoker)delegate
      {
        tsslStatus.Text = string.Format("{0} - {1}", currentTime, message);
      });
    }

        private void CreateBackupTSMI_Click(object sender, EventArgs e)
        {
          SetStatusLabel("��������� ��������� ����� ��");
          string currentTime = DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss");
          string err;
          if (G.CreateBackup(this, out err))
          {
            SetStatusLabel("�������� �������� ��������� ����� ��");
          }
          else
          {
            SetStatusLabel(err);
            MessageBox.Show("������ �������� ��������� ����� ��", err, MessageBoxButtons.OK, MessageBoxIcon.Error);
          }
        }

        private void QuestionsCMS_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            AddQuestionTSMI.Enabled = (SelectedId_Razdel != null);
            ShowAnswerTSMI.Enabled = (_questionListControl.CountItemsSelected == 1);
            EditQuestionTSMI.Enabled = (_questionListControl.CountItemsSelected == 1);
            DeleteQuestionTSMI.Enabled = (_questionListControl.CountItemsSelected == 1);
            //QuestionsCMS.Enabled = (listView1.SelectedItems.Count == 1);
        }

        private void TV1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (splitContainer1.Panel2Collapsed == false)
                NodeSelect(TV1.SelectedNode);
                //TV1_AfterSelect(sender, new TreeViewEventArgs(e.Node));
        }

        private void DGVQuestions_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Clicks == 2)
            {
                if (_questionListControl.CountItemsSelected==1)
                {
                    GetQuestionAndAnswer(_questionListControl.SelectedQuestionId.ToString());
                }
                else
                    MessageBox.Show("� ��������� ������� ��� ��������. �������� ������.");
            }
            else
                if (e.Button == MouseButtons.Left)
                {
                    TabControl.SelectedTab = TabControl.TabPages["CategoriesTP"];
                    DGVQuestionsDrag = true;
                    StartNode = null;
                    DoDragDrop(SelectedPathLbl.Text, DragDropEffects.Copy);
                }
        }

    private void CheckAndSaveDocument()
    {
      if (ModalDialogForSelectQuestion)
        return;
      if (saveFile.Enabled)
      {
        if (MessageBox.Show("��������� ��������� ������ �� ������?", "������������� ����������",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
        {
          SaveAnswerToDB();
        }
      }
    }

        private void splitContainer1_Panel2_Leave(object sender, EventArgs e)
        {
          CheckAndSaveDocument();
        }

        private void ASCII_TSMI_Click(object sender, EventArgs e)
        {
            if (richText.SelectedText.Length > 0)
            {
                if (MessageBox.Show("�������������� ���������� ����� �� WIN1252 � WIN1251?", "������������� ���������������",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    var fromEncodind = Encoding.GetEncoding(1252);//�� ����� ���������
                    var bytes = fromEncodind.GetBytes(richText.SelectedText);
                    var toEncoding = Encoding.GetEncoding(1251);//� ����� ���������
                    richText.SelectedText = toEncoding.GetString(bytes);
                }
            }
            else
                if (MessageBox.Show("�������������� ����� �� WIN1252 � WIN1251?", "������������� ���������������",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    var fromEncodind = Encoding.GetEncoding(1252);//�� ����� ���������
                    var bytes = fromEncodind.GetBytes(richText.Text);
                    var toEncoding = Encoding.GetEncoding(1251);//� ����� ���������
                    richText.Text = toEncoding.GetString(bytes);
                }
        }

        private void SearchCategoryBtn_Click(object sender, EventArgs e)
        {

        }

        private void ����ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string FromCode = "65001";
            string ToCode = "1251";
            G.InputBox("FromCodePage","�����1", ref FromCode);
            G.InputBox("ToCodePage", "�����2", ref ToCode);
            richText.Text = G.ConvertEncoding(richText.Text, Convert.ToInt32(FromCode), Convert.ToInt32(ToCode));
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            if (richText == null)
              return;
            if (this.Width - TabControl.Width - 50>50)
                richText.RightMargin = this.Width - TabControl.Width - 50;
            else
                richText.RightMargin =20;
        }

        public void listView1_MouseDown(object sender, MouseEventArgs e)
        {
          if (e.Clicks == 2)
          {
            if(_questionListControl.CountItemsTotal > 0)
              ShowAnswerTSMI_Click(sender, new EventArgs());
          }
          else
          {
            int countItemsSelected = _questionListControl.CountItemsSelected;
                if (e.Button == MouseButtons.Left && countItemsSelected == 1)
            {
              TabControl.SelectedTab = TabControl.TabPages["CategoriesTP"];
              DGVQuestionsDrag = true;
              StartNode = null;
              DoDragDrop(SelectedPathLbl.Text, DragDropEffects.Copy);
            }
          }
        }

        private void BackBtn_Click(object sender, EventArgs e)
        {
            btnNextQuestion.Visible = true;
            btnNextQuestion.BackColor = SelectedPathLbl.BackColor;
            CurTransitionRow -= 1;
            if (CurTransitionRow == 0)
                BackBtn.Visible = false;
            //else
            //    CurTransitionRow -= 1;
            //BackBtn.Visible = false;
            //SelectedPathLbl.Text = listView1.Tag.ToString();

            switch (TransitionDT.Rows[CurTransitionRow]["type"].ToString())
            {
                case "0":
                    TV1.SelectedNode = null;
                    LastQuestions();    //��������� ����������� �������
                    break;
                case "1":
                    //TV1.SelectedNode = (TreeNode)TransitionDT.Rows[CurTransitionRow]["TN"];
                    NodeSelect((TreeNode)TransitionDT.Rows[CurTransitionRow]["TN"]);
                    break;
                case "2":
                    TV1.SelectedNode = null;
                    GetQuestionAndAnswer(TransitionDT.Rows[CurTransitionRow]["id"].ToString());
                    break;
            }
        }

    public void listView1_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (_questionListControl.CountItemsSelected == 1)
      {
        CountQuestionsVal.Text = _questionListControl.SelectedIndex.ToString() + " �� " +
                                 _questionListControl.CountItemsTotal.ToString();
      }
      else
      {
        CountQuestionsVal.Text = _questionListControl.CountItemsTotal.ToString();
      }
    }

    private void SortAscTSMI_Click(object sender, EventArgs e)
    {
      lastOrderByDesc = false;
      SortAscTSMI.Visible = false;
      SortDescTSMI.Visible = true;
      _questionListControl.Sorting = SortOrder.Ascending;
      _settingsXml.SetSetting(Constants.LAST_SORTING, SortOrder.Ascending.ToString());
    }

    private void SortDescTSMI_Click(object sender, EventArgs e)
    {
      lastOrderByDesc = true;
      SortAscTSMI.Visible = true;
      SortDescTSMI.Visible = false;
      _questionListControl.Sorting = SortOrder.Descending;
      _settingsXml.SetSetting(Constants.LAST_SORTING, SortOrder.Descending.ToString());
    }

        private void AddRowInHistory(int type)
        {
            //int i = TransitionDT.Rows.Count;
            while (CurTransitionRow+1 < TransitionDT.Rows.Count)
            //for (int i = CurTransitionRow + 1; i < TransitionDT.Rows.Count; i++)
            {
                TransitionDT.Rows.RemoveAt(TransitionDT.Rows.Count-1);
                btnNextQuestion.Visible = false;
            }
            switch (type)
            {
                case 0: // ��������� ����������� �������
                    TransitionDT.Rows.Add(type, "", null);
                    break;
                case 1: // TreeNode
                    TransitionDT.Rows.Add(type, TV1.SelectedNode.Tag.ToString(), TV1.SelectedNode);
                    break;
                case 2: // ������
                    TransitionDT.Rows.Add(type, ID_ContentTSSL.Text, null);
                    break;
            }
            
            CurTransitionRow += 1;
            BackBtn.Visible = true;
            BackBtn.BackColor = SelectedPathLbl.BackColor;
        }

        #region ����������� ����� �������� �������� (DelRazdelyRecursive)
        private void DelRazdelyRecursive(TreeNode TN)
        {
            if (G.ExecSQLiteQuery("DELETE FROM otvet WHERE id_content IN (SELECT id_content FROM vopros WHERE id_category=" + TN.Name+")") &&
                G.ExecSQLiteQuery("DELETE FROM vopros WHERE id_category=" + TN.Name) &&
                G.ExecSQLiteQuery("DELETE FROM category WHERE id_category='" + TN.Name.Replace("'", "''") + "'"))
            {
                foreach (TreeNode TNChild in TN.Nodes)
                {
                    DelRazdelyRecursive(TNChild);
                }
            }
        }
        #endregion ����������� ����� �������� �������� (DelRazdelyRecursive)

        #region �������� �������� �� ���� ����������
        private void DelRazdelTSMI_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("������� ������ ������ � ����������?", "�������� �������", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes &&
                MessageBox.Show("������ ������ � ����������� �� ��������� ��� ���������, ����������� ��� ���?", "�������� �������", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                DelRazdelyRecursive(TV1.SelectedNode);  //�������� ���������� ������� � ���� �����������
                RefreshCountQuestAndAnswers();          //������� ���-�� ������� � ��������
                if (TV1.SelectedNode.Parent != null)
                {
                    G.ExecSQLiteQuery(GetUpdateCategoryCountChildSql(TV1.SelectedNode.Parent.Name));
                    TV1.SelectedNode.Parent.Tag = (TV1.SelectedNode.Nodes.Count - 1).ToString();
                }
                TV1.SelectedNode.Remove();
                _questionListControl.ClearItems();
                if (TV1.Nodes.Count > 0)
                {
                    TV1.SelectedNode = null;
                    SelectedPathLbl.Text = string.Empty;
                    CountSubcategoryVal.Text = "0";
                    CountQuestionsVal.Text = "0";
                    //NodeSelect(TV1.Nodes[0]);
                    //TV1_AfterSelect(sender, new TreeViewEventArgs(TV1.Nodes[0]));
                }
            }
        }
        #endregion �������� �������� �� ���� ����������

        /// <summary>
        /// �������� ���-�� ������������
        /// </summary>
        /// <param name="idCategory">���������, � ������� ����� �������� ���������� ������������</param>
        private string GetUpdateCategoryCountChildSql(string idCategory)
        {
          return "UPDATE category SET count_child = (SELECT count(*) FROM category c WHERE c.parent_category = category.id_category) where id_category=" + idCategory;
        }

        private void CategoriesContextMenu_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            CreateQuestionTSMI.Enabled = 
                CreateSubcategoryTSMI.Enabled = 
                DelRazdelMainTSMI.Enabled =
                ChangeNameCategoryTSMI.Enabled =
                (TV1.SelectedNode != null);
        }

        TreeNode TN_ReplaceRazdel;
        Form DelRazdelWithReplaceForm;
        private void DelRazdelWithReplaceTSMI_Click(object sender, EventArgs e)
        {
            DelRazdelWithReplaceForm = new Form();
            //TreeView TVCopy = new TreeView();
            DelRazdelWithReplaceForm.Name = "ReplaceRazdelForm";
            DelRazdelWithReplaceForm.Text = "�������� ������� � ������������";

            //G.GetTreeNodes(TVCopy, null);
            TV1.ContextMenuStrip = null;

            //���������� �������
            TV1.MouseDown -= TV1_MouseDown;
            TV1.AfterSelect -= TV1_AfterSelect;

            TV1.AllowDrop = false;
            DelRazdelWithReplaceForm.Controls.Add(TV1);

            //����� � ������������
            Label TitleLbl = new Label();
            TitleLbl.Text = "������� ������� "+TV1.SelectedNode.Text+" �:";
            TitleLbl.Dock = DockStyle.Top;
            DelRazdelWithReplaceForm.Controls.Add(TitleLbl);

            //������ ������������� �����������
            Button Btn = new Button();
            Btn.Text = "������� � ������������";
            Btn.Dock = DockStyle.Bottom;
            Btn.Click += new EventHandler(DelRazdelWithReplace_Click);
            DelRazdelWithReplaceForm.Controls.Add(Btn);

            DelRazdelWithReplaceForm.FormClosing += new FormClosingEventHandler(ReplaceRazdelForm_FormClosing);
            //MainSC.Panel1Collapsed = true;
            TN_ReplaceRazdel = TV1.SelectedNode;
            DelRazdelWithReplaceForm.ShowDialog();
        }

        #region �������� ������� � ������������ ����������� (DelRazdelWithReplace_Click)
        private void DelRazdelWithReplace_Click(object sender, EventArgs e)
        {
            //�������� �� ������
            if (TV1.SelectedNode == null)
            {
                MessageBox.Show("�������� ������ ��� �����������", "������", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            //�������� �� ����������
            if (TV1.SelectedNode == TN_ReplaceRazdel)
            {
                MessageBox.Show("������ ����������� ��������� ������ � ����", "������", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            //�������� �� �������� ����
            TreeNode TNParent = TV1.SelectedNode.Parent;
            while (TNParent!=null)
            {
                if (TNParent==TN_ReplaceRazdel)
                {
                    MessageBox.Show("������ ����������� ��������� ������ � �������� ����","������",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    return;
                }
                TNParent = TNParent.Parent;
            }
            //�������� � ������������
            #region 
            if (G.ExecSQLiteQuery("UPDATE category SET parent_category='" + TV1.SelectedNode.Name.Replace("'", "''") + "' WHERE parent_category='" + TN_ReplaceRazdel.Name.Replace("'", "''") + "'") &&
                G.ExecSQLiteQuery("UPDATE vopros SET id_category='" + TV1.SelectedNode.Name.Replace("'", "''") + "' WHERE id_category='" + TN_ReplaceRazdel.Name.Replace("'","''") + "'") &&
                G.ExecSQLiteQuery("DELETE FROM category WHERE id_category='"+TN_ReplaceRazdel.Name.Replace("'","''")+"'"))
            {
                G.GetTreeNodes(TV1, TV1.SelectedNode, true);    //������������ �����
                NodeSelect(TV1.SelectedNode);
                CountSubcategoryVal.Text = TV1.SelectedNode.Nodes.Count.ToString();
                TN_ReplaceRazdel.Remove();
                DelRazdelWithReplaceForm.Close();
            }
            #endregion
        }
        #endregion �������� ������� � ������������ ����������� (DelRazdelWithReplace_Click)

        private void ReplaceRazdelForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            TV1.Parent = CategoriesTP;
            TV1.Dock = DockStyle.Fill;
            TV1.BringToFront();
            TV1.ContextMenuStrip = CategoriesContextMenu;
            
            //��������� �������
            TV1.MouseDown += TV1_MouseDown;
            TV1.AfterSelect += TV1_AfterSelect;
            TV1.AllowDrop = true;
            //MainSC.Panel1Collapsed = false;
        }

        private void SearchTxtBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
                SearchBtn_Click(sender, e);
        }

        private void tsmiGridView_Click(object sender, EventArgs e)
        {
          _questionListControl = _questionDgvControl;
          _questionListViewControl.Visible = false;
          _questionDgvControl.Visible = true;
          _questionListControl.AddQuestionsIntoListControl(true);
          _settingsXml.SetSetting(Constants.LAST_VIEW, _questionListControl.ToString());
          tsmiGridView.Checked = true;
          tsmiListView.Checked = false;
        }

        private void tsmiListView_Click(object sender, EventArgs e)
        {
          _questionListControl = _questionListViewControl;
          _questionListViewControl.Visible = true;
          _questionDgvControl.Visible = false;
          _questionListControl.AddQuestionsIntoListControl(true);
          _settingsXml.SetSetting(Constants.LAST_VIEW, _questionListControl.ToString());
          tsmiGridView.Checked = false;
          tsmiListView.Checked = true;
        }

        private void richMenu_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
          copyRichText.Enabled = (richText.SelectedText.Length > 0);
          cutRichText.Enabled = (richText.SelectedText.Length > 0);
        }

    [DllImport("user32.dll")]
    private static extern short GetAsyncKeyState(Keys vKey);

    private void richText_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.Control)
      {
        //if (_richTextBoxToolTip.synChecking.IsVisible
        // && !string.IsNullOrEmpty(_richTextBoxToolTip.Url))
        //{
        //  //MessageBox.Show("fff");
        //  Cursor = Cursors.Hand;
        //}
        switch (e.KeyCode)
        {
          case Keys.B:
            e.SuppressKeyPress = true;  // Stops other controls on the form receiving event.
            bold.Checked = !bold.Checked;
            Tools_Click(bold, new EventArgs());
            break;
          case Keys.U:
            e.SuppressKeyPress = true;  // Stops other controls on the form receiving event.
            under.Checked = !under.Checked;
            Tools_Click(under, new EventArgs());
            break;
          case Keys.I:
            e.SuppressKeyPress = true;  // Stops other controls on the form receiving event.
            italic.Checked = !italic.Checked;
            Tools_Click(italic, new EventArgs());
            break;
          case Keys.J:
            // ������������ ������ �� ������
            const string JUSTIFIED_ALIGN_RTF = "\\pard\\qj";
              if (richText.SelectedRtf.Length == 0)
                richText.SelectedRtf = @"{\rtf1\qj}";
              else
                richText.SelectedRtf = richText.SelectedRtf
                  .Replace("\\pard\\f0", JUSTIFIED_ALIGN_RTF)
                  .Replace("\\pard\\cf1", JUSTIFIED_ALIGN_RTF)
                  .Replace("\\pard\\ql", JUSTIFIED_ALIGN_RTF)
                  .Replace("\\pard\\qr", JUSTIFIED_ALIGN_RTF)
                  .Replace("\\pard\\qc", JUSTIFIED_ALIGN_RTF);
            break;
          case Keys.F8:
            richText.ReadOnly = true;
            richText.SelectionBackColor = Color.AliceBlue;
            richText.ReadOnly = false;
            if (richText.SelectedText.Length == 0)
              MessageBox.Show("�� ������� �����");
            else
            if (richText.SelectedText.Length > 0)
            {
              using (Form f = new Form())
              {
                TextBox tb = new TextBox();
                tb.Text = richText.SelectedRtf;
                tb.Multiline = true;
                tb.Dock = DockStyle.Fill;
                f.Controls.Add(tb);
                tb.MouseDoubleClick += delegate
                {
                  try
                  {
                    tb.BackColor = Color.White;
                    richText.SelectedRtf = tb.Text;
                  }
                  catch (Exception) { tb.BackColor = Color.LightCoral; }
                };
                f.ShowDialog();
              }
            }
            break;
          case Keys.Space:
            Constants.CtrlSpaceEntered = true;
            Point location = richText.GetPositionFromCharIndex(richText.SelectionStart > 0 ? richText.SelectionStart - 1 : 0);

            Point pt = richText.GetPositionFromCharIndex(richText.SelectionStart);
            pt.Y = (int)Math.Ceiling(richText.Font.GetHeight())+ pt.Y;
            if (pt.Y + _intellisenseUserControl.Height > richText.Height)
              pt.Y = pt.Y - _intellisenseUserControl.Height;
            if (pt.Y < 0)
              pt.Y = 0;
            if (pt.X + _intellisenseUserControl.Width > richText.Width)
              pt.X = pt.X - _intellisenseUserControl.Width;
            if (pt.X < 0)
              pt.X = 0;

            int selectionStart = 0;
            int selectionLength = 0;
            string partWord = GetWordFromCharIndex(location, ref selectionStart, ref selectionLength);
            _intellisenseUserControl.ShowIntellisense(pt, partWord, selectionStart, selectionLength);
            break;
        }
      }
    }

    private string GetWordFromCharIndex(Point location, ref int selectionStart, ref int selectionLength)
    {
      string word = string.Empty;
      try
      {
        int mousePointerCharIndex = richText.GetCharIndexFromPosition(location);

        if (mousePointerCharIndex == 0)
          return word;

        int startWord = mousePointerCharIndex;
        bool firstStep = true;
        while (startWord > 0)
        {
          if (firstStep)
            firstStep = false;
          else
            startWord--;
          //if (richText.Text.Length <= startWord+1)
          string s = richText.Text.Substring(startWord, 1);
          if (s.IndexOfAny(TooltipUserControl.StartOrEndWordChars) >= 0)
          {
            startWord += 1;
            break;
          }
        }
        int endWord = mousePointerCharIndex;
        word = richText.Text.Substring(startWord, endWord - startWord + 1);
        if (word.Length == 1 && word.IndexOfAny(TooltipUserControl.StartOrEndWordChars) >= 0)
          word = string.Empty;
        if (word.Length > 1 && word.Substring(word.Length-1).IndexOfAny(TooltipUserControl.StartOrEndWordChars) >= 0)
          word = word.Substring(0, word.Length - 1);

        // �������� �����, ����� ��� ����������
        while (endWord < richText.Text.Length)
        {
          string s = richText.Text.Substring(endWord, 1);
          if (s.IndexOfAny(TooltipUserControl.StartOrEndWordChars) >= 0)
          {
            break;
          }
          endWord++;
        }
        string checkWord = richText.Text.Substring(startWord, endWord - startWord);
        while (checkWord.EndsWith("."))
        {
          checkWord = checkWord.Remove(checkWord.Length - 1);
          endWord--;
        }
        if (endWord > startWord)
        {
          selectionStart = startWord;
          selectionLength = endWord - startWord;
        }
      }
      catch (Exception) { }
      return word;
    }

    private void tsmiAboutProgram_Click(object sender, EventArgs e)
    {
      using (AboutProgramForm aboutProgramForm = new AboutProgramForm())
      {
        aboutProgramForm.ShowInTaskbar = false;
        aboutProgramForm.ShowDialog();
      }
    }

    private void tsmiDesignSettings_Click(object sender, EventArgs e)
    {
      _appSettingForm.Show();
    }

    private void richText_MouseDown(object sender, MouseEventArgs e)
    {
      if (e.Button == MouseButtons.Left
       && (ModifierKeys & Keys.Control) == Keys.Control)
      {
        // ���� ������������ ���������, �� ���������� ������ ����� � ���� ����������� �� ����� �� �������, �� ��������� �� ������
        if (_richTextBoxToolTip.Visible
         && !string.IsNullOrEmpty(_richTextBoxToolTip.Url)
         && !_richTextBoxToolTip.Title.StartsWith("http://"))
        {
          if (!_richTextBoxToolTip.Title.StartsWith("http://"))
            this.RichText_LinkClicked(sender, new LinkClickedEventArgs(_richTextBoxToolTip.Url));
        }
      }
    }

    private void tsmiDictionary_Click(object sender, EventArgs e)
    {
      // ������� ��������� (� ��������� ������)
      if (_dictionaryEditor.Parent != null)
      {
        _dictionaryEditor.Parent = null;
        splitContainer2.Panel2Collapsed = true;
      }
      else
      {
        splitContainer2.Panel2Collapsed = false;
        _dictionaryEditor.Parent = splitContainer2.Panel2;
        _dictionaryEditor.Dock = DockStyle.Fill;
        int idContent;
        int.TryParse(ID_ContentTSSL.Text, out idContent);
        _dictionaryEditor.RefreshAllData(idContent);
      }
      //richText.InsertLink("������1");
    }

    private void btnSelectQuestion_Click(object sender, EventArgs e)
    {
      int idContent = GetCurrentQuestionId();
      if (idContent == 0)
      {
        MessageBox.Show("�������� ������ �� ������ ��� �������� ���", "�� ������ ������", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        return;
      }
      DialogResult = DialogResult.OK;
    }

    /// <summary>
    /// ������� ��������� ���� ��� ������ �������
    /// </summary>
    public void SetModalDialogForSelectQuestion()
    {
      btnSelectQuestion.Visible = true;
      menuTop.Visible
        = toolsTop.Visible
        = toolStrip1.Visible
        = false;
      CategoriesContextMenu.Parent = null;
      richText.ReadOnly = true;
    }

    private void tsmiSaveNodeSelect_Click(object sender, EventArgs e)
    {
      tsmiSaveNodeSelect.Checked = !tsmiSaveNodeSelect.Checked;
      _settingsXml.SetSetting(Constants.SAVE_SECTION_NODE_SELECT, tsmiSaveNodeSelect.Checked.ToString());
    }

    private void btnNextQuestion_Click(object sender, EventArgs e)
    {
      CurTransitionRow += 1;
      if (TransitionDT.Rows.Count == CurTransitionRow+1)
      {
        btnNextQuestion.Visible = false;
        BackBtn.Visible = true;
        BackBtn.BackColor = SelectedPathLbl.BackColor;
      }

      switch (TransitionDT.Rows[CurTransitionRow]["type"].ToString())
      {
        case "0":
          TV1.SelectedNode = null;
          LastQuestions();    //��������� ����������� �������
          break;
        case "1":
          //TV1.SelectedNode = (TreeNode)TransitionDT.Rows[CurTransitionRow]["TN"];
          NodeSelect((TreeNode)TransitionDT.Rows[CurTransitionRow]["TN"]);
          break;
        case "2":
          TV1.SelectedNode = null;
          GetQuestionAndAnswer(TransitionDT.Rows[CurTransitionRow]["id"].ToString());
          break;
      }
    }

    static void SetRoundedShape(Control control, int radius)
    {
      System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
      path.AddLine(radius, 0, control.Width - radius, 0);
      path.AddArc(control.Width - radius, 0, radius, radius, 270, 90);
      path.AddLine(control.Width, radius, control.Width, control.Height - radius);
      path.AddArc(control.Width - radius, control.Height - radius, radius, radius, 0, 90);
      path.AddLine(control.Width - radius, control.Height, radius, control.Height);
      path.AddArc(0, control.Height - radius, radius, radius, 90, 90);
      path.AddLine(0, control.Height - radius, 0, radius);
      path.AddArc(0, 0, radius, radius, 180, 90);
      control.Region = new Region(path);
    }

    /// <summary>
    /// ���������� �������� �� ������
    /// </summary>
    private void tsbAddImage_Click(object sender, EventArgs e)
    {
      using (OpenFileDialog ofd = new OpenFileDialog())
      {
        ofd.Title = "�������� ����� � ������������� (��������� ��������� ������ ����� ���������� � ������ ����������)";
        ofd.Multiselect = true;
        if (ofd.ShowDialog() == DialogResult.OK)
        {
          Bitmap combineBitmap = EditImageForm.CombineBitmap(ofd.FileNames);
          byte[] bytes = EditImageForm.ImageToByte(combineBitmap);

          if (ofd.FileNames.Length > 0)
          {
            using (EditImageForm editImageForm = new EditImageForm())
            {
              editImageForm.Picture = combineBitmap;
              if (editImageForm.ShowDialog() == DialogResult.OK)
              {
                richText.InsertImage(editImageForm.Picture);
              }
            }
          }
        }
      }
    }

    private void ReplaceFontControlToMenuOrBack()
    {
      if (tsmiReplaceFontControlToMenu.Checked)
      {
        selFont.Alignment
          = size.Alignment
          = zoom.Alignment
          = ToolStripItemAlignment.Right;
        menuTop.Items.Add(zoom);
        menuTop.Items.Add(size);
        menuTop.Items.Add(selFont);
      }
      else
      {
        selFont.Alignment
          = size.Alignment
          = zoom.Alignment
          = ToolStripItemAlignment.Left;
        this.toolsTop.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openFile,
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
            //this.alignJustify,
            this.lineSpacing,
            this.sep7,
            this.bullet,
            this.selectColor,
            this.highLight,
            this.sep8,
            this.tsddbInsertTable,
            this.tsbAddImage,
            this.AddInFavoritesTSB});
      }
    }

    private void tsmiReplaceFontControlToMenu_Click(object sender, EventArgs e)
    {
      tsmiReplaceFontControlToMenu.Checked = !tsmiReplaceFontControlToMenu.Checked;
      _settingsXml.SetSetting(Constants.RTF_COMBOBOX_CONTROLS_REPLACE_TO_MENU, tsmiReplaceFontControlToMenu.Checked.ToString());
      ReplaceFontControlToMenuOrBack();
    }

    private void lblSearchDescription_FontChanged(object sender, EventArgs e)
    {
      SearchTxtBox.Top = label1.Top + label1.Height;
      lblSearchDescription.Top = SearchTxtBox.Top + SearchTxtBox.Height;
      SearchAllRB.Top
        = SearchQuestRB.Top
        = SearchAnswRB.Top
        = lblSearchDescription.Top+ lblSearchDescription.Height;
      
      SearchQuestRB.Left = SearchAllRB.Left + SearchAllRB.Width+3;
      SearchAnswRB.Left = SearchQuestRB.Left + SearchQuestRB.Width+3;
      SearchBtn.Top
        = searchDown.Top
        = searchUp.Top = SearchAnswRB.Top + SearchAnswRB.Height + 5;
      panel1.Height = SearchBtn.Top + SearchBtn.Height+5;
    }

    #endregion ������ / Methods

    private void GlobalSearch(bool down)
    {
      if (DGVResultSearch.Rows.Count == 0)
        return;
      if (splitContainer1.Panel2Collapsed)
        DGVResultSearch_CellClick(null, null);
      bool endSearch = false;
      bool successSearch = false;
      while (!endSearch && !successSearch)
      {
        successSearch = fnd.FindNext(SearchTxtBox, false, down);
        if (successSearch)
          break;
        int nextIndex = down ? 1 : -1;
        if ((down && DGVResultSearch.Rows.Count > DGVResultSearch.CurrentRow.Index + nextIndex)
          || (!down && DGVResultSearch.CurrentRow.Index != 0))
        {
          DGVResultSearch.CurrentCell = DGVResultSearch.Rows[DGVResultSearch.CurrentRow.Index + nextIndex].Cells[DGVResultSearch.CurrentCell.OwningColumn.Name];
          DGVResultSearch_CellClick(null, null);
          if (!down)
            richText.SelectionStart = richText.Text.Length;
          endSearch = fnd.FindNext(SearchTxtBox, false, down);
        }
        else
          endSearch = true;
      }
    }

    private void searchDown_Click(object sender, EventArgs e)
    {
      GlobalSearch(true);
    }

    private void searchUp_Click(object sender, EventArgs e)
    {
      GlobalSearch(false);
    }

    private void SearchTxtBox_TextChanged(object sender, EventArgs e)
    {
      SearchTxtBox.BackColor = Color.White;
      searchDown.Enabled = searchUp.Enabled = false;
    }

    private void tsmiSmoothScrollingDocument_Click(object sender, EventArgs e)
    {
      tsmiSmoothScrollingDocument.Checked = !tsmiSmoothScrollingDocument.Checked;
      _settingsXml.SetSetting(Constants.RTF_SMOOTH_SCROLLING, tsmiSmoothScrollingDocument.Checked.ToString());
      Constants.RtfSmoothScrolling = tsmiSmoothScrollingDocument.Checked;
    }
  }
}
