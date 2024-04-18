using DontStopTheTrain.Events;
using Zenject;

namespace DontStopTheTrain.Train
{
    public sealed class WagonSystemsFabric : IFabric<IWagonSystem, IWagonSystemStaticData>
    {
        [Inject]
        private TurnBasedController _turnBasedController;
        [Inject]
        private BuffAndPerksService _buffAndPerksService;
        [Inject]
        private EventStarter _eventStarter;
        [Inject]
        private WagonSystemsManager _wagonSystemsManager;

        public IWagonSystem Create(IWagonSystemStaticData staticData)
        {
            IWagonSystem newSystem =  new BaseWagonSystem(staticData, _turnBasedController, _buffAndPerksService, _eventStarter);
            _wagonSystemsManager.TryToAdd(newSystem);
            return newSystem;
        /*   switch (staticData.Type)
            {
               // case WagonSystemType.Сhassis:
                default:
                    UnityEngine.Debug.Log($"The type [{staticData.Type}] is not found");
                    return null;

            }*/
        }
    }
}
