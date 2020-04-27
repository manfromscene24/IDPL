using IPDP.Processing;
using IPDP.Processing.AlgorithmImplementations.Binarization;
using IPDP.Processing.AlgorithmImplementations.Inverse;
using IPDP.Processing.AlgorithmImplementations.MeanFilter;
using System;
using System.Collections.Generic;

namespace IPDP.Resources.State
{
    public class ParameterEnteringState : State
    {
        public String algorithmOption;
        
        public ParameterEnteringState(ImageProcessingProgram program) : base(program)
        {
            
        }

        public override bool PrintMenu()
        {
            Console.WriteLine("Please enter the parameters for the algorithm: ");
            return true;
        }

        public override bool ChooseAlgorithm()
        {
            throw new NotImplementedException();
        }

        public override bool EnterParameters()
        {   
            ProcessingAlgorithm algorithm;
            switch(Program.paramState.algorithmOption)
            {
                case "1":
                    algorithm = new MeanFilterImplementation();
                    algorithm.PreProcessingEvent.Subscribe(new MeanPreProcessingCommand());
                    algorithm.PostProcessingEvent.Subscribe(new MeanPostProcessingCommand());
                    algorithm.ProcessingStepEvent.Subscribe(new MeanProcessingStepCommand());
                    break;
                case "2":
                    algorithm = new Binarization();
                    algorithm.PreProcessingEvent.Subscribe(new BinarizationPreProccesingCommand());
                    algorithm.PostProcessingEvent.Subscribe(new BinarizationPostProccesingCommand());
                    algorithm.ProcessingStepEvent.Subscribe(new BinarizationProccessingStepCommand());
                    break;
                case "3":
                    algorithm = new Inverse();
                    algorithm.PreProcessingEvent.Subscribe(new InversePreProcessingCommand());
                    algorithm.PostProcessingEvent.Subscribe(new InversePostProcessingCommand());
                    break;
                default:
                    return false; 
            }
            var parameters = new Dictionary<String, String>();
            foreach (var parameter in algorithm.ExpectedParameters)
            {
                Console.Write($"{parameter} = ");
                var value = Console.ReadLine();
                parameters.Add(parameter, value);
            }
            Program.builder.WriteImage(algorithm.Process(Program.image, parameters), "result.png");
            Program.SetMachineState(Program.loadingState);
            return true;
        }

        public override bool EnterPath()
        {
            throw new NotImplementedException();
        }

        public override bool LoadImage()
        {
            throw new NotImplementedException();
        }

        public override bool Execute()
        {
            return EnterParameters();
        }
    }
}

