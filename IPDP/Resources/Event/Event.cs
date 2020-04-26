using IPDP.Resources.Observable.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPDP.Resources.Event
{
    public class Event
    {
        protected List<EventCommand> _subscribers;

        public Event()
        {
            _subscribers = new List<EventCommand>();
        }

        public void Publish(EventArgs args)
        {
            foreach (var subscriber in _subscribers)
            {
                subscriber.Args = args;
                subscriber.Execute();
            }
        }

        public void Subscribe(EventCommand subscriber)
        {
            _subscribers.Add(subscriber);
        }

        public void Unsubscribe(EventCommand subscriber)
        {
            _subscribers.Remove(subscriber);
        }
    }
}
