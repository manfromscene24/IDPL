using IPDP.Processing;
using IPDP.Processing.AlgorithmImplementations.MeanFilter;
using IPDP.Processing.AlgorithmImplementations.Binarization;
using IPDP.Processing.AlgorithmImplementations.Inverse;
using IPDP.Resources;
using IPDP.Resources.Writer;
using System;
using System.Collections.Generic;

namespace IPDP
{
    public enum EUserOption
    {
        InsertCoin,
        EjectCoin,
        BuyProduct,
        FillMachine,
        InspectMachine
    }
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ImageBuilder();
            var imageName = "test.bmp";
            var image = builder.GetImage(imageName);

            var image2Name = "test.png";
            var image2 = builder.GetImage(image2Name);

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
            var result2 = meanFilter.Process(image2, parameters);
            
            
            var writer = new BmpWriter();
            var writer2 = new PngWriter();
            writer.WriteImage(result, "written.bmp");
            writer2.WriteImage(result2, "meanPng.png");
            


            ProcessingAlgorithm binarization = new Binarization();
            binarization.PreProcessingEvent.Subscribe(new BinarizationPreProccesingCommand());
            binarization.PostProcessingEvent.Subscribe(new BinarizationPostProccesingCommand());
            binarization.ProcessingStepEvent.Subscribe(new BinarizationProccessingStepCommand());
            parameters.Add("threshold", "127");
            result = binarization.Process(image, parameters);
            writer.WriteImage(result, "binarizedImage.bmp");
            result2 = binarization.Process(image2, parameters);
            writer2.WriteImage(result2, "binarPng.png");

            

            ProcessingAlgorithm inverse = new Inverse();
            inverse.PreProcessingEvent.Subscribe(new InversePreProcessingCommand());
            inverse.PostProcessingEvent.Subscribe(new InversePostProcessingCommand());
            result = inverse.Process(image, parameters);
            writer.WriteImage(result, "inverseImage.bmp");
            result2 = inverse.Process(image2, parameters);
            writer2.WriteImage(result2, "inversePng.png");


        }
    }
}
