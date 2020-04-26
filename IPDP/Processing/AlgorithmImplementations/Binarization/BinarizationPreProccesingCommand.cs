using IPDP.Resources.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
