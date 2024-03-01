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
        //�� ������ ���� �������� ����������, �� � �������? ��
        List<ICondition> Conditions { get; } //�������, ������� ������ ���� ��������� ��� ���������� ������
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