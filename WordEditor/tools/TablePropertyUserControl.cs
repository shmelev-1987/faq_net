using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace FAQ_Net.tools
{
  public partial class TablePropertyUserControl : UserControl
  {
    public delegate void TableSizeSelectedEventHandler(object sender, TableSizeEventArgs e);

    /// <summary>
    /// Событие на изменение поля
    /// </summary>
    public event TableSizeSelectedEventHandler OnCreateTableClickButton;


    public TablePropertyUserControl()
    {
      InitializeComponent();
      numCountColumns.Minimum = 1;
      numCountRows.Minimum = 1;
      numCountColumns.Maximum = 100;
      numCountRows.Maximum = 100000;
    }

    private void btnCreateTable_Click(object sender, EventArgs e)
    {
      if (OnCreateTableClickButton != null)
        OnCreateTableClickButton(this, new TableSizeEventArgs(new Size(Convert.ToInt32(numCountColumns.Value), Convert.ToInt32(numCountRows.Value))));
    }

    #region Перемещение контрола

    Point MouseDownLocation;

    private void Control_MouseDown(object sender, MouseEventArgs e)
    {
      if (e.Button == MouseButtons.Left)
        MouseDownLocation = e.Location;
    }

    private void Control_MouseMove(object sender, MouseEventArgs e)
    {
      if (e.Button == MouseButtons.Left)
      {
        this.Left += e.X - MouseDownLocation.X;
        this.Top += e.Y - MouseDownLocation.Y;
      }
    }

    public void _btnClose_Click(object sender, EventArgs e)
    {
      this.Parent = null;
    }

    #endregion Перемещение контрола
  }
}
