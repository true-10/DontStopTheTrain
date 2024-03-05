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
    }
}
