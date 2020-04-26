using IPDP.Resources.Observable.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
