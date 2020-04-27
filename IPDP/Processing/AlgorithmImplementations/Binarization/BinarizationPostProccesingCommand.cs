using IPDP.Resources.Event;
using System;

namespace IPDP.Processing.AlgorithmImplementations.Binarization
{
    class BinarizationPostProccesingCommand : EventCommand
    {
        protected override void Execute(EventArgs args)
        {
            Console.Out.WriteLine("Finished binarizing algorithm.");
        }
    }
}
