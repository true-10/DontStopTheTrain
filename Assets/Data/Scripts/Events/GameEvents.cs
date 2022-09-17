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
        int EventType { get; }
        //List<int> int_params;
    }

    public enum GameEventStatus
    {
        None,
        Complete,
        InProgress,
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
        GameEventStatus EventStatus { get; set; }
    }

    public interface IGameEventsController
    {

        Action<IGameEventCallback> OnComplete { get; set; }
        Action<IGameEvent> OnChangeStatus { get; set; }
    }
}