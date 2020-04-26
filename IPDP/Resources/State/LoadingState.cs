using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPDP.Resources.State
{
    public class LoadingState : State
    {
        public override bool ChooseAlgorithm()
        {
            throw new NotImplementedException();
        }

        public override bool EnterParameters()
        {
            throw new NotImplementedException();

        }

        public override bool EnterPath()
        {
            Console.WriteLine("Please enter a path: ");
            string imgPath = Console.ReadLine();
            Program.SetMachineState(Program.loadedState);
            return true;
        }

        public override bool LoadImage()
        {
            throw new NotImplementedException();
        }
    }
}
