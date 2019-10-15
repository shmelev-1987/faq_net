using System;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing.Drawing2D;

namespace IndentGrip
{
    public partial class IndentGrip : UserControl
    {
        // Define outline for drawing border around rightMarginOutline label.
        private Point[] rightMarginOutline = new Point[] { new Point(4, 1), new Point(8, 5), new Point(8, 8), new Point(0, 8), new Point(0, 5) };
        HatchBrush penBrush = new System.Drawing.Drawing2D.HatchBrush(
                 HatchStyle.DashedVertical, Color.Black, SystemColors.Window);
        private Pen linePen;
        
        public IndentGrip()
        {
            InitializeComponent();
            SetRegion();
        }

        public int GripLocationX
        {
            get { return this.Location.X; }
        }


        private void SetRegion()
        {
            // Set rightMargin's region.
            Point[] pts = new Point[] { new Point(4, 1), new Point(5, 1), new Point(9, 5), new Point(9, 9), new Point(0, 9), new Point(0, 5) };
            byte[] types = new byte[] { (byte)PathPointType.Start, (byte)PathPointType.Line, (byte)PathPointType.Line, (byte)PathPointType.Line, (byte)PathPointType.Line,
                (byte)(PathPointType.Line | PathPointType.CloseSubpath) };
            GraphicsPath path = new GraphicsPath(pts, types);
            this.Region = new Region(path);
            path.Dispose();
            // Initialize linePen;
            linePen = new Pen(penBrush);
        }


        private void RightMarginGrip_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawPolygon(Pens.Black, rightMarginOutline);
        }

    }
}