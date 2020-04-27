using IPDP.Resources.Observable.Command;
using System;

namespace IPDP.Resources.Event
{
    public abstract class EventCommand : ICommand
    {
        public EventArgs Args { get; set; }

        public void Execute()
        {
            Execute(Args);
        }

        protected abstract void Execute(EventArgs args);
    }
}
