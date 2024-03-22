using Zenject;

namespace DontStopTheTrain.Events
{

    public sealed class EventFabric : IFabric<IEvent, IEventStaticData>
    {
        [Inject]
        private ConditionsManager _conditionsManager;
        [Inject]
        private EventsService _eventsService;
        [Inject]
        private BuffAndPerksService _buffAndPerksService;
        [Inject]
        private TurnBasedController _turnBasedController;

        public IEvent Create(IEventStaticData staticData)
        {
            switch (staticData.Type)
            {
                case EventType.Wagon:
                    return new WagonEvent(staticData, _conditionsManager.GetConditions(staticData.ConditionsToComplete), 
                        _eventsService, _buffAndPerksService, _turnBasedController);
                case EventType.View:
                    return new ViewEvent(staticData, _turnBasedController);
                case EventType.ChangeBiom:
                default:
                    return null;
            }
        }
    }
}

