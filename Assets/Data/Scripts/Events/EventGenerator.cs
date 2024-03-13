using System.Collections.Generic;
using System.Linq;
using True10.Extentions;
using Zenject;

namespace DontStopTheTrain.Events
{
    public sealed class EventGenerator
    {
        [Inject]
        private EventsStaticManager _eventsStaticManager;
        [Inject]
        private EventFabric _eventsFabric;
        [Inject]
        private EventsService _eventsService;       

        public IEvent GetEvent()
        {
            var availableEventForLevel = GetEventStaticDatasByLevel();
            var randomStatic = availableEventForLevel.GetRandomElement();
            var eventData = _eventsFabric.Create(randomStatic);
            return eventData;
        }

        public List<IEvent> GetEvents()
        {
            var availableEventByLevel = GetEventStaticDatasByLevel();
            List<IEvent> events = new();
            foreach (var staticData in availableEventByLevel)
            {
                var eventData = _eventsFabric.Create(staticData);
                if (events.Contains(eventData))
                {
                    continue;
                }
                events.Add(eventData);
            }
            return events;
        }

        private List<IEventStaticData> GetEventStaticDatasByLevel()
        {
            return _eventsStaticManager
                .Datas
                .Where(eventData => _eventsService.IsAvailableForPlayerLevel(eventData))
                .ToList();
        }
    }
}

