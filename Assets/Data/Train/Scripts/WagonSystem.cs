using UniRx;

namespace DontStopTheTrain.Train
{
    public class WagonSystem : IWagonSystem
    {
        public IWagonSystemStaticData StaticData => _staticData;

        public int Price { get; private set; }

        public int EnergyConsumption { get; private set; }

        public int DeteriorationSpeed { get; private set; }
        public int Weight { get; private set; }

        public IReadOnlyReactiveProperty<int> MaxHealth { get; private set; }

        public IReadOnlyReactiveProperty<int> Health { get; private set; }

        public WagonSystem(IWagonSystemStaticData staticData)
        {
            _staticData = staticData;
        }

        private IWagonSystemStaticData _staticData;
    }
}
