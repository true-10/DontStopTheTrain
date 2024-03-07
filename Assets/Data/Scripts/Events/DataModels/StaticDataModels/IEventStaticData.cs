using System.Collections.Generic;
using UnityEngine;

namespace DontStopTheTrain.Events
{
    public interface IEventStaticData
    {
        EventId Id { get; }
        EventType Type { get; }
        // int Weight { get; }
        int Chance { get; }//Weight?
        int ActionPointPrice { get; }
        IReadOnlyList<RewardId> RewardIds { get; }
        IReadOnlyCollection<IConditionStaticData> Conditions { get; }
        IReadOnlyCollection<int> Levels { get; }
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
