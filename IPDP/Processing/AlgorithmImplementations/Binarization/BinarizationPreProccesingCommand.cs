using IPDP.Resources.Event;
using System;

namespace IPDP.Processing.AlgorithmImplementations.Binarization
{
    public class BinarizationPreProccesingCommand : EventCommand
    {
        protected override void Execute(EventArgs args)
        {
            Console.Out.WriteLine("Began binarizing algorithm.");
        }
    }
}
