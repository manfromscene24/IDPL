namespace IPDP.Resources.Observable.Command
{
    public interface ICommand
    {
        void Execute();
    }

    public interface ICommand<TReturnType>
    {
        TReturnType Execute();
    }
}
