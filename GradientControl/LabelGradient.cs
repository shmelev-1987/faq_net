using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace GradientControls
{
  public class LabelGradient : Label, IGradientControl
  {
    ///// <summary>
    ///// Делегат на изменение поля
    ///// </summary>
    //public delegate void EventChangeValue();

    ///// <summary>
    ///// Событие на выбор значения
    ///// </summary>
    //public event EventChangeValue OnChangeValue;

    //private bool _growing;
    
    //private void resizeLabel()
    //{
    //  if (_growing)
    //    return;
    //  try
    //  {
    //    _growing = true;
    //    Size sz = new Size(this.Width, Int32.MaxValue);
    //    sz = TextRenderer.MeasureText(this.Text, this.Font, sz, TextFormatFlags.WordBreak);
    //    this.Height = sz.Height;
    //  }
    //  finally
    //  {
    //    _growing = false;
    //  }
    //}
    //protected override void OnTextChanged(EventArgs e)
    //{
    //  base.OnTextChanged(e);
    //  resizeLabel();
    //}
    //protected override void OnFontChanged(EventArgs e)
    //{
    //  base.OnFontChanged(e);
    //  resizeLabel();
    //}
    //protected override void OnSizeChanged(EventArgs e)
    //{
    //  base.OnSizeChanged(e);
    //  resizeLabel();
    //}

    //public LabelGradient()
    //{
    //  this.AutoSize = false;
    //}

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

    protected override void OnPaintBackground(System.Windows.Forms.PaintEventArgs pevent)
    {
      Graphics gfx = pevent.Graphics;
      if (this.Width == 0 || this.Height == 0)
        return;
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
