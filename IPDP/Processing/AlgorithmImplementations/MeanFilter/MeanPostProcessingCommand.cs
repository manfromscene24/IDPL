using IPDP.Resources.Event;
using System;

namespace IPDP.Processing.AlgorithmImplementations.MeanFilter
{
    public class MeanPostProcessingCommand : EventCommand
    {
        protected override void Execute(EventArgs args)
        {
            Console.Out.WriteLine("Finished applying mean filter algorithm.");
        }
    }
}
