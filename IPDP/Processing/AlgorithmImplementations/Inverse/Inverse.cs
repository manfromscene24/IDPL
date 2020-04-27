using IPDP.Resources;
using IPDP.Resources.Iterator;
using System;
using System.Collections.Generic;

namespace IPDP.Processing.AlgorithmImplementations.Inverse
{
    class Inverse : ProcessingAlgorithm
    {
        protected override Image AlgorithmImplementation(Image sourceImage, Dictionary<String, String> parameters)
        {
            var resultImage = new Image(sourceImage.Height, sourceImage.Width);

            for (var iterator = new PixelIterator(sourceImage); iterator != null; iterator = iterator + 1)
            {
                Pixel inversePix = new Pixel((byte)255, (byte)255, (byte)255);
                resultImage[iterator.CurrentPixel.Y, iterator.CurrentPixel.X] = new Pixel();
                resultImage[iterator.CurrentPixel.Y, iterator.CurrentPixel.X].R = (byte)(inversePix.R - sourceImage[iterator.CurrentPixel.Y, iterator.CurrentPixel.X].R);
                resultImage[iterator.CurrentPixel.Y, iterator.CurrentPixel.X].G = (byte)(inversePix.G - sourceImage[iterator.CurrentPixel.Y, iterator.CurrentPixel.X].G);
                resultImage[iterator.CurrentPixel.Y, iterator.CurrentPixel.X].B = (byte)(inversePix.B - sourceImage[iterator.CurrentPixel.Y, iterator.CurrentPixel.X].B);
            }

            return resultImage;
        }

        protected override bool ValidateParameters(Dictionary<String, String> parameters)
        {
            return true;
        }
    }
}
