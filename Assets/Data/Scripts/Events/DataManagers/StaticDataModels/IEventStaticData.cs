using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DontStopTheTrain.Events
{
    public interface IEventStaticData
    {
        int Id { get; }
        int ActionPointPrice { get; }
        EventType Type { get; }
        // int Weight { get; }
        int Chance { get; }
        int RewardId { get; }

        IReadOnlyCollection<IConditionStaticData> Conditions { get; }
    }

    public enum EventType
    {
        None = 0,
        Wagon = 1,//�������� �������
        View = 2, //����� ���� �� ���������, �� ������� ����� � �����
        ChangeBiom = 3, //����� �����/�������


    }
}
