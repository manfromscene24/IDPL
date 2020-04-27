using IPDP.Resources.Event;
using System;

namespace IPDP.Processing.AlgorithmImplementations.MeanFilter
{
    public class MeanPreProcessingCommand : EventCommand
    {
        protected override void Execute(EventArgs args)
        {
            Console.Out.WriteLine("Began applying mean filter algorithm.");
        }
    }
}
