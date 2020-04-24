using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPDP.Resources.Reader
{
    public class BmpReader : IImageReader
    {
        protected static class BmpReaderAdapter
        {
            public static Pixel[,] ReadImage(String filename)
            {
                var image = System.Drawing.Image.FromFile(filename);
                var bitmap = new Bitmap(image);
                Pixel[,] adaptedImage = new Pixel[image.Height, image.Width];
                for (var iRow = 0; iRow < image.Height; iRow += 1)
                {
                    for (var iCol = 0; iCol < image.Width; iCol += 1)
                    {
                        var pixel = bitmap.GetPixel(iCol, iRow);
                        adaptedImage[iRow, iCol] = new Pixel(pixel.R, pixel.G, pixel.B);
                    }
                }
                return adaptedImage;
            }
        }

        public Pixel[,] ReadImage(String filename)
        {
            return BmpReaderAdapter.ReadImage(filename);
        }
    }
}
