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
        private EventsManager _eventsManager;
        [Inject]
        private EventFabric _eventsFabric;
        [Inject]
        private EventsService _eventsService;
        [Inject]
        private Train.Train _train;

        public IEvent GetEvent()
        {
            var availableEventForLevel = GetEventStaticDatasByLevel();
            var randomStatic = availableEventForLevel.GetRandomElement();
            var eventData = _eventsFabric.CreateEvent(randomStatic);
            return eventData;
        }

        public List<IEvent> GetEvents(/*int level, */int count)
        {
            //берем события по уровню
            var availableEventForLevel = GetEventStaticDatasByLevel();
            List<IEvent> events = new();
            foreach (var staticData in availableEventForLevel)
            {
                var eventData = _eventsFabric.CreateEvent(staticData);
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
                .EventsStaticData
                .Where(eventData => _eventsService.IsAvailableForPlayerLevel(eventData))
                .ToList();
        }
    }
}

