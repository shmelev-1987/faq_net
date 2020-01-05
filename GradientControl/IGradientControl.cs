using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace GradientControls
{
  public interface IGradientControl
  {
    Color BackColor
    {
      get;
      set;
    }

    Color ForeColor
    {
      get;
      set;
    }

    [Browsable(true), Category("Appearance"), DefaultValue(typeof(Color), "LightCyan")]
    Color BackColorBottom
    {
      get;
      set;
    }

    [Browsable(true), Category("Appearance"), DefaultValue(typeof(GradientEnums.FillColorMode), "Full")]
    GradientEnums.FillColorMode FillColorType
    {
      get;
      set;
    }

    [Browsable(true), Category("Appearance"), DefaultValue(typeof(LinearGradientMode), "ForwardDiagonal")]
    LinearGradientMode GradientMode
    {
      get;
      set;
    }
  }
}
