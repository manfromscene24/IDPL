using System;
using System.Drawing;

namespace IPDP.Resources.Writer
{

    public class BmpWriter : IImageWriter
    {
        protected static class BmpWriterAdapter
        {

            public static void WriteImage(Image image, string filename)
            {
                using (var bitmap = new Bitmap(image.Width, image.Height))
                {

                    for (var iRow = 0; iRow < image.Height; iRow += 1)
                    {
                        for (var iCol = 0; iCol < image.Width; iCol += 1)
                        {
                            var pixel = image[iRow, iCol];
                            bitmap.SetPixel(iCol, iRow, Color.FromArgb(pixel.A, pixel.R, pixel.G, pixel.B));
                        }
                    }
                    bitmap.Save(filename);
                }
            }

        }
        public void WriteImage(Image image, string filename)
        {
            BmpWriterAdapter.WriteImage(image, filename);
            Console.WriteLine();
        }
    }
}
