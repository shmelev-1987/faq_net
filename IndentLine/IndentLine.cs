// Freeware. Written by Matt Fomich.
// matt.fomich@gmail.com

using System;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing.Drawing2D;

namespace IndentLine
{
    public partial class IndentLine : UserControl
    {
        private HatchBrush penBrush = new System.Drawing.Drawing2D.HatchBrush(
                HatchStyle.DashedVertical, Color.Black, SystemColors.Window);
        private Pen linePen;
        public IndentLine()
        {
            linePen = new Pen(penBrush);
            InitializeComponent();
        }

        private void IndentLine_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawLine(linePen, 0, 0, 0, 3000);
        }
    }
}