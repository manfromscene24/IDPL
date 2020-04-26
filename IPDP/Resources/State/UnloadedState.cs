using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPDP.Resources.State
{
    public class UnloadedState : State
    {
        public UnloadedState(ImageProcessingProgram program):base(program)
        {

        }
        public override bool ChooseAlgorithm()
        {
            Console.WriteLine("In " + this.ToString());
            return false;
        }

        public override bool EnterParameters()
        {
            Console.WriteLine("In " + this.ToString());
            return false;
        }

        public override bool EnterPath()
        {
            Console.WriteLine("In " + this.ToString());
            return false;
        }

        public override bool LoadImage()
        {
            Console.WriteLine("Image Loading...");
            Program.SetMachineState(Program.loadingState);
            return true;
        }
    }
}
