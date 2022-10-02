using DontStopTheTrain.Train;
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
        GameEventStatus Status { get; set; }
        //������
    }

    /// <summary>
    ///����� �������, ������� ����� ��������� � ������
    ///��������� ������� ����������
    ///��������� �������
    ///���������� ����
    /// </summary>
    public interface IWagonEvent : IGameEvent
    {
        IWagonType WagobType { get; } //�� ����� ��� ������� ���������������� ��� �������
    }

}
