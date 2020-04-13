using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace GradientControls
{

  /// <summary>
  /// ToolStripSplitCheckButton adds a Check property to a ToolStripSplitButton.
  /// </summary>
  public partial class ToolStripSplitCheckButton : ToolStripSplitButton
  {
    private bool _checked;
    private static ProfessionalColorTable _professionalColorTable;


    public bool Checked
    {
      get
      {
        return _checked;
      }
      set
      {
        _checked = value;
        Invalidate();
      }
    }


    private void RenderCheckedButtonFill(Graphics g, Rectangle bounds)
    {
      if ((bounds.Width == 0) || (bounds.Height == 0))
      {
        return;
      }

      if (!UseSystemColors)
      {
        using (Brush b = new LinearGradientBrush(bounds, ColorTable.ButtonCheckedGradientBegin, ColorTable.ButtonCheckedGradientEnd, LinearGradientMode.Vertical))
        {
          g.FillRectangle(b, bounds);
        }
      }
      else
      {
        Color fillColor = ColorTable.ButtonCheckedHighlight;

        using (Brush b = new SolidBrush(fillColor))
        {
          g.FillRectangle(b, bounds);
        }
      }
    }

    private bool UseSystemColors
    {
      get { return (ColorTable.UseSystemColors || !ToolStripManager.VisualStylesEnabled); }
    }


    private static ProfessionalColorTable ColorTable
    {
      get
      {
        if (_professionalColorTable == null)
        {
          _professionalColorTable = new ProfessionalColorTable();
        }
        return _professionalColorTable;
      }
    }

    protected override void OnPaint(PaintEventArgs e)
    {
      if (_checked)
      {
        Graphics g = e.Graphics;
        Rectangle bounds = new Rectangle(Point.Empty, Size);

        RenderCheckedButtonFill(g, bounds);

        using (Pen p = new Pen(ColorTable.ButtonSelectedBorder))
        {
          g.DrawRectangle(p, bounds.X, bounds.Y, bounds.Width - 1, bounds.Height - 1);
        }
      }
      base.OnPaint(e);
    }
  }
}

