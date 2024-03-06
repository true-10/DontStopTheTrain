using UnityEngine;

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

    public interface IWagonSystem : IDeteriorable
    {
        WagonSystemType Type { get; }
        public Sprite Icon { get; }
        int Price { get; }//цена
    }

    public interface IEngineSystem : IWagonSystem
    {
        int Power { get; }
        //fuel consumption
    }

    public interface IBrakeSystem : IWagonSystem
    {

    }
    public interface ICargoSystem : IWagonSystem
    {
        //грузоподьемность?
        //кол-во слотов под грузы (как в сноураннере)

    }
    public interface IPassangerSystem : IWagonSystem
    {
        //кол-во мест для пассажиров?
    }
}
