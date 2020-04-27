using IPDP.Processing;
using IPDP.Processing.AlgorithmImplementations.MeanFilter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPDP.Resources.State
{
    public class ParameterEnteringState : State
    {
        public int algorithmOption;
        
        
        public ParameterEnteringState(ImageProcessingProgram program) : base(program)
        {
        }

        public override bool ChooseAlgorithm()
        {
            throw new NotImplementedException();
        }

        public override bool EnterParameters()
        {   
            Console.WriteLine("Please enter the parameters for the algorithm: ");
            Console.WriteLine("Parameter 1");
            var param1 = Console.ReadLine();
            param1 = Console.ReadLine();
            Console.WriteLine("Parameter 2");
            var param2 = Console.ReadLine();
            var parameters = new Dictionary<String, String>();
            parameters.Add(param1,param2);
            switch(Program.paramState.algorithmOption)
            {
                case 1:
                    ProcessingAlgorithm meanFilter = new MeanFilterImplementation();
                    meanFilter.PreProcessingEvent.Subscribe(new MeanPreProcessingCommand());
                    meanFilter.PostProcessingEvent.Subscribe(new MeanPostProcessingCommand());
                    meanFilter.ProcessingStepEvent.Subscribe(new MeanProcessingStepCommand());
                    var result = meanFilter.Process(Program.image, parameters);
                    Program.bmpWriter.WriteImage(result, Program.image.ToString());
                    break;
                case 2:
                    Processing.ProcessingAlgorithm binarization = new Processing.AlgorithmImplementations.Binarization.Binarization();
                    binarization.PreProcessingEvent.Subscribe(new Processing.AlgorithmImplementations.Binarization.BinarizationPreProccesingCommand());
                    binarization.PostProcessingEvent.Subscribe(new Processing.AlgorithmImplementations.Binarization.BinarizationPostProccesingCommand());
                    binarization.ProcessingStepEvent.Subscribe(new Processing.AlgorithmImplementations.Binarization.BinarizationProccessingStepCommand());
                    result = binarization.Process(Program.image, parameters);
                    Program.bmpWriter.WriteImage(result, Program.image.ToString());
                    break;
                case 3:
                    Processing.ProcessingAlgorithm inverse = new Processing.AlgorithmImplementations.Inverse.Inverse();
                    inverse.PreProcessingEvent.Subscribe(new Processing.AlgorithmImplementations.Inverse.InversePreProcessingCommand());
                    inverse.PostProcessingEvent.Subscribe(new Processing.AlgorithmImplementations.Inverse.InversePostProcessingCommand());
                    result = inverse.Process(Program.image, parameters);
                    Program.bmpWriter.WriteImage(result, Program.image.ToString());
                    break;
                case 4:
                    Program.UpdateState(EUserOption.ChooseAlgorithm);
                    break;

            }
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
    }
}

