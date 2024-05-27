using DontStopTheTrain.Events;
using System;
using True10.Interfaces;
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

    public interface IWagonSystem : IHealthable, IGameLifeCycle
    {
        Action<IEvent, IWagonSystem> OnEventStarted { get; set; }
        // Action<SystemChangedCallback> OnSystemChanged { get; set; }
        Action<IWagonSystem> OnFocus { get; set; }
        IEvent ActiveEvent { get; }
        //IEventViewer EventViewer { get; }
        IWagonSystemStaticData StaticData { get; }
        int Price { get; }//цена
        int EnergyConsumption { get; } //потребление энергии
        int DeteriorationSpeed { get; } //скорость износа
        int Weight { get; }//масса системы для расчетов скорости/расхода топлива/торможения?


        void TryToFocus();
    }

    public class SystemChangedCallback
    {
        public IWagonSystem System;
        public SystemCallbackStatus Status;

    }

    public enum SystemCallbackStatus
    {
        None,
        Upgrade,
        Broken,
        Replace//?
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
