using DontStopTheTrain.Events;
using System.Collections.Generic;

namespace DontStopTheTrain
{
    ///
    public interface IUnlock
    {
        int Id { get; }
        int MinimalLevelPlayer { get; }//minimal user player for unlocking this perk 

    }
    public interface IInfuencer : IPerk
    {//это тот же перк, только временный?
        //временный баф/дебаф
        IReadOnlyCollection<IConditionStaticData> StopConditions { get; }
    }

    public interface IPerk
    {
        int Value { get; }
        int Level { get; }
        IPerkStaticData StaticData { get; }
    }

    public class Perk : IPerk
    {
        public int Value => StaticData.Value;

        public int Level => 1;

        public IPerkStaticData StaticData { get; }

        public Perk(IPerkStaticData staticData)
        {
            StaticData = staticData;
        }

    }

    public interface IPerkStaticData
    {
        PerkType Type { get; }
        int Value { get; }
        IReadOnlyCollection<IConditionStaticData> UnlockConditions { get; }
        IReadOnlyCollection<InventoryItem> UpgradePrice { get; }

        Information Info { get; }

    }

    public enum PerkType
    {
        None = 0,
        ActionPoint = 1, //добавляем очки опыта
        Experience = 2, //множитель опыта
        Credits = 3, //множитель денег
        Score = 4, //множитель очков

        Seller = 5,//торговец - снижаем цены на покупки
        //ремонтник - снижаем цену за ремонт
        //хозяюшка - износ оборудования замедляется
        //
        BoostBuf = 10, //ускорение - баф
    }
    public enum PerkOperationType
    {
        Add = 0,
        Mult = 1
    }
}
