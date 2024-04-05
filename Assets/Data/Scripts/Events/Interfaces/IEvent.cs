using DontStopTheTrain.MiniGames;
using System;
using System.Collections.Generic;
using True10.Enums;

namespace DontStopTheTrain.Events
{
    public interface IEvent
    {
        Action<IEvent> OnComplete { get; set; }
        Action<IEvent> OnFocus { get; set; }
        EventId Id => StaticData.Id;
        //IMiniGame MiniGame { get; }
        int ActionPointPrice { get; }
        int Chance { get; }
        IEventStaticData StaticData { get; }

        int HashCode { get; }
        IReadOnlyCollection<ICondition> СompleteConditions { get; }
        ProgressStatus Status { get; }//??

        void Start();
        bool TryToComplete(); 
        void TryToFocus(); 
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