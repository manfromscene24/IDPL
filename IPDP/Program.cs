using IPDP.Processing;
using IPDP.Processing.AlgorithmImplementations.MeanFilter;
using IPDP.Resources;
using IPDP.Resources.Writer;
using System;
using System.Collections.Generic;

namespace IPDP
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ImageBuilder();
            var imageName = "test.bmp";
            var image = builder.GetImage(imageName);
            if (image == null)
            {
                Console.Out.WriteLine($"Image \"{imageName}\" not found. Ending program.");
                return;
            }

            ProcessingAlgorithm meanFilter = new MeanFilterImplementation();
            var parameters = new Dictionary<String, String>();
            parameters.Add("maskSize", "3");
            meanFilter.PreProcessingEvent.Subscribe(new MeanPreProcessingCommand());
            meanFilter.PostProcessingEvent.Subscribe(new MeanPostProcessingCommand());
            meanFilter.ProcessingStepEvent.Subscribe(new MeanProcessingStepCommand());
            var result = meanFilter.Process(image, parameters);

            var writer = new BmpWriter();
            writer.WriteImage(result, "written.bmp");
        }
    }
}
