using UniRx;

namespace DontStopTheTrain.Train
{
    public sealed class WagonSystemsFabric : IFabric<IWagonSystem, IWagonSystemStaticData>
    {
        public IWagonSystem Create(IWagonSystemStaticData staticData)
        {
            return new WagonSystem(staticData);
            switch (staticData.Type)
            {
               // case WagonSystemType.Сhassis:
                default:
                    UnityEngine.Debug.Log($"The type [{staticData.Type}] is not found");
                    return null;

            }
        }
    }

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

    public sealed class WagonsFabric : IFabric<IWagon, IWagonStaticData>
    {
        public IWagon Create(IWagonStaticData staticData)
        {
            return new WagonData(staticData);
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
