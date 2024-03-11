namespace DontStopTheTrain
{
    ///
    public interface IUnlock
    {
        int Id { get; }
        int MinimalLevelPlayer { get; }//minimal user player for unlocking this perk 

    }
    public interface IInfuencers
    {
        //временный баф/дебаф
    }

    public interface IPerk
    {
        IPerkStaticData StaticData {get;}
    }

    public interface IPerkStaticData
    {
        PerkType Type { get; }
        int UnlockId { get; }
        Information Info { get; }

    }

    public enum PerkType
    {
        None = 0,
        ActionPoint = 1, //добавляем очки опыта
        ExpMultiplayer = 2, //множитель опыта
        //торговец - снижаем цены на покупки
        //ремонтник - снижаем цену за ремонт
    }

}
