using DontStopTheTrain.MiniGames;
using System.Collections.Generic;
using True10.StaticData;
using UnityEngine;

namespace DontStopTheTrain.Events
{
    public class EventStaticDataBase : ScriptableObject, IEventStaticData
    {
        public int HashCode => GetHashCode();
        public EventId Id => _id;
        public int ActionPointPrice => _actionPointPrice;
        public virtual EventType Type => EventType.None;
        public int Weight => _weight;
        public int Time => _time;
        public int FastFixMinLevel => _fastFixMinLevel;
        public IReadOnlyList<RewardId> WinRewardIds => _rewardIds.AsReadOnly();
       // public IReadOnlyList<RewardId> FailRewardIds => _failRewardIds.AsReadOnly();
        public GameObject EventPrefab => _eventPrefab;
        public IReadOnlyCollection<IConditionStaticData> ConditionsToComplete => _conditionsToComplete.AsReadOnly();
        public IReadOnlyCollection<IConditionStaticData> ConditionsToStart => _conditionsToStart.AsReadOnly();

        public Information Info => _info;

        //public AbstractMiniGame MiniGamePrefab => _miniGamePrefab;


        public IReadOnlyList<IBuff> FailDebuffs => throw new System.NotImplementedException();

        [SerializeField, Min(0)]
        private EventId _id;
        [SerializeField, Min(0), Tooltip("кол-во очков действия для завершения события")]
        private int _actionPointPrice;
        [SerializeField, Min(1)]
        private int _weight;
        [SerializeField, Min(1), Tooltip("Длительность события в ходах. 0 - без ограничений")]
        private int _time;
        [SerializeField, Min(1), Tooltip("Уровень игрока, после которого не надо играть мини игру")]
        private int _fastFixMinLevel;
        [SerializeField, Min(0)]
        private List<RewardId> _rewardIds;
        [SerializeField, Min(0)]
        private List<RewardId> _failRewardIds;
       // [SerializeField]
        //private AbstractMiniGame _miniGamePrefab;
        [SerializeField]
        private List<ConditionBase> _conditionsToComplete;
        [SerializeField]
        private List<ConditionBase> _conditionsToStart;
        [SerializeField]
        private GameObject _eventPrefab;
        [SerializeField, Tooltip("Общая информация")]
        private Information _info;
    }
}