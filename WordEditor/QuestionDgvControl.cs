using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace FAQ_Net
{
  class QuestionDgvControl : IViewQuestion
  {
    private DataGridView _dgvControl;
    private DataGridViewTextBoxColumn _idColumn;
    private DataGridViewTextBoxColumn _questionColumn;
    private DataGridViewTextBoxColumn _createDateColumn;
    private DataGridViewTextBoxColumn _modifDateColumn;

    public QuestionDgvControl(Control owner, ContextMenuStrip contextMenuStrip)
    {
      _idColumn = new DataGridViewTextBoxColumn();
      _idColumn.ValueType = typeof(int);
      _idColumn.Visible = false;
      _idColumn.HeaderText = "ID-вопроса";

      _questionColumn = new DataGridViewTextBoxColumn();
      _questionColumn.ValueType = typeof (string);
      //_questionColumn.ColumnName = "question";
      _questionColumn.HeaderText = "Вопрос";

      _createDateColumn = new DataGridViewTextBoxColumn();
      _createDateColumn.ValueType = typeof (DateTime);
      _createDateColumn.CellTemplate.Style.Format = "dd.MM.yyyy HH:mm:ss";
      _createDateColumn.Width = 110;
       //"create_date"
      _createDateColumn.HeaderText = "Дата создания";

      _modifDateColumn = new DataGridViewTextBoxColumn();
      _modifDateColumn.ValueType = typeof(DateTime);
      _modifDateColumn.CellTemplate.Style.Format = "dd.MM.yyyy HH:mm:ss";
      _modifDateColumn.Width = 110;
      //"create_date"
      _modifDateColumn.HeaderText = "Дата изменения";

      _dgvControl = new DataGridView();
      _dgvControl.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
      _dgvControl.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
      _dgvControl.AllowUserToOrderColumns = true;
      _dgvControl.AllowUserToAddRows = false;
      _dgvControl.AllowUserToDeleteRows = false;
      _dgvControl.EnableHeadersVisualStyles = false;

      _dgvControl.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
      _dgvControl.MultiSelect = false;
      _dgvControl.Dock = DockStyle.Fill;
      //_listControl.ShowCustomizeSection = false;
      _dgvControl.Columns.Add(_idColumn);
      _dgvControl.Columns.Add(_questionColumn);
      _dgvControl.Columns.Add(_createDateColumn);
      _dgvControl.Columns.Add(_modifDateColumn);
      owner.Controls.Add(_dgvControl);
      _dgvControl.BringToFront();
      _dgvControl.ContextMenuStrip = contextMenuStrip;
      _dgvControl.MouseDown += (Application.OpenForms[0] as MainForm).listView1_MouseDown;
      //_listControl.RowFocusChanged += (Application.OpenForms[0] as MainForm).listView1_SelectedIndexChanged;
    }

    public object Tag
    {
      get { return _dgvControl.Tag; }
      set { _dgvControl.Tag = value; }
    }

    //public string Tag
    //{
    //  get { return (_listControl.SelectedItems[0].Items[0] as Question).IdContent.ToString(); }
    //  //set { _listControl.SelectedItems[0].Items[0] } ;
    //}

    //public event MouseEventHandler MouseDown;

    //public void OnMouseDown1(object sender, MouseEventArgs e)
    //{
    //  if (MouseDown != null)
    //    MouseDown(_listControl, e);
    //}

    public bool Visible
    {
      get { return _dgvControl.Visible; }
      set { _dgvControl.Visible = value; }
    }

    public int CountItemsTotal
    {
      get { return _dgvControl.Rows.Count; }
    }

    public int CountItemsSelected
    {
      get { return _dgvControl.SelectedRows.Count; }
    }

    public string SelectedQuestionId
    {
      get { return _dgvControl.SelectedRows[0].Cells[0].Value.ToString(); }
    }

    public string SelectedQuestionText
    {
      get { return _dgvControl.SelectedRows[0].Cells[1].Value.ToString(); }
      set { _dgvControl.SelectedRows[0].Cells[1].Value = value; }
    }

    public DateTime SelectedQuestionCreateDate
    {
      get { return Convert.ToDateTime(_dgvControl.SelectedRows[0].Cells[2].Value.ToString()); }
    }

    public void ClearItems()
    {
      _dgvControl.Rows.Clear();
    }

    public void AddItem(Question question)
    {
      _dgvControl.Rows.Add(question.IdContent, question.Text, question.CreateTime, question.ModifTime);
    }

    public void AddQuestionsIntoListControl(bool isUseGlobalQuestionList)
    {
      if (_dgvControl.Visible)
      {
        G.AddItemsIntoListView(this, isUseGlobalQuestionList);
        return;
      }
    }

    public SortOrder Sorting
    {
      set
      {
        if (value == SortOrder.None)
          _dgvControl.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
        else
        if (value == SortOrder.Ascending)
          _dgvControl.Sort(_dgvControl.Columns[1], System.ComponentModel.ListSortDirection.Ascending);
        else
        if (value == SortOrder.Descending)
        {
          _dgvControl.Sort(_dgvControl.Columns[1], System.ComponentModel.ListSortDirection.Descending);
        }
      }
    }

    public void RemoveFirstSelectedItem()
    {
      _dgvControl.Rows.RemoveAt(_dgvControl.SelectedRows[0].Index);
    }

    /// <summary>
    /// Получить номер выбранной строки
    /// </summary>
    public int SelectedIndex
    {
      get { return _dgvControl.CurrentRow.Index + 1; }
    }

    /// <summary>
    /// Получить номер выбранной строки
    /// </summary>
    public DataGridView DgvControl
    {
      get { return _dgvControl; }
    }
  }
}
