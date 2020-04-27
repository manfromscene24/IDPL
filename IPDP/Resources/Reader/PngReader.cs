using Emgu.CV;
using Emgu.CV.Structure;
using System;

namespace IPDP.Resources.Reader
{
    public class PngReader : IImageReader
    {
        protected class PngReaderAdapter
        {
            public static Pixel[,] ReadImage(String filename)
            {
                Image<Bgr, Byte> image = new Image<Bgr, Byte>(filename);

                Pixel[,] adaptedImage = new Pixel[image.Height, image.Width];

                for (var iRow = 0; iRow < image.Height; iRow += 1)
                {
                    for (var iCol = 0; iCol < image.Width; iCol += 1)
                    {
                        var pixel = image[iRow, iCol];
                        adaptedImage[iRow, iCol] = new Pixel((byte)pixel.Red, (byte)pixel.Green, (byte)pixel.Blue);
                    }
                }
                return adaptedImage;
            }
        }

        public Pixel[,] ReadImage(string filename)
        {
            return PngReaderAdapter.ReadImage(filename);
        }
    }
}