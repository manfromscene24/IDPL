using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
