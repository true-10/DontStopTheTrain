using Zenject;

namespace DontStopTheTrain.Events
{

    public sealed class EventFabric : IFabric<IEvent, IEventStaticData>
    {
        [Inject]
        private ConditionsManager _conditionsManager;
        [Inject]
        private EventsService _eventsService;

        public IEvent Create(IEventStaticData staticData)
        {
            switch (staticData.Type)
            {
                case EventType.Wagon:
                    return new WagonEvent(staticData, _conditionsManager.GetConditions(staticData.Conditions), _eventsService);
                case EventType.View:
                case EventType.ChangeBiom:
                default:
                    return null;
            }
        }
    }
}

