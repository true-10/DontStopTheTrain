using DontStopTheTrain.Train;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DontStopTheTrain.Events
{


    public interface IWagonEventFabric
    {
        IWagonEvent GetEventById(int id);
    }


    public interface IWagonEventCallback
    {
        IWagonEvent WagonEvent { get; set; } //��� ������ ��������?,
        EventStatus Status { get; set; }
        //������
    }

    /// <summary>
    ///����� �������, ������� ����� ��������� � ������
    ///��������� ������� ����������
    ///��������� �������
    ///���������� ����
    /// </summary>
    public interface IWagonEvent : IEvent
    {
        WagonType WagonType { get; } //�� ����� ��� ������� ���������������� ��� �������
    }

}
