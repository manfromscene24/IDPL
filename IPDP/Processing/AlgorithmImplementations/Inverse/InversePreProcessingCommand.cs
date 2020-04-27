using IPDP.Resources.Event;
using System;

namespace IPDP.Processing.AlgorithmImplementations.Inverse
{
    class InversePreProcessingCommand : EventCommand
    {
        protected override void Execute(EventArgs args)
        {
            Console.Out.WriteLine("Began inversing algorithm.");
        }
    }
}
