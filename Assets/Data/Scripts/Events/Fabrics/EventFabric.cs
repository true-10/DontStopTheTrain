using Zenject;

namespace DontStopTheTrain.Events
{
    public class EventFabric
    {
        [Inject]
        private ConditionFabric _conditionFabric;
        [Inject]
        private EventsService _eventsService;

        public IEvent CreateEvent(IEventStaticData staticData)
        {
            switch (staticData.Type)
            {
                case EventType.Wagon:
                    return new WagonEvent(staticData, _conditionFabric, _eventsService);
                default:
                    return null;
            }
        }
    }
}

