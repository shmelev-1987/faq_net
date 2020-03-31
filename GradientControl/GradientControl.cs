using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;

namespace PulseButton
{
  public class GradientControl : Control
  {
    public enum Shape
    {
      Round,
      Rectangle
    }

    private readonly Timer pulseTimer;

    private RectangleF[] pulses;

    private RectangleF centerRect;

    private Color[] pulseColors;

    private int pulseWidth;

    private bool mouseOver;

    private bool pressed;

    private float pulseSpeed;

    private IContainer components = null;

    [Browsable(true), Category("Appearance"), DefaultValue(typeof(Color), "LightSkyBlue")]
    public Color ButtonColorTop
    {
      get;
      set;
    }

    [Browsable(true), Category("Appearance"), DefaultValue(typeof(Color), "LightCyan")]
    public Color ButtonColorBottom
    {
      get;
      set;
    }

    [Browsable(true), Category("Appearance"), DefaultValue(typeof(Color), "Black")]
    public Color PulseColor
    {
      get;
      set;
    }

    [Browsable(true), Category("Appearance"), DefaultValue(typeof(PulseButton.Shape), "Round")]
    public PulseButton.Shape ShapeType
    {
      get;
      set;
    }

    [Browsable(true), Category("Appearance"), DefaultValue(10)]
    public int CornerRadius
    {
      get;
      set;
    }

    [Browsable(true), Category("Appearance"), DefaultValue(typeof(Color), "Orange")]
    public Color FocusColor
    {
      get;
      set;
    }

    [Browsable(true), Category("Appearance"), DefaultValue(typeof(Color), "White")]
    public new Color ForeColor
    {
      get
      {
        return base.ForeColor;
      }
      set
      {
        base.ForeColor = value;
      }
    }

    [Browsable(true), Category("Appearance"), DefaultValue(3)]
    public int NumberOfPulses
    {
      get
      {
        return this.pulses.Length;
      }
      set
      {
        if (value > 0)
        {
          this.pulses = new RectangleF[value];
          this.pulseColors = new Color[value];
          this.ArrangePulses();
        }
      }
    }

    [Browsable(true), Category("Appearance"), DefaultValue(10)]
    public int PulseWidth
    {
      get
      {
        return this.pulseWidth;
      }
      set
      {
        this.pulseWidth = value;
        this.ArrangePulses();
      }
    }

    [Browsable(true), Category("Appearance"), DefaultValue(typeof(float), "0.3f")]
    public float PulseSpeed
    {
      get
      {
        return this.pulseSpeed;
      }
      set
      {
        if (value > 0f)
        {
          this.pulseSpeed = value;
        }
      }
    }

    [Browsable(false), DefaultValue(50)]
    public int Interval
    {
      get
      {
        return this.pulseTimer.Interval;
      }
      set
      {
        this.pulseTimer.Interval = value;
      }
    }

    public GradientControl()
    {
      base.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
      base.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
      base.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
      base.SetStyle(ControlStyles.ResizeRedraw, true);
      base.SetStyle(ControlStyles.UserPaint, true);
      this.InitializeComponent();
      base.SuspendLayout();
      this.pulseWidth = 1;
      this.PulseSpeed = 0.3f;
      this.ButtonColorTop = Color.CornflowerBlue;
      this.ButtonColorBottom = Color.DodgerBlue;
      this.FocusColor = Color.Orange;
      this.PulseColor = Color.Black;
      this.ShapeType = PulseButton.Shape.Rectangle;
      this.CornerRadius = 5;
      base.Size = new Size(40, 40);
      this.pulseTimer = new Timer
      {
        Interval = 50
      };
      this.pulseTimer.Tick += new EventHandler(this.PulseTimerTick);
      this.pulses = new RectangleF[3];
      this.pulseColors = new Color[3];
      this.ArrangePulses();
      this.pulseTimer.Enabled = true;
      base.ResumeLayout(true);
    }

    private void PulseTimerTick(object sender, EventArgs e)
    {
      this.pulseTimer.Enabled = false;
      this.InflatePulses();
      base.Invalidate();
      this.pulseTimer.Enabled = true;
    }

    protected override void OnMouseUp(MouseEventArgs e)
    {
      base.OnMouseUp(e);
      if (e.Button == MouseButtons.Left)
      {
        this.pressed = false;
      }
    }

    protected override void OnMouseDown(MouseEventArgs e)
    {
      base.OnMouseDown(e);
      if (e.Button == MouseButtons.Left)
      {
        this.pressed = true;
      }
    }

    protected override void OnMouseMove(MouseEventArgs mevent)
    {
      base.OnMouseMove(mevent);
      this.mouseOver = this.centerRect.Contains(mevent.Location);
    }

    protected override void OnMouseLeave(EventArgs e)
    {
      base.OnMouseLeave(e);
      this.mouseOver = false;
      this.pressed = false;
    }

    protected override void OnEnabledChanged(EventArgs e)
    {
      base.OnEnabledChanged(e);
      this.pulseTimer.Enabled = base.Enabled;
    }

    protected override void OnResize(EventArgs e)
    {
      base.OnResize(e);
      if (this.pulses != null && this.pulses.Length != 0)
      {
        this.ArrangePulses();
      }
    }

    protected override void OnPaint(PaintEventArgs e)
    {
      base.OnPaintBackground(e);
      Graphics graphics = e.Graphics;
      graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
      graphics.SmoothingMode = SmoothingMode.AntiAlias;
      this.DrawPulses(graphics);
      if (!this.centerRect.IsEmpty)
      {
        this.DrawCenter(graphics);
        this.DrawBorder(graphics);
        //if (base.Image != null)
        //{
        //	graphics.DrawImage(base.Image, this.centerRect);
        //}
        if (this.mouseOver)
        {
          this.DrawHighLight(graphics);
        }
        if (!this.pressed)
        {
          this.DrawReflex(graphics);
        }
      }
    }

    protected virtual void DrawBorder(Graphics g)
    {
      using (Pen pen = new Pen((!this.Focused) ? Color.FromArgb(60, Color.Black) : this.FocusColor, 2f))
      {
        this.PaintShape(g, pen, this.centerRect);
      }
    }

    protected virtual void DrawCenter(Graphics g)
    {
      if (base.Enabled)
      {
        using (LinearGradientBrush linearGradientBrush = new LinearGradientBrush(this.centerRect, this.ButtonColorTop, this.ButtonColorBottom, LinearGradientMode.Horizontal))
        {
          this.PaintShape(g, linearGradientBrush, this.centerRect);
        }
      }
      else
      {
        using (SolidBrush solidBrush = new SolidBrush(Color.Gray))
        {
          this.PaintShape(g, solidBrush, this.centerRect);
        }
      }
    }

    protected virtual void DrawPulses(Graphics g)
    {
      if (base.Enabled)
      {
        for (int i = 0; i < this.pulses.Length; i++)
        {
          using (SolidBrush solidBrush = new SolidBrush(this.pulseColors[i]))
          {
            this.PaintShape(g, solidBrush, this.pulses[i]);
          }
        }
      }
    }

    //protected virtual void DrawText(Graphics g)
    //{
    //	StringFormat stringFormat = new StringFormat(StringFormat.GenericDefault)
    //	{
    //		Trimming = StringTrimming.EllipsisCharacter
    //	};
    //	stringFormat.FormatFlags |= StringFormatFlags.MeasureTrailingSpaces;
    //	stringFormat.FormatFlags ^= StringFormatFlags.LineLimit;
    //	stringFormat.HotkeyPrefix = HotkeyPrefix.Show;
    //	SizeF element = g.MeasureString(this.Text, this.Font, new SizeF(this.centerRect.Width, this.centerRect.Height), stringFormat);
    //	//RectangleF alignPlacement = PulseButton.GetAlignPlacement(this.TextAlign, this.centerRect, element);
    //	using (SolidBrush solidBrush = new SolidBrush(this.ForeColor))
    //	{
    //		g.DrawString(this.Text, this.Font, solidBrush, alignPlacement, stringFormat);
    //	}
    //}

    protected virtual void DrawReflex(Graphics g)
    {
      using (GraphicsPath graphicsPath = new GraphicsPath())
      {
        RectangleF rectangleF = this.centerRect;
        rectangleF.Height /= 2f;
        if (this.ShapeType == PulseButton.Shape.Round)
        {
          graphicsPath.AddArc(this.centerRect, -180f, 180f);
          RectangleF rect = rectangleF;
          rect.Offset(0f, rectangleF.Height);
          rect.Height /= 6f;
          graphicsPath.AddArc(rect, 0f, 180f);
          graphicsPath.CloseFigure();
        }
        else
        {
          rectangleF.Height += rectangleF.Height / 6f;
          graphicsPath.AddRectangle(rectangleF);
        }
        RectangleF bounds = graphicsPath.GetBounds();
        using (LinearGradientBrush linearGradientBrush = new LinearGradientBrush(bounds, Color.FromArgb(30, Color.White), Color.FromArgb(60, Color.White), LinearGradientMode.ForwardDiagonal))
        {
          g.FillPath(linearGradientBrush, graphicsPath);
        }
      }
    }

    protected virtual void DrawHighLight(Graphics g)
    {
      RectangleF rect = this.centerRect;
      rect.Inflate(-2f, -2f);
      using (Pen pen = new Pen(Color.FromArgb(60, Color.White), 4f))
      {
        if (this.ShapeType == PulseButton.Shape.Round)
        {
          g.DrawEllipse(pen, rect);
        }
        else
        {
          g.DrawPath(pen, PulseButton.GetRoundRect(g, rect, (float)this.CornerRadius));
        }
      }
    }

    protected virtual void PaintShape(Graphics g, Pen p, RectangleF rectangle)
    {
      if (this.ShapeType == PulseButton.Shape.Round)
      {
        g.DrawEllipse(p, rectangle);
      }
      else
      {
        using (GraphicsPath roundRect = PulseButton.GetRoundRect(g, rectangle, (float)this.CornerRadius))
        {
          g.DrawPath(p, roundRect);
        }
      }
    }

    protected virtual void PaintShape(Graphics g, Brush b, RectangleF rectangle)
    {
      if (this.ShapeType == PulseButton.Shape.Round)
      {
        g.FillEllipse(b, rectangle);
      }
      else
      {
        using (GraphicsPath roundRect = PulseButton.GetRoundRect(g, rectangle, (float)this.CornerRadius))
        {
          g.FillPath(b, roundRect);
        }
      }
    }

    public static GraphicsPath GetRoundRect(Graphics g, RectangleF rect, float radius)
    {
      GraphicsPath graphicsPath = new GraphicsPath();
      float num = radius * 2f;
      graphicsPath.AddArc(rect.X + rect.Width - num, rect.Y, num, num, 270f, 90f);
      graphicsPath.AddArc(rect.X + rect.Width - num, rect.Y + rect.Height - num, num, num, 0f, 90f);
      graphicsPath.AddArc(rect.X, rect.Y + rect.Height - num, num, num, 90f, 90f);
      graphicsPath.AddArc(rect.X, rect.Y, num, num, 180f, 90f);
      graphicsPath.CloseFigure();
      RectangleF bounds = graphicsPath.GetBounds();
      using (LinearGradientBrush linearGradientBrush = new LinearGradientBrush(bounds, Color.AliceBlue, Color.Aquamarine, LinearGradientMode.ForwardDiagonal))
      {
        g.FillPath(linearGradientBrush, graphicsPath);
      }
      return graphicsPath;
    }

    //public static RectangleF GetAlignPlacement(ContentAlignment align, RectangleF rect, SizeF element)
    //{
    //	float x = rect.Left;
    //	float y = rect.Y;
    //	if ((align & (ContentAlignment)1092) != (ContentAlignment)0)
    //	{
    //		x = rect.Right - element.Width;
    //	}
    //	else if ((align & (ContentAlignment)546) != (ContentAlignment)0)
    //	{
    //		x = rect.Width / 2f - element.Width / 2f + rect.Left;
    //	}
    //	if ((align & (ContentAlignment)1792) != (ContentAlignment)0)
    //	{
    //		y = rect.Bottom - element.Height;
    //	}
    //	else if ((align & (ContentAlignment)112) != (ContentAlignment)0)
    //	{
    //		y = rect.Height / 2f - element.Height / 2f + rect.Y;
    //	}
    //	return new RectangleF(x, y, element.Width, element.Height);
    //}

    private void ArrangePulses()
    {
      this.centerRect = new RectangleF((float)this.pulseWidth, (float)this.pulseWidth, (float)(base.Width - 2 * this.pulseWidth), (float)(base.Height - 2 * this.pulseWidth));
      for (int i = 1; i <= this.pulses.Length; i++)
      {
        this.pulses[i - 1] = new RectangleF((float)(this.pulseWidth * i) / (float)this.pulses.Length, (float)(this.pulseWidth * i) / (float)this.pulses.Length, (float)(base.Width - 2 * this.pulseWidth * i / this.pulses.Length), (float)(base.Height - 2 * this.pulseWidth * i / this.pulses.Length));
        this.pulseColors[i - 1] = Color.FromArgb((int)Math.Min(this.pulses[i - 1].X * 255f / (float)this.pulseWidth, 255f), Color.White);
      }
    }

    private void InflatePulses()
    {
      for (int i = 0; i < this.pulses.Length; i++)
      {
        this.pulses[i].Inflate(this.PulseSpeed, this.PulseSpeed);
        if (this.pulses[i].Width > (float)base.Width || this.pulses[i].Height > (float)base.Height || this.pulses[i].X < 0f || this.pulses[i].Y < 0f)
        {
          this.pulses[i] = new RectangleF((float)this.pulseWidth, (float)this.pulseWidth, (float)(base.Width - 2 * this.pulseWidth), (float)(base.Height - 2 * this.pulseWidth));
        }
        this.pulseColors[i] = Color.FromArgb((int)Math.Min(this.pulses[i].X * 255f / (float)this.pulseWidth, 255f), this.PulseColor);
      }
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
      {
        this.components.Dispose();
      }
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.components = new Container();
    }
  }
}
