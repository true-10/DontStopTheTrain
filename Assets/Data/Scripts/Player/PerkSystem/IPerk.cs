using DontStopTheTrain.Events;

namespace DontStopTheTrain
{
    public interface IPerk
    {
        int Value { get; }
        int Level { get; }
        IPerkStaticData StaticData { get; }
    }

    public enum PerkType
    {
        None = 0,
        ActionPoint = 1, //добавляем очки опыта
        Experience = 2, //множитель опыта
        Credits = 3, //множитель денег
        Score = 4, //множитель очков

        Seller = 5,//торговец - снижаем цены на покупки
        ReduceActionPointPrice = 6,
        //ремонтник - снижаем цену за ремонт
        //хозяюшка - износ оборудования замедляется
        //
        BoostBuf = 10, //ускорение - баф
    }
}
