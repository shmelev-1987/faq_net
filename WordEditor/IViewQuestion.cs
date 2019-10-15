using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace FAQ_Net
{
  interface IViewQuestion
  {
    object Tag { get; set; }
    bool Visible { get; set; }
    int CountItemsTotal { get; }
    int CountItemsSelected { get; }
    string SelectedQuestionId { get; }
    string SelectedQuestionText { get; set; }
    void ClearItems();
    void AddItem(Question question);
    void AddQuestionsIntoListControl(bool isUseGlobalQuestionList);
    SortOrder Sorting { set; }

    void RemoveFirstSelectedItem();
    int SelectedIndex { get; }
  }
}
