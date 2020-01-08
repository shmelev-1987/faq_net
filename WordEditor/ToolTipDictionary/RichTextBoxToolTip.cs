using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;
using System.Drawing.Drawing2D;

namespace FAQ_Net
{

  /// <summary>
  /// This will hold info items for our dictionary
  /// </summary>
  [Serializable()]
  [TypeConverter(typeof(ExpandableObjectConverter))]
  public class DictionaryInfo
  {
    /// <summary>
    /// Если 0, то это подсказка действует на все вопросы, иначе на один (текущий)
    /// </summary>
    public int IdContent { get; set; }
    /// <summary>
    /// Заголовок подсказки
    /// </summary>
    public string Title { get; set; }
    /// <summary>
    /// Описание подсказки
    /// </summary>
    public string Description { get; set; }
    /// <summary>
    /// Номер записи
    /// </summary>
    public int Index { get; set; }
    ///// <summary>
    ///// ID-вопроса, на который ссылается подсказка, чтобы происходил переход 
    ///// </summary>
    //public int TargetVoprosId { get; set; }
    /// <summary>
    /// Если Url содержит только цифру, например: http://1, то это означает, что должен выполняться переход на вопрос из БД, ID которого равен "1"
    /// </summary>
    public string Url { get; set; }
    public TooltipDictionary.TooltipType TooltipType { get; set; }
  }
  

  /// <summary>
  /// Contains methods for manipulating the dictionary used for our RichTextBox
  /// </summary>
  [EditorBrowsable(EditorBrowsableState.Always)]
  public class eDictionary
  {
    private List<DictionaryInfo> dicList = new List<DictionaryInfo>();

    /// <summary>
    /// Adds a new dictionary info item to the dictionary
    /// </summary>
    /// <param name="inf">The info item to add as a 'DictionaryInfo'</param>
    public void Add(DictionaryInfo inf)
    {
      inf.Index = dicList.Count + 1;
      dicList.Add(inf);
    }

    /// <summary>
    /// Adds a new dictionary info item to the dictionary
    /// </summary>
    /// <param name="inf">The info item to add as a 'DictionaryInfo'</param>
    public void Add(int idContent, string title, string description, string url, TooltipDictionary.TooltipType tooltipType)
    {
      var inf = new DictionaryInfo()
      {
          IdContent = idContent
        , Title = title
        , Description = description
        , Url = url
        , TooltipType = tooltipType
        , Index = dicList.Count + 1
      };
      if (MainForm.IdContentUrlRegEx_v2.IsMatch(url))
      {
        var questionInfo = GetByTitle(0, "\\\\" + url.Substring(2));
        if (questionInfo != null)
          inf.Description = questionInfo.Description;
      }
      else
      if (MainForm.IdContentUrlRegEx_v1.IsMatch(url))
      {
        var questionInfo = GetByTitle(0, "\\\\" + url.Substring(7));
        if (questionInfo != null)
          inf.Description = questionInfo.Description;
      }
      dicList.Add(inf);
    }

    /// <summary>
    /// Removes an existing items from the dictionary
    /// </summary>
    /// <param name="inf">The info item to remove as a 'DictionaryInfo'</param>
    public void Remove(DictionaryInfo inf)
    {
      try
      {
        dicList.Remove(inf);
      }
      catch { throw new Exception("InfNotFoundInDictinaryException"); };
    }

    /// <summary>
    /// Removes an info item at a specified index from the dictionary
    /// </summary>
    /// <param name="infIndex">The info-item's index to target</param>
    public void RemoveAt(int infIndex)
    {
      try
      {
        dicList.RemoveAt(infIndex);
      }
      catch { throw new Exception("IndexNotFoundException"); }
    }

    /// <summary>
    /// Checks wheather a dictionary info item that has the same 
    /// Title, Description and Index exists in the dictionary or not
    /// </summary>
    /// <param name="inf">The dictionary info item to check for</param>
    /// <returns></returns>
    public bool Exists(DictionaryInfo inf)
    {
      return dicList.Contains(inf);
    }

    /// <summary>
    /// Checks wheather the dictionary contains an info item that has the
    /// same Title as the specified one
    /// </summary>
    /// <param name="infTitle">The dictionary info item to check for</param>
    /// <returns></returns>
    public bool Contains(int idContent, string infTitle)
    {
      return dicList.Find(x => x.IdContent == idContent && (string.Compare(x.Title, infTitle, true) == 0)) != null;
      //bool _yes = false;
      //for (int i=0;i< dicList.Count;i++)
      //{
      //  if (dicList[i].Title == infTitle)
      //  {
      //    _yes = true;
      //    break;
      //  }
      //};
      //return _yes;
    }

    /// <summary>
    /// Returns all the occurences of the specified title whithin the dictionary
    /// </summary>
    /// <param name="infTitle">The dictionary info item to get</param>
    /// <returns>If no occurence was found a new empty list will be returned</returns>
    public DictionaryInfo GetByTitle(int idContent, string infTitle)
    {
      DictionaryInfo result = dicList.Find(x => x.IdContent == idContent && (string.Compare(x.Title, infTitle, true) == 0));
      if (result == null)
      {
        result = dicList.Find(x => x.IdContent == 0 && (string.Compare(x.Title, infTitle, true) == 0));
        //if (result != null)
        //  result.Description = dicList[result.Index].Description;
      }
      return result;
    }

    /// <summary>
    /// Checks wheather the dictionary contains an info item that has the
    /// same Index as the specified one
    /// </summary>
    /// <param name="infIndex">The dictionary info item to check for</param>
    /// <returns></returns>
    public bool Contains(int infIndex)
    {
      bool _yes = false;
      foreach (var e in dicList) { if (e.Index == infIndex) _yes = true; };
      return _yes;
    }

    /// <summary>
    /// Edits the specified dictionary info item according to the specified value
    /// </summary>
    /// <param name="inf">The desired info item from the dictionary</param>
    /// <param name="title">The new title. This value can be null to return the existing title</param>
    /// <param name="description">The new description. This value can be null to return the existing description</param>
    public void Edit(DictionaryInfo inf, string title, string description, int idContent, int tooltipType, string url)
    {
      if (dicList.Contains(inf))
      {
        inf.Title = title;
        inf.Description = description;
        inf.TooltipType = (TooltipDictionary.TooltipType)tooltipType;
        inf.IdContent = idContent;
        inf.Url = url;
      }
      else
      {
        throw new Exception("ElementNotFoundException");
      };
    }

    /// <summary>
    /// Returns a value indicating the capacity of this dictionary
    /// </summary>
    public int Capacity
    {
      get { return dicList.Capacity; }
      set { dicList.Capacity = value; }
    }

    /// <summary>
    /// Holds all values that were defined on the current class variable.
    /// </summary>
    public List<DictionaryInfo> Dictionary
    {
      get { return dicList; }
      set
      {
        foreach (var x in value)
        {
          if (this.Contains(x.Index))
          {
            throw new Exception("An index of '" + x.Index + "' already exists in the collection!\nNone of the specified items were been added");
          };
        };

        this.AddRange(value);
      }
    }

    public void AddRange(IEnumerable<DictionaryInfo> list)
    {
      foreach (var i in list)
      {
        var x = (DictionaryInfo)i;
        x.Index = dicList.Count + 1;
        dicList.Add(x);
      };
    }
  }

  //public class WaitTimer
  //{
  //  System.Windows.Forms.Timer _timer;
  //  private bool _intervalMoved;
  //  public bool IntervalMoved
  //  {
  //    get { return _intervalMoved; }
  //    set
  //    {
  //      _intervalMoved = value;
  //      if (_intervalMoved == true)
  //      {
  //        _timer.Start();
  //      }
  //    }
  //  }

  //  public WaitTimer()
  //  {
  //    _timer = new Timer();
  //    _timer.Interval = 1000;
  //    _timer.Tick += TimerTick;
  //  }

  //  private void TimerTick(object sender, EventArgs e)
  //  {
  //    _timer.Stop();
  //    IntervalMoved = true;
  //  }
  //}

  //[Browsable(false)]
  //[EditorBrowsable(EditorBrowsableState.Never)]
  //public class eToolTip : ToolTip
  //{
  //  #region Hidden methods & props

  //  [Browsable(false)]
  //  [EditorBrowsable(EditorBrowsableState.Never)]
  //  new public bool Active { get; set; }

  //  [Browsable(false)]
  //  [EditorBrowsable(EditorBrowsableState.Never)]
  //  new public int AutomaticDelay { get { return base.AutomaticDelay; } set { base.AutomaticDelay = value; } }

  //  [Browsable(false)]
  //  [EditorBrowsable(EditorBrowsableState.Never)]
  //  new public int AutoPopDelay { get { return base.AutoPopDelay; } set { base.AutoPopDelay = value; } }

  //  [Browsable(false)]
  //  [EditorBrowsable(EditorBrowsableState.Never)]
  //  new public Color BackColor { get { return base.BackColor; } set { base.BackColor = value; } }

  //  [Browsable(false)]
  //  [EditorBrowsable(EditorBrowsableState.Never)]
  //  protected override CreateParams CreateParams { get { return base.CreateParams; } }

  //  [Browsable(false)]
  //  [EditorBrowsable(EditorBrowsableState.Never)]
  //  new public Color ForeColor { get { return base.ForeColor; } set { base.ForeColor = value; } }

  //  [Browsable(false)]
  //  [EditorBrowsable(EditorBrowsableState.Never)]
  //  new public int InitialDelay { get { return base.InitialDelay; } set { base.InitialDelay = value; } }

  //  [Browsable(false)]
  //  [EditorBrowsable(EditorBrowsableState.Never)]
  //  new public bool IsBalloon { get { return base.IsBalloon; } set { base.IsBalloon = value; } }

  //  [Browsable(false)]
  //  [EditorBrowsable(EditorBrowsableState.Never)]
  //  new public bool OwnerDraw { get { return base.OwnerDraw; } set { base.OwnerDraw = value; } }

  //  [Browsable(false)]
  //  [EditorBrowsable(EditorBrowsableState.Never)]
  //  new public int ReshowDelay { get { return base.ReshowDelay; } set { base.ReshowDelay = value; } }

  //  [Browsable(false)]
  //  [EditorBrowsable(EditorBrowsableState.Never)]
  //  new public bool ShowAlways { get { return base.ShowAlways; } set { base.ShowAlways = value; } }

  //  [Browsable(false)]
  //  [EditorBrowsable(EditorBrowsableState.Never)]
  //  new public bool StripAmpersands { get { return base.StripAmpersands; } set { base.StripAmpersands = value; } }

  //  [Browsable(false)]
  //  [EditorBrowsable(EditorBrowsableState.Never)]
  //  new public object Tag { get { return base.Tag; } set { base.Tag = value; } }

  //  [Browsable(false)]
  //  [EditorBrowsable(EditorBrowsableState.Never)]
  //  new public ToolTipIcon ToolTipIcon { get { return base.ToolTipIcon; } set { base.ToolTipIcon = value; } }

  //  [Browsable(false)]
  //  [EditorBrowsable(EditorBrowsableState.Never)]
  //  new public string ToolTipTitle { get { return base.ToolTipTitle; } set { base.ToolTipTitle = value; } }

  //  [Browsable(false)]
  //  [EditorBrowsable(EditorBrowsableState.Never)]
  //  new public bool UseAnimation { get { return base.UseAnimation; } set { base.UseAnimation = value; } }

  //  [Browsable(false)]
  //  [EditorBrowsable(EditorBrowsableState.Never)]
  //  new public bool UseFading { get { return base.UseFading; } set { base.UseFading = value; } }

  //  #endregion

  //  #region Done!
  //  public eToolTip()
  //  {
  //    this.OwnerDraw = true;
  //    this.Popup += new PopupEventHandler(this.OnPopup);
  //    this.Draw += new DrawToolTipEventHandler(this.OnDraw);
  //    this.InitialDelay = 1;
  //    this.ReshowDelay = 500;
  //    // Force the ToolTip text to be displayed whether or not the control active.
  //    this.ShowAlways = true;
  //    this.AutoSize = true;
  //  }

  //  /// <summary>
  //  /// Gets or sets a pre-title string.
  //  /// </summary>
  //  [DefaultValue("")]
  //  [Browsable(false)]
  //  [EditorBrowsable(EditorBrowsableState.Never)]
  //  public string Prefix { get; set; }

  //  /// <summary>
  //  /// Gets or sets a after-title string.
  //  /// </summary>
  //  [DefaultValue("")]
  //  [Browsable(false)]
  //  [EditorBrowsable(EditorBrowsableState.Never)]
  //  public string Suffix { get; set; }

  //  //[Browsable(false)]
  //  //[EditorBrowsable(EditorBrowsableState.Never)]
  //  //public void Show()
  //  //{
  //  //  this.SetToolTip(SelectedControl, "CAPTION_TEST");
  //  //  this.Show();
  //  //}
  //  private static RichTextBox _selCtrl = new RichTextBox();

  //  [Browsable(false)]
  //  [EditorBrowsable(EditorBrowsableState.Never)]
  //  public RichTextBox SelectedControl
  //  {
  //    get { return _selCtrl; }
  //    set { _selCtrl = value; }
  //  }
  //  private Size _definedSZ = new Size(100, 70);
  //  private bool _autoCalcSz = true;

  //  [Browsable(false)]
  //  [EditorBrowsable(EditorBrowsableState.Never)]
  //  public Size Size
  //  {
  //    get { return _definedSZ; }
  //    set { _definedSZ = value; }
  //  }

  //  [Browsable(false)]
  //  [EditorBrowsable(EditorBrowsableState.Never)]
  //  public bool AutoSize
  //  {
  //    get { return _autoCalcSz; }
  //    set { _autoCalcSz = value; }
  //  }
  //  private Bitmap ResizeBitmap(Bitmap srcImage, int newWidth, int newHeight)
  //  {
  //    Bitmap newImage = new Bitmap(newWidth, newHeight);
  //    using (Graphics gr = Graphics.FromImage(newImage))
  //    {
  //      // Drawing our custom bg
  //      gr.SmoothingMode = SmoothingMode.HighQuality;
  //      gr.InterpolationMode = InterpolationMode.HighQualityBicubic;
  //      gr.PixelOffsetMode = PixelOffsetMode.HighQuality;
  //      gr.SmoothingMode = SmoothingMode.HighQuality;
  //      gr.DrawImage(srcImage, new Rectangle(0, 0, newWidth, newHeight));
  //    }

  //    return newImage;
  //  }
  //  private static string _tdsc = string.Empty;

  //  [Browsable(false)]
  //  [EditorBrowsable(EditorBrowsableState.Never)]
  //  public string ToolTipDescription
  //  {
  //    get { return _tdsc; }
  //    set
  //    {
  //      string _tmp = value;
  //      while (_tmp.Contains("  ")) { _tmp = _tmp.Replace("  ", " "); };
  //      while (_tmp.Contains("\n\n")) { _tmp = _tmp.Replace("\n\n", "\n"); };
  //      //MessageBox.Show(_tmp);
  //      _tdsc = _tmp;
  //    }
  //  }
  //  private static Bitmap _bg = Properties.Resources.Bg;
  //  private static Brush _eBrush = Brushes.Black;
  //  private static Brush _eDsc = Brushes.Black;
  //  private const float _fSz = 12F;
  //  private static Font _dscF = new Font("Times new roman", _fSz, FontStyle.Regular);
  //  private static Font _uiF = new Font("Times new roman", _fSz, FontStyle.Bold);

  //  [Browsable(false)]
  //  [EditorBrowsable(EditorBrowsableState.Never)]
  //  public Brush TitleBrush
  //  {
  //    get { return _eBrush; }
  //    set
  //    {
  //      if (value == null)
  //      {
  //        _eBrush = Brushes.Black;
  //      }
  //      else
  //      {
  //        _eBrush = value;
  //      }
  //    }
  //  }

  //  [Browsable(false)]
  //  [EditorBrowsable(EditorBrowsableState.Never)]
  //  public Brush DescriptionBrush
  //  {
  //    get { return _eDsc; }
  //    set
  //    {
  //      if (value == null)
  //      {
  //        _eDsc = Brushes.Black;
  //      }
  //      else
  //      {
  //        _eDsc = value;
  //      }
  //    }
  //  }

  //  [Browsable(false)]
  //  [EditorBrowsable(EditorBrowsableState.Never)]
  //  public Bitmap BackgroundImage
  //  {
  //    get { return _bg; }
  //    set
  //    {
  //      if (value == null)
  //        _bg = Properties.Resources.Bg;
  //      else
  //        _bg = value;
  //    }
  //  }

  //  [Browsable(false)]
  //  [EditorBrowsable(EditorBrowsableState.Never)]
  //  public Font TitleFont
  //  {
  //    get { return _uiF; }
  //    set
  //    {
  //      _uiF = value;
  //    }
  //  }

  //  [Browsable(false)]
  //  [EditorBrowsable(EditorBrowsableState.Never)]
  //  public Font DescriptionFont
  //  {
  //    get { return _dscF; }
  //    set
  //    {
  //      _dscF = value;
  //    }
  //  }
  //  private int _maxW = 0;
  //  // Summary:
  //  //      This sets a maximum value for the width of the tooltip.
  //  //      For desabling MaxWidth reset this to a 0 value.
  //  //      If this value is smaller than the calculated width of the title text the width of the title will be used as a minimum width for the tooltip. 
  //  // Note: 
  //  //      by assigning a value to this please avoid using 'new line' characters, sucj as '\n' character.

  //  [Browsable(false)]
  //  [EditorBrowsable(EditorBrowsableState.Never)]
  //  public int MaxWidth
  //  {
  //    get { return _maxW; }
  //    set { _maxW = value; }
  //  }

  //  //[Browsable(false)]
  //  //[EditorBrowsable(EditorBrowsableState.Never)]
  //  //public void Hide()
  //  //{
  //  //  //this.SetToolTip(SelectedControl, string.Empty);
  //  //}
  //  private Size tSize = new Size(0, 0);

  //  [Browsable(false)]
  //  [EditorBrowsable(EditorBrowsableState.Never)]
  //  private void OnPopup(object sender, PopupEventArgs e)
  //  {

  //    //MessageBox.Show(RichTextBoxToolTip.TitlePrefix);
  //    if (!AutoSize)
  //    {
  //      e.ToolTipSize = Size;
  //    }
  //    else
  //    {
  //      var r = new Bitmap(e.ToolTipSize.Width, e.ToolTipSize.Height);
  //      var g = Graphics.FromImage(r);
  //      var szT = g.MeasureString(Prefix + this.ToolTipTitle + Suffix, this.TitleFont);
  //      var szD = g.MeasureString(this.ToolTipDescription, this.DescriptionFont);

  //      MinWidth = (int)szT.Width + 10;
  //      if (szT.Width > szD.Width)
  //      {
  //        // Set tooltip's size according to the Title text property
  //        if (ToolTipDescription == "")
  //        {
  //          // Set tooltip size without respecting the description's size
  //          e.ToolTipSize = new Size((int)szT.Width + 10, (int)(szT.Height) + 10);
  //        }
  //        else
  //        {
  //          // Set tooltip size by taking into account the description's size
  //          var w = szT.Width;
  //          if (w < szD.Width) { w = szD.Width; };
  //          var h = szT.Height + szD.Height;
  //          e.ToolTipSize = new Size((int)w + 10, (int)h + 20);
  //        };
  //      }
  //      else
  //      {
  //        if (MaxWidth != 0)
  //        {
  //          var ex = g.MeasureString(this.ToolTipDescription, this.DescriptionFont, MaxWidth);
  //          int mVal = MaxWidth;
  //          if (mVal == 0) mVal = 1;
  //          int w = ((int)ex.Width) + 10;
  //          int h = (int)(ex.Height);
  //          int wrappedLines = w / mVal;
  //          if (wrappedLines == 0) wrappedLines = 1;
  //          w /= wrappedLines;
  //          h *= wrappedLines;
  //          if (w < MinWidth)
  //          {
  //            e.ToolTipSize = new Size(MinWidth, (int)(h + szT.Height) + (TitleFont.Height + 10));
  //          }
  //          else
  //          {
  //            e.ToolTipSize = new Size(w + 10, h + (int)szT.Height + (TitleFont.Height + 10));
  //          };
  //        }
  //        else
  //        {
  //          int w = ((int)szD.Width) + 10;
  //          int h = (int)(szD.Height);
  //          tSize = new Size(w + 10, h + (int)szT.Height);
  //          tSize.Height += (TitleFont.Height + 10);
  //          e.ToolTipSize = tSize;
  //        };
  //      };

  //    };
  //  }
  //  private int MinWidth;
  //  private void OnDraw(object sender, DrawToolTipEventArgs e) // use this event to customise the tool tip
  //  {
  //    // Set our background
  //    Graphics g = e.Graphics;
  //    var n = BackgroundImage as Bitmap;
  //    var rectSz = e.Bounds.Size;
  //    n = ResizeBitmap(n, rectSz.Width, rectSz.Height);
  //    g.Clear(Color.White);
  //    g.DrawImage(n, 0, 0);
  //    e.DrawBorder();

  //    // Draw our ToolTip title
  //    var rectF = new RectangleF(new PointF(8, TitleFont.Height + 10), new Size(tSize.Width - 8, tSize.Height));
  //    if (MaxWidth != 0)
  //    {
  //      g.DrawString(ToolTipDescription, DescriptionFont, DescriptionBrush, rectF);
  //    }
  //    else
  //    {
  //      g.DrawString(ToolTipDescription, DescriptionFont, DescriptionBrush, rectF.Location);
  //    };
  //    g.DrawString((Prefix + this.ToolTipTitle + Suffix).Trim('\n'), TitleFont, TitleBrush, new PointF(6, 4));
  //  }
  //  #endregion
  //}
  
}
