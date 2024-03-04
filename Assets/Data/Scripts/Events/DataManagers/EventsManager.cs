using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace DontStopTheTrain.Events
{
    public sealed class EventsManager
    {
        public List<IEvent> Events { get; private set; } = new();

        public void Add(IEvent newEvent)
        {
            if (Events.Contains(newEvent))
            {
                UnityEngine.Debug.Log($"Mission already[id = {newEvent.StaticData.Id}] added ");
                return;
            }
            Events.Add(newEvent);
        }

        public IEvent GetEventById(EventId id)
        {
            return Events
                //.Where(m => m.StaticData.Id == id)
                .FirstOrDefault(m => m.StaticData.Id == id);
        }

        public void Remove(IEvent eventToRemove)
        {
            if (Events.Contains(eventToRemove))
            {
                return;
            }
            Events.Remove(eventToRemove);
        }
    }

}
