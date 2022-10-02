using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace DontStopTheTrain.Events
{

    public interface IGameEvent
    {
        int Id { get; }
        GameEventStatus Status { get; set; }//??

        int ActionPointPrice { get; }
        int EventType { get; }
        //List<int> int_params;
        Action Fire { get; set; }
        Action OnComplete { get; set; }
    }

    public enum GameEventStatus
    {
        None, //��������������
        Start,
        InProgress,
        Complete,
        Fail
    }

    /// <summary>
    /// ������� �� ������. ���� ������� ����. ��� ������ �� �������������� ������� ������. ���� �������� ������ IWagonEvent
    /// </summary>
    public interface IRoadEvent : IGameEvent
    {
        ///��� �������. �������� �������, ��������� ����, ����� �������� � ��
        int RoadEventType { get;} 
    }

    /// <summary>
    /// ������� ��� ���������. �� �������, �� �������, �� �������� ��, � ��
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