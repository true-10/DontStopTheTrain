using System.Collections.Generic;
using UnityEngine;

namespace DontStopTheTrain.Events
{
    public interface IEventStaticData
    {
        EventId Id { get; }
        int ActionPointPrice { get; }
        EventType Type { get; }
        // int Weight { get; }
        int Chance { get; }
        IReadOnlyList<RewardId> RewardIds { get; }
        GameObject EventPrefab { get; } 
        IReadOnlyCollection<IConditionStaticData> Conditions { get; }
        IReadOnlyCollection<int> Levels { get; }
        public Information Info { get; }
    }

    public interface IWagonEventStaticData : IEventStaticData
    {
        WagonEventType WagonEventType { get; }
    }

    public enum WagonEventType
    {
        None = 0,
        Fire = 1,
        SystemFailure = 2,


    }
}
