namespace IPDP.Resources.State
{
    public abstract class State
    {
        public ImageProcessingProgram Program;

        public abstract bool Execute();

        public abstract bool PrintMenu();

        public abstract bool LoadImage();

        public abstract bool EnterPath();

        public abstract bool ChooseAlgorithm();

        public abstract bool EnterParameters();

        public State(ImageProcessingProgram program)
        {
            this.Program = program;
        }
    }
}
