namespace DontStopTheTrain
{
    public interface IFabric<T, StaticData>
    {
        T Create(StaticData staticData);
    }
}

