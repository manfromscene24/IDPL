using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPDP.Resources.Observer.Command
{
    public abstract class SubscribedCommand<TPropertyType> : ICommand
        where TPropertyType : new()
    {
        public TPropertyType OldValue { get; set; }
        public TPropertyType NewValue { get; set; }

        public void Execute()
        {
            Execute(OldValue, NewValue);
        }

        protected abstract void Execute(TPropertyType oldValue, TPropertyType newValue);
    }

    public abstract class SubscribedCommand<TPropertyType, TReturnType> : ICommand<TReturnType>
        where TPropertyType : new()
    {
        public TPropertyType OldValue { get; set; }
        public TPropertyType NewValue { get; set; }

        public TReturnType Execute()
        {
            return Execute(OldValue, NewValue);
        }

        protected abstract TReturnType Execute(TPropertyType oldValue, TPropertyType newValue);
    }
}
