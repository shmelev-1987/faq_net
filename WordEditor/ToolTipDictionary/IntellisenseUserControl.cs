using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace FAQ_Net
{
  public partial class IntellisenseUserControl : UserControl
  {
    private readonly ToolTip HelpTT = new ToolTip();
    private readonly ToolTip KeywordsTT = new ToolTip();
    private int OldRowIndex = -1;
    private int _selectionStart = 0;
    private int _selectionLength = 0;

    /// <summary>
    /// Фиксированная строка поиска в текущей вкладке
    /// </summary>
    //private string FixedFilterSearchInHelpDGV = "";
    RichTextBoxCustom _richTextBoxCustom;

    public IntellisenseUserControl(RichTextBoxCustom rtb)
    {
      InitializeComponent();

      _richTextBoxCustom = rtb;
      
      // HelpDGV - помощник по автодополнению (IntelliSense)
      dgvHelp.AllowUserToAddRows = false;
      dgvHelp.AllowUserToDeleteRows = false;
      dgvHelp.AllowUserToOrderColumns = true;
      dgvHelp.AllowUserToResizeColumns = false;
      dgvHelp.AllowUserToResizeRows = false;
      dgvHelp.BackgroundColor = System.Drawing.Color.White;
      dgvHelp.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
      dgvHelp.GridColor = System.Drawing.Color.White;
      dgvHelp.MultiSelect = false;
      dgvHelp.ReadOnly = true;
      dgvHelp.RowHeadersVisible = false;
      dgvHelp.ColumnHeadersVisible = false;
      dgvHelp.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
      dgvHelp.Size = new System.Drawing.Size(300, 202);
      dgvHelp.KeyDown += new System.Windows.Forms.KeyEventHandler(dgvHelp_KeyDown);
      dgvHelp.KeyPress += new System.Windows.Forms.KeyPressEventHandler(dgvHelp_KeyPress);
      dgvHelp.MouseMove += new System.Windows.Forms.MouseEventHandler(dgvHelp_MouseMove);
      dgvHelp.Leave += new System.EventHandler(dgvHelp_Leave);

      // Основные (общие) операторы SQL
      dgvHelp.DataSource = TooltipDictionary.HelpDT;
      HelpTT.ToolTipIcon = ToolTipIcon.Info;
      HelpTT.ShowAlways = true;

      dgvHelp.Columns[TooltipDictionary.ID_CONTENT].Width = 0;
      dgvHelp.Columns[TooltipDictionary.ID_CONTENT].Visible = false;
      dgvHelp.Columns[TooltipDictionary.COMMENT_COLUMN_NAME].Visible = false;
      dgvHelp.Columns[TooltipDictionary.FORE_COLOR].Visible = false;
      dgvHelp.Columns[TooltipDictionary.URL_ADR_COLUMN_NAME].Visible = false;
      dgvHelp.Columns[TooltipDictionary.WORD].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
      dgvHelp.Columns[TooltipDictionary.WORD].FillWeight = 100;

      this.Hide();
    }

    private void dgvHelp_MouseDoubleClick(object sender, MouseEventArgs e)
    {
      if (dgvHelp.SelectedRows.Count > 0)
      {
        dgvHelp_KeyDown(sender, new KeyEventArgs(Keys.Enter));
      }
    }

    private void dgvHelp_KeyDown(object sender, KeyEventArgs e)
    {
      #region Нажатие клавиши Enter
      if (e.KeyCode == Keys.Enter
       && dgvHelp.CurrentRow != null)
      {
        KeywordsTT.Tag = string.Empty;
        //_richTextBoxCustom.Text = TE.Text.Remove(TE.CurrentPos-1, 1); //Удаление пробела после операции (Ctrl+Space)
        //if (FixedFilterSearchInHelpDGV.IndexOf(" OR (S_Name LIKE ") >= 0)
        //{
        //  //FixedFilterSearchInHelpDGV.Substring(FixedFilterSearchInHelpDGV.IndexOf("S_Name LIKE '") + 13)
        //  string Filter = FixedFilterSearchInHelpDGV.Substring(FixedFilterSearchInHelpDGV.IndexOf("S_Name LIKE '") + 13);
        //  Filter = Filter.Substring(0, Filter.LastIndexOf("%"));
        //  if (dgvHelp.CurrentRow.Cells["S_Name"].Value.ToString().StartsWith(Filter))
        //    _richTextBoxCustom.SelectedRtf = RtfTable.InsertText(dgvHelp.CurrentRow.Cells[TooltipDictionary.WORD].Value.ToString().Substring(Filter.Length));
        //  else
        //    _sqlScriptTE.InsertText(dgvHelp.CurrentRow.Cells["S_Name"].Value.ToString());
        //}
        //else
        if (_selectionLength > 0)
          _richTextBoxCustom.Select(_selectionStart, _selectionLength);
        _richTextBoxCustom.SelectedRtf = Rtf.InsertText(dgvHelp.CurrentRow.Cells[TooltipDictionary.WORD].Value.ToString()
          , dgvHelp.CurrentRow.Cells[TooltipDictionary.WORD].Style.ForeColor
          , !string.IsNullOrEmpty(dgvHelp.CurrentRow.Cells[TooltipDictionary.URL_ADR_COLUMN_NAME].Value.ToString()));
        //dgvHelp.Hide();
        HelpTT.Hide(dgvHelp);
        _richTextBoxCustom.Focus();
      }
      #endregion Нажатие клавиши Enter
    }

    private void dgvHelp_KeyPress(object sender, KeyPressEventArgs e)
    {
      HelpTT.Hide(this);
      KeywordsTT.Hide(this);
      switch (e.KeyChar)
      {
        #region Escape (скрыть все подсказки)
        case (char)27:  //Escape
          KeywordsTT.Tag = string.Empty;
          this.Hide();
          _richTextBoxCustom.Focus();
          break;
        #endregion Escape (скрыть все подсказки)
        #region Enter (ничего не делать, т.к. выполнится процедура HelpDGV_KeyDown())
        case (char)13:  //Enter
          //Ничего не делать, т.к. выполнится процедура HelpDGV_KeyDown()
          break;
        #endregion Enter (ничего не делать, т.к. выполнится процедура HelpDGV_KeyDown())
        #region BackSpace (стереть последний символ)
        case (char)8:   //Если нажата клавиша BackSpace
          if (KeywordsTT.Tag.ToString().Length > 0)
            KeywordsTT.Tag = KeywordsTT.Tag.ToString().Remove(KeywordsTT.Tag.ToString().Length - 1);
          else
            KeywordsTT.Tag = string.Empty;
          ShowKeywordsHelp();
          break;
        #endregion BackSpace (стереть последний символ)
        default:
          KeywordsTT.Tag += e.KeyChar.ToString(); //Добавить символ к концу фильтра
          ShowKeywordsHelp();
          break;
      }
    }

    /// <summary>
    /// Показать введенный текст поиска по подсказкам с клавиатуры
    /// </summary>
    private void ShowKeywordsHelp()
    {
      Point location = _richTextBoxCustom.GetPositionFromCharIndex(_richTextBoxCustom.SelectionStart > 0 ? _richTextBoxCustom.SelectionStart - 1 : 0);
      //int SplitterDistance = _splitContainerMain.SplitterDistance;
      //if (_splitContainerMain.Panel1Collapsed)
      //  SplitterDistance = 0;

      KeywordsTT.Show(
          KeywordsTT.Tag.ToString(),   //Подсказка по выбранному оператору
          this,
          new Point(dgvHelp.Location.X, dgvHelp.Location.Y - 20)
          );

      DataView dv = ((DataTable)dgvHelp.DataSource).DefaultView;
      try
      {
        //if (dgvHelp.CurrentRow != null &&
        //    !string.IsNullOrEmpty(dgvHelp.CurrentRow.Cells["S_RootName"].Value.ToString()))
        //{
        //  int indexOfNameLike = FixedFilterSearchInHelpDGV.IndexOf(" OR (S_Name LIKE ");
        //  if (indexOfNameLike > -1)
        //  {
        //    FixedFilterSearchInHelpDGV = FixedFilterSearchInHelpDGV.Substring(0, indexOfNameLike);
        //  }
        //}
        try
        {
          //dv.RowFilter = string.Format("{0} AND {1} LIKE '%{2}%'", FixedFilterSearchInHelpDGV, TooltipDictionary.WORD, KeywordsTT.Tag);
          dv.RowFilter = string.Format("{0} LIKE '%{1}%'", TooltipDictionary.WORD, KeywordsTT.Tag);
        }
        catch (Exception ex)
        {
          KeywordsTT.Show(dv.RowFilter + Environment.NewLine + ex.Message, this);
        }
        SetColorAttributesHelpDGV();

      }
      catch (InvalidOperationException) { }
    }

    private bool _isVisible;

    private void dgvHelp_MouseMove(object sender, MouseEventArgs e)
    {
      if (e.X < dgvHelp.Width - 20)
      {
        DataGridView.HitTestInfo hti = dgvHelp.HitTest(e.X, e.Y);

        // Данная проверка необходима для корректного отображения комментария ToolTip'а, после метода Show()
        if (hti.RowIndex != OldRowIndex)
        {
          HelpTT.Hide(this);
          _isVisible = false;
        }

        if (hti.RowIndex >= 0 && dgvHelp.Rows[hti.RowIndex].Cells[TooltipDictionary.COMMENT_COLUMN_NAME].Value != null
          && (hti.RowIndex != OldRowIndex || (dgvHelp.Rows.Count == 1 && !_isVisible)))
        {
          dgvHelp.Rows[hti.RowIndex].Selected = true;
          dgvHelp.CurrentCell = dgvHelp.Rows[hti.RowIndex].Cells[TooltipDictionary.WORD];

          HelpTT.ToolTipTitle = dgvHelp.Rows[hti.RowIndex].Cells[TooltipDictionary.WORD].Value.ToString();
          HelpTT.Show(
              dgvHelp.Rows[hti.RowIndex].Cells[TooltipDictionary.COMMENT_COLUMN_NAME].Value.ToString().Replace(
              "\\n", System.Environment.NewLine).Replace(
              "\\t", "\t"),   //Подсказка по выбранному оператору
                  this,
                  new Point(
                  dgvHelp.Location.X + dgvHelp.Width + 5/* + SplitterDistance*/,
                  dgvHelp.Location.Y + dgvHelp.GetRowDisplayRectangle(hti.RowIndex, true).Y));
          _isVisible = true;
          OldRowIndex = hti.RowIndex;
        }
      }
    }

    private void dgvHelp_Leave(object sender, EventArgs e)
    {
      HelpTT.Hide(this);
      KeywordsTT.Hide(this);
      this.Hide();
    }

    private void SetColorAttributesHelpDGV()
    {
      foreach (DataGridViewRow row in dgvHelp.Rows)
      {
        if (row.Cells[TooltipDictionary.FORE_COLOR].Value != null)
        {
          row.Cells[TooltipDictionary.WORD].Style.ForeColor = Color.FromName(row.Cells[TooltipDictionary.FORE_COLOR].Value.ToString());
          row.Cells[TooltipDictionary.WORD].Style.SelectionForeColor = Color.FromName(row.Cells[TooltipDictionary.FORE_COLOR].Value.ToString());
        }
        row.Cells[TooltipDictionary.WORD].Style.BackColor = Color.White;
        row.Cells[TooltipDictionary.WORD].Style.SelectionBackColor = Color.LightBlue;
      }
    }

    public void ShowIntellisense(Point location, string searchText, int selectionStart, int selectionLength)
    {
      _selectionStart = selectionStart;
      _selectionLength = selectionLength;
      KeywordsTT.Tag = searchText;
      SetColorAttributesHelpDGV();
      //KeywordsTT.Tag = rowFilterText;
      //try
      //{
      //  ((DataTable)dgvHelp.DataSource).DefaultView.RowFilter = rowFilterText;
      //}
      //catch (Exception ex)
      //{
      //  KeywordsTT.Show(rowFilterText + Environment.NewLine + ex.Message, this);
      //}

      this.Location = location;
      this.Show();
      dgvHelp.Focus();
      ShowKeywordsHelp();
    }

    public DataGridView HelpDataGridView
    {
      get { return dgvHelp; }
    }
  }
}
