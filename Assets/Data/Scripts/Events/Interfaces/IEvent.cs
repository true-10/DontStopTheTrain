using System;
using System.Collections.Generic;
using True10.Enums;

namespace DontStopTheTrain.Events
{
    public interface IEvent
    {
        Action<IEvent> OnComplete { get; set; }
        EventId Id => StaticData.Id;
        int ActionPointPrice { get; }
        IEventStaticData StaticData { get; }

        int HashCode { get; }
        int Weight { get; }
        IReadOnlyCollection<ICondition> СompleteConditions { get; }
        ProgressStatus Status { get; }//??

        void Start();
        bool TryToComplete(); 
        void Reset();
    }

    /// <summary>
    /// событие на трассе. типа снежная буря. это влияет на вентяляционные системы поезда. типа содержит список IWagonEvent
    /// </summary>
    public interface IRoadEvent : IEvent
    {
        ///тип события. красивый рассвет, песчанная буря, атака рейдеров и тд
        int RoadEventType { get; }
    }

    /// <summary>
    /// событие при остановке. на станции, на стрелке, на заправке хз, и тд
    /// </summary>
    public interface IStopageEvent : IEvent
    {

    }
}