using IPDP.Resources;
using System;
using System.Collections.Generic;

namespace IPDP.Processing.AlgorithmImplementations.Binarization
{
    public class Binarization : ProcessingAlgorithm
    {
        public Binarization()
        {
            ExpectedParameters.Add("threshold");
        }
        protected override Image AlgorithmImplementation(Image sourceImage, Dictionary<String, String> parameters)
        {
            var resultImage = new Image(sourceImage.Height, sourceImage.Width);
            var threshold = Int32.Parse(parameters["threshold"]);

            for (var iRow = 0; iRow < resultImage.Height; iRow++)
            {
                for (var iCol = 0; iCol < resultImage.Width; iCol++)
                {
                    var pixelValue = sourceImage[iRow, iCol].R + sourceImage[iRow, iCol].G + sourceImage[iRow, iCol].B;

                    if (pixelValue <= threshold * 3)
                    {
                        resultImage[iRow, iCol] = new Pixel(0, 0, 0);

                    }
                    else
                    {
                        resultImage[iRow, iCol] = new Pixel();
                        resultImage[iRow, iCol].R = 255; resultImage[iRow, iCol].G = 255; resultImage[iRow, iCol].B = 255;
                    }
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
            if (Int32.TryParse(parameters["threshold"], out parseResult))
            {
                if (parseResult < 1)
                {
                    Console.Out.WriteLine("Bad \"threshold\" value.");
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
