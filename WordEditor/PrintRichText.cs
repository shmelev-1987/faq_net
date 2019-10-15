using System;
using System.Runtime.InteropServices;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace FAQ_Net
{
    ///<Summary>
    /// Adapted from Martin Muller's article:
    /// "Getting WYSIWYG Print Results from a .NET RichTextBox",
    /// MSDN, January 2003.
    /// http://msdn.microsoft.com/en-us/library/ms996492.aspx
    ///
    /// Print interfaces (PageSetup, PrintPreview, PrintDialog) have been added.
    ///</Summary>
    internal class PrintRichText
    {
        private PageSettings pageSettings;
        private RichTextBox rtb;
        private const Int32 WM_USER = 0x400;
        private const Int32 EM_FORMATRANGE = WM_USER + 57;
        private int toChar;
        private int FirstCharEachPage;

        [DllImport("user32.dll")]
        private static extern Int32 SendMessage(IntPtr hWnd, Int32 msg, Int32 wParam, IntPtr lParam);

        [StructLayout(LayoutKind.Sequential)]
        private struct RECT
        {
            public int left;
            public int top;
            public int right;
            public int bottom;
        }
        [StructLayout(LayoutKind.Sequential)]
        private struct CHARRANGE
        {
            public int cpMin;
            public int cpMax;
        }
        [StructLayout(LayoutKind.Sequential)]
        private struct FORMATRANGE
        {
            public IntPtr hdc;
            public IntPtr hdcTarget;
            public RECT rc;
            public RECT rcPage;
            public CHARRANGE chrg;
        }

        /// <summary>
        /// Prints either the selected rich text, or all
        /// the text from a RichTextBox. 
        /// </summary>
        /// <param name="rtbToPrint">ref The RichTextbox to print from.</param>
        /// <param name="pageSet">A Printing PageSettings object, or null.
        /// If null is used, then the rich text will be printed using the
        /// default page settings. (Portrait, 8.5 x 11, 1 in. margins).
        /// </param>
        internal PrintRichText(ref RichTextBoxCustom rtbToPrint, PageSettings pageSet)
        {
            rtb = rtbToPrint;
            pageSettings = pageSet;
        }

        public void PrintDialog()
        {
            using (PrintDocument pd = new PrintDocument())
            {
                using (PrintDialog dlg = new PrintDialog())
                {
                    if (pageSettings != null)
                    { pd.DefaultPageSettings = pageSettings; }
                    pd.BeginPrint += new PrintEventHandler(printDoc_BeginPrint);
                    pd.PrintPage += new PrintPageEventHandler(printDoc_PrintPage);
                    pd.EndPrint += new PrintEventHandler(printDoc_EndPrint);
                    dlg.Document = pd;
                    // Allow user print selection option if there is
                    // any selected text.
                    dlg.AllowSelection = rtb.SelectionLength > 0;
                    dlg.AllowPrintToFile = true;
                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        pd.Print();
                    }
                }
            }
        }

        /// <summary>
        /// Displays a PageSetupDialog to the user.
        /// </summary>
        public void PageSetupDlg()
        {
            using (PrintDocument pd = new PrintDocument())
            {
                if (pageSettings != null)
                { pd.DefaultPageSettings = pageSettings; }
                pd.BeginPrint += new PrintEventHandler(printDoc_BeginPrint);
                pd.PrintPage += new PrintPageEventHandler(printDoc_PrintPage);
                pd.EndPrint += new PrintEventHandler(printDoc_EndPrint);
                using (PageSetupDialog ps = new PageSetupDialog())
                {
                    ps.Document = pd;
                    if (ps.ShowDialog() == DialogResult.OK)
                    {
                        pageSettings = pd.DefaultPageSettings;
                    }
                }
            }
        }

        /// <summary>
        /// Displays a PrintPreview dialog to the user.
        /// </summary>
        public void PrintPreviewDlg()
        {
            using (PrintPreviewDialog prev = new PrintPreviewDialog())
            {
                using (PrintDocument pd = new PrintDocument())
                {
                    if (pageSettings != null)
                    { pd.DefaultPageSettings = pageSettings; }
                    pd.BeginPrint += new PrintEventHandler(printDoc_BeginPrint);
                    pd.PrintPage += new PrintPageEventHandler(printDoc_PrintPage);
                    pd.EndPrint += new PrintEventHandler(printDoc_EndPrint);
                    prev.Document = pd;
                    prev.PrintPreviewControl.Zoom = 1;
                    prev.Width = rtb.Parent.Width - 200;
                    prev.Height = rtb.Parent.Height - 150;
                    prev.UseAntiAlias = true;
                    prev.ShowIcon = false;
                    prev.AutoScaleMode = AutoScaleMode.Dpi;
                    prev.AutoSizeMode = AutoSizeMode.GrowOnly;
                    prev.Shown += new EventHandler(printPrev_Shown);
                    prev.ShowDialog();
                }
            }
        }

        private void printPrev_Shown(object sender, EventArgs e)
        {
            ((PrintPreviewDialog)sender).Left = rtb.Parent.Left + 100;
            ((PrintPreviewDialog)sender).Top = rtb.Parent.Top + 120;
        }

        /// <summary>
        /// Convert between 1/100 inch (unit used by the .NET framework)
        /// and twips (1/1440 inch, used by Win32 API calls)
        /// </summary>
        /// <param name="n">Value in 1/100 inch</param>
        /// <returns>Value in twips</returns>
        private Int32 HundredthInchToTwips(int n)
        {
            // return (Int32)(n * 14.4);
            // changed method for more accuracy.
            return (Int32)(decimal.Multiply(n, 14.4M));
        }

        /// <summary>
        /// Free cached data from rich edit control after printing.
        /// </summary>
        private void FormatRangeDone()
        {
            IntPtr lParam = new IntPtr(0);
            SendMessage(rtb.Handle, EM_FORMATRANGE, 0, lParam);
        }

        /// <summary>
        /// Calculate or render the contents of our RichTextBox for printing.
        /// </summary>
        /// <param name="measureOnly">If true, only the calculation is performed,
        /// otherwise the text is rendered as well</param>
        /// <param name="e">The PrintPageEventArgs object from the
        /// PrintPage event</param>
        /// <param name="charFrom">Index of first character to be printed</param>
        /// <param name="charTo">Index of last character to be printed</param>
        /// <returns>(Index of last character that fitted on the
        /// page) + 1</returns>
        private int FormatRange(bool measureOnly, PrintPageEventArgs e,
                               int charFrom, int charTo)
        {
            // Specify which characters to print.
            CHARRANGE cr;
            cr.cpMin = charFrom;
            cr.cpMax = charTo;
            // Specify the area inside page margins.
            RECT rc;
            rc.top = 250;// HundredthInchToTwips(e.MarginBounds.Top);   //Отступ от верхнего края листа
            rc.bottom = HundredthInchToTwips(e.MarginBounds.Bottom);
            rc.left = HundredthInchToTwips(e.MarginBounds.Left);
            rc.right = HundredthInchToTwips(e.MarginBounds.Right);
            // Specify the page area.
            RECT rcPage;
            rcPage.top = HundredthInchToTwips(e.PageBounds.Top);
            rcPage.bottom = HundredthInchToTwips(e.PageBounds.Bottom);
            rcPage.left = HundredthInchToTwips(e.PageBounds.Left);
            rcPage.right = HundredthInchToTwips(e.PageBounds.Right);
            // Get device context of output device.
            IntPtr hdc = e.Graphics.GetHdc();
            // Fill in the FORMATRANGE struct.
            FORMATRANGE fr;
            fr.chrg = cr;
            fr.hdc = hdc;
            fr.hdcTarget = hdc;
            fr.rc = rc;
            fr.rcPage = rcPage;
            // Non-Zero wParam means render, Zero means measure.
            Int32 wParam = (measureOnly ? 0 : 1);
            // Allocate memory for the FORMATRANGE struct and
            // copy the contents of our struct to this memory
            IntPtr lParam = Marshal.AllocCoTaskMem(Marshal.SizeOf(fr));
            Marshal.StructureToPtr(fr, lParam, false);
            // Send the actual Win32 message.
            int res = SendMessage(rtb.Handle, EM_FORMATRANGE, wParam, lParam);
            // Free allocated memory.
            Marshal.FreeCoTaskMem(lParam);
            // and release the device context.
            e.Graphics.ReleaseHdc(hdc);
            return res;
        }

        private void printDoc_BeginPrint(object sender, PrintEventArgs e)
        {
            // Set range of chars to print, either selection or all text.
            if (((PrintDocument)sender).PrinterSettings.PrintRange == PrintRange.Selection)
            {
                FirstCharEachPage = rtb.SelectionStart;
                toChar = FirstCharEachPage + rtb.SelectionLength;
            }
            else
            {
                FirstCharEachPage = 0;
                toChar = rtb.TextLength;
            }
        }

        private void printDoc_PrintPage(object sender, PrintPageEventArgs e)
        {
            // calculate and render as much text as will fit
            // on the page and remember the last character
            // printed for the beginning of the next page.
            FirstCharEachPage = FormatRange(false, e, FirstCharEachPage, toChar);
            // check if there are more pages to print
            if (FirstCharEachPage < toChar)
            {
                e.HasMorePages = true;
            }
            else
            {
                e.HasMorePages = false;
            }
        }

        private void printDoc_EndPrint(object sender, PrintEventArgs e)
        {
            // Clean up cached information.
            FormatRangeDone();
        }
    }
}