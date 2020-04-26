using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPDP.Resources.State
{
    public class ImageProcessingProgram
    {
        private State programState;
        public LoadedState loadedState;
        public UnloadedState unloadedState;
        public LoadingState loadingState;
        public ParameterEnteringState paramState;

        var builder = new ImageBuilder();
       
        public ImageProcessingProgram()
        {
            loadedState = new LoadedState(this);
            unloadedState = new UnloadedState(this);
            loadingState = new LoadingState(this);
            paramState = new ParameterEnteringState(this);

            programState = unloadedState;
        }

        public void UpdateState(EUserOption option)
        {
            switch(option)
            {
                case EUserOption.LoadImage:
                    LoadingImage();
                    break;
                case EUserOption.EnterPath:
                    EnterPath();
                    break;
            }
        }

        public void SetMachineState(State state)
        {
            programState = state;
        }

        private void EnterPath()
        {
            programState.EnterPath();
        }

        public void LoadingImage()
        {
            programState.LoadImage();
        }

        public void ChooseAlgorithm()
        {
            programState.ChooseAlgorithm();
        }

        public void EnterParameters()
        {
            programState.EnterParameters();
        }
    }
}
