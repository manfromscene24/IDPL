using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPDP.Resources
{
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
                if (row >= Height || col >= Width || row < 0 || col < 0)
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
                if (row >= Height || col >= Width || row < 0 || col < 0)
                {
                    throw new Exception("Indices out of image bounds.");
                }
                Pixels[row, col] = value;
            }
        }
    }
}
