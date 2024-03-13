using Zenject;

namespace DontStopTheTrain.Events
{

    public sealed class EventFabric : IFabric<IEvent, IEventStaticData>
    {
        [Inject]
        private ConditionFabric _conditionFabric;
        [Inject]
        private EventsService _eventsService;

        public IEvent Create(IEventStaticData staticData)
        {
            switch (staticData.Type)
            {
                case EventType.Wagon:
                    return new WagonEvent(staticData, _conditionFabric, _eventsService);
                case EventType.View:
                case EventType.ChangeBiom:
                default:
                    return null;
            }
        }
    }
}

