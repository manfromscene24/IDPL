using IPDP.Resources.Event;
using IPDP.Resources.Event.Args;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPDP.Processing.AlgorithmImplementations.Binarization
{
    class BinarizationProccessingStepCommand : EventCommand
    {
        protected override void Execute(EventArgs args)
        {
            SequentialProcessingStepEventArgs stepArgs;
            try
            {
                stepArgs = (SequentialProcessingStepEventArgs)args;
            }
            catch
            {
                Console.Out.WriteLine("Bad argument passing.");
                return;
            }
            var progress = (float)(stepArgs.CurrentPixel.Y * stepArgs.ProcessingImage.Width + stepArgs.CurrentPixel.X) / (stepArgs.ProcessingImage.Width * stepArgs.ProcessingImage.Height);
            Console.Out.WriteLine($"Processed {Math.Round(progress * 100, 2)}% of the image.");
        }
    }
}
