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

        public override bool Execute()
        {
            return LoadImage();
        }

        public override bool LoadImage()
        {
            var option = Console.ReadLine();
            int intCheck;
            while (Int32.TryParse(option, out intCheck) && (intCheck <= 0 || intCheck > 3))
            {
                Console.WriteLine("Try again.");
                option = Console.ReadLine();
            }
            if(intCheck == 1) 
            Program.SetMachineState(Program.loadingState);
            else if(intCheck == 2)
                Environment.Exit(0);
            return true;
        }

        public override bool PrintMenu()
        {
            Console.WriteLine("1.Load image");
            Console.WriteLine("2.Exit");
            return true;
        }
    }
}
