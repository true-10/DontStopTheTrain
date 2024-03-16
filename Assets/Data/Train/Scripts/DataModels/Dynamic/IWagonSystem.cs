using UnityEngine;

namespace DontStopTheTrain.Train
{
    //какие системы?
    //обязательные:
    //-тормозная система
    //-климат контроль

    //специальные:
    //-Двигатель
    //-Генератор
    //

    //опциональные:
    //-


    public enum WagonSystemId
    {

    }

    public interface IWagonSystem : IHealthable
    {
        IWagonSystemStaticData StaticData { get; }
        int Price { get; }//цена
        int EnergyConsumption { get; } //потребление энергии
        int DeteriorationSpeed { get; } //скорость износа
        int Weight { get; }//масса системы для расчетов скорости/расхода топлива/торможения?
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

    public interface IWeaponSystem : IWagonSystem
    {

    }
}
