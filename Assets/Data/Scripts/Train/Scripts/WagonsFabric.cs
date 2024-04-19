using Zenject;

namespace DontStopTheTrain.Train
{
    public sealed class WagonsFabric : IFabric<IWagon, IWagonStaticData>
    {
        [Inject]
        private TurnBasedController _turnBasedController;
        [Inject]
        private BuffAndPerksService _buffAndPerksService;

        public IWagon Create(IWagonStaticData staticData)
        {
            return new WagonData(staticData, _turnBasedController, _buffAndPerksService);
            switch (staticData.WagonType)
            {
                //case WagonType.Empty:
                default:
                    UnityEngine.Debug.Log($"The type [{staticData.WagonType}] is not found");
                    return null;

            }
        }
    }
}
