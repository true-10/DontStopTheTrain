using System;
using System.Collections;
using UnityEngine;


namespace DontStopTheTrain.Events
{
    public enum EventStatus
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
    public interface IRoadEvent : IEvent
    {
        ///��� �������. �������� �������, ��������� ����, ����� �������� � ��
        int RoadEventType { get;} 
    }

    /// <summary>
    /// ������� ��� ���������. �� �������, �� �������, �� �������� ��, � ��
    /// </summary>
    public interface IStopageEvent : IEvent
    {

    }

}