using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace DontStopTheTrain.Events
{
    /// <summary>
    /// 
    /// </summary>
    public interface IEventTrigger
    {
        Action<IEvent> OnTrigger { get; set; }
    }

    public interface IEvent
    {
        Action<IEvent> OnComplete { get; set; }
        int Id => StaticData.Id;
        int HashCode { get; }

        int Weight { get; }
        //не только очки действия вкладывать, но и ресурсы? да
        List<ICondition> Conditions { get; } //условия, которые должны быть выполнены для завершения ивента
        IEventStaticData StaticData { get; set; }//??
        EventStatus Status { get; set; }//??

        //List<int> int_params;
        void Initialize(IEventInitData data);
        //void Complete();


    }
    public interface IEventInitData
    {

    }

    public enum EventStatus
    {
        None, //бездействующие
        Start,
        InProgress,
        Complete,
        Fail
    }

    /// <summary>
    /// событие на трассе. типа снежная буря. это влияет на вентяляционные системы поезда. типа содержит список IWagonEvent
    /// </summary>
    public interface IRoadEvent : IEvent
    {
        ///тип события. красивый рассвет, песчанная буря, атака рейдеров и тд
        int RoadEventType { get;} 
    }

    /// <summary>
    /// событие при остановке. на станции, на стрелке, на заправке хз, и тд
    /// </summary>
    public interface IStopageEvent : IEvent
    {

    }

}