using System;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Text;

namespace FAQ_Net
{
  public delegate void ZoomChangedEventHandler(object sender, ZoomChangedEventArgs e);

  public class RichTextBoxCustom : RichTextBox
  {

    #region ��� ��������� ��� ����, ����� ��������� �������������� RFT-������� (��� � Word, ����� ������ ���������� ������ ����� �������)

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

    #endregion ��� ��������� ��� ����, ����� ��������� �������������� RFT-�������

    [DllImport("User32.dll", CharSet = CharSet.Auto, EntryPoint = "SendMessage")]
    static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

    private void ScrollWithoutSmooth(ref Message m)
    {
      int scrollLines = SystemInformation.MouseWheelScrollLines;
      for (int i = 0; i < scrollLines; i++)
      {
        if (m.WParam == (IntPtr)4287102976)
          SendMessage(m.HWnd, WM_VSCROLL, (IntPtr)SB_LINEDOWN, (IntPtr)0);
        else
          SendMessage(m.HWnd, WM_VSCROLL, (IntPtr)SB_LINEUP, (IntPtr)0);
      }
    }

    /// <summary>
    /// Occurs when the zoom factor changes.
    /// </summary>
    public event ZoomChangedEventHandler ZoomChanged;
    private const int EM_SETZOOM = 1024 + 225;
    private const int WM_MOUSEWHEEL = 522;
    //private const int EM_STREAMIN = 0x449; // ID ������� �������� RTF-���������
    private const int WM_CHAR = 0x102;
    private float _ZoomFactor = 1;
    private const int WM_HSCROLL = 0x114;
    private const int WM_VSCROLL = 0x115;
    private const int SB_LINEDOWN = 1;
    private const int SB_LINEUP = 0;
    private const int SB_THUMBTRACK = 5;


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
      // ���� ���� ������� ��������� ������ Ctrl+Space, �� ��������� ���������, ����� �� ���������� ������
      if (Constants.CtrlSpaceEntered && m.Msg == WM_CHAR)
      {
        Constants.CtrlSpaceEntered = false;
        return;
      }
      // ��� �������
      //using (System.IO.StreamWriter sw = new System.IO.StreamWriter(@"d:\MyDocuments\2019\log.log", true))
      //{
      //  sw.WriteLine(string.Format("{0}\t{1}", DateTime.Now.ToString("dd.MM.yyyy hh:mm:ss"), m.ToString()));
      //  sw.Close();
      //}
      switch (m.Msg)
      {
        case EM_SETZOOM:
        case WM_MOUSEWHEEL:
          if (!Constants.RtfSmoothScrolling
          && (m.WParam == (IntPtr)4287102976 /* Scroll down */ || m.WParam == (IntPtr)7864320 /* Scroll up */))
            ScrollWithoutSmooth(ref m);
          else
          {
            base.WndProc(ref m);
            OnZoomChanged(new ZoomChangedEventArgs(this.ZoomFactor));
          }
          break;
        //case WM_VSCROLL:
        //    if (!Constants.RtfSmoothScrolling && ((uint)m.WParam & 0xFF) == SB_THUMBTRACK)
        //      ScrollWithoutSmooth(ref m);
        //    else
        //      base.WndProc(ref m);
        //    break;
        default:
          base.WndProc(ref m);
          break;
          //case EM_STREAMIN:
          //  if (OnQuestionChanged != null)
          //    OnQuestionChanged();
          //  break;
      }
    }

    #region Insert Image

    // �������� ��������� ����: https://www.codeproject.com/Articles/4544/Insert-Plain-Text-and-Images-into-RichTextBox-at-R
    // Insert Plain Text and Images into RichTextBox at Runtime

    /// <summary>
		/// Initializes the text colors, creates dictionaries for RTF colors and
		/// font families, and stores the horizontal and vertical resolution of
		/// the RichTextBox's graphics context.
		/// </summary>
    public RichTextBoxCustom() : base()
    {
      // Initialize default text and background colors
      textColor = RtfColor.Black;
      highlightColor = RtfColor.White;

      // Initialize the dictionary mapping color codes to definitions
      rtfColor = new System.Collections.Specialized.HybridDictionary();
      rtfColor.Add(RtfColor.Aqua, RtfColorDef.Aqua);
      rtfColor.Add(RtfColor.Black, RtfColorDef.Black);
      rtfColor.Add(RtfColor.Blue, RtfColorDef.Blue);
      rtfColor.Add(RtfColor.Fuchsia, RtfColorDef.Fuchsia);
      rtfColor.Add(RtfColor.Gray, RtfColorDef.Gray);
      rtfColor.Add(RtfColor.Green, RtfColorDef.Green);
      rtfColor.Add(RtfColor.Lime, RtfColorDef.Lime);
      rtfColor.Add(RtfColor.Maroon, RtfColorDef.Maroon);
      rtfColor.Add(RtfColor.Navy, RtfColorDef.Navy);
      rtfColor.Add(RtfColor.Olive, RtfColorDef.Olive);
      rtfColor.Add(RtfColor.Purple, RtfColorDef.Purple);
      rtfColor.Add(RtfColor.Red, RtfColorDef.Red);
      rtfColor.Add(RtfColor.Silver, RtfColorDef.Silver);
      rtfColor.Add(RtfColor.Teal, RtfColorDef.Teal);
      rtfColor.Add(RtfColor.White, RtfColorDef.White);
      rtfColor.Add(RtfColor.Yellow, RtfColorDef.Yellow);

      // Initialize the dictionary mapping default Framework font families to
      // RTF font families
      rtfFontFamily = new System.Collections.Specialized.HybridDictionary();
      rtfFontFamily.Add(FontFamily.GenericMonospace.Name, RtfFontFamilyDef.Modern);
      rtfFontFamily.Add(FontFamily.GenericSansSerif, RtfFontFamilyDef.Swiss);
      rtfFontFamily.Add(FontFamily.GenericSerif, RtfFontFamilyDef.Roman);
      rtfFontFamily.Add(FF_UNKNOWN, RtfFontFamilyDef.Unknown);
    }

    #region My Structs

    // Definitions for colors in an RTF document
    private struct RtfColorDef
    {
      public const string Black = @"\red0\green0\blue0";
      public const string Maroon = @"\red128\green0\blue0";
      public const string Green = @"\red0\green128\blue0";
      public const string Olive = @"\red128\green128\blue0";
      public const string Navy = @"\red0\green0\blue128";
      public const string Purple = @"\red128\green0\blue128";
      public const string Teal = @"\red0\green128\blue128";
      public const string Gray = @"\red128\green128\blue128";
      public const string Silver = @"\red192\green192\blue192";
      public const string Red = @"\red255\green0\blue0";
      public const string Lime = @"\red0\green255\blue0";
      public const string Yellow = @"\red255\green255\blue0";
      public const string Blue = @"\red0\green0\blue255";
      public const string Fuchsia = @"\red255\green0\blue255";
      public const string Aqua = @"\red0\green255\blue255";
      public const string White = @"\red255\green255\blue255";
    }

    // Control words for RTF font families
    private struct RtfFontFamilyDef
    {
      public const string Unknown = @"\fnil";
      public const string Roman = @"\froman";
      public const string Swiss = @"\fswiss";
      public const string Modern = @"\fmodern";
      public const string Script = @"\fscript";
      public const string Decor = @"\fdecor";
      public const string Technical = @"\ftech";
      public const string BiDirect = @"\fbidi";
    }

    #endregion

    #region My Constants

    // Not used in this application.  Descriptions can be found with documentation
    // of Windows GDI function SetMapMode
    private const int MM_TEXT = 1;
    private const int MM_LOMETRIC = 2;
    private const int MM_HIMETRIC = 3;
    private const int MM_LOENGLISH = 4;
    private const int MM_HIENGLISH = 5;
    private const int MM_TWIPS = 6;

    // Ensures that the metafile maintains a 1:1 aspect ratio
    private const int MM_ISOTROPIC = 7;

    // Allows the x-coordinates and y-coordinates of the metafile to be adjusted
    // independently
    private const int MM_ANISOTROPIC = 8;

    // Represents an unknown font family
    private const string FF_UNKNOWN = "UNKNOWN";

    // The number of hundredths of millimeters (0.01 mm) in an inch
    // For more information, see GetImagePrefix() method.
    private const int HMM_PER_INCH = 2540;

    // The number of twips in an inch
    // For more information, see GetImagePrefix() method.
    private const int TWIPS_PER_INCH = 1440;

    #endregion

    // Enum for possible RTF colors
    public enum RtfColor
    {
      Black, Maroon, Green, Olive, Navy, Purple, Teal, Gray, Silver,
      Red, Lime, Yellow, Blue, Fuchsia, Aqua, White
    }

    #region My Privates

    // The default text color
    private RtfColor textColor;

    // The default text background color
    private RtfColor highlightColor;

    // Dictionary that maps color enums to RTF color codes
    private System.Collections.Specialized.HybridDictionary rtfColor;

    // Dictionary that mapas Framework font families to RTF font families
    private System.Collections.Specialized.HybridDictionary rtfFontFamily;

    #endregion

    #region My Enums

    // Specifies the flags/options for the unmanaged call to the GDI+ method
    // Metafile.EmfToWmfBits().
    private enum EmfToWmfBitsFlags
    {

      // Use the default conversion
      EmfToWmfBitsFlagsDefault = 0x00000000,

      // Embedded the source of the EMF metafiel within the resulting WMF
      // metafile
      EmfToWmfBitsFlagsEmbedEmf = 0x00000001,

      // Place a 22-byte header in the resulting WMF file.  The header is
      // required for the metafile to be considered placeable.
      EmfToWmfBitsFlagsIncludePlaceable = 0x00000002,

      // Don't simulate clipping by using the XOR operator.
      EmfToWmfBitsFlagsNoXORClip = 0x00000004
    };

    #endregion

    #region Elements required to create an RTF document

    /* RTF HEADER
		 * ----------
		 * 
		 * \rtf[N]		- For text to be considered to be RTF, it must be enclosed in this tag.
		 *				  rtf1 is used because the RichTextBox conforms to RTF Specification
		 *				  version 1.
		 * \ansi		- The character set.
		 * \ansicpg[N]	- Specifies that unicode characters might be embedded. ansicpg1252
		 *				  is the default used by Windows.
		 * \deff[N]		- The default font. \deff0 means the default font is the first font
		 *				  found.
		 * \deflang[N]	- The default language. \deflang1033 specifies US English.
		 * */
    private const string RTF_HEADER = @"{\rtf1\ansi\ansicpg1252\deff0\deflang1033";

    /* RTF DOCUMENT AREA
		 * -----------------
		 * 
		 * \viewkind[N]	- The type of view or zoom level.  \viewkind4 specifies normal view.
		 * \uc[N]		- The number of bytes corresponding to a Unicode character.
		 * \pard		- Resets to default paragraph properties
		 * \cf[N]		- Foreground color.  \cf1 refers to the color at index 1 in
		 *				  the color table
		 * \f[N]		- Font number. \f0 refers to the font at index 0 in the font
		 *				  table.
		 * \fs[N]		- Font size in half-points.
		 * */
    private const string RTF_DOCUMENT_PRE = @"\viewkind4\uc1\pard\cf1\f0\fs20";
    private const string RTF_DOCUMENT_POST = @"\cf0\fs17}";
    private string RTF_IMAGE_POST = @"}";

    #endregion

    #region RTF Helpers

    /// <summary>
    /// Creates a font table from a font object.  When an Insert or Append 
    /// operation is performed a font is either specified or the default font
    /// is used.  In any case, on any Insert or Append, only one font is used,
    /// thus the font table will always contain a single font.  The font table
    /// should have the form ...
    /// 
    /// {\fonttbl{\f0\[FAMILY]\fcharset0 [FONT_NAME];}
    /// </summary>
    /// <param name="_font"></param>
    /// <returns></returns>
    private string GetFontTable(Font _font)
    {

      StringBuilder _fontTable = new StringBuilder();

      // Append table control string
      _fontTable.Append(@"{\fonttbl{\f0");
      _fontTable.Append(@"\");

      // If the font's family corresponds to an RTF family, append the
      // RTF family name, else, append the RTF for unknown font family.
      if (rtfFontFamily.Contains(_font.FontFamily.Name))
        _fontTable.Append(rtfFontFamily[_font.FontFamily.Name]);
      else
        _fontTable.Append(rtfFontFamily[FF_UNKNOWN]);

      // \fcharset specifies the character set of a font in the font table.
      // 0 is for ANSI.
      _fontTable.Append(@"\fcharset0 ");

      // Append the name of the font
      _fontTable.Append(_font.Name);

      // Close control string
      _fontTable.Append(@";}}");

      return _fontTable.ToString();
    }

    ///// <summary>
    ///// Creates a font table from the RtfColor structure.  When an Insert or Append
    ///// operation is performed, _textColor and _backColor are either specified
    ///// or the default is used.  In any case, on any Insert or Append, only three
    ///// colors are used.  The default color of the RichTextBox (signified by a
    ///// semicolon (;) without a definition), is always the first color (index 0) in
    ///// the color table.  The second color is always the text color, and the third
    ///// is always the highlight color (color behind the text).  The color table
    ///// should have the form ...
    ///// 
    ///// {\colortbl ;[TEXT_COLOR];[HIGHLIGHT_COLOR];}
    ///// 
    ///// </summary>
    ///// <param name="_textColor"></param>
    ///// <param name="_backColor"></param>
    ///// <returns></returns>
    //private string GetColorTable(RtfColor _textColor, RtfColor _backColor)
    //{

    //  StringBuilder _colorTable = new StringBuilder();

    //  // Append color table control string and default font (;)
    //  _colorTable.Append(@"{\colortbl ;");

    //  // Append the text color
    //  _colorTable.Append(rtfColor[_textColor]);
    //  _colorTable.Append(@";");

    //  // Append the highlight color
    //  _colorTable.Append(rtfColor[_backColor]);
    //  _colorTable.Append(@";}\n");

    //  return _colorTable.ToString();
    //}

    /// <summary>
    /// Called by overrided RichTextBox.Rtf accessor.
    /// Removes the null character from the RTF.  This is residue from developing
    /// the control for a specific instant messaging protocol and can be ommitted.
    /// </summary>
    /// <param name="_originalRtf"></param>
    /// <returns>RTF without null character</returns>
    private string RemoveBadChars(string _originalRtf)
    {
      return _originalRtf.Replace("\0", "");
    }

    #endregion

    /// <summary>
    /// Inserts an image into the RichTextBox.  The image is wrapped in a Windows
    /// Format Metafile, because although Microsoft discourages the use of a WMF,
    /// the RichTextBox (and even MS Word), wraps an image in a WMF before inserting
    /// the image into a document.  The WMF is attached in HEX format (a string of
    /// HEX numbers).
    /// 
    /// The RTF Specification v1.6 says that you should be able to insert bitmaps,
    /// .jpegs, .gifs, .pngs, and Enhanced Metafiles (.emf) directly into an RTF
    /// document without the WMF wrapper. This works fine with MS Word,
    /// however, when you don't wrap images in a WMF, WordPad and
    /// RichTextBoxes simply ignore them.  Both use the riched20.dll or msfted.dll.
    /// </summary>
    /// <remarks>
    /// NOTE: The image is inserted wherever the caret is at the time of the call,
    /// and if any text is selected, that text is replaced.
    /// </remarks>
    /// <param name="_image"></param>
    public void InsertImage(Image _image)
    {

      StringBuilder _rtf = new StringBuilder();

      // Append the RTF header
      _rtf.Append(RTF_HEADER);

      // Create the font table using the RichTextBox's current font and append
      // it to the RTF string
      _rtf.Append(GetFontTable(this.Font));

      // Create the image control string and append it to the RTF string
      _rtf.Append(GetImagePrefix(_image));

      // Create the Windows Metafile and append its bytes in HEX format
      _rtf.Append(GetRtfImage(_image));

      // Close the RTF image control string
      _rtf.Append(RTF_IMAGE_POST);

      this.SelectedRtf = _rtf.ToString();
    }

    /// <summary>
    /// Creates the RTF control string that describes the image being inserted.
    /// This description (in this case) specifies that the image is an
    /// MM_ANISOTROPIC metafile, meaning that both X and Y axes can be scaled
    /// independently.  The control string also gives the images current dimensions,
    /// and its target dimensions, so if you want to control the size of the
    /// image being inserted, this would be the place to do it. The prefix should
    /// have the form ...
    /// 
    /// {\pict\wmetafile8\picw[A]\pich[B]\picwgoal[C]\pichgoal[D]
    /// 
    /// where ...
    /// 
    /// A	= current width of the metafile in hundredths of millimeters (0.01mm)
    ///		= Image Width in Inches * Number of (0.01mm) per inch
    ///		= (Image Width in Pixels / Graphics Context's Horizontal Resolution) * 2540
    ///		= (Image Width in Pixels / Graphics.DpiX) * 2540
    /// 
    /// B	= current height of the metafile in hundredths of millimeters (0.01mm)
    ///		= Image Height in Inches * Number of (0.01mm) per inch
    ///		= (Image Height in Pixels / Graphics Context's Vertical Resolution) * 2540
    ///		= (Image Height in Pixels / Graphics.DpiX) * 2540
    /// 
    /// C	= target width of the metafile in twips
    ///		= Image Width in Inches * Number of twips per inch
    ///		= (Image Width in Pixels / Graphics Context's Horizontal Resolution) * 1440
    ///		= (Image Width in Pixels / Graphics.DpiX) * 1440
    /// 
    /// D	= target height of the metafile in twips
    ///		= Image Height in Inches * Number of twips per inch
    ///		= (Image Height in Pixels / Graphics Context's Horizontal Resolution) * 1440
    ///		= (Image Height in Pixels / Graphics.DpiX) * 1440
    ///	
    /// </summary>
    /// <remarks>
    /// The Graphics Context's resolution is simply the current resolution at which
    /// windows is being displayed.  Normally it's 96 dpi, but instead of assuming
    /// I just added the code.
    /// 
    /// According to Ken Howe at pbdr.com, "Twips are screen-independent units
    /// used to ensure that the placement and proportion of screen elements in
    /// your screen application are the same on all display systems."
    /// 
    /// Units Used
    /// ----------
    /// 1 Twip = 1/20 Point
    /// 1 Point = 1/72 Inch
    /// 1 Twip = 1/1440 Inch
    /// 
    /// 1 Inch = 2.54 cm
    /// 1 Inch = 25.4 mm
    /// 1 Inch = 2540 (0.01)mm
    /// </remarks>
    /// <param name="_image"></param>
    /// <returns></returns>
    private string GetImagePrefix(Image _image)
    {
      // The horizontal resolution at which the control is being displayed
      float xDpi;

      // The vertical resolution at which the control is being displayed
      float yDpi;

      using (Graphics _graphics = this.CreateGraphics())
      {
        xDpi = _graphics.DpiX;
        yDpi = _graphics.DpiY;
      }

      StringBuilder _rtf = new StringBuilder();

      // Calculate the current width of the image in (0.01)mm
      int picw = (int)Math.Round((_image.Width / xDpi) * HMM_PER_INCH);

      // Calculate the current height of the image in (0.01)mm
      int pich = (int)Math.Round((_image.Height / yDpi) * HMM_PER_INCH);

      // Calculate the target width of the image in twips
      int picwgoal = (int)Math.Round((_image.Width / xDpi) * TWIPS_PER_INCH);

      // Calculate the target height of the image in twips
      int pichgoal = (int)Math.Round((_image.Height / yDpi) * TWIPS_PER_INCH);

      // Append values to RTF string
      _rtf.Append(@"{\pict\wmetafile8");
      _rtf.Append(@"\picw");
      _rtf.Append(picw);
      _rtf.Append(@"\pich");
      _rtf.Append(pich);
      _rtf.Append(@"\picwgoal");
      _rtf.Append(picwgoal);
      _rtf.Append(@"\pichgoal");
      _rtf.Append(pichgoal);
      _rtf.Append(" ");

      return _rtf.ToString();
    }

    /// <summary>
    /// Use the EmfToWmfBits function in the GDI+ specification to convert a 
    /// Enhanced Metafile to a Windows Metafile
    /// </summary>
    /// <param name="_hEmf">
    /// A handle to the Enhanced Metafile to be converted
    /// </param>
    /// <param name="_bufferSize">
    /// The size of the buffer used to store the Windows Metafile bits returned
    /// </param>
    /// <param name="_buffer">
    /// An array of bytes used to hold the Windows Metafile bits returned
    /// </param>
    /// <param name="_mappingMode">
    /// The mapping mode of the image.  This control uses MM_ANISOTROPIC.
    /// </param>
    /// <param name="_flags">
    /// Flags used to specify the format of the Windows Metafile returned
    /// </param>
    [DllImportAttribute("gdiplus.dll")]
    private static extern uint GdipEmfToWmfBits(IntPtr _hEmf, uint _bufferSize,
      byte[] _buffer, int _mappingMode, EmfToWmfBitsFlags _flags);


    /// <summary>
    /// Wraps the image in an Enhanced Metafile by drawing the image onto the
    /// graphics context, then converts the Enhanced Metafile to a Windows
    /// Metafile, and finally appends the bits of the Windows Metafile in HEX
    /// to a string and returns the string.
    /// </summary>
    /// <param name="_image"></param>
    /// <returns>
    /// A string containing the bits of a Windows Metafile in HEX
    /// </returns>
    private string GetRtfImage(Image _image)
    {

      StringBuilder _rtf = null;

      // Used to store the enhanced metafile
      System.IO.MemoryStream _stream = null;

      // Used to create the metafile and draw the image
      Graphics _graphics = null;

      // The enhanced metafile
      System.Drawing.Imaging.Metafile _metaFile = null;

      // Handle to the device context used to create the metafile
      IntPtr _hdc;

      try
      {
        _rtf = new StringBuilder();
        _stream = new System.IO.MemoryStream();

        // Get a graphics context from the RichTextBox
        using (_graphics = this.CreateGraphics())
        {

          // Get the device context from the graphics context
          _hdc = _graphics.GetHdc();

          // Create a new Enhanced Metafile from the device context
          _metaFile = new System.Drawing.Imaging.Metafile(_stream, _hdc);

          // Release the device context
          _graphics.ReleaseHdc(_hdc);
        }

        // Get a graphics context from the Enhanced Metafile
        using (_graphics = Graphics.FromImage(_metaFile))
        {

          // Draw the image on the Enhanced Metafile
          _graphics.DrawImage(_image, new Rectangle(0, 0, _image.Width, _image.Height));

        }

        // Get the handle of the Enhanced Metafile
        IntPtr _hEmf = _metaFile.GetHenhmetafile();

        // A call to EmfToWmfBits with a null buffer return the size of the
        // buffer need to store the WMF bits.  Use this to get the buffer
        // size.
        uint _bufferSize = GdipEmfToWmfBits(_hEmf, 0, null, MM_ANISOTROPIC,
          EmfToWmfBitsFlags.EmfToWmfBitsFlagsDefault);

        // Create an array to hold the bits
        byte[] _buffer = new byte[_bufferSize];

        // A call to EmfToWmfBits with a valid buffer copies the bits into the
        // buffer an returns the number of bits in the WMF.  
        uint _convertedSize = GdipEmfToWmfBits(_hEmf, _bufferSize, _buffer, MM_ANISOTROPIC,
          EmfToWmfBitsFlags.EmfToWmfBitsFlagsDefault);

        // Append the bits to the RTF string
        for (int i = 0; i < _buffer.Length; ++i)
        {
          _rtf.Append(String.Format("{0:X2}", _buffer[i]));
        }

        return _rtf.ToString();
      }
      finally
      {
        if (_graphics != null)
          _graphics.Dispose();
        if (_metaFile != null)
          _metaFile.Dispose();
        if (_stream != null)
          _stream.Close();
      }
    }

    #endregion

    #region BULLETING

    // Source code from: https://www.codeproject.com/Articles/18878/RichTextBox-with-Search-Line-Numbering-Bulleting-P

    [StructLayout(LayoutKind.Sequential)]
    private class PARAFORMAT2
    {
      public int cbSize;
      public int dwMask;
      public short wNumbering;
      public short wReserved;
      public int dxStartIndent;
      public int dxRightIndent;
      public int dxOffset;
      public short wAlignment;
      public short cTabCount;
      [MarshalAs(UnmanagedType.ByValArray, SizeConst = 0x20)]
      public int[] rgxTabs;

      public int dySpaceBefore; // Vertical spacing before para
      public int dySpaceAfter; // Vertical spacing after para
      public int dyLineSpacing; // Line spacing depending on Rule
      public short sStyle; // Style handle
      public byte bLineSpacingRule; // Rule for line spacing (see tom.doc)
      public byte bOutlineLevel; // Outline Level
      public short wShadingWeight; // Shading in hundredths of a per cent
      public short wShadingStyle; // Byte 0: style, nib 2: cfpat, 3: cbpat
      public short wNumberingStart; // Starting value for numbering
      public short wNumberingStyle; // Alignment, Roman/Arabic, (), ), ., etc.
      public short wNumberingTab; // Space bet 1st indent and 1st-line text
      public short wBorderSpace; // Border-text spaces (nbl/bdr in pts)
      public short wBorderWidth; // Pen widths (nbl/bdr in half twips)
      public short wBorders; // Border styles (nibble/border)

      public PARAFORMAT2()
      {
        this.cbSize = Marshal.SizeOf(typeof(PARAFORMAT2));
      }
    }

    #region PARAFORMAT MASK VALUES
    // PARAFORMAT mask values
    private const uint PFM_STARTINDENT = 0x00000001;
    private const uint PFM_RIGHTINDENT = 0x00000002;
    private const uint PFM_OFFSET = 0x00000004;
    private const uint PFM_ALIGNMENT = 0x00000008;
    private const uint PFM_TABSTOPS = 0x00000010;
    private const uint PFM_NUMBERING = 0x00000020;
    private const uint PFM_OFFSETINDENT = 0x80000000;

    // PARAFORMAT 2.0 masks and effects
    private const uint PFM_SPACEBEFORE = 0x00000040;
    private const uint PFM_SPACEAFTER = 0x00000080;
    private const uint PFM_LINESPACING = 0x00000100;
    private const uint PFM_STYLE = 0x00000400;
    private const uint PFM_BORDER = 0x00000800; // (*)
    private const uint PFM_SHADING = 0x00001000; // (*)
    private const uint PFM_NUMBERINGSTYLE = 0x00002000; // RE 3.0
    private const uint PFM_NUMBERINGTAB = 0x00004000; // RE 3.0
    private const uint PFM_NUMBERINGSTART = 0x00008000; // RE 3.0

    private const uint PFM_RTLPARA = 0x00010000;
    private const uint PFM_KEEP = 0x00020000; // (*)
    private const uint PFM_KEEPNEXT = 0x00040000; // (*)
    private const uint PFM_PAGEBREAKBEFORE = 0x00080000; // (*)
    private const uint PFM_NOLINENUMBER = 0x00100000; // (*)
    private const uint PFM_NOWIDOWCONTROL = 0x00200000; // (*)
    private const uint PFM_DONOTHYPHEN = 0x00400000; // (*)
    private const uint PFM_SIDEBYSIDE = 0x00800000; // (*)
    private const uint PFM_TABLE = 0x40000000; // RE 3.0
    private const uint PFM_TEXTWRAPPINGBREAK = 0x20000000; // RE 3.0
    private const uint PFM_TABLEROWDELIMITER = 0x10000000; // RE 4.0

    // The following three properties are read only
    private const uint PFM_COLLAPSED = 0x01000000; // RE 3.0
    private const uint PFM_OUTLINELEVEL = 0x02000000; // RE 3.0
    private const uint PFM_BOX = 0x04000000; // RE 3.0
    private const uint PFM_RESERVED2 = 0x08000000; // RE 4.0

    public enum AdvRichTextBulletType
    {
      Normal = 1,
      Number = 2,
      LowerCaseLetter = 3,
      UpperCaseLetter = 4,
      LowerCaseRoman = 5,
      UpperCaseRoman = 6
    }

    public enum AdvRichTextBulletStyle
    {
      RightParenthesis = 0x000,
      DoubleParenthesis = 0x100,
      Period = 0x200,
      Plain = 0x300,
      NoNumber = 0x400
    }
    #endregion

    [DllImport("user32.dll", CharSet = System.Runtime.InteropServices.CharSet.Auto)]
    private static extern IntPtr SendMessage(HandleRef hWnd, int msg, int wParam, [In, Out, MarshalAs(UnmanagedType.LPStruct)] PARAFORMAT2 lParam);

    private AdvRichTextBulletType _BulletType = AdvRichTextBulletType.Number;
    private AdvRichTextBulletStyle _BulletStyle = AdvRichTextBulletStyle.Period;
    private short _BulletNumberStart = 1;


    public AdvRichTextBulletType BulletType
    {
      get { return _BulletType; }
      set
      {
        _BulletType = value;
        NumberedBullet(true);
      }
    }
    public AdvRichTextBulletStyle BulletStyle
    {
      get { return _BulletStyle; }
      set
      {
        _BulletStyle = value;
        NumberedBullet(true);
      }
    }
    public void NumberedBullet(bool TurnOn)
    {
      PARAFORMAT2 paraformat1 = new PARAFORMAT2();
      paraformat1.dwMask = (int)(PFM_NUMBERING | PFM_OFFSET | PFM_NUMBERINGSTART | PFM_NUMBERINGSTYLE | PFM_NUMBERINGTAB);
      if (!TurnOn)
      {
        paraformat1.wNumbering = 0;
        paraformat1.dxOffset = 0;
      }
      else
      {
        paraformat1.wNumbering = (short)_BulletType;
        paraformat1.dxOffset = this.BulletIndent;
        paraformat1.wNumberingStyle = (short)_BulletStyle;
        paraformat1.wNumberingStart = _BulletNumberStart;
        paraformat1.wNumberingTab = 500;
      }
      SendMessage(new System.Runtime.InteropServices.HandleRef(this, this.Handle), 0x447, 0, paraformat1);
    }

    #endregion BULLETING

    #region BeginUpdate(), EndUpdate()
    // Source code: http://geekswithblogs.net/pvidler/archive/2003/10/15/182.aspx
    private int updating = 0;
    private int oldEventMask = 0;

    /// <summary>
    /// Maintains performance while updating.
    /// </summary>
    /// <remarks>
    /// <para>
    /// It is recommended to call this method before doing
    /// any major updates that you do not wish the user to
    /// see. Remember to call EndUpdate when you are finished
    /// with the update. Nested calls are supported.
    /// </para>
    /// <para>
    /// Calling this method will prevent redrawing. It will
    /// also setup the event mask of the underlying richedit
    /// control so that no events are sent.
    /// </para>
    /// </remarks>
    public void BeginUpdate()
    {
      // Deal with nested calls.
      ++updating;

      if (updating > 1)
        return;

      // Prevent the control from raising any events.
      oldEventMask = SendMessage(new HandleRef(this, Handle),
                                  EM_SETEVENTMASK, 0, 0);

      // Prevent the control from redrawing itself.
      SendMessage(new HandleRef(this, Handle),
                   WM_SETREDRAW, 0, 0);
    }

    /// <summary>
    /// Resumes drawing and event handling.
    /// </summary>
    /// <remarks>
    /// This method should be called every time a call is made
    /// made to BeginUpdate. It resets the event mask to it's
    /// original value and enables redrawing of the control.
    /// </remarks>
    public void EndUpdate()
    {
      // Deal with nested calls.
      --updating;

      if (updating > 0)
        return;

      // Allow the control to redraw itself.
      SendMessage(new HandleRef(this, Handle),
                   WM_SETREDRAW, 1, 0);

      // Allow the control to raise event messages.
      SendMessage(new HandleRef(this, Handle),
                   EM_SETEVENTMASK, 0, oldEventMask);
    }
    #endregion BeginUpdate(), EndUpdate()

    #region Justify TextAlign
    // Source code: http://geekswithblogs.net/pvidler/archive/2003/10/15/182.aspx
    // Constants from the Platform SDK.
    private const int EM_SETEVENTMASK = 1073;
    private const int EM_GETPARAFORMAT = 1085;
    private const int EM_SETPARAFORMAT = 1095;
    private const int EM_SETTYPOGRAPHYOPTIONS = 1226;
    private const int WM_SETREDRAW = 11;
    private const int TO_ADVANCEDTYPOGRAPHY = 1;
    private const int SCF_SELECTION = 1;

    // It makes no difference if we use PARAFORMAT or
    // PARAFORMAT2 here, so I have opted for PARAFORMAT2.
    [StructLayout(LayoutKind.Sequential)]
    private struct PARAFORMAT
    {
      public int cbSize;
      public uint dwMask;
      public short wNumbering;
      public short wReserved;
      public int dxStartIndent;
      public int dxRightIndent;
      public int dxOffset;
      public short wAlignment;
      public short cTabCount;
      [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
      public int[] rgxTabs;

      // PARAFORMAT2 from here onwards.
      public int dySpaceBefore;
      public int dySpaceAfter;
      public int dyLineSpacing;
      public short sStyle;
      public byte bLineSpacingRule;
      public byte bOutlineLevel;
      public short wShadingWeight;
      public short wShadingStyle;
      public short wNumberingStart;
      public short wNumberingStyle;
      public short wNumberingTab;
      public short wBorderSpace;
      public short wBorderWidth;
      public short wBorders;
    }

    /// <summary>
    /// Gets or sets the alignment to apply to the current
    /// selection or insertion point.
    /// </summary>
    /// <remarks>
    /// Replaces the SelectionAlignment from
    /// <see cref="RichTextBox"/>.
    /// </remarks>
    public new TextAlign SelectionAlignment
    {
      get
      {
        PARAFORMAT fmt = new PARAFORMAT();
        fmt.cbSize = Marshal.SizeOf(fmt);

        // Get the alignment.
        SendMessage(new HandleRef(this, Handle),
                     EM_GETPARAFORMAT,
                     SCF_SELECTION, ref fmt);

        // Default to Left align.
        if ((fmt.dwMask & PFM_ALIGNMENT) == 0)
          return TextAlign.Left;

        return (TextAlign)fmt.wAlignment;
      }

      set
      {
        PARAFORMAT fmt = new PARAFORMAT();
        fmt.cbSize = Marshal.SizeOf(fmt);
        fmt.dwMask = PFM_ALIGNMENT;
        fmt.wAlignment = (short)value;

        // Set the alignment.
        SendMessage(new HandleRef(this, Handle),
                     EM_SETPARAFORMAT,
                     SCF_SELECTION, ref fmt);
      }
    }

    [DllImport("user32", CharSet = CharSet.Auto)]
    private static extern int SendMessage(HandleRef hWnd,
                                           int msg,
                                           int wParam,
                                           int lParam);

    [DllImport("user32", CharSet = CharSet.Auto)]
    private static extern int SendMessage(HandleRef hWnd,
                                           int msg,
                                           int wParam,
                                           ref PARAFORMAT lp);
    #endregion Justify TextAlign
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

  /// <summary>
  /// Specifies how text in a <see cref="AdvRichTextBox"/> is
  /// horizontally aligned.
  /// </summary>
  public enum TextAlign
  {
    /// <summary>
    /// The text is aligned to the left.
    /// </summary>
    Left = 1,

    /// <summary>
    /// The text is aligned to the right.
    /// </summary>
    Right = 2,

    /// <summary>
    /// The text is aligned in the center.
    /// </summary>
    Center = 3,

    /// <summary>
    /// The text is justified.
    /// </summary>
    Justify = 4
  }
}
