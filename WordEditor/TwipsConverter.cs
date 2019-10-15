// Freeware. Written by Matt Fomich.
// Performs conversions between pixels and
// twips, based on Windows display settings.

using System;
using System.Runtime.InteropServices;

namespace FAQ_Net
{
    public class TwipsConverter
    {
        private const byte HORIZONTAL = 0;
        private const byte VERTICAL = 1;
        const Int16 WU_LOGPIXELSX = 88;
        const Int16 WU_LOGPIXELSY = 90;
        [DllImport("user32.dll", EntryPoint = "GetDC")]
        public static extern int GetDC(int hWnd);
        [DllImport("user32.dll", EntryPoint = "ReleaseDC")]
        public static extern int ReleaseDC(int hwnd, int hDc);
        [DllImport("gdi32", EntryPoint = "GetDeviceCaps")]
        private static extern int GetDeviceCaps(int hdc, int nIndex);
        public readonly float horizontalPixelsPerTwip;
        public readonly float horizontalTwipsPerPixel;

        /// <summary>
        /// Initializes TwipsConverter class that performs conversions
        /// between pixels and twips.
        /// </summary>
        public TwipsConverter()
        {
            horizontalPixelsPerTwip = twipsToPixels(1, HORIZONTAL);
            horizontalTwipsPerPixel = (float)decimal.Divide(1.0M, (decimal)horizontalPixelsPerTwip);
        }

        /// <summary>
        /// Converts Horizontal twips to pixels.
        /// </summary>
        /// <param name="twips">The twips value to convert.</param>
        /// <returns></returns>
        public int ConvertHTwipsToPixels(int twips)
        {
           return (int)(float)(twips * horizontalPixelsPerTwip);
            //return decimal.Multiply(twips, horizontalPixelsPerTwip);
        }

        /// <summary>
        /// Converts pixels to horizontal twips.
        /// </summary>
        /// <param name="pixels">the pixel value to convert to horizontal twips.</param>
        /// <returns>Returns the horizontal twips value in decimals.</returns>
        public int ConvertPixelsToHTwips(int pixels)
        {
           // return decimal.Multiply(pixels, horizontalTwipsPerPixel);
            return (int)(pixels * horizontalTwipsPerPixel);
        }
    
        /// <summary>
        /// Converts Twips to Pixels based on Windows graphic display.
        /// </summary>
        /// <param name="twips">The twips to convert to pixels.</param>
        /// <param name="direction">Zero for horizontal, any other number for vertical.</param>
        /// <returns>Returns the pixel value in decimals.</returns>
        private float twipsToPixels(int twips, int direction)
        {
            int dc;
            int pixelsPerInch;
            Int16 twipsPerInch = 1440;
            dc = GetDC(0);
            if (direction == 0)// Horizontal
            {
                pixelsPerInch = GetDeviceCaps(dc, WU_LOGPIXELSX);
            }
            else // Vertical
            {
                pixelsPerInch = GetDeviceCaps(dc, WU_LOGPIXELSY);
            }
            dc = ReleaseDC(0, dc);
            if (dc != 1)
            {
                throw new Exception("The device context used was not released.");
            }
            decimal d = decimal.Divide(twips, twipsPerInch);
            return (float)(d * pixelsPerInch);
        }
    }
}