using IPDP.Resources.State;
using System;

namespace IPDP
{
    public enum EUserOption
    {
        LoadImage,
        EnterPath,
        ChooseAlgorithm,
        EnterParameters

    }
    class Program
    {
        static void Main(string[] args)
        {

            ImageProcessingProgram program = new ImageProcessingProgram();
            Console.WriteLine("============== Image Processing ==============");
            String option = null;
            while (true)
            {
                program.programState.PrintMenu();
                program.Execute();
            }
        }
    }
}
