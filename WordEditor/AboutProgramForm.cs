using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FAQ_Net
{
  public partial class AboutProgramForm : Form
  {
    private string _copyText = string.Empty;
    public AboutProgramForm()
    {
      InitializeComponent();
      label1.Text = string.Format("FAQ.Net - версия {0}", Application.ProductVersion);
      var attributes = System.Reflection.Assembly.GetEntryAssembly().GetCustomAttributes(typeof(System.Reflection.AssemblyCopyrightAttribute), false);

      if (attributes.Length > 0)
      {
        label4.Text = (attributes[0] as System.Reflection.AssemblyCopyrightAttribute).Copyright;
      }
      rtbAboutApplication.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(rtbAboutApplication_LinkClicked);
    }

    private void rtbAboutApplication_LinkClicked(object sender, LinkClickedEventArgs e)
    {
      try
      {
        System.Diagnostics.Process.Start(e.LinkText);
      }
      catch (Exception ex)
      {
        MessageBox.Show("Error: " + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    private void tsmiCopy_Click(object sender, EventArgs e)
    {
      Clipboard.SetText(_copyText);
    }

    private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
    {
      object sourceCntrl = ((System.Windows.Forms.ContextMenuStrip)sender).SourceControl;
      if (sourceCntrl == linkLabel1)
        _copyText = linkLabel1.Text;
      if (sourceCntrl == rtbAboutApplication)
      {
        if (rtbAboutApplication.SelectedText.Length > 0)
          _copyText = rtbAboutApplication.SelectedText;
        else
          _copyText = rtbAboutApplication.Text;
      }
    }
  }
}
