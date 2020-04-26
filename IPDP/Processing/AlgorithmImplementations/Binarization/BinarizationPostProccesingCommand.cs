using IPDP.Resources.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
