namespace DontStopTheTrain.Train
{
    //какие системы?
    //обязательные:
    //-тормозная система

    //специальные:
    //-Двигатель
    //-

    //опциональные:
    //-

    public enum WagonSystemType
    {

    }

    public enum WagonSystemId
    {

    }

    public interface IWagonSystem
    {

    }

    public interface IEngineSystem : IWagonSystem
    {

    }

    public interface IBrakeSystem : IWagonSystem
    {

    }
}
