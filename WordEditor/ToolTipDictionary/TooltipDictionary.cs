using System;
using System.Windows.Forms;
using System.Data;

namespace FAQ_Net
{
  /// <summary>
  /// Класс для удобства управления всплывающими подсказками.
  /// Все подсказки загружаются при запуске приложения и всегда хранятся в памяти
  /// </summary>
  public class TooltipDictionary
  {
    #region Fields / Поля

    public static TreeView TV_Dictionary;
    public static eDictionary eDictionary;
    public static DataTable HelpDT;

    #endregion Fields / Поля

    #region Constants / Константы

    public const string
        _ONE_QUOTE = "'"
      , _TWO_QUOTES = "''"
      , ID_CONTENT = "id_content"
      , GROUP_NAME = "group_name"
      , WORD = "word"
      , FORE_COLOR = "fore_color"
      , COMMENT_COLUMN_NAME = "comment"
      , TOOLTIP_TYPE_COLUMN_NAME = "tooltip_type"
      , URL_ADR_COLUMN_NAME = "url_adr";

    #endregion Constants / Константы

    public enum TooltipType
    {
      QuestionHref = 0,
      InternetHref = 1,
      StaticComment = 2,
    }

    #region Methods / Методы

    public static void InitializeToolTip()
    {
      eDictionary = new eDictionary();
      TV_Dictionary = new TreeView();
      TV_Dictionary.Dock = DockStyle.Fill;
      TV_Dictionary.HideSelection = false;

      // Создать таблицу для удобства фильтрации слов
      HelpDT = new DataTable("HelpDT");
      //HelpDT.Columns.Add("Img", typeof(Image));
      DataColumn wordColumn = HelpDT.Columns.Add(WORD, typeof(String));
      DataColumn idContentColumn = HelpDT.Columns.Add(ID_CONTENT, typeof(int));
      HelpDT.Columns.Add(COMMENT_COLUMN_NAME, typeof(String));
      HelpDT.Columns.Add(FORE_COLOR, typeof(String));
      HelpDT.Columns.Add(URL_ADR_COLUMN_NAME, typeof(String));
      HelpDT.PrimaryKey = new DataColumn[] { idContentColumn, wordColumn };

      // Подсказки для всех URL на вопросы БД, например: вопрос_ID, где ID - числовое значение, обозначающее номер вопроса
      G.ExecSQLiteQuery("select id_content,question from vopros");
      foreach (System.Data.DataRow row in G.DT.Rows)
      {
        string urlQuestion = "http://" + row["id_content"].ToString();
        string idContent = row["id_content"].ToString();
        AddItem(Convert.ToInt32(idContent), string.Format("вопрос{0}", idContent), row["question"].ToString(), urlQuestion, TooltipType.QuestionHref);
      }
      // Подсказки, определенные пользователем
      G.ExecSQLiteQuery("select * from word_tooltip");
      foreach (System.Data.DataRow row in G.DT.Rows)
      {
        int idContent = Convert.ToInt32(row[ID_CONTENT]);
        int tooltipType = Convert.ToInt32(row[TOOLTIP_TYPE_COLUMN_NAME]);
        string word = row[WORD].ToString();
        string comments = row[COMMENT_COLUMN_NAME].ToString();
        AddItem(idContent, word, comments, row[URL_ADR_COLUMN_NAME].ToString(), (TooltipType)tooltipType);
        AddHelpRow(idContent, word, comments, row[FORE_COLOR].ToString(), row[URL_ADR_COLUMN_NAME].ToString());
      }
    }

    public static void AddHelpRow(int idContent, string word, string comments, string foreColor, string url)
    {
      DataRow newHelpRow = HelpDT.NewRow();
      newHelpRow[ID_CONTENT] = idContent;
      newHelpRow[WORD] = word;
      newHelpRow[COMMENT_COLUMN_NAME] = comments;
      newHelpRow[FORE_COLOR] = foreColor;
      newHelpRow[URL_ADR_COLUMN_NAME] = url;
      HelpDT.Rows.Add(newHelpRow);
    }

    /// <summary>
    /// Добавить подсказку на слово в словарь
    /// </summary>
    public static void AddItem(int idContent, string title, string description, string url, TooltipType tooltipType)
    {
      if (!eDictionary.Contains(idContent, title))
      {
        eDictionary.Add(idContent, title, description, url, tooltipType);
      }
    }

    public static bool DeleteItem(int idContent, string word)
    {
      bool result = false;
      if (MessageBox.Show("Удалить всплывающую подсказку для слова '" + word + "'", "Подтверждение удаления", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
      {
        if (TooltipDictionary.DeleteWordTooltip(idContent, word))
        {
          DictionaryInfo deletedWord = eDictionary.GetByTitle(idContent, word);
          eDictionary.Remove(deletedWord);
          HelpDT.Rows.Remove(GetHelpDtRow(idContent, word));
          result = true;
        }
      }
      return result;
    }

    public static void QuotedStr(ref string strInput)
    {
      strInput = strInput.Replace(_ONE_QUOTE, _TWO_QUOTES);
    }



    /// <summary>
    /// Добавить всплывающую подсказку у слова
    /// </summary>
    public static bool InsertWordToolTip(int idContent, string word, int tooltipType, string comment, string url, string groupName, string foreColor)
    {
      if (eDictionary.Contains(idContent, word))
      {
        MessageBox.Show(string.Format("Слово \"{0}\" уже есть в категории \"{1}\"", word, idContent==0? Constants.PUBLIC_DICTIONARY_CATEGORY : Constants.PRIVATE_DICTIONARY_CATEGORY)
          , "Дублирование подсказки", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        return false;
      }
      QuotedStr(ref word);
      QuotedStr(ref comment);
      QuotedStr(ref url);
      QuotedStr(ref groupName);
      QuotedStr(ref foreColor);

      if (G.ExecSQLiteQuery(
          string.Format("INSERT INTO word_tooltip ({0}, {2}, {4}, {6}, {8}, {10}, {12}) VALUES ({1},'{3}',{5},'{7}','{9}','{11}','{13}')"
          , ID_CONTENT, idContent
          , WORD, word
          , TOOLTIP_TYPE_COLUMN_NAME, tooltipType
          , COMMENT_COLUMN_NAME, comment
          , URL_ADR_COLUMN_NAME, url
          , GROUP_NAME, groupName
          , FORE_COLOR, foreColor
          )))
      {
        AddItem(idContent, word, comment, url, (TooltipType)tooltipType);
        DictionaryEditor.AddNode(idContent, groupName, word, foreColor, true);
        AddHelpRow(idContent, word, comment, foreColor, url);
        return true;
      }
      return false;
    }

    /// <summary>
    /// Изменить всплывающую подсказку у слова
    /// </summary>
    public static bool UpdateWordToolTip(int idContent, string word, int tooltipType, string comment, string url, string groupName, string foreColor, int oldIdContent, string oldWord)
    {
      if ((oldIdContent != idContent || string.Compare(word, oldWord, true) != 0)
        && eDictionary.Contains(idContent, word))
      {
        MessageBox.Show(string.Format("Слово \"{0}\" уже есть в категории \"{1}\"", word, idContent == 0 ? Constants.PUBLIC_DICTIONARY_CATEGORY : Constants.PRIVATE_DICTIONARY_CATEGORY)
          , "Дублирование подсказки", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        return false;
      }
      QuotedStr(ref word);
      QuotedStr(ref comment);
      QuotedStr(ref url);
      QuotedStr(ref groupName);
      QuotedStr(ref foreColor);
      QuotedStr(ref oldWord);

      if (G.ExecSQLiteQuery(
          string.Format("UPDATE word_tooltip SET id_content={0}, word='{1}', tooltip_type={2}, comment='{3}', url_adr='{4}', group_name='{5}', fore_color='{6}' WHERE id_content='{7}' AND word='{8}'"
          , idContent, word, tooltipType, comment, url, groupName, foreColor, oldIdContent, oldWord)))
      {
        DictionaryInfo oldDicInfo = eDictionary.GetByTitle(oldIdContent, oldWord);
        if (MainForm.IdContentUrlRegEx.IsMatch(url))
        {
          if (G.ExecSQLiteQuery("select question from vopros where id_content="+ url.Substring(7))
            && G.DT.Rows.Count == 1)
          {
            eDictionary.Edit(oldDicInfo, word, G.DT.Rows[0][0].ToString(), idContent, tooltipType, url);
          }
        }
        else
          eDictionary.Edit(oldDicInfo, word, comment, idContent, tooltipType, url);

        TreeNode parentNodeLevel1 = TooltipDictionary.TV_Dictionary.SelectedNode.Parent;
        // Редактировать слово в дереве
        if (TooltipDictionary.TV_Dictionary.SelectedNode.Text == word
          && (parentNodeLevel1.Text == groupName || parentNodeLevel1.Text == Constants.WithoutGroup)
          && TooltipDictionary.TV_Dictionary.SelectedNode.Name == idContent.ToString())
        {
          TooltipDictionary.TV_Dictionary.SelectedNode.ForeColor = System.Drawing.Color.FromName(foreColor);
        }
        else
        {
          TooltipDictionary.TV_Dictionary.SelectedNode.Remove();
          if (parentNodeLevel1.Nodes.Count == 0)
          {
            TreeNode parentNodeLevel0 = parentNodeLevel1.Parent;
            parentNodeLevel1.Remove();
            if (parentNodeLevel0.Nodes.Count == 0)
              parentNodeLevel0.Remove();
          }
          DictionaryEditor.AddNode(idContent, groupName, word, foreColor, true);
        }

        // Пересоздать запись в HelpDGV
        HelpDT.Rows.Remove(GetHelpDtRow(oldIdContent, oldWord));
        AddHelpRow(idContent, word, comment, foreColor, url);
        return true;
      }
      return false;
    }

    private static DataRow GetHelpDtRow(int idContent, string word)
    {
      DataRow[] rows = HelpDT.Select(string.Format("{0}={1} and {2}='{3}'", ID_CONTENT, idContent, WORD, word));
      if (rows.Length == 1)
        return rows[0];
      return null;
    }

    /// <summary>
    /// Удалить всплывающую подсказку
    /// </summary>
    public static bool DeleteWordTooltip(int idContent, string word)
    {
      QuotedStr(ref word);

      return G.ExecSQLiteQuery(
          string.Format("DELETE FROM word_tooltip WHERE id_content={0} AND word='{1}'", idContent, word));
    }

    #endregion Methods / Методы
  }
}
