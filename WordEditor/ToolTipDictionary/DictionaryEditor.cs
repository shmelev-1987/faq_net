using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace FAQ_Net
{
  public partial class DictionaryEditor : UserControl
  {
    private int _oldIdContent;
    private int _currentQuestionId;
    private string _oldWordForSave;
    ToolTip tt = new ToolTip();


    //private const string CATEGORY_PROP_NAME = "Категория";
    //private const string WORD_PROP_NAME = "Слово";
    //private const string TOOLTIP_TYPE_PROP_NAME = "Тип подсказки";
    //private const string TOOLTIP_COMMENT_PROP_NAME = "Текст подсказки";
    //private const string QUESTION_PROP_NAME = "Вопрос";
    //private const string URL_PROP_NAME = "URL-адрес";
    //private const string FORE_COLOR_PROP_NAME = "Цвет шрифта";
    //private const string GROUP_PROP_NAME = "Группа";

    public DictionaryEditor()
    {
      InitializeComponent();

      splitContainer1.Panel1.Controls.Add(TooltipDictionary.TV_Dictionary);
      TooltipDictionary.TV_Dictionary.BringToFront();
      TooltipDictionary.TV_Dictionary.AfterSelect += tvDictionary_AfterSelect;
      // Категории
      cmbCategoryWord.Items.Add(Constants.PUBLIC_DICTIONARY_CATEGORY);
      cmbCategoryWord.Items.Add(Constants.PRIVATE_DICTIONARY_CATEGORY);

      // Типы подсказок
      cmbToolTipType.Items.Add(Constants.TOOLTIPTYPE_0__DB_QUESTION);
      cmbToolTipType.Items.Add(Constants.TOOLTIPTYPE_1_INTERNET_QUESTION);
      cmbToolTipType.Items.Add(Constants.TOOLTIPTYPE_2_STATIC_TEXT);

      splitContainer1.Panel2Collapsed = true;

      cmbForeColor.DrawMode = DrawMode.OwnerDrawFixed;
      cmbForeColor.DropDownStyle = ComboBoxStyle.DropDownList;
      inMargin = 2;
      boxWidth = 3;
      cmbForeColor.BeginUpdate();
      foreach (KnownColor kc in Enum.GetValues(typeof(KnownColor)))
      {
        Color known = Color.FromKnownColor(kc);
        cmbForeColor.Items.Add(known.Name);
      }
      cmbForeColor.EndUpdate();
    }

    private void SetPropertyValues(int idContent, string word, int tooltipType, string comment, string url, string groupName, string foreColor)
    {
      cmbCategoryWord.SelectedIndex = (idContent == 0) ? cmbCategoryWord.Items.IndexOf(Constants.PUBLIC_DICTIONARY_CATEGORY) : cmbCategoryWord.Items.IndexOf(Constants.PRIVATE_DICTIONARY_CATEGORY);
      txbWord.Text = word;
      cmbToolTipType.SelectedIndex = tooltipType;
      txbComment.Text = comment;
      txbQuestion.Text = string.Empty;
      txbUrl.Text = url;
      if (tooltipType == (int)TooltipDictionary.TooltipType.QuestionHref
        && MainForm.IdContentUrlRegEx.IsMatch(url))
      {
        txbQuestion.Text = url.Substring(7);
      }
      cmbForeColor.SelectedIndex = -1;
      cmbForeColor.Text = foreColor;
      cmbGroup.Text = groupName;
      //int categoryPropertyIndex = propertyGridEx1.Item.FindItem(CATEGORY_PROP_NAME);
      //propertyGridEx1.Item[categoryPropertyIndex].Value = (idContent == 0) ? Constants.PUBLIC_DICTIONARY_CATEGORY: Constants.PRIVATE_DICTIONARY_CATEGORY;

    }

    private void SetDefaultProperty()
    {
      SetPropertyValues(0, string.Empty, 0, string.Empty, string.Empty, string.Empty, "Black");
      //int categoryPropertyIndex = propertyGridEx1.Item.FindItem(CATEGORY_PROP_NAME);
      //propertyGridEx1.Item[categoryPropertyIndex].Value = Constants.PUBLIC_DICTIONARY_CATEGORY;

      //int categoryPropertyIndex = propertyGridEx1.Item.Add(CATEGORY_PROP_NAME, Constants.PUBLIC_DICTIONARY_CATEGORY, false, "Обязательные свойства", CATEGORY_PROP_NAME, true);
      //propertyGridEx1.Item[categoryPropertyIndex].Choices = new PropertyGridEx.CustomChoices(new string[] { Constants.PUBLIC_DICTIONARY_CATEGORY, Constants.PRIVATE_DICTIONARY_CATEGORY });
    }

    public void RefreshAllData(int idContent)
    {
      if (TooltipDictionary.TV_Dictionary.Nodes.Count == 0)
      {
        TooltipDictionary.TV_Dictionary.Nodes.Clear();
        TreeNode publicNode = TooltipDictionary.TV_Dictionary.Nodes.Add(Constants.PUBLIC_DICTIONARY_CATEGORY, Constants.PUBLIC_DICTIONARY_CATEGORY);
        TreeNode privateNode = TooltipDictionary.TV_Dictionary.Nodes.Add(Constants.PRIVATE_DICTIONARY_CATEGORY, Constants.PRIVATE_DICTIONARY_CATEGORY);
        if (G.ExecSQLiteQuery(string.Format("select id_content,word,tooltip_type,comment,url_adr,case when group_name='' then '{0}' else group_name end as group_name, fore_color from word_tooltip where id_content in (0,{1})"
          , Constants.WithoutGroup, idContent)))
        {
          foreach (DataRow row in G.DT.Rows)
          {
            AddNode(Convert.ToInt32(row[TooltipDictionary.ID_CONTENT])
              , row[TooltipDictionary.GROUP_NAME].ToString()
              , row[TooltipDictionary.WORD].ToString()
              , row[TooltipDictionary.FORE_COLOR].ToString()
              , false
              , publicNode
              , privateNode);
            if (cmbGroup.Items.IndexOf(row[TooltipDictionary.GROUP_NAME].ToString()) == -1)
              cmbGroup.Items.Add(row[TooltipDictionary.GROUP_NAME].ToString());
          }
          if (privateNode.Nodes.Count == 0)
            TooltipDictionary.TV_Dictionary.Nodes.Remove(privateNode);
        }
      }
      else
      {
        RefreshPrivateNode(idContent);
      }
    }

    private void AddGroupName(string groupName)
    {
      if (cmbGroup.Items.IndexOf(groupName) == -1)
        cmbGroup.Items.Add(groupName);
    }

    public static void AddNode(int idContent, string groupName, string title
      //, string description, string url, TooltipDictionary.TooltipType tooltipType
      , string foreColor, bool selectNodeAfterCreate = false, TreeNode publicNode = null, TreeNode privateNode = null)
    {
      if (publicNode == null)
        publicNode = TooltipDictionary.TV_Dictionary.Nodes[Constants.PUBLIC_DICTIONARY_CATEGORY];
      if (privateNode == null)
        privateNode = TooltipDictionary.TV_Dictionary.Nodes[Constants.PRIVATE_DICTIONARY_CATEGORY];
      if (idContent > 0 && privateNode == null)
        privateNode = TooltipDictionary.TV_Dictionary.Nodes.Add(Constants.PRIVATE_DICTIONARY_CATEGORY, Constants.PRIVATE_DICTIONARY_CATEGORY);
      TreeNode categoryNode = (idContent == 0) ? publicNode : privateNode;
      TreeNode groupNode = null;
      if (string.IsNullOrEmpty(groupName))
        groupName = Constants.WithoutGroup;
      int groupIndex = categoryNode.Nodes.IndexOfKey(groupName);
      if (groupIndex == -1)
        groupNode = categoryNode.Nodes.Add(groupName, groupName);
      else
        groupNode = categoryNode.Nodes[groupIndex];
      TreeNode wordNode = null;
      if (idContent == 0)
        wordNode = groupNode.Nodes.Add("0", title);
      else
        wordNode = groupNode.Nodes.Add(idContent.ToString(), title);
      if (wordNode.Level == 2)
        wordNode.ForeColor = Color.FromName(foreColor);
      if (selectNodeAfterCreate)
        TooltipDictionary.TV_Dictionary.SelectedNode = wordNode;
      //if (cmbForeColor.Items.IndexOf(row[TooltipDictionary.FORE_COLOR].ToString()) < 0)
      //  cmbForeColor.Items.Add(row[TooltipDictionary.FORE_COLOR].ToString());
    }

    public void RefreshPrivateNode(int idContent)
    {
      TreeNode privateNode = TooltipDictionary.TV_Dictionary.Nodes[Constants.PRIVATE_DICTIONARY_CATEGORY];
      if (privateNode != null)
        privateNode.Remove();
      if (idContent == 0)
        return;
      privateNode = TooltipDictionary.TV_Dictionary.Nodes.Add(Constants.PRIVATE_DICTIONARY_CATEGORY, Constants.PRIVATE_DICTIONARY_CATEGORY);
      if (G.ExecSQLiteQuery(string.Format("select id_content,word,tooltip_type,comment,url_adr,case when group_name='' then '{0}' else group_name end as group_name, fore_color from word_tooltip where id_content in ({1})"
        , Constants.WithoutGroup, idContent)))
      {
        foreach (DataRow row in G.DT.Rows)
        {
          AddNode(Convert.ToInt32(row[TooltipDictionary.ID_CONTENT])
            , row[TooltipDictionary.GROUP_NAME].ToString()
            , row[TooltipDictionary.WORD].ToString()
            , row[TooltipDictionary.FORE_COLOR].ToString()
            , false
            , null
            , privateNode);
          AddGroupName(row[TooltipDictionary.GROUP_NAME].ToString());
        }
        if (privateNode.Nodes.Count == 0)
          TooltipDictionary.TV_Dictionary.Nodes.Remove(privateNode);
      }
      //foreach (string S_Type in Types)
      //{
      //  TreeNode TN = null;
      //  if (S_TypeCmbBox.Items.IndexOf(S_Type) < 0)
      //  {
      //    S_TypeCmbBox.Items.Add(S_Type);
      //    TN = TV.Nodes.Add(S_Type, S_Type);
      //  }
      //  if (TN == null)
      //    TN = TV.Nodes[S_Type];
      //  TN.Nodes.Clear();
      //  DataTable dtSqlOperators = Global.SQLiteServiceConn.SelectSqlOperators(S_Type);
      //  foreach (DataRow row in dtSqlOperators.Rows)
      //  {
      //    TreeNode TNGroup = null;
      //    int GroupIndex = TN.Nodes.IndexOfKey(row["S_Group"].ToString());
      //    //TN.Nodes[TN.Nodes.IndexOfKey(row["S_Group"].ToString())];
      //    if (GroupIndex == -1)
      //      TNGroup = TN.Nodes.Add(row["S_Group"].ToString(), row["S_Group"].ToString());
      //    else
      //      TNGroup = TN.Nodes[GroupIndex];
      //    TreeNode TN1 = TNGroup.Nodes.Add(row["S_Name"].ToString(), row["S_Name"].ToString());
      //    if (TN1.Level == 2)
      //      TN1.ForeColor = Color.FromName(row["S_ForeColor"].ToString());
      //    if (S_ForeColorCmbBox.Items.IndexOf(row["S_ForeColor"].ToString()) < 0)
      //      S_ForeColorCmbBox.Items.Add(row["S_ForeColor"].ToString());
      //    if (S_GroupCmbBox.Items.IndexOf(row["S_Group"].ToString()) == -1)
      //      S_GroupCmbBox.Items.Add(row["S_Group"].ToString());
      //  }
      //}

      //int privateNodeIndex = tvDictionary.Nodes.IndexOfKey(Constants.PRIVATE_DICTIONARY_CATEGORY);
      //tvDictionary.Nodes[privateNodeIndex].Nodes.Clear();
      //if (G.ExecSQLiteQuery(string.Format("select * from word_tooltip where id_content in ({0})", idContent)))
      //{
      //  foreach (DataRow row in G.DT.Rows)
      //  {
      //    tvDictionary.Nodes[privateNodeIndex].Nodes.Add(row["id_content"].ToString(), row["word"].ToString());
      //  }
      //}
    }

    ///// <summary>
    ///// Выбрать SQL-операторы
    ///// </summary>
    ///// <param name="strFilterType">WHERE S_Type = ?</param>
    ///// <returns></returns>
    //public DataTable SelectWordToolTip(string category)
    //{
    //  string sql = "select * from word_tooltip where id_content = 0";
    //  if (category == Constants.PRIVATE_DICTIONARY_CATEGORY)
    //    sql = "select * from word_tooltip where id_content > 0";
    //  G.ExecSQLiteQuery(sql);
    //  return G.DT;
    //}

    private void SetIdContentForSave(int idContentSource)
    {
      _currentQuestionId = (Application.OpenForms[0] as MainForm).GetCurrentQuestionId();
      _oldIdContent = (idContentSource == 0) ? 0 : _currentQuestionId;
      _oldWordForSave = TooltipDictionary.TV_Dictionary.SelectedNode == null ? null : TooltipDictionary.TV_Dictionary.SelectedNode.Text;
      if (_currentQuestionId == 0)
      {
        if (cmbCategoryWord.Items.IndexOf(Constants.PRIVATE_DICTIONARY_CATEGORY) >= 0)
          cmbCategoryWord.Items.RemoveAt(cmbCategoryWord.Items.IndexOf(Constants.PRIVATE_DICTIONARY_CATEGORY));
      }
      else
      {
        if (cmbCategoryWord.Items.IndexOf(Constants.PRIVATE_DICTIONARY_CATEGORY) == -1)
          cmbCategoryWord.Items.Add(Constants.PRIVATE_DICTIONARY_CATEGORY);
      }
    }

    private void tsbAdd_Click(object sender, EventArgs e)
    {
      splitContainer1.Panel2Collapsed = false;
      splitContainer1.Panel1Collapsed = true;
      tsbSave.Text = "Создать";
      SetDefaultProperty();
      SetIdContentForSave(0);
    }

    private void tsbSave_Click(object sender, EventArgs e)
    {
      bool successExecSql = false;
      int idContent = (cmbCategoryWord.Text == Constants.PUBLIC_DICTIONARY_CATEGORY) ? 0 : _currentQuestionId;
      string url = (cmbToolTipType.SelectedIndex == (int)TooltipDictionary.TooltipType.QuestionHref) ? "http://" + txbQuestion.Text : txbUrl.Text;
      if (tsbSave.Text == "Создать")
      {
        successExecSql = TooltipDictionary.InsertWordToolTip(
           idContent
          , txbWord.Text
          ,cmbToolTipType.SelectedIndex
          ,txbComment.Text
          , url
          , cmbGroup.Text
          ,cmbForeColor.Text);
      }
      else
      {
        string comment = txbComment.Text;
        if (cmbToolTipType.SelectedIndex == (int)TooltipDictionary.TooltipType.QuestionHref)
          comment = "Вопрос"+ txbQuestion.Text;
        successExecSql = TooltipDictionary.UpdateWordToolTip(
           idContent
          , txbWord.Text
          ,cmbToolTipType.SelectedIndex
          , comment
          , url
          , cmbGroup.Text
          ,cmbForeColor.Text
          , _oldIdContent
          , _oldWordForSave
          );
      }
      if (successExecSql)
      {
        AddGroupName(cmbGroup.Text);
        splitContainer1.Panel2Collapsed = true;
        splitContainer1.Panel1Collapsed = false;
        //if (tsbSave.Text == "Создать")
        //  TooltipDictionary.TV_Dictionary.Nodes[cmbCategoryWord.Text].Nodes.Add(idContent.ToString(), txbWord.Text);
        //RefreshAllData(new string[] { S_TypeCmbBox.Text });
      }
    }

    private void tsbCancel_Click(object sender, EventArgs e)
    {
      splitContainer1.Panel2Collapsed = true;
      splitContainer1.Panel1Collapsed = false;
    }

    private void cmbToolTipType_SelectedIndexChanged(object sender, EventArgs e)
    {
      const int STEP_POINT_Y = 3;
      lblComment.Visible
        = txbComment.Visible
        = !(cmbToolTipType.SelectedIndex == cmbToolTipType.Items.IndexOf(Constants.TOOLTIPTYPE_0__DB_QUESTION));
      lblQuestion.Visible
        = txbQuestion.Visible
        = btnSelectQuestion.Visible
        = (cmbToolTipType.SelectedIndex == cmbToolTipType.Items.IndexOf(Constants.TOOLTIPTYPE_0__DB_QUESTION));
      lblUrl.Visible
        = txbUrl.Visible
        = (cmbToolTipType.SelectedIndex == cmbToolTipType.Items.IndexOf(Constants.TOOLTIPTYPE_1_INTERNET_QUESTION));
      if (cmbToolTipType.SelectedIndex == cmbToolTipType.Items.IndexOf(Constants.TOOLTIPTYPE_0__DB_QUESTION))
      {
        lblQuestion.Anchor
          = lblForeColor.Anchor
          = lblGroup.Anchor
          = AnchorStyles.Left | AnchorStyles.Top;
        btnSelectQuestion.Anchor = AnchorStyles.Right | AnchorStyles.Top;
        txbQuestion.Anchor
          = cmbForeColor.Anchor
          = cmbGroup.Anchor
          = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right;
        lblQuestion.Location = new Point(cmbToolTipType.Location.X, cmbToolTipType.Location.Y+ cmbToolTipType.Height+ STEP_POINT_Y);
        txbQuestion.Location = new Point(lblQuestion.Location.X, lblQuestion.Location.Y + lblQuestion.Height + STEP_POINT_Y);
        btnSelectQuestion.Location = new Point(btnSelectQuestion.Location.X, lblQuestion.Location.Y + lblQuestion.Height + 3);
        lblForeColor.Location = new Point(txbQuestion.Location.X, txbQuestion.Location.Y + txbQuestion.Height + STEP_POINT_Y);
        cmbForeColor.Location = new Point(lblForeColor.Location.X, lblForeColor.Location.Y + lblForeColor.Height + STEP_POINT_Y);
        lblGroup.Location = new Point(cmbForeColor.Location.X, cmbForeColor.Location.Y + cmbForeColor.Height + STEP_POINT_Y);
        cmbGroup.Location = new Point(lblGroup.Location.X, lblGroup.Location.Y + lblGroup.Height + STEP_POINT_Y);
      }
      else
      if (cmbToolTipType.SelectedIndex == cmbToolTipType.Items.IndexOf(Constants.TOOLTIPTYPE_1_INTERNET_QUESTION))
      {
        lblUrl.Anchor
          = AnchorStyles.Left | AnchorStyles.Top;
        txbUrl.Anchor
          = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right;
        lblForeColor.Anchor
          = lblGroup.Anchor
          = AnchorStyles.Left | AnchorStyles.Bottom;
        cmbForeColor.Anchor
          = cmbGroup.Anchor
          = AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Right;
        lblUrl.Location = new Point(cmbToolTipType.Location.X, cmbToolTipType.Location.Y + cmbToolTipType.Height + STEP_POINT_Y);
        txbUrl.Location = new Point(lblUrl.Location.X, lblUrl.Location.Y + lblUrl.Height + STEP_POINT_Y);
        lblComment.Location = new Point(txbUrl.Location.X, txbUrl.Location.Y + txbUrl.Height + STEP_POINT_Y);
        txbComment.Location = new Point(lblComment.Location.X, lblComment.Location.Y + lblComment.Height + STEP_POINT_Y);
        lblForeColor.Location = new Point(txbComment.Location.X, txbComment.Location.Y + txbComment.Height + STEP_POINT_Y);
        cmbForeColor.Location = new Point(lblForeColor.Location.X, lblForeColor.Location.Y + lblForeColor.Height + STEP_POINT_Y);
        lblGroup.Location = new Point(cmbForeColor.Location.X, cmbForeColor.Location.Y + cmbForeColor.Height + STEP_POINT_Y);
        cmbGroup.Location = new Point(lblGroup.Location.X, lblGroup.Location.Y + lblGroup.Height + STEP_POINT_Y);
      }
      else
      if (cmbToolTipType.SelectedIndex == cmbToolTipType.Items.IndexOf(Constants.TOOLTIPTYPE_2_STATIC_TEXT))
      {
        lblForeColor.Anchor
          = lblGroup.Anchor
          = AnchorStyles.Left | AnchorStyles.Bottom;
        cmbForeColor.Anchor
          = cmbGroup.Anchor
          = AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Right;
        lblComment.Location = new Point(cmbToolTipType.Location.X, cmbToolTipType.Location.Y + cmbToolTipType.Height + STEP_POINT_Y);
        txbComment.Location = new Point(lblComment.Location.X, lblComment.Location.Y + lblComment.Height + STEP_POINT_Y);
        lblForeColor.Location = new Point(txbComment.Location.X, txbComment.Location.Y + txbComment.Height + STEP_POINT_Y);
        cmbForeColor.Location = new Point(lblForeColor.Location.X, lblForeColor.Location.Y + lblForeColor.Height + STEP_POINT_Y);
        lblGroup.Location = new Point(cmbForeColor.Location.X, cmbForeColor.Location.Y + cmbForeColor.Height + STEP_POINT_Y);
        cmbGroup.Location = new Point(lblGroup.Location.X, lblGroup.Location.Y + lblGroup.Height + STEP_POINT_Y);
      }
    }

    private void tsbDelete_Click(object sender, EventArgs e)
    {
      if (TooltipDictionary.TV_Dictionary.SelectedNode.Level == 2)
      {
        int idContent
          = (TooltipDictionary.TV_Dictionary.SelectedNode.Parent.Parent.Text == Constants.PUBLIC_DICTIONARY_CATEGORY) ? 0
          : (Application.OpenForms[0] as MainForm).GetCurrentQuestionId();
        if (TooltipDictionary.DeleteItem(idContent, TooltipDictionary.TV_Dictionary.SelectedNode.Text))
        {
          TooltipDictionary.TV_Dictionary.SelectedNode.Remove();
        }
      }
    }

    private void tsbCopy_Click(object sender, EventArgs e)
    {
      EditOrCopyWordToolTip(true);
    }

    protected int inMargin;
    protected int boxWidth;
    private Color c;

    private void cmbForeColor_DrawItem(object sender, DrawItemEventArgs e)
    {
      //cmbForeColor.OnDrawItem(e);
      if ((e.State & DrawItemState.ComboBoxEdit) != DrawItemState.ComboBoxEdit)
        e.DrawBackground();

      Graphics g = e.Graphics;
      if (e.Index == -1)  //if index is -1 do nothing
        return;
      c = Color.FromName((string)cmbForeColor.Items[e.Index]);

      //the color rectangle
      g.FillRectangle(new SolidBrush(c), e.Bounds.X + this.inMargin, e.Bounds.Y +
          this.inMargin, e.Bounds.Width / this.boxWidth - 2 * this.inMargin,
          e.Bounds.Height - 2 * this.inMargin);
      //draw border around color rectangle
      g.DrawRectangle(Pens.Black, e.Bounds.X + this.inMargin,
          e.Bounds.Y + this.inMargin, e.Bounds.Width / this.boxWidth -
          2 * this.inMargin, e.Bounds.Height - 2 * this.inMargin);
      //draw strings
      g.DrawString(c.Name, e.Font, new SolidBrush(ForeColor),
          (float)(e.Bounds.Width / this.boxWidth + 5 * this.inMargin),
          (float)e.Bounds.Y);

      //e.Graphics.DrawString(cmbForeColor.Items[e.Index].ToString(), cmbForeColor.Font, new SolidBrush(Color.FromName(cmbForeColor.Items[e.Index].ToString())), e.Bounds);
    }

    private void tvDictionary_AfterSelect(object sender, TreeViewEventArgs e)
    {
      tsbEdit.Enabled =
        tsbCopy.Enabled =
        tsbDelete.Enabled = (TooltipDictionary.TV_Dictionary.SelectedNode != null && TooltipDictionary.TV_Dictionary.SelectedNode.Level == 2);
    }

    private void tsbEdit_Click(object sender, EventArgs e)
    {
      EditOrCopyWordToolTip(false);
    }

    private void EditOrCopyWordToolTip(bool isCopy)
    {
      if (TooltipDictionary.TV_Dictionary.SelectedNode.Level == 2)
      {
        if (isCopy)
          tsbSave.Text = "Создать";
        else
          tsbSave.Text = "Сохранить";
        splitContainer1.Panel2Collapsed = false;
        splitContainer1.Panel1Collapsed = true;
        //int _oldIdContent = (TooltipDictionary.TV_Dictionary.SelectedNode.Parent.Parent.Text == Constants.PUBLIC_DICTIONARY_CATEGORY) ? 0 : currentQuestionId;
        SetIdContentForSave(Convert.ToInt32(TooltipDictionary.TV_Dictionary.SelectedNode.Name));
        int currentQuestionId = (TooltipDictionary.TV_Dictionary.SelectedNode.Parent.Parent.Text == Constants.PUBLIC_DICTIONARY_CATEGORY) ? 0 : _oldIdContent;
        string wordSql = TooltipDictionary.TV_Dictionary.SelectedNode.Text;
        TooltipDictionary.QuotedStr(ref wordSql);
        string sql = string.Format(
            "SELECT * FROM word_tooltip WHERE id_content={0} AND {1}='{2}' ORDER BY {1}"
            , currentQuestionId
            , TooltipDictionary.WORD, wordSql);
        G.ExecSQLiteQuery(sql);
        if (G.DT.Rows.Count == 1)
        {
          DataRow row = G.DT.Rows[0];
          SetPropertyValues(currentQuestionId
            , row[TooltipDictionary.WORD].ToString()
            , Convert.ToInt32(row[TooltipDictionary.TOOLTIP_TYPE_COLUMN_NAME])
            , row[TooltipDictionary.COMMENT_COLUMN_NAME].ToString()
            , row[TooltipDictionary.URL_ADR_COLUMN_NAME].ToString()
            , row[TooltipDictionary.GROUP_NAME].ToString()
            , row[TooltipDictionary.FORE_COLOR].ToString()
            );
        }
      }
    }

    private void btnSelectQuestion_Click(object sender, EventArgs e)
    {
      using (MainForm mf = new MainForm(true))// { ModalDialogForSelectQuestion = true })
      {
        mf.SetModalDialogForSelectQuestion();
        if (mf.ShowDialog() == DialogResult.OK)
        {
          txbQuestion.Text = mf.GetCurrentQuestionId().ToString();
        }
      }
    }

    private void txbWord_TextChanged(object sender, EventArgs e)
    {
      //foreach(char chr in SyntaxChecking.StartOrEndWordChars)
      //{
      //  txbWord.Text = txbWord.Text.Replace(chr, ' ');
      //}
      //txbWord.Text = txbWord.Text.Replace(" ", string.Empty);
    }

    private void txbWord_KeyPress(object sender, KeyPressEventArgs e)
    {
      foreach (char chr in TooltipUserControl.StartOrEndWordChars)
      {
        if (e.KeyChar.Equals(chr))
        {
          e.Handled = true;
          StringBuilder msgToolTip = new StringBuilder();
          tt.SetToolTip(txbWord, "Запрещено использовать символ " + chr);
        }
      }
    }

    #region TreeView search

    private const string SEARCH_TEXT = "Поиск слова...";
    private int LastNodeIndex = 0;
    private string LastSearchText;
    private List<TreeNode> _currentNodeMatches = new List<TreeNode>();

    /// <summary>
    /// Поиск узлов в дереве TreeView
    /// </summary>
    /// <param name="SearchText">Искомый текст</param>
    /// <param name="StartNode">Узел, с которого начинается поиск</param>
    private void SearchNodes(string SearchText, TreeNode StartNode)
    {
      //TreeNode node = null;
      while (StartNode != null)
      {
        StartNode.Collapse();
        StartNode.BackColor = TooltipDictionary.TV_Dictionary.BackColor;    //Очистить цвет (по-умолчанию)
        if (StartNode.Text.ToUpper().StartsWith(SearchText.ToUpper()))
        {
          _currentNodeMatches.Add(StartNode);
          StartNode.BackColor = Color.Gold;   //Подсветка цветом
        }
        //StartNode.Expand();
        //StartNode.Collapse();
        if (StartNode.Nodes.Count != 0)
        {
          SearchNodes(SearchText, StartNode.Nodes[0]);//Recursive Search 
        }
        StartNode = StartNode.NextNode;
      }
    }

    private void tstbSearch_Leave(object sender, EventArgs e)
    {
      if (tstbSearch.Text == string.Empty)
        tstbSearch.Text = SEARCH_TEXT;
    }

    private void tstbSearch_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode == Keys.Return && TooltipDictionary.TV_Dictionary.Nodes.Count > 0)
      {
        string searchText = tstbSearch.Text;
        if (String.IsNullOrEmpty(searchText))
        {
          return;
        }

        if (LastSearchText != searchText)
        {
          //It's a new Search
          _currentNodeMatches.Clear();
          LastSearchText = searchText;
          LastNodeIndex = 0;
          SearchNodes(searchText, TooltipDictionary.TV_Dictionary.Nodes[0]);
        }

        if (LastNodeIndex >= 0 && _currentNodeMatches.Count > 0 && LastNodeIndex < _currentNodeMatches.Count)
        {
          TreeNode selectedNode = _currentNodeMatches[LastNodeIndex];
          LastNodeIndex++;

          TooltipDictionary.TV_Dictionary.SelectedNode = selectedNode;
          if (LastNodeIndex >= _currentNodeMatches.Count)
            LastNodeIndex = 0;
        }
      }
    }

    private void tstbSearch_Enter(object sender, EventArgs e)
    {
      if (tstbSearch.Text == SEARCH_TEXT)
        tstbSearch.Text = string.Empty;
    }


    #endregion TreeView search

    private void tstbSearch_TextChanged(object sender, EventArgs e)
    {
      string searchText = tstbSearch.Text;
      if (searchText == SEARCH_TEXT)
        tstbSearch.ForeColor = Color.Gray;
      else
        tstbSearch.ForeColor = Color.Black;
    }

    private void tsbSearch_Click(object sender, EventArgs e)
    {
      tstbSearch_KeyDown(sender, new KeyEventArgs(Keys.Enter));
    }

    public SplitterPanel EditPanel
    {
      get { return splitContainer1.Panel2; }
    }
  }
}
