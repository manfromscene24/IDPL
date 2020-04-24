using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPDP.Resources
{
    public class Pixel
    {
        public byte R { get; set; }
        public byte G { get; set; }
        public byte B { get; set; }
        public byte A { get; set; }

        public Pixel() { }

        public Pixel(byte r, byte g, byte b)
        {
            R = r;
            G = g;
            B = b;
            A = 255;
        }

        public Pixel(byte r, byte g, byte b, byte a)
        {
            R = r;
            G = g;
            B = b;
            A = a;
        }
    }

    public class Image
    {
        public Pixel[,] Pixels { get; protected set; }
        public int Height 
        {
            get
            {
                if (Pixels == null)
                {
                    return 0;
                }
                return Pixels.GetLength(0);
            }
        }
        public int Width
        {
            get
            {
                if (Pixels == null)
                {
                    return 0;
                }
                return Pixels.GetLength(1);
            }
        }

        public Image(Pixel[,] pixels)
        {
            Pixels = pixels;
        }

        public Pixel this[int row, int col]
        {
            get
            {
                if (Pixels == null)
                {
                    return null;
                }
                if (row >= Height || col >= Width)
                {
                    throw new Exception("Indices out of image bounds.");
                }
                return Pixels[row, col];
            }
            set 
            {
                if (Pixels == null)
                {
                    return;
                }
                if (row >= Height || col >= Width)
                {
                    throw new Exception("Indices out of image bounds.");
                }
                Pixels[row, col] = value;
            }
        }
    }
}
