using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WaitWnd
{
  public partial class WaitForm : Form
  {
    public WaitForm()
    {
      InitializeComponent();
      this.StartPosition = FormStartPosition.CenterParent;
      SetDefaultSettings();
    }
    public WaitForm(Form parent)
    {
      InitializeComponent();
      if (parent != null)
      {
        this.StartPosition = FormStartPosition.Manual;
        this.Location = new Point(parent.Location.X + parent.Width / 2 - this.Width / 2, parent.Location.Y + parent.Height / 2 - this.Height / 2);
      }
      else
      {
        this.StartPosition = FormStartPosition.CenterParent;
      }
      SetDefaultSettings();
    }

    private void SetDefaultSettings()
    {
      this.ShowInTaskbar = false;
      //this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
      this.AllowTransparency = true;
      this.ShowIcon = false;
      this.TransparencyKey = this.BackColor;//он же будет заменен на прозрачный цвет
      this.Opacity = 10.0;
    }

    public void CloseLoadingForm()
    {
      this.DialogResult = DialogResult.OK;
      this.Close();
      if (label1.Image != null)
      {
        label1.Image.Dispose();
      }
    }

    #region Перемещение контрола

    Point MouseDownLocation;

    private void Move_MouseDown(object sender, MouseEventArgs e)
    {
      if (e.Button == MouseButtons.Left)
        MouseDownLocation = e.Location;
    }

    private void Move_MouseMove(object sender, MouseEventArgs e)
    {
      if (e.Button == MouseButtons.Left)
      {
        this.Left += e.X - MouseDownLocation.X;
        this.Top += e.Y - MouseDownLocation.Y;
      }
    }

    #endregion Перемещение контрола
  }
}
