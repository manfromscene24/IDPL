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

