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

    

    public interface IGameEvent
    {

        int HashCode { get; }

        //�� ������ ���� �������� ����������, �� � �������? ��
        List<ICondition> Conditions { get; } //�������, ������� ������ ���� ��������� ��� ���������� ������
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

        public List<ICondition> Conditions => throw new NotImplementedException();

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

}