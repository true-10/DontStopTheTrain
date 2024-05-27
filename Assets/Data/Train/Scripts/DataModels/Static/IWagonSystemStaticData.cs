using DontStopTheTrain.Events;
using System.Collections.Generic;
using True10.StaticData;

namespace DontStopTheTrain.Train
{
    public interface IWagonSystemStaticData
    {
        WagonSystemType Type { get; }
        Information Info { get; }
        int BaseEnergyConsumption { get; } //потребление энергии
        int BaseDeteriorationSpeed { get; } //базовая скорость износа
        int Weight { get; }
        int MaxHealth { get; }
        IReadOnlyCollection<WagonEventType> WagonEventTypes { get; }//допустимые события у это системы

        IWagonSystemVisualData WagonPartStaticData { get; }
        public IWagonSystemStaticData NextLevelStaticData { get; }
        public int Price { get; }
        public int UpgradePrice { get; }

        //список доступных мини игр?
    }

    public enum WagonSystemType
    {
        None = 0,
        Сhassis, //ходовая часть (рампы, тормоза, двигатель и тд)
        Service,//?? обслуживающие системы? Водопровод, отопление, кондей,?
        Generator,//Fabric?? вырабатывающие что то..  электрогенератор, кухня, мастерская
        Storage, //баки с топливом, холодильники, кузов

        //Hull,
        //Cart,
        //Engine
    }
}
