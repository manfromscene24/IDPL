using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IPDP.Resources;

namespace IPDP.Processing
{
    public abstract class ProcessingAlgorithm
    {
        public delegate void PreProcessingEvent(Image image);
        public event PreProcessingEvent PreProcessing;
        public delegate void ProcessingStepEvent(ProcessingStepEventArgs e);
        public event ProcessingStepEvent ProcessingStep;
        public delegate void PostProcessingEvent(Image image);
        public event PostProcessingEvent PostProcessing;

        public abstract Dictionary<String, String> ExpectedParameters { get; }

        public Image Process(Image sourceImage, Dictionary<String, String> parameters)
        {
            if (ValidateParameters(parameters))
            {
                var copy = sourceImage;
                PreProcessing?.Invoke(copy);
                AlgorithmImplementation(copy, parameters);
                PostProcessing?.Invoke(copy);
                return copy;
            }
            else
            {
                throw new Exception("Invalid parameters.");
            }
        }

        protected abstract bool ValidateParameters(Dictionary<string, string> parameters);

        protected abstract void AlgorithmImplementation(Image sourceImage, Dictionary<string, string> parameters);
    }
}
