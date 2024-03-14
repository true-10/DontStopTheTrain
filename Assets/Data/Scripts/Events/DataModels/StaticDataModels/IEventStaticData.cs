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
        IReadOnlyCollection<IConditionStaticData> ConditionsToComplete { get; }//условия завершения
        IReadOnlyCollection<IConditionStaticData> ConditionsToStart { get; }//условия выдачи
        public Information Info { get; }
        GameObject EventPrefab { get; }
    }

    public interface IWagonEventStaticData : IEventStaticData
    {
        WagonEventType WagonEventType { get; }
    }
    /// <summary>
    ///некое событие, которое может произойти в вагоне
    ///накрылась система вентиляции
    ///сломались тормоза
    ///взорвалась жопа
    /// </summary>
    public enum WagonEventType
    {
        None = 0,
        Fire = 1,//может перекидываться на другие вагоны?
        ShortCircuit = 2,
        SystemFailure = 3,
    }
}
