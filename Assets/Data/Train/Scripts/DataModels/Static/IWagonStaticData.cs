using UnityEngine;

namespace DontStopTheTrain.Train
{
    //что делают вагоны?
    //везут груз
    //везут пассажиров
    //хранят роботов ремонтников/инструменты


    public interface IWagonStaticData
    {
        int Id { get; }
        WagonType Type { get; }
        Information Info { get; } 
        //int Price { get; }//цена покупки
        //systems
    }

    public enum WagonType
    {
        Empty = 0,
        Locomotive = 1,
        Crew = 2,
        Service = 3,
        Food = 4,
        Passangers = 4,
        Cargo = 5,
    }

    public interface ILocomotiveStaticData : IWagonStaticData
    {

    }

    public interface ICrewWagonStaticData : IWagonStaticData
    {
        //кол-во сотрудников? но это в системе есть
    }
    public interface IServiceWagonStaticData : IWagonStaticData
    {

    }
}
