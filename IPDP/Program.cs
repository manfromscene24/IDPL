using IPDP.Processing;
using IPDP.Processing.AlgorithmImplementations.MeanFilter;
using IPDP.Processing.AlgorithmImplementations.Binarization;
using IPDP.Processing.AlgorithmImplementations.Inverse;
using IPDP.Resources;
using IPDP.Resources.Writer;
using System;
using System.Collections.Generic;
using IPDP.Resources.State;

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
