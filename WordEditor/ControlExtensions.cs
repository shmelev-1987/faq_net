using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Reflection;

namespace FAQ_Net
{
  public static class ControlExtensions
  {
    public static T Clone<T>(T controlToClone)
        where T : Control
    {
      PropertyInfo[] controlProperties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

      T instance = Activator.CreateInstance<T>();

      RichTextBox rtb = new RichTextBox();
      foreach (PropertyInfo propInfo in controlProperties)
      {
        if (propInfo.Name == "Parent")
          continue;
        if (propInfo.CanWrite)
        {
          if (propInfo.Name != "WindowTarget")
          {
            try
            {
              propInfo.SetValue(instance, propInfo.GetValue(controlToClone, null), null);
            }
            catch (Exception) { }
          }
        }
      }

      return instance;
    }

    //public static DataGridView CloneDataGridView<T>(T controlToClone)
    //    where T : DataGridView
    //{
    //  DataGridView dgv = new DataGridView();
    //  PropertyInfo[] controlProperties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

    //  //RichTextBox rtb = new RichTextBox();
    //  foreach (PropertyInfo propInfo in controlProperties)
    //  {
    //    if (propInfo.Name == "Parent")
    //      continue;
    //    if (propInfo.CanWrite)
    //    {
    //      if (propInfo.Name == "DefaultCellStyle")
    //      {
    //        dgv.DefaultCellStyle = new DataGridViewCellStyle();
    //        dgv.DefaultCellStyle.Font = new System.Drawing.Font((propInfo.GetValue(controlToClone, null) as DataGridViewCellStyle).Font.FontFamily
    //          , (propInfo.GetValue(controlToClone, null) as DataGridViewCellStyle).Font.Size);
    //      }
    //      else
    //      if (propInfo.Name != "WindowTarget")
    //      {
    //        try
    //        {
    //          propInfo.SetValue(dgv, propInfo.GetValue(controlToClone, null), null);
    //        }
    //        catch (Exception ex)
    //        {
    //          //rtb.AppendText(Environment.NewLine + propInfo.Name + ex.Message);
    //        }
    //      }
    //    }
    //  }
    //  //using (Form f = new Form())
    //  //{
    //  //  rtb.Dock = DockStyle.Fill;
    //  //  f.Controls.Add(rtb);
    //  //  f.ShowDialog();
    //  //}

    //  return dgv;
    //}
  }
}
