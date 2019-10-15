// Freeware. Written by Matt Fomich.
// matt.fomich@gmail.com

using System;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing.Drawing2D;

namespace Ruler
{
    public partial class Ruler : UserControl
    {
        private const byte NUMBER_POS = 8;
        private const byte HALF_POINT = 4;
        private byte inches = 7;
        private int totalTickMarks = 60;
        private float spacingMultiplier = 12.1F;
        private int rightLimit = 700;
        private int leftLimit = 20;
        private float rightMargin = 716F;
        private Brush darkBrush = new SolidBrush(SystemColors.ControlDark);

        public Ruler()
        {
            InitializeComponent();
        }

        public int RightLimit
        {
            get { return rightLimit; }
            set
            {
                rightLimit = value;
                this.Invalidate();
            }

        }

        public int LeftLimit
        {
            get { return leftLimit; }
            set { leftLimit = value; }
        }

        public float RightMargin
        {
            get { return rightMargin; }
            set { rightMargin = value; }
        }

        public byte Inches
        {
            get { return inches; }
            set { inches = value; }
        }

        public int TotalTickMarks
        {
            get { return totalTickMarks; }
            set { totalTickMarks = value; }
        }

        public float SpacingMultiplier
        {
            get { return spacingMultiplier; }
            set { spacingMultiplier = value; }
        }

        private void Ruler_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillRectangle(darkBrush, rightLimit, 0, 2000, this.Height);
            int i;
            for (i = 0; i < totalTickMarks; i++)
            {
                // Don't draw lines where the numbers go.
                if (i % NUMBER_POS != 0)
                {
                    if (i % HALF_POINT != 0)
                    {
                        e.Graphics.DrawLine(Pens.Black, (int)(i * spacingMultiplier + 3), 5, (int)(i * spacingMultiplier + 3), 6);
                    }
                    else
                    {
                        // Draw large line at halfway point between inches.
                        e.Graphics.DrawLine(Pens.Black, (int)(i * spacingMultiplier + 3), 4, (int)(i * spacingMultiplier + 3), 7);
                    }
                }
                if (i <= inches && i > 0)
                {
                    e.Graphics.DrawString((i).ToString(), this.Font, Brushes.Black, ((i * spacingMultiplier) * NUMBER_POS) - 2, 1);
                }
            }
        }
    }
}