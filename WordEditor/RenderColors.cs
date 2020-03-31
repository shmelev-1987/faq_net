using System;
using System.Drawing;
using System.Windows.Forms;

namespace FAQ_Net
{
  class RenderColors : ToolStripProfessionalRenderer
  {
    private Color selected = Color.FromArgb(75, SystemColors.MenuHighlight.R,
        SystemColors.MenuHighlight.G, SystemColors.MenuHighlight.B);
    private Rectangle rc;

    protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
    {
      // Use a blank white background. 
      rc = new Rectangle(0, 0, e.Item.Width, e.Item.Height);
      e.Graphics.FillRectangle(Brushes.White, rc);
      rc = new Rectangle(2, 0, e.Item.Width - 13, e.Item.Height - 1);
      if (e.Item.Selected)
      {
        using (Brush br = new SolidBrush(selected))
        {
          // Fill with selection color.
          e.Graphics.FillRectangle(br, rc);
        }
        using (Pen p = new Pen(ProfessionalColors.MenuItemBorder))
        {
          // Draw selection rectangle around item.
          e.Graphics.DrawRectangle(p, rc);
        }
      }
      rc = new Rectangle(4, 2, 40, 11);
      // Fill a rectangle in the color of the menu item.
      using (Brush b = new SolidBrush(Color.FromName(e.Item.Name)))
      {
        e.Graphics.FillRectangle(b, rc);
      }
      e.Graphics.DrawRectangle(Pens.Black, rc);
      // Draw text of selected color.
      using (Font fnt = new Font("Tahoma", 8, FontStyle.Regular))
      {
        e.Graphics.DrawString(e.Item.Text, fnt, Brushes.Black, new Point(50, 1));
      }
    }
  }
}
