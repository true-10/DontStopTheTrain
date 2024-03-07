using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace DontStopTheTrain.Events
{
    public sealed class EventsManager
    {
        public IReadOnlyCollection<IEvent> Events => _events;

        private List<IEvent> _events = new();

        public void Add(IEvent newEvent)
        {
            if (_events.Contains(newEvent))
            {
                UnityEngine.Debug.Log($"Event already[id = {newEvent.StaticData.Id}] added ");
                return;
            }
            _events.Add(newEvent);
        }

        public IEvent GetEventById(EventId id)
        {
            return _events
                //.Where(m => m.StaticData.Id == id)
                .FirstOrDefault(m => m.StaticData.Id == id);
        }

        public void Remove(IEvent eventToRemove)
        {
            if (_events.Contains(eventToRemove))
            {
                return;
            }
            _events.Remove(eventToRemove);
        }
    }

}
