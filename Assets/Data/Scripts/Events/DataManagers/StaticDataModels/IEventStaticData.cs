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
        Wagon = 1,//вагонное событие
        View = 2, //обзор чего то бесплатно, но немного опыта и очков
        ChangeBiom = 3, //смена биома/лоакции


    }
}
