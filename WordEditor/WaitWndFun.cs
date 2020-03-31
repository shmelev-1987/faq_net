using System;
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
      try
      {
        loadthread = new Thread(new ThreadStart(LoadingProcessEx));
        loadthread.Start();
      }
      catch (Exception ex)
      {
        FAQ_Net.G.AddRowToLog("Не запускается фоновая форма ожидания Show()", ex.Message);
      }
    }
    /// <summary>
    /// 显示等待框
    /// </summary>
    /// <param name="parent">父窗体</param>
    public void Show(Form parent)
    {
      try
      {
        loadthread = new Thread(new ParameterizedThreadStart(LoadingProcessEx));
        loadthread.Start(parent);
      }
      catch (Exception ex)
      {
        FAQ_Net.G.AddRowToLog("Не запускается фоновая форма ожидания Show(parent)", ex.Message);
      }
    }
    public void Close()
    {
      try
      {
        if (loadingForm != null)
        {
          loadingForm.BeginInvoke(new System.Threading.ThreadStart(loadingForm.CloseLoadingForm));
          loadingForm = null;
          loadthread = null;
        }
      }
      catch (Exception ex)
      {
        FAQ_Net.G.AddRowToLog("Не закрывается фоновая форма ожидания", ex.Message);
      }
    }
    private void LoadingProcessEx()
    {
      try
      {
        loadingForm = new WaitForm();
        loadingForm.ShowDialog();
      }
      catch (Exception ex)
      {
        FAQ_Net.G.AddRowToLog("Не отображается фоновая форма ожидания LoadingProcessEx()", ex.Message);
      }
    }
    private void LoadingProcessEx(object parent)
    {
      try
      {
        Form Cparent = parent as Form;
        loadingForm = new WaitForm(Cparent);
        loadingForm.ShowDialog();
      }
      catch (Exception ex)
      {
        FAQ_Net.G.AddRowToLog("Не отображается фоновая форма ожидания LoadingProcessEx(parent)", ex.Message);
      }
    }
  }
}
