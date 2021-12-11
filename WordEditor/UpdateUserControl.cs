using System;
using System.Drawing;
using System.Windows.Forms;

namespace FAQ_Net
{
  public partial class UpdateUserControl : UserControl
  {
    private string _downloadReleaseUrl;
    private Version _lastVersion = new Version();
    public const string NOT_SHOW_UPDATE_VERSION = "NotShowUpdateVer";

    public UpdateUserControl()
    {
      InitializeComponent();
    }

    public string UpdateInfoText
    {
      set { txbUpdateInfo.Text = value; }
    }

    public string DownloadReleaseUrl
    {
      set { _downloadReleaseUrl = value; }
    }

    public Version LastVersion
    {
      set { _lastVersion = value; }
    }

    private void btnGoToUpdateUrl_Click(object sender, EventArgs e)
    {
      if (_downloadReleaseUrl.StartsWith("http:") ||
          _downloadReleaseUrl.StartsWith("https:"))
      {
        System.Diagnostics.Process browserProcess = new System.Diagnostics.Process();

        try
        {
          // true is the default, but it is important not to set it to false
          browserProcess.StartInfo.UseShellExecute = true;
          browserProcess.StartInfo.FileName = _downloadReleaseUrl;
          browserProcess.Start();
        }
        catch (System.ComponentModel.Win32Exception noBrowser)
        {
          if (noBrowser.ErrorCode == -2147467259)
            MessageBox.Show("Запуск браузера", "Браузер не найден: " + noBrowser.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        catch (Exception)
        {
          try
          {
            browserProcess.StartInfo.FileName = "iexplore.exe";
            browserProcess.StartInfo.Arguments = _downloadReleaseUrl;
            browserProcess.Start();
          }
          catch (Exception ex)
          {
            MessageBox.Show("Запуск браузера", "Ошибка: " + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
          }
        }
        browserProcess.Dispose();
      }
      else
        MessageBox.Show("URL-адрес должен начинаться с 'http:' или 'https:'", "Неверный URL", MessageBoxButtons.OK,
            MessageBoxIcon.Warning);
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

    #endregion Перемещение контрола

    private void btnCancel_Click(object sender, EventArgs e)
    {
      this.Dispose();
    }

    private void chkNotShowUpdate_CheckedChanged(object sender, EventArgs e)
    {
      if (chkNotShowUpdate.Checked)
        MainForm._settingsXml.SetSetting(NOT_SHOW_UPDATE_VERSION
          , chkNotShowUpdate.Checked ? _lastVersion.ToString() : new Version(0, 0, 0, 0).ToString());
    }
  }
}
