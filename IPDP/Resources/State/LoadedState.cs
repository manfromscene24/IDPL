using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPDP.Resources.State
{
    public class LoadedState : State
    {
        public LoadedState(ImageProcessingProgram program) : base(program)
        {
        }

        public override bool ChooseAlgorithm()
        {
            Console.WriteLine("Please choose an Image Processing Algorithm.");
            int option = Console.Read();
            Program.SetMachineState(Program.paramState);
            Program.paramState.algorithmOption = option;
            Program.paramState.EnterParameters();
            return true;
        }

        public override bool EnterParameters()
        {
            throw new NotImplementedException();
        }

        public override bool EnterPath()
        {
            throw new NotImplementedException();
        }

        public override bool LoadImage()
        {
            throw new NotImplementedException();
        }
    }
}
