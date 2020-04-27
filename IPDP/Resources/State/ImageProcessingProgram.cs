namespace IPDP.Resources.State
{
    public class ImageProcessingProgram
    {
        public State programState { get; protected set; }
        public LoadedState loadedState;
        public UnloadedState unloadedState;
        public LoadingState loadingState;
        public ParameterEnteringState paramState;

        public Image image;
        public ImageBuilder builder = new ImageBuilder();

        public ImageProcessingProgram()
        {
            loadedState = new LoadedState(this);
            unloadedState = new UnloadedState(this);
            loadingState = new LoadingState(this);
            paramState = new ParameterEnteringState(this);

            programState = unloadedState;
        }

        public void SetMachineState(State state)
        {
            programState = state;
        }

        public void Execute()
        {
            while(programState.Execute() == false)
            {
                programState.PrintMenu();
            }
        }
    }
}
