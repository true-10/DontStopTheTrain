using DontStopTheTrain.MiniGames;
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
        int Weight { get; }
        int FastFixMinLevel { get; }//уровень игрока, после которого не надо играть мини игру
        //AbstractMiniGame MiniGamePrefab { get;  }
        int ActionPointPrice { get; }
        int Time { get; }//время длительности, после которого завершается. если 0, то без ограничений
        IReadOnlyList<RewardId> WinRewardIds { get; }
        //IReadOnlyList<RewardId> FailRewardIds { get; }
        IReadOnlyList<IBuff> FailDebuffs { get; }
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
        PassangersConflict = 4, //пассажиры чото не поделили
        //CrewConflict = 4, //команда чото не поделила
        //жалоба пассажиров? типа холодно, поддайте жару и прочее
    }
}
