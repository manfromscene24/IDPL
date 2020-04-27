using System;
using System.Collections.Generic;
using IPDP.Resources;
using IPDP.Resources.Event;

namespace IPDP.Processing
{
    public abstract class ProcessingAlgorithm
    {
        public Event PreProcessingEvent { get; protected set; }
        public Event ProcessingStepEvent { get; protected set; }
        public Event PostProcessingEvent { get; protected set; }

        public HashSet<String> ExpectedParameters { get; }

        public ProcessingAlgorithm()
        {
            PreProcessingEvent = new Event();
            ProcessingStepEvent = new Event();
            PostProcessingEvent = new Event();

            ExpectedParameters = new HashSet<String>();
        }

        public Image Process(Image sourceImage, Dictionary<String, String> parameters)
        {
            if (ValidateParameters(parameters))
            {
                PreProcessingEvent.Publish(new EventArgs());
                var resultImage = AlgorithmImplementation(sourceImage, parameters);
                PostProcessingEvent.Publish(new EventArgs());
                return resultImage;
            }
            else
            {
                throw new Exception("Invalid parameters.");
            }
        }

        protected abstract bool ValidateParameters(Dictionary<String, String> parameters);

        protected abstract Image AlgorithmImplementation(Image sourceImage, Dictionary<String, String> parameters);
    }
}
