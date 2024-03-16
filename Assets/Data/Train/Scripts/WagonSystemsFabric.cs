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
}
