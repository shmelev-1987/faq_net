using System;
using System.Drawing;
using System.Windows.Forms;

namespace FAQ_Net
{
  /// <summary>
  /// Creates a ToolStripDownDown that displays its items in a table.
  /// </summary>
  public class ColorTable : ToolStripDropDown
  {
    private Color selectedColor;
    private string toolTipText;
    private int itemIndex;

    // ------------------ First Row -----------------------------
    internal static Color Black = Color.Black;
    internal static Color Brown = Color.FromArgb(153, 51, 0);
    internal static Color OliveGreen = Color.FromArgb(51, 51, 0);
    internal static Color DarkGreen = Color.FromArgb(0, 51, 0);

    internal static Color DarkTeal = Color.FromArgb(0, 51, 102);
    internal static Color DarkBlue = Color.FromArgb(0, 0, 128);
    internal static Color Indigo = Color.FromArgb(51, 51, 153);
    internal static Color Gray80 = Color.FromArgb(51, 51, 51);
    // ------------------ Second Row ----------------------------
    internal static Color DarkRed = Color.FromArgb(128, 0, 0);
    internal static Color Orange = Color.FromArgb(255, 102, 0);
    internal static Color DarkYellow = Color.FromArgb(128, 128, 0);
    internal static Color Green = Color.Green;

    internal static Color Teal = Color.Teal;
    internal static Color Blue = Color.Blue;
    internal static Color BlueGray = Color.FromArgb(102, 102, 153);
    internal static Color Gray50 = Color.FromArgb(128, 128, 128);
    // ------------------ Third Row -----------------------------       
    internal static Color Red = Color.Red;
    internal static Color LightOrange = Color.FromArgb(255, 153, 0);
    internal static Color Lime = Color.FromArgb(153, 204, 0);
    internal static Color SeaGreen = Color.FromArgb(51, 153, 102);

    internal static Color Aqua = Color.FromArgb(51, 204, 204);
    internal static Color LightBlue = Color.FromArgb(51, 102, 255);
    internal static Color Violet = Color.FromArgb(128, 0, 128);
    internal static Color Gray40 = Color.FromArgb(153, 153, 153);
    // ----------------- Forth Row ------------------------------
    internal static Color Pink = Color.FromArgb(255, 0, 255);
    internal static Color Gold = Color.FromArgb(255, 204, 0);
    internal static Color Yellow = Color.FromArgb(255, 255, 0);
    internal static Color BrightGreen = Color.FromArgb(0, 255, 0);

    internal static Color Turquoise = Color.FromArgb(0, 255, 255);
    internal static Color SkyBlue = Color.FromArgb(0, 204, 255);
    internal static Color Plum = Color.FromArgb(153, 51, 102);
    internal static Color Gray25 = Color.FromArgb(192, 192, 192);
    // ----------------- Fifth Row ------------------------------
    internal static Color Rose = Color.FromArgb(255, 153, 204);
    internal static Color Tan = Color.FromArgb(255, 204, 153);
    internal static Color LightYellow = Color.FromArgb(255, 255, 153);
    internal static Color LightGreen = Color.FromArgb(204, 255, 204);

    internal static Color LightTurquoise = Color.FromArgb(204, 255, 255);
    internal static Color PaleBlue = Color.FromArgb(153, 204, 255);
    internal static Color Lavender = Color.FromArgb(204, 153, 255);
    internal static Color White = Color.White;

    /// <summary>
    /// Returns the color from the image in the selected dropdown item.
    /// </summary>
    public Color SelectedColor
    {
      get { return selectedColor; }
    }

    /// <summary>
    ///  Returns the ToolTipText for the selected dropdown item.
    /// </summary>
    public string ToolTipText
    {
      get { return toolTipText; }
    }

    public ColorTable()
    {
      this.SuspendLayout();
      // Set yellow as default highlight color.
      selectedColor = Color.Yellow;
      this.LayoutStyle = ToolStripLayoutStyle.Table;
      TableLayoutSettings layout = (TableLayoutSettings)this.LayoutSettings;
      layout.ColumnCount = 8;
      layout.RowCount = 5;

      // 


      // Highlight color values used here have been shamelessly
      // copied from microsoft word's Highlight color values.
      Color[] colors = new Color[] { Black, Brown, OliveGreen, DarkGreen, DarkTeal, DarkBlue, Indigo, Gray80,
            DarkRed, Orange, DarkYellow, Green, Teal, Blue, BlueGray, Gray50,
            Red, LightOrange, Lime, SeaGreen, Aqua, LightBlue, Violet, Gray40,
            Pink, Gold, Yellow, BrightGreen, Turquoise, SkyBlue, Plum, Gray25,
            Rose, Tan, LightYellow, LightGreen, LightTurquoise, PaleBlue, Lavender, White
            };
      // ToolTipText used. Same text as MS Word, what a coincidence!
      string[] colorNames = new string[] {
            "Black", "Brown", "OliveGreen", "DarkGreen", "DarkTeal", "DarkBlue", "Indigo", "Gray80",
            "DarkRed", "Orange", "DarkYellow", "Green", "Teal", "Blue", "BlueGray", "Gray50",
            "Red", "LightOrange", "Lime", "SeaGreen", "Aqua", "LightBlue", "Violet", "Gray40",
            "Pink", "Gold", "Yellow", "BrightGreen", "Turquoise", "SkyBlue", "Plum", "Gray25",
            "Rose", "Tan", "LightYellow", "LightGreen", "LightTurquoise", "PaleBlue", "Lavender", "White"
            };
      // Set rectangle and padding values so that
      // when an item is selected the selection
      // frame highlights the color "square" with
      // even spacing around it.          
      Rectangle rc = new Rectangle(1, 1, 11, 11);
      Padding itemPadding = new Padding(2, 1, 2, 1);
      // To get selection frame perfectly centered
      // The size of the bitmap image to draw on is
      // 13 pixels wide and 12 pixels high.
      int bmWidth = 13;
      int bmHeight = 12;
      // Add the Fourteen colors to the dropdown.
      for (int i = 0; i < colors.Length; i++)
      {
        Bitmap bm = new Bitmap(bmWidth, bmHeight);
        using (Graphics g = Graphics.FromImage(bm))
        {
          // g.Clear(colors[i]);
          g.FillRectangle(new SolidBrush(colors[i]), rc);
          g.DrawRectangle(Pens.Gray, 1, 0, 11, 11);
        }
        ToolStripMenuItem item = (new ToolStripMenuItem(bm));
        this.Items.Add(item);
        item.Padding = itemPadding;
        item.ImageScaling = ToolStripItemImageScaling.None;
        item.ImageAlign = ContentAlignment.MiddleCenter;
        item.DisplayStyle = ToolStripItemDisplayStyle.Image;
        item.ToolTipText = colorNames[i];
        item.MouseDown += color_MouseDown;
        item.Tag = colors[i];
        this.Opening += ColorTable_Opening;
      }
      // Select yellow item as default selected color.
      this.Items[0].Select();
      // Also add an option to clear existing highlighting
      // back to default/no highlighting.
      ToolStripMenuItem noColor = new ToolStripMenuItem("None");
      this.Items.Add(noColor);
      layout.SetCellPosition(noColor, new TableLayoutPanelCellPosition(0, 0));
      layout.SetColumnSpan(noColor, layout.ColumnCount);
      // The color white is used to indicate "No Highlight".
      Bitmap bmp = new Bitmap(1, 1);
      using (Graphics g = Graphics.FromImage(bmp))
      {
        g.Clear(Color.White);
      }
      noColor.Image = bmp;
      noColor.Tag = Color.White;
      noColor.DisplayStyle = ToolStripItemDisplayStyle.Text;
      noColor.Dock = DockStyle.Fill;
      noColor.ToolTipText = "No Highlight";
      noColor.MouseDown += color_MouseDown;
      this.ResumeLayout();
    }

    void ColorTable_Opening(object sender, System.ComponentModel.CancelEventArgs e)
    {
      this.Items[itemIndex].Select();
    }

    private void color_MouseDown(object sender, MouseEventArgs e)
    {
      ToolStripMenuItem item = (ToolStripMenuItem)sender;
      itemIndex = this.Items.IndexOf(item);
      selectedColor = (Color)item.Tag;
      toolTipText = item.ToolTipText;
    }
  }
}