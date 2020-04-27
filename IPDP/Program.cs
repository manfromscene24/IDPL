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
            Console.WriteLine("1. Load Image");
            Console.WriteLine("2. EXIT");
            int option = Console.Read();
            while (option != '0')
            {
                switch (program.Inspect())
                {
                    case 1:
                            switch (option)
                            {
                                case '1':
                                    program.UpdateState(EUserOption.LoadImage);
                                    break;
                                case '2':
                                    Environment.Exit(0);
                                    break;

                            }
                        Console.WriteLine("1. Enter Path");
                        Console.WriteLine("2. Exit");

                        break;
                    case 2:
                            switch (option)
                            {
                                case '1':
                                    program.UpdateState(EUserOption.EnterPath);

                                    break;
                                case '2':
                                    Environment.Exit(0);
                                    break;
                            }
                        if (program.Inspect() == 3)
                        {
                            Console.WriteLine("1. Choose Algorithm");
                            Console.WriteLine("2. Exit");
                        }
                        break;

                    case 3:
        
                            switch (option)
                            { 
                                case '1':
                                    program.UpdateState(EUserOption.ChooseAlgorithm);
                                    break;
                                case '2':
                                    Environment.Exit(0);
                                    break;

                            }
                     
                        break;
                    case 4:
                        program.UpdateState(EUserOption.EnterParameters);
                        break;
                }

                option = Console.Read();
            }
        }
    }
}
