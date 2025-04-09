using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.HPTY.ServiceLayer.Extensions
{
    public interface IEventPublisher
    {
        void Publish<T>(T eventData) where T : class;
        void Subscribe<T>(Action<T> handler) where T : class;

    }

    public class EventPublisher : IEventPublisher
    {
        private readonly Dictionary<Type, List<Delegate>> _handlers = new Dictionary<Type, List<Delegate>>();

        public void Subscribe<T>(Action<T> handler) where T : class
        {
            var eventType = typeof(T);
            if (!_handlers.ContainsKey(eventType))
            {
                _handlers[eventType] = new List<Delegate>();
            }
            _handlers[eventType].Add(handler);
        }

        public void Publish<T>(T eventData) where T : class
        {
            var eventType = typeof(T);
            if (!_handlers.ContainsKey(eventType))
                return;

            foreach (var handler in _handlers[eventType])
            {
                ((Action<T>)handler)(eventData);
            }
        }
    }
}
