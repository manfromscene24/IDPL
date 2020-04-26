using IPDP.Resources;
using IPDP.Resources.Event.Args;
using IPDP.Resources.Iterator;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IPDP.Processing.AlgorithmImplementations.MeanFilter
{
    public class MeanFilterImplementation : ProcessingAlgorithm
    {
        public MeanFilterImplementation()
        {
            ExpectedParameters.Add("maskSize");
        }

        protected override Image AlgorithmImplementation(Image sourceImage, Dictionary<String, String> parameters)
        {
            var maskSize = Int32.Parse(parameters["maskSize"]);
            var mask = new int[maskSize, maskSize];
            for (var iRow = 0; iRow < maskSize; iRow += 1)
            {
                for (var iCol = 0; iCol < maskSize; iCol += 1)
                {
                    mask[iRow, iCol] = 1;
                }
            }
            var resultImage = new Image(sourceImage.Height, sourceImage.Width);
            for (var iterator = new MaskIterator(sourceImage, maskSize); iterator != null; iterator = iterator + 1)
            {
                var accumulation = new double[3];
                foreach (var pixel in iterator.InMaskPixels)
                {
                    accumulation[0] += pixel.DecoratedPixel.R * mask[pixel.MaskY, pixel.MaskX];
                    accumulation[1] += pixel.DecoratedPixel.G * mask[pixel.MaskY, pixel.MaskX];
                    accumulation[2] += pixel.DecoratedPixel.B * mask[pixel.MaskY, pixel.MaskX];
                }
                resultImage[iterator.CurrentPixel.Y, iterator.CurrentPixel.X] = new Pixel();
                resultImage[iterator.CurrentPixel.Y, iterator.CurrentPixel.X].R = (byte)(accumulation[0] / Math.Round((double)iterator.InMaskPixels.Count(), 0));
                resultImage[iterator.CurrentPixel.Y, iterator.CurrentPixel.X].G = (byte)(accumulation[1] / Math.Round((double)iterator.InMaskPixels.Count(), 0));
                resultImage[iterator.CurrentPixel.Y, iterator.CurrentPixel.X].B = (byte)(accumulation[2] / Math.Round((double)iterator.InMaskPixels.Count(), 0));
                if ((iterator.CurrentPixel.X + iterator.CurrentPixel.Y * sourceImage.Width) % sourceImage.Width == 0)
                {
                    ProcessingStepEvent.Publish(new SequentialProcessingStepEventArgs(sourceImage, iterator.CurrentPixel));
                }
            }
            return resultImage;
        }

        protected override bool ValidateParameters(Dictionary<String, String> parameters)
        {
            foreach (var parameter in ExpectedParameters)
            {
                if (!parameters.ContainsKey(parameter))
                {
                    Console.Out.WriteLine($"Missing parameter \"{parameter}\".");
                    return false;
                }
            }
            int parseResult;
            if (Int32.TryParse(parameters["maskSize"], out parseResult))
            {
                if (parseResult < 1)
                {
                    Console.Out.WriteLine("Bad \"maskSize\" value.");
                    return false;
                }
            }
            else
            {
                return false;
            }
            return true;
        }
    }
}
