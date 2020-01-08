using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
//using BinaryComponents.SuperList;
//using ListControl = BinaryComponents.SuperList.ListControl;

namespace FAQ_Net
{
  class QuestionListViewControl : IViewQuestion
  {
    private ListView _listControl;

    public QuestionListViewControl(Control owner, ContextMenuStrip contextMenuStrip, MainForm mf)
    {
      _listControl = new ListView();
      _listControl.Dock = DockStyle.Fill;

      _listControl.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      _listControl.HideSelection = false;
      _listControl.MultiSelect = false;
      _listControl.Size = new System.Drawing.Size(890, 67);
      _listControl.TabIndex = 4;
      _listControl.UseCompatibleStateImageBehavior = false;
      _listControl.View = System.Windows.Forms.View.List;      

      //_listControl.ShowCustomizeSection = false;
      //_listControl.Columns.Add(_questionColumn);
      //_listControl.Columns.Add(_createDateColumn);
      owner.Controls.Add(_listControl);
      _listControl.BringToFront();
      _listControl.Activation = ItemActivation.OneClick;
      _listControl.BackColor = System.Drawing.Color.FromArgb(28,28,28);
      _listControl.ForeColor = System.Drawing.Color.White;
      _listControl.ContextMenuStrip = contextMenuStrip;
      
      _listControl.MouseDown += mf.listView1_MouseDown;
      _listControl.SelectedIndexChanged += mf.listView1_SelectedIndexChanged;
    }

    //public void OnMouseDown1(object sender, MouseEventArgs e)
    //{
    //  if (MouseDown != null)
    //    MouseDown(_listControl, e);
    //}

    public string SelectedQuestionId
    {
      get
      {
        string result = string.Empty;
        if (_listControl.SelectedItems.Count != 0)
          result = _listControl.SelectedItems[0].Tag.ToString();
        return result;
      }
    }

    public string SelectedQuestionText
    {
      get { return _listControl.SelectedItems[0].Text; }
      set { _listControl.SelectedItems[0].Text = value; }
    }

    public object Tag
    {
      get { return _listControl.Tag; }
      set { _listControl.Tag = value; }
    }

    public bool Visible
    {
      get { return _listControl.Visible; }
      set { _listControl.Visible = value; }
    }

    public int CountItemsTotal
    {
      get { return _listControl.Items.Count; }
    }

    public int CountItemsSelected
    {
      get { return _listControl.SelectedItems.Count; }
    }

    //public Question SelectedQuestion
    //{
    //  get { return _listControl.SelectedItems[0] as Question; }
    //}

    public void ClearItems()
    {
      _listControl.Items.Clear();
    }

    public void AddItem(Question question)
    {
      ListViewItem i = new ListViewItem(question.Text);
      i.Tag = question.IdContent;
      _listControl.Items.Add(i);
    }

    public void AddQuestionsIntoListControl(bool isUseGlobalQuestionList)
    {
      if (_listControl.Visible)
      {
        G.AddItemsIntoListView(this, isUseGlobalQuestionList);
        return;
      }
    }

    public SortOrder Sorting
    {
      get { return _listControl.Sorting; }
      set { _listControl.Sorting = value; }
    }

    public void RemoveFirstSelectedItem()
    {
      _listControl.Items.RemoveAt(_listControl.SelectedItems[0].Index);
    }

    /// <summary>
    /// Получить номер выбранной строки
    /// </summary>
    public int SelectedIndex
    {
      get { return _listControl.SelectedItems[0].Index + 1; }
    }

    public ListView QuestionListView
    {
      get { return _listControl; }
    }
  }
}
