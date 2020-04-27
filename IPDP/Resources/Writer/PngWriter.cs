using Emgu.CV;
using Emgu.CV.Structure;
using IPDP.Resources.Iterator;
using System;

namespace IPDP.Resources.Writer
{
    public class PngWriter : IImageWriter
    {
        protected static class PngWriterAdapter
        {
            public static void WriteImage(Image image, String filename)
            {
                var mat = new Mat(image.Height, image.Width, Emgu.CV.CvEnum.DepthType.Cv8U, 3);
                var img = mat.ToImage<Bgr, Byte>();

                for (var iterator = new PixelIterator(image); iterator != null; iterator = iterator + 1)
                {
                    img.Data[iterator.CurrentPixel.Y, iterator.CurrentPixel.X, 0] = iterator.CurrentPixel.DecoratedPixel.B;
                    img.Data[iterator.CurrentPixel.Y, iterator.CurrentPixel.X, 1] = iterator.CurrentPixel.DecoratedPixel.G;
                    img.Data[iterator.CurrentPixel.Y, iterator.CurrentPixel.X, 2] = iterator.CurrentPixel.DecoratedPixel.R;
                }
                img.Save(filename);

                mat.Dispose();
            }
        }
        public void WriteImage(Image image, String filename)
        {
            PngWriterAdapter.WriteImage(image, filename);
        }
    }
}