using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace DontStopTheTrain.Events
{

    /// <summary>
    /// 
    /// </summary>
    public interface IGameEventTriiger
    {
        Action<IGameEvent> OnTrigger { get; set; }
    }

    public interface IGameEventStaticData
    {
        int Id { get; }
        int ActionPointPrice { get; }
        int EventType { get; }
       // int Weight { get; }
        int Chance { get; }
    }

    public class GameEventStaticData : IGameEventStaticData
    {
        public int Id { get; set; }

        public int ActionPointPrice { get; set; }

        public int EventType { get; set; }
        public int Chance { get; set; }
    }

    public interface IGameEvent
    {

        int HashCode { get; }
        IGameEventStaticData StaticData { get; set; }//??
        GameEventStatus Status { get; set; }//??

        //List<int> int_params;
        void Start();
        void Complete();
        Action OnComplete { get; set; }
        Action OnStart { get; set; }
        Action OnTick { get; set; }


    }

    public class BaseGameEvent : IGameEvent
    {
        public IGameEventStaticData StaticData { get; set; }
        public GameEventStatus Status { get; set; }
        public Action OnComplete { get; set; }
        public Action OnStart { get; set; }
        public Action OnTick { get; set; }

        public int HashCode => $"{StaticData.Id}".GetHashCode();

        public void Complete()
        {
            if (Status == GameEventStatus.Complete)
            {
                //     return;
            }
            Status = GameEventStatus.Complete;
            OnComplete?.Invoke();
        }

        public void Start()
        {
            if (Status == GameEventStatus.Start)
            {
           //     return;
            }
            Status = GameEventStatus.Start;
            OnStart?.Invoke();
        }
    }

    public enum GameEventStatus
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
    public interface IRoadEvent : IGameEvent
    {
        ///тип события. красивый рассвет, песчанная буря, атака рейдеров и тд
        int RoadEventType { get;} 
    }

    /// <summary>
    /// событие при остановке. на станции, на стрелке, на заправке хз, и тд
    /// </summary>
    public interface IStopageEvent : IGameEvent
    {

    }

    public interface IGameEventCallback
    {
        int EventId { get; set; }
        //IGameEvent GameEvent { get; set; }
        GameEventStatus EventStatus { get; set; }
    }

    public class GameEventCallback : IGameEventCallback
    {
        public int EventId { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public GameEventStatus EventStatus { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}