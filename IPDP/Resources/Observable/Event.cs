using IPDP.Resources.Observable.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPDP.Resources.Observable
{
    public class Event
    {
        protected List<ICommand> _subscribers;

        public Event()
        {
            _subscribers = new List<ICommand>();
        }

        public void Publish()
        {
            foreach (var subscriber in _subscribers)
            {
                subscriber.Execute();
            }
        }

        public void Subscribe(ICommand subscriber)
        {
            _subscribers.Add(subscriber);
        }

        public void Unsubscribe(ICommand subscriber)
        {
            _subscribers.Remove(subscriber);
        }
    }
}
