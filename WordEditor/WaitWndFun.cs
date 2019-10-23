using System.Threading;
using System.Windows.Forms;

namespace WaitWnd
{
  /// <summary>
  /// Пример взят с сайта https://www.codeproject.com/Tips/1165273/Simple-Display-Dialog-of-Waiting-in-WinForms
  /// </summary>
  public class WaitWndFun
  {
    WaitForm loadingForm;
    Thread loadthread;
    /// <summary>
    /// 显示等待框
    /// </summary>
    public void Show()
    {
      loadthread = new Thread(new ThreadStart(LoadingProcessEx));
      loadthread.Start();
    }
    /// <summary>
    /// 显示等待框
    /// </summary>
    /// <param name="parent">父窗体</param>
    public void Show(Form parent)
    {
      loadthread = new Thread(new ParameterizedThreadStart(LoadingProcessEx));
      loadthread.Start(parent);
    }
    public void Close()
    {
      if (loadingForm != null)
      {
        loadingForm.BeginInvoke(new System.Threading.ThreadStart(loadingForm.CloseLoadingForm));
        loadingForm = null;
        loadthread = null;
      }
    }
    private void LoadingProcessEx()
    {
      loadingForm = new WaitForm();
      loadingForm.ShowDialog();
    }
    private void LoadingProcessEx(object parent)
    {
      Form Cparent = parent as Form;
      loadingForm = new WaitForm(Cparent);
      loadingForm.ShowDialog();
    }
  }
}