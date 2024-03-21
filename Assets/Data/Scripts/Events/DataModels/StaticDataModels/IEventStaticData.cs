using System.Collections.Generic;
using True10.StaticData;
using UnityEngine;

namespace DontStopTheTrain.Events
{
    public interface IEventStaticData
    {
        int HashCode { get; }
        EventId Id { get; }
        EventType Type { get; }
        int Chance { get; }
        int ActionPointPrice { get; }
        IReadOnlyList<RewardId> RewardIds { get; }
        IReadOnlyCollection<IConditionStaticData> ConditionsToComplete { get; }//������� ����������
        IReadOnlyCollection<IConditionStaticData> ConditionsToStart { get; }//������� ������
        public Information Info { get; }
        GameObject EventPrefab { get; }
    }

    public interface IWagonEventStaticData : IEventStaticData
    {
        WagonEventType WagonEventType { get; }
    }
    /// <summary>
    ///����� �������, ������� ����� ��������� � ������
    ///��������� ������� ����������
    ///��������� �������
    ///���������� ����
    /// </summary>
    public enum WagonEventType
    {
        None = 0,
        Fire = 1,//����� �������������� �� ������ ������?
        ShortCircuit = 2,
        SystemFailure = 3,
    }
}
