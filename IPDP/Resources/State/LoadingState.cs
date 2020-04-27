using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPDP.Resources.State
{
    public class LoadingState : State
    {
        public LoadingState(ImageProcessingProgram program) : base(program)
        {
        }

        public override bool PrintMenu()
        {
            Console.WriteLine("Please enter a path: ");
            return true;
        }

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
            
            string imgPath = Console.ReadLine();
            String imageName = System.IO.Path.GetFileName(imgPath);
            Program.image = Program.builder.GetImage(imageName);
            if (Program.image == null)
            {
                Console.Out.WriteLine($"Image \"{imageName}\" not found.");
                return false;
            }
            else
                Console.Out.WriteLine($"Image \"{imageName}\" loaded succesfully!");
            Program.SetMachineState(Program.loadedState);
            return true;
        }

        public override bool LoadImage()
        {
            throw new NotImplementedException();
        }

        public override bool Execute()
        {
            return EnterPath();
        }
    }
}
