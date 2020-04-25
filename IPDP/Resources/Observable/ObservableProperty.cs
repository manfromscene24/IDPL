using IPDP.Resources.Observable.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPDP.Resources.Observable
{
    public class ObservableProperty<TPropertyType>
        where TPropertyType : new()
    {
        protected List<SubscribedCommand<TPropertyType>> _subscribers;
        protected TPropertyType _value; 

        public TPropertyType Value
        {
            get { return _value; }
            set
            {
                if (!EqualityComparer<TPropertyType>.Default.Equals(_value, value))
                {
                    foreach(var command in _subscribers)
                    {
                        command.OldValue = _value;
                        command.NewValue = value;
                        command.Execute();
                    }
                    _value = value;
                }
            }
        }

        public ObservableProperty(TPropertyType value)
        {
            _value = value;
            _subscribers = new List<SubscribedCommand<TPropertyType>>();
        }

        public ObservableProperty()
        {
            _value = new TPropertyType();
            _subscribers = new List<SubscribedCommand<TPropertyType>>();
        }
    }

    public class ObservableProperty<TPropertyType, TReturnType>
        where TPropertyType : new()
    {
        protected List<SubscribedCommand<TPropertyType, TReturnType>> _subscribers;
        protected List<TReturnType> _returnValues;
        protected TPropertyType _value;

        public TPropertyType Value
        {
            get { return _value; }
            set
            {
                if (!EqualityComparer<TPropertyType>.Default.Equals(_value, value))
                {
                    _returnValues = new List<TReturnType>();
                    foreach (var command in _subscribers)
                    {
                        command.OldValue = _value;
                        command.NewValue = value;
                        _returnValues.Add(command.Execute());
                    }
                    _value = value;
                }
            }
        }

        public List<TReturnType> ReturnValues
        {
            get { return _returnValues; }
        }

        public ObservableProperty(TPropertyType value)
        {
            _value = value;
            _subscribers = new List<SubscribedCommand<TPropertyType, TReturnType>>();
        }

        public ObservableProperty()
        {
            _value = new TPropertyType();
            _subscribers = new List<SubscribedCommand<TPropertyType, TReturnType>>();
        }
    }
}
