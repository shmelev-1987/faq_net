// Freeware. Written by Matt Fomich.
// matt.fomich@gmail.com

using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace FAQ_Net
{
    /// <summary>
    /// Applies character and paragraph formatting to text in a RichTextBox.
    /// </summary>
    public class Format
    {
        private IntPtr hWnd;
        private const int WM_USER = 1024;
        private const int EM_GETCHARFORMAT = WM_USER + 58;
        private const int EM_SETCHARFORMAT = WM_USER + 68;
        private const uint CFM_FACE = 536870912;
        private const uint CFM_SIZE = 2147483648;
        private const int TWIPS_PER_POINT = 20;
        private const int SCF_DEFAULT = 0;
        private const int SCF_SELECTION = 1;
        public const int PFM_SPACEAFTER = 128;
        public const int PFM_LINESPACING = 256;
        private const int EM_GETPARAFORMAT = 1085;
        public const int EM_SETPARAFORMAT = 1095;
        public const int PFM_RIGHTINDENT = 2;
        private const byte BL_SINGLE_LINE_SPACING = 0;
        private const byte BL_ONE_AND_HALF_LINE_SPACING = 1;
        private const byte BL_DOUBLE_LINE_SPACING = 2;

        [DllImport("user32.dll", EntryPoint = "SendMessage", CharSet = CharSet.Auto)]
        private static extern Int32 SendMessage(IntPtr hWnd, Int32 msg, Int32 wParam, ref CHARFORMAT lParam);

        [DllImport("user32.dll", EntryPoint = "SendMessage", CharSet = CharSet.Auto)]
        private static extern Int32 SendMessage(IntPtr hWnd, Int32 msg, Int32 wParam, ref PARAFORMAT2 lParam);

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        private struct CHARFORMAT
        {
            public int cbSize;
            public UInt32 dwMask;
            public UInt32 dwEffects;
            public Int32 yHeight;
            public Int32 yOffset;
            public Int32 crTextColor;
            public byte bCharSet;
            public byte bPitchAndFamily;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
            public char[] szFaceName;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        public struct PARAFORMAT2
        {
            // PARAFORMAT & PARAFORMAT2
            public int cbSize;
            public uint dwMask;
            public Int16 wNumbering;
            public Int16 wReserved;
            public int dxStartIndent;
            public int dxRightIndent;
            public int dxOffset;
            public Int16 wAlignment;
            public Int16 cTabCount;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
            public int[] rgxTabs;
            // PARAFORMAT2 only below
            public int dySpaceBefore;
            public int dySpaceAfter;
            public int dyLineSpacing;
            public Int16 sStyle;
            public byte bLineSpacingRule;
            public byte bOutlineLevel;
            public Int16 wShadingWeight;
            public Int16 wShadingStyle;
            public Int16 wNumberingStart;
            public Int16 wNumberingStyle;
            public Int16 wNumberingTab;
            public Int16 wBorderSpace;
            public Int16 wBorderWidth;
            public Int16 wBorders;
        }

        /// <summary>
        /// Provides a simple interface to apply appropriate
        /// paragraph line spacing to the selected text.
        /// </summary>
        public struct LineSpacing
        {
            /// <summary>
            /// Single-spaced line spacing between lines of text.
            /// </summary>
            public static byte Single
            {
                get { return BL_SINGLE_LINE_SPACING; }
            }

            /// <summary>
            /// One and one half spaced line spacing between lines of text.
            /// </summary>
            public static byte OneAndHalf
            {
                get { return BL_ONE_AND_HALF_LINE_SPACING; }
            }

            /// <summary>
            /// Double-spaced line spacing between lines of text. 
            /// </summary>
            public static byte Double
            {
                get { return BL_DOUBLE_LINE_SPACING; }
            }
        }

        /// <summary>
        /// Initializes new instance of Format Class, for formatting text
        /// in a RichTextBox.
        /// </summary>
        /// <param name="rtbHandle">The handle to the RichTextbox to edit.</param>
        internal Format(IntPtr rtbHandle)
        {
            hWnd = rtbHandle;
        }

        /// <summary>
        /// Sets the selected text font face to
        /// the specified font name.
        /// </summary>
        internal string SelectionFontName
        {
            set { SetSelectionFontName(value); }
        }

        /// <summary>
        /// Sets the selected text font size to
        /// the specified size.
        /// </summary>
        internal float SelectionFontSize
        {
            set { SetSelectionFontSize(value); }
        }

        /// <summary>
        /// Adds (or removes) the specified font style
        /// to the selected text.
        /// </summary>
        /// <param name="fs"></param>
        /// <param name="AddStyle"></param>
        internal void SetSelectionFontStyle(FontStyle fs, bool AddStyle)
        {
            CHARFORMAT cf = new CHARFORMAT();
            cf.cbSize = Marshal.SizeOf(cf);
            cf.dwMask = (UInt32)fs;
            if (AddStyle)
            {
                cf.dwEffects = cf.dwMask;
            }
            SendMessage(hWnd, EM_SETCHARFORMAT, SCF_SELECTION, ref cf);
        }

        private void SetSelectionFontName(string font)
        {
            CHARFORMAT cf = new CHARFORMAT();
            cf.cbSize = Marshal.SizeOf(cf);
            cf.dwMask = CFM_FACE;
            char ch = new char();
            font = font.PadRight(32, ch);
            cf.szFaceName = font.ToCharArray();
            SendMessage(hWnd, EM_SETCHARFORMAT, SCF_SELECTION, ref cf);
        }

        private void SetSelectionFontSize(float size)
        {
            CHARFORMAT cf = new CHARFORMAT();
            cf.cbSize = Marshal.SizeOf(cf);
            cf.dwMask = CFM_SIZE;
            cf.yHeight = (int)(size * TWIPS_PER_POINT);
            SendMessage(hWnd, EM_SETCHARFORMAT, SCF_SELECTION, ref cf);
        }

        /// <summary>
        /// Sets vertical line spacing between lines
        /// of text, for the current text selection.
        /// </summary>
        /// <param name="spacing">Set to one of the bLineSpacingRule (BL_) constants,
        /// such as "BL_SINGLE_LINE_SPACING".</param>
        public void SetSelectionLineSpacing(byte spacing)
        {
            // Ignore request if spacing value not valid.
            // Valid values are 0, 1 and 2.
            if (spacing < 3)
            {
                PARAFORMAT2 pf = new PARAFORMAT2();
                pf.cbSize = Marshal.SizeOf(pf);
                pf.dwMask |= PFM_LINESPACING | PFM_SPACEAFTER;
                pf.bLineSpacingRule = spacing;
                SendMessage(hWnd, EM_SETPARAFORMAT, SCF_SELECTION, ref pf);
            }
        }

        /// <summary>
        /// Gets the existing vertical line spacing between
        /// lines of text, for the current text selection.
        /// </summary>
        public byte GetSelectionLineSpacing()
        {
            PARAFORMAT2 pf = new PARAFORMAT2();
            pf.cbSize = Marshal.SizeOf(pf);
            pf.dwMask |= PFM_LINESPACING | PFM_SPACEAFTER;
            SendMessage(hWnd, EM_GETPARAFORMAT, SCF_SELECTION, ref pf);
            return pf.bLineSpacingRule;
        }

        /// <summary>
        /// Gets or sets the right indent value of the
        /// selected text, in twips.
        /// </summary>
        public int SelectionRightIndentTwips
        {
            get { return GetSelectionRightIndent(); }

            set { SetSelectionRightIndent(value); }
        }

        /// <summary>
        /// Sets the right indent value. Right indent is the
        /// distance to indent to the left, from the right
        /// margin. The larger the number, the further to
        /// the left the text will be indented.
        /// </summary>
        /// <param name="twipsIndentValue"></param>
        private void SetSelectionRightIndent(int twipsIndentValue)
        {
            PARAFORMAT2 pf = new PARAFORMAT2();
            pf.cbSize = Marshal.SizeOf(pf);
            pf.dwMask = PFM_RIGHTINDENT;
            pf.dxRightIndent = twipsIndentValue;
            SendMessage(hWnd, EM_SETPARAFORMAT, SCF_SELECTION, ref pf);
        }

        /// <summary>
        /// Returns the rtf formatting right indent value for the
        /// selected text, in twips.
        /// </summary>
        /// <returns>The right indent value in twips.</returns>
        private int GetSelectionRightIndent()
        {
            PARAFORMAT2 pf = new PARAFORMAT2();
            pf.cbSize = Marshal.SizeOf(pf);
            pf.dwMask = PFM_RIGHTINDENT;
            SendMessage(hWnd, EM_GETPARAFORMAT, SCF_SELECTION, ref pf);
            return pf.dxRightIndent;
        }
    }
}



