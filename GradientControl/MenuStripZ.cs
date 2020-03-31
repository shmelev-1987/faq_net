using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.ComponentModel;
using System.Reflection;

namespace GradientControls
{
  public class MenuStripZ : MenuStrip, IGradientControl
  {
    private Color _menuColor1;
    private Color _menuColor2;
    private Color _menuColor3;
    private Color _menuColor4;
    private Color _menuColor5;
    private Color _menuColor6;
    private Color _menuColor7;
    private Color _backColorBottom;
    private GradientControls.GradientEnums.FillColorMode _fillColorType;
    private LinearGradientMode _gradientMode;

    public MenuStripZ()
    {
      if (MenuColor1.Equals(Color.Empty))
        MenuColor1 = Color.FromArgb(60, 60, 60);
      if (MenuColor2.Equals(Color.Empty))
        MenuColor2 = Color.FromArgb(20, 20, 20);
      if (MenuColor3.Equals(Color.Empty))
        MenuColor3 = Color.FromArgb(30, 30, 30);
      if (MenuColor4.Equals(Color.Empty))
        MenuColor4 = Color.FromArgb(220, 220, 220);
      if (MenuColor5.Equals(Color.Empty))
        MenuColor5 = Color.Black;
      if (MenuColor6.Equals(Color.Empty))
        MenuColor6 = Color.White;
      if (MenuColor7.Equals(Color.Empty))
        MenuColor7 = Color.FromArgb(255, 80, 90, 90);
      this.Renderer = new MyMenuRenderer(MenuColor1, MenuColor2, MenuColor3, MenuColor4, MenuColor5, MenuColor6, MenuColor7);
    }

    [Browsable(true), Category("Appearance"), DefaultValue(typeof(Color), "LightCyan")]
    public Color BackColorBottom
    {
      //get;
      //set;
      get { return _backColorBottom; }
      set
      {
        if (_backColorBottom != value)
        {
          _backColorBottom = value;
          Invalidate();
        }
      }
    }

    [Browsable(true), Category("Appearance"), DefaultValue(typeof(GradientEnums.FillColorMode), "Full")]
    public GradientEnums.FillColorMode FillColorType
    {
      get { return _fillColorType; }
      set
      {
        if (_fillColorType != value)
        {
          _fillColorType = value;
          Invalidate();
        }
      }
    }

    [Browsable(true), Category("Appearance"), DefaultValue(typeof(LinearGradientMode), "ForwardDiagonal")]
    public LinearGradientMode GradientMode
    {
      get { return _gradientMode; }
      set
      {
        if (_gradientMode != value)
        {
          _gradientMode = value;
          Invalidate();
        }
      }
    }

    protected override void OnPaintBackground(System.Windows.Forms.PaintEventArgs pevent)
    {
      Graphics gfx = pevent.Graphics;
      if (this.Width == 0 || this.Height == 0)
        return;
      Rectangle rect = new Rectangle(0, 0, this.Width, this.Height);

      // Dispose of brush resources after use
      using (LinearGradientBrush lgb = new LinearGradientBrush(rect, this.BackColor
        , (_fillColorType == GradientControls.GradientEnums.FillColorMode.Gradient) ? this.BackColorBottom : this.BackColor
        , _gradientMode))
      {
        gfx.FillRectangle(lgb, rect);
      }
      ControlPaint.DrawBorder3D(gfx, rect, Border3DStyle.Adjust);
    }

    protected override void OnResize(EventArgs e)
    {
      base.OnResize(e);
      Invalidate();
    }

    [Browsable(true), Category("Appearance"), DefaultValue(typeof(Color), "60; 60; 60")]
    public Color MenuColor1
    {
      get { return _menuColor1; }
      set
      {
        _menuColor1 = value;
        this.Renderer = new MyMenuRenderer(_menuColor1, MenuColor2, MenuColor3, MenuColor4, MenuColor5, MenuColor6, MenuColor7);
      }
    }

    [Browsable(true), Category("Appearance"), DefaultValue(typeof(Color), "20; 20; 20")]
    public Color MenuColor2
    {
      get { return _menuColor2; }
      set
      {
        _menuColor2 = value;
        this.Renderer = new MyMenuRenderer(MenuColor1, MenuColor2, MenuColor3, MenuColor4, MenuColor5, MenuColor6, MenuColor7);
      }
    }

    [Browsable(true), Category("Appearance"), DefaultValue(typeof(Color), "30; 30; 30")]
    public Color MenuColor3
    {
      get { return _menuColor3; }
      set
      {
        _menuColor3 = value;
        this.Renderer = new MyMenuRenderer(MenuColor1, MenuColor2, MenuColor3, MenuColor4, MenuColor5, MenuColor6, MenuColor7);
      }
    }

    [Browsable(true), Category("Appearance"), DefaultValue(typeof(Color), "220; 220; 220")]
    public Color MenuColor4
    {
      get { return _menuColor4; }
      set
      {
        _menuColor4 = value;
        this.Renderer = new MyMenuRenderer(MenuColor1, MenuColor2, MenuColor3, MenuColor4, MenuColor5, MenuColor6, MenuColor7);
      }
    }

    [Browsable(true), Category("Appearance"), DefaultValue(typeof(Color), "Black")]
    public Color MenuColor5
    {
      get { return _menuColor5; }
      set
      {
        _menuColor5 = value;
        this.Renderer = new MyMenuRenderer(MenuColor1, MenuColor2, MenuColor3, MenuColor4, MenuColor5, MenuColor6, MenuColor7);
      }
    }

    [Browsable(true), Category("Appearance"), DefaultValue(typeof(Color), "White")]
    public Color MenuColor6
    {
      get { return _menuColor6; }
      set
      {
        _menuColor6 = value;
        this.Renderer = new MyMenuRenderer(MenuColor1, MenuColor2, MenuColor3, MenuColor4, MenuColor5, MenuColor6, MenuColor7);
      }
    }

    [Browsable(true), Category("Appearance"), DefaultValue(typeof(Color), "60; 60; 60")]
    public Color MenuColor7
    {
      get { return _menuColor7; }
      set
      {
        _menuColor7 = value;
        this.Renderer = new MyMenuRenderer(MenuColor1, MenuColor2, MenuColor3, MenuColor4, MenuColor5, MenuColor6, MenuColor7);
      }
    }
  }

  public class MyMenuRenderer : ToolStripRenderer
  {
    public Color _menuColor1 { get; set; }
    private Color _menuColor2;
    private Color _menuColor3;
    private Color _menuColor4;
    private Color _menuColor5;
    private Color _menuColor6;
    private Color _menuColor7;

    public MyMenuRenderer(Color menuColor1, Color menuColor2, Color menuColor3, Color menuColor4, Color menuColor5, Color menuColor6, Color menuColor7)
    {
      _menuColor1 = menuColor1;
      _menuColor2 = menuColor2;
      _menuColor3 = menuColor3;
      _menuColor4 = menuColor4;
      _menuColor5 = menuColor5;
      _menuColor6 = menuColor6;
      _menuColor7 = menuColor7;
    }

    protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
    {
      base.OnRenderMenuItemBackground(e);

      if (e.Item.Enabled)
      {
        if (e.Item.IsOnDropDown == false && e.Item.Selected)
        {
          var rect = new Rectangle(0, 0, e.Item.Width - 1, e.Item.Height - 1);
          var rect2 = new Rectangle(0, 0, e.Item.Width - 1, e.Item.Height - 1);
          e.Graphics.FillRectangle(new SolidBrush(_menuColor1), rect);
          e.Graphics.DrawRectangle(new Pen(new SolidBrush(_menuColor5)), rect2);
          e.Item.ForeColor = _menuColor6;
        }
        else
        {
          e.Item.ForeColor = _menuColor6;
        }

        if (e.Item.IsOnDropDown && e.Item.Selected)
        {
          var rect = new Rectangle(0, 0, e.Item.Width - 1, e.Item.Height - 1);
          e.Graphics.FillRectangle(new SolidBrush(_menuColor1), rect);
          e.Graphics.DrawRectangle(new Pen(new SolidBrush(_menuColor5)), rect);
          e.Item.ForeColor = _menuColor6;
        }
        if ((e.Item as ToolStripMenuItem).DropDown.Visible && e.Item.IsOnDropDown == false)
        {
          var rect = new Rectangle(0, 0, e.Item.Width - 1, e.Item.Height - 1);
          var rect2 = new Rectangle(0, 0, e.Item.Width - 1, e.Item.Height - 1);
          e.Graphics.FillRectangle(new SolidBrush(_menuColor2), rect);
          e.Graphics.DrawRectangle(new Pen(new SolidBrush(_menuColor5)), rect2);
          e.Item.ForeColor = _menuColor6;
        }
      }
    }
    protected override void OnRenderSeparator(ToolStripSeparatorRenderEventArgs e)
    {
      base.OnRenderSeparator(e);
      var DarkLine = new SolidBrush(_menuColor3);
      var rect = new Rectangle(30, 3, e.Item.Width - 30, 1);
      e.Graphics.FillRectangle(DarkLine, rect);
    }

    protected override void OnRenderItemCheck(ToolStripItemImageRenderEventArgs e)
    {
      base.OnRenderItemCheck(e);

      if (e.Item.Selected)
      {
        var rect = new Rectangle(4, 2, 18, 18);
        var rect2 = new Rectangle(5, 3, 16, 16);
        SolidBrush b = new SolidBrush(_menuColor5);
        SolidBrush b2 = new SolidBrush(_menuColor4);

        e.Graphics.FillRectangle(b, rect);
        e.Graphics.FillRectangle(b2, rect2);
        e.Graphics.DrawImage(e.Image, new Point(5, 3));
      }
      else
      {
        var rect = new Rectangle(4, 2, 18, 18);
        var rect2 = new Rectangle(5, 3, 16, 16);
        SolidBrush b = new SolidBrush(_menuColor6);
        SolidBrush b2 = new SolidBrush(_menuColor7);

        e.Graphics.FillRectangle(b, rect);
        e.Graphics.FillRectangle(b2, rect2);
        e.Graphics.DrawImage(e.Image, new Point(5, 3));
      }
    }

    protected override void OnRenderImageMargin(ToolStripRenderEventArgs e)
    {
      base.OnRenderImageMargin(e);

      var rect = new Rectangle(0, 0, e.ToolStrip.Width, e.ToolStrip.Height);
      e.Graphics.FillRectangle(new SolidBrush(_menuColor2), rect);

      var DarkLine = new SolidBrush(_menuColor2);
      var rect3 = new Rectangle(0, 0, 26, e.AffectedBounds.Height);
      e.Graphics.FillRectangle(DarkLine, rect3);

      e.Graphics.DrawLine(new Pen(new SolidBrush(_menuColor2)), 28, 0, 28, e.AffectedBounds.Height);

      var rect2 = new Rectangle(0, 0, e.ToolStrip.Width - 1, e.ToolStrip.Height - 1);
      e.Graphics.DrawRectangle(new Pen(new SolidBrush(_menuColor5)), rect2);
    }
  }
}
