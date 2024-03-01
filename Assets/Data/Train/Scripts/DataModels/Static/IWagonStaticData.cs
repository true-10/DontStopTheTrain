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

    }
    public interface IServiceWagonStaticData : IWagonStaticData
    {

    }
}
