using System;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Security.Permissions;

namespace FAQ_Net
{   
    public delegate void ZoomChangedEventHandler(object sender, ZoomChangedEventArgs e);

    public class RichTextBoxCustom : RichTextBox
    {

    #region Код необходим для того, чтобы корректно обрабатывались RFT-таблицы (как в Word, чтобы данные оставались внутри ячеек таблицы)

    [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    public static extern IntPtr LoadLibrary(string libname);
    private static IntPtr RichEditModuleHandle;
    private const string RichEditDllV3 = "RichEd20.dll";
    private const string RichEditDllV41 = "Msftedit.dll";
    private const string RichEditClassV3A = "RichEdit20A";
    private const string RichEditClassV3W = "RichEdit20W";
    private const string RichEditClassV41W = "RICHEDIT50W";
    protected override CreateParams CreateParams
    {
      [SecurityPermission(SecurityAction.LinkDemand, UnmanagedCode = true)]
      get
      {
        if (RichEditModuleHandle == IntPtr.Zero)
        {
          RichEditModuleHandle = LoadLibrary(RichEditDllV41);
          if (RichEditModuleHandle == IntPtr.Zero)
          {
            return base.CreateParams;
          }
        }
        CreateParams theParams = base.CreateParams;
        theParams.ClassName = RichEditClassV41W;
        return theParams;
      }
    }

    #endregion Код необходим для того, чтобы корректно обрабатывались RFT-таблицы

        /// <summary>
        /// Occurs when the zoom factor changes.
        /// </summary>
        public event ZoomChangedEventHandler ZoomChanged;
        private const int EM_SETZOOM = 1024 + 225;
        private const int WM_MOUSEWHEEL = 522;
        //private const int EM_STREAMIN = 0x449; // ID события загрузки RTF-документа
        private float _ZoomFactor = 1;
       
       
        protected virtual void OnZoomChanged(ZoomChangedEventArgs e)
        {
            if (ZoomChanged != null)
            {
                if (this._ZoomFactor != this.ZoomFactor)
                {
                    this._ZoomFactor = e.ZoomFactor;
                    ZoomChanged(this, e);
                }
            }
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            switch (m.Msg)
            {
                case EM_SETZOOM:
                case WM_MOUSEWHEEL:
                    OnZoomChanged(new ZoomChangedEventArgs(this.ZoomFactor));
                    break;
             //case EM_STREAMIN:
             //  if (OnQuestionChanged != null)
             //    OnQuestionChanged();
             //  break;
            }
        }
    }

    public class ZoomChangedEventArgs : EventArgs
    {
        private readonly float zoomFactor;

        public ZoomChangedEventArgs(float Zoom_Factor)
        {
            zoomFactor = Zoom_Factor;
        }

        // Gets the current zoom factor.
        public float ZoomFactor
        {
            get { return zoomFactor; }
        }
    }

}