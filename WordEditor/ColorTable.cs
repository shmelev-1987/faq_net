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
            layout.ColumnCount = 5;
            layout.RowCount = 3;
            // Highlight color values used here have been shamelessly
            // copied from microsoft word's Highlight color values.
            Color[] colors = new Color[] { Color.FromArgb(255, 255, 0), Color.FromArgb(0, 255, 0),
            Color.FromArgb(0, 255, 255), Color.FromArgb(255, 0, 255), Color.FromArgb(0, 0, 255), Color.FromArgb(255, 0, 0),
            Color.FromArgb(0, 0, 128), Color.FromArgb(0, 128, 128), Color.FromArgb(0, 128, 0), Color.FromArgb(128, 0, 128),
            Color.FromArgb(128, 0, 0), Color.FromArgb(128, 128, 0), Color.FromArgb(128, 128, 128), Color.FromArgb(192, 192, 192),
            Color.FromArgb(0, 0, 0) };
            // ToolTipText used. Same text as MS Word, what a coincidence!
            string[] colorNames = new string[] { "Yellow", "Bright Green", "Turquoise", "Pink", "Blue", "Red", "Dark Blue",
                "Teal", "Green", "Violet", "Dark Red", "Dark Yellow", "Gray-50%", "Gray-25%", "Black" };
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
            for (int i = 0; i < 15; i++)
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
            layout.SetColumnSpan(noColor, 5);
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