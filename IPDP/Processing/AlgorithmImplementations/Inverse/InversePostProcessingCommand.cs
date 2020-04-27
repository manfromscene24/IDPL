using IPDP.Resources.Event;
using System;

namespace IPDP.Processing.AlgorithmImplementations.Inverse
{
    class InversePostProcessingCommand : EventCommand
    {
        protected override void Execute(EventArgs args)
        {
            Console.Out.WriteLine("Finished inversing algorithm.");
        }
    }
}
