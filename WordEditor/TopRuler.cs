// Freeware. Written by Matt Fomich.
// matt.fomich@gmail.com

using System;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace RichTextEditor
{
    public class TopRuler : UserControl
    {
        private const byte NUMBER_POS = 8;
        private const byte HALF_POINT = 4;
        private const byte LINE_OFFSET = 16;
        private byte inches = 7;
        private int totalTickMarks;
        private float spacingMultiplier;
        private int rightLimit = 640;
        private int leftLimit = 20;
        private float rightMargin;
        private RightMarginLine mainFormRightLine;
        private RichTextBoxCustom richText;
        private int oldRightMarginX;
        private int rightLineOffset = 16;
        private int rightMarginMouseX;
        private Brush darkBrush = new SolidBrush(SystemColors.ControlDark);
        // Define outline for drawing border around rightMarginOutline label.
        private Point[] rightMarginOutline = new Point[] { new Point(4, 1), new Point(8, 5), new Point(8, 8), new Point(0, 8), new Point(0, 5) };
        HatchBrush penBrush = new System.Drawing.Drawing2D.HatchBrush(
                 HatchStyle.DashedVertical, Color.Black, SystemColors.Window);
        private global::RightMarginGrip.RightMarginGrip rightMarginGrip1;
        private Pen linePen;

        public TopRuler()
        {
            InitializeComponent();
            rightMarginGrip.MouseDown += new MouseEventHandler(rightMarginGrip_MouseDown);
            rightMarginGrip.MouseMove += new MouseEventHandler(rightMarginGrip_MouseMove);
            rightMarginGrip.MouseUp += new MouseEventHandler(rightMarginGrip_MouseUp);
            rightMarginGrip.Left = (int)rightMargin - 4;
            linePen = new Pen(penBrush);
        }

        public void InitializeObjects(RichTextBoxCustom rtb, RightMarginLine rightLine)
        {
            if (rtb != null && rightLine != null)
            {
                this.richText = rtb;
                this.mainFormRightLine = rightLine;
            }
            else
            {
                throw new NullReferenceException("RichTextBoxCustom and RightMarginLine must be initialized before calling InitializeObjects function.");
            }
     
        }

        private void InitializeComponent()
        {
            this.rightMarginGrip1 = new RightMarginGrip.RightMarginGrip();
            this.SuspendLayout();
            // 
            // rightMarginGrip1
            // 
            this.rightMarginGrip1.Location = new System.Drawing.Point(645, 3);
            this.rightMarginGrip1.Name = "rightMarginGrip1";
            this.rightMarginGrip1.Size = new System.Drawing.Size(10, 10);
            this.rightMarginGrip1.TabIndex = 1;
            // 
            // TopRuler
            // 
            this.Controls.Add(this.rightMarginGrip1);
            this.Name = "TopRuler";
            this.Size = new System.Drawing.Size(848, 14);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.TopRuler_Paint);
            this.ResumeLayout(false);

        }

        public Point RightMarginGripLocation
        {
            get { return rightMarginGrip.Location; }
            set { rightMarginGrip.Location = value; }
        }

        public int RightLimit
        {
            get { return rightLimit; }
            set { rightLimit = value; }
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

        public void AdjustRuler(float ZoomFactor)
        {
            // todo: fix and finish coding...
            ZoomFactor *= 100;
            if (ZoomFactor > 400)
            {
                if (spacingMultiplier == 12.40F && rightMargin == 665.0F)
                {
                    return;
                }
                SpacingMultiplier = 12.40F;
                rightMargin = 665.0F;
            }
            else if (ZoomFactor > 299.9999)
            {
                if (spacingMultiplier == 12.36F && rightMargin == 659.0F)
                {
                    return;
                }
                SpacingMultiplier = 12.36F;
                rightMargin = 659.0F;
            }
            else if (ZoomFactor > 119.9999)
            {
                if (spacingMultiplier == 12.36F && rightMargin == 649.0F)
                {
                    return;
                }
                SpacingMultiplier = 12.36F;
                rightMargin = 649.0F;
            }
            else if (ZoomFactor > 70)// default.
            {
                if (spacingMultiplier == 12.0F)
                {
                    return;
                }
                spacingMultiplier = 12.0F;
                rightMargin = (spacingMultiplier * (totalTickMarks - 7) + 3);
                rightMarginGrip.Left = (int)rightMargin - 4;
            }
            else if (ZoomFactor > 59.9999)
            {
                if (spacingMultiplier == 11.950F && rightMargin == 640.0F)
                {
                    return;
                }
                spacingMultiplier = 11.950F;
                rightMargin = 640.0F;
            }
            else if (ZoomFactor > 39.9999)
            {
                if (spacingMultiplier == 11.930F && rightMargin == 638.0F)
                {
                    return;
                }
                spacingMultiplier = 11.930F;
                rightMargin = 638.0F;
            }
            else if (ZoomFactor > 19.99999)
            {
                if (spacingMultiplier == 11.890F && rightMargin == 637.0F)
                {
                    return;
                }
                spacingMultiplier = 11.890F;
                rightMargin = 637.0F;
            }
            else if (ZoomFactor > 9.99999 && ZoomFactor < 20)
            {
                if (spacingMultiplier == 11.880F && rightMargin == 635.0F)
                {
                    return;
                }
                spacingMultiplier = 11.880F;
                rightMargin = 635.0F;
            }
            this.Invalidate();
        }

        private void setRightIndent(int newRightLimit)
        {           
           // todo: finish coding right indent settings.
            newRightLimit -= LINE_OFFSET;
            Format fmt = new Format(richText.Handle);
            TwipsConverter conv = new TwipsConverter();
            fmt.SetRightIndent((int)conv.ConvertPixelsToHorizontalTwips((int)RightMargin - newRightLimit)); 
        }

        private void rightMarginGrip_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                rightMarginMouseX = Control.MousePosition.X - rightMarginGrip.GripLocationX;
                oldRightMarginX = rightMarginGrip.Left;
            }
        }

        private void rightMarginGrip_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (rightMarginGrip.Left > leftLimit && rightMarginGrip.Left < rightLimit)
                {
                    rightMarginGrip.Left = Control.MousePosition.X - rightMarginMouseX;
                    mainFormRightLine.Left = rightMarginGrip.Left + LINE_OFFSET;
                }
            }
        }

        private void rightMarginGrip_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (rightMarginGrip.Left <= leftLimit)
                {
                    rightMarginGrip.Left = leftLimit + 2;
                }
                else if (rightMarginGrip.Left >= rightLimit)
                {
                    rightMarginGrip.Left = rightLimit - 2;
                }
                int tickMarkPointX;
                int pointerX = rightMarginGrip.Left + 4;
                for (int i = totalTickMarks; i >= 0; i--)
                {
                    tickMarkPointX = (int)(i * spacingMultiplier + 3);
                    if (Math.Abs(pointerX - tickMarkPointX) < 7)
                    {
                        rightMarginGrip.Left = tickMarkPointX - 4;
                        mainFormRightLine.Left = tickMarkPointX + ((-4) + (this.rightLineOffset));
                        setRightIndent(mainFormRightLine.Left);
                        return;
                    }
                }
                // Unexpected.  Return to old location.
                rightMarginGrip.Left = oldRightMarginX;
            }
        }

        private void TopRuler_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillRectangle(darkBrush, rightMargin, 0, 200, this.Height);
            int i;
            for (i = 0; i < totalTickMarks; i++)
            {
                // Don't draw lines where the numbers go.
                if (i % NUMBER_POS != 0)
                {
                    //tickMarkPointX = (int)(i * spacingMultiplier + 3);

                    if (i % HALF_POINT != 0)
                    {
                        e.Graphics.DrawLine(Pens.Black, (int)(i * spacingMultiplier + 3), 5, (int)(i * spacingMultiplier + 3), 6);
                    }
                    else
                    {
                        // Draw large line at halfway point between inches.
                        e.Graphics.DrawLine(Pens.Black, (int)(i * spacingMultiplier + 3), 2, (int)(i * spacingMultiplier + 3), 8);
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