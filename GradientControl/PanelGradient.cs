using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace GradientControls
{
  public class PanelGradient : Panel, IGradientControl
  {
    private Color _backColorBottom;
    private GradientEnums.FillColorMode _fillColorType;
    private LinearGradientMode _gradientMode;

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

    protected override void OnPaintBackground(System.Windows.Forms.PaintEventArgs e)
    {
      base.OnPaintBackground(e);
      if (_fillColorType == GradientEnums.FillColorMode.Full)
        return;
      if (this.Width == 0 || this.Height == 0)
        return;
      Graphics gfx = e.Graphics;
      Rectangle rect = new Rectangle(0, 0, this.Width, this.Height);

      // Dispose of brush resources after use
      using (LinearGradientBrush lgb = new LinearGradientBrush(rect, this.BackColor
        , (_fillColorType == GradientEnums.FillColorMode.Gradient) ? this.BackColorBottom : this.BackColor
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
  }
}
