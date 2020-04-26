using IPDP.Resources.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
