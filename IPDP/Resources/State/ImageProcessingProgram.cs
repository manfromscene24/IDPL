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

        public Image image;
        public ImageBuilder builder = new ImageBuilder();
        public Writer.BmpWriter bmpWriter = new Writer.BmpWriter();
        public Writer.PngWriter pngWriter = new Writer.PngWriter();
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
                case EUserOption.ChooseAlgorithm:
                    ChooseAlgorithm();
                    break;
                case EUserOption.EnterParameters:
                    EnterParameters();
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

        public int Inspect()
        {
            if (programState.ToString() == "IPDP.Resources.State.UnloadedState")
                return 1;
            else if (programState.ToString() == "IPDP.Resources.State.LoadingState")
                return 2;
            else if (programState.ToString() == "IPDP.Resources.State.LoadedState")
                return 3;
            else if (programState.ToString() == "IPDP.Resources.State.ParameterEnteringState")
                return 4;
            else return 0;
        }
    }
}
