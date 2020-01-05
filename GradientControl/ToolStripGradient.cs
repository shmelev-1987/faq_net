using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace GradientControls
{
  public class ToolStripGradient : ToolStrip, IGradientControl
  {

    private Color _backColorBottom;
    private GradientEnums.FillColorMode _fillColorType;
    private LinearGradientMode _gradientMode;

    public ToolStripGradient()
    {
      this.BackColor = System.Drawing.SystemColors.Control;
    }

    [Browsable(true), Category("Appearance"), DefaultValue(typeof(Color), "LightCyan")]
    public Color BackColorBottom
    {
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
      if (System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Designtime
        || this.BackColor.ToArgb() == Color.Transparent.ToArgb())
      {
        base.OnPaintBackground(e);
        return;
      }
      //if (this.BackColor == Color.Transparent)
      //  backColor = this.Parent.BackColor;
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
  }
}
