using System.Collections.Generic;
using UnityEngine;

namespace DontStopTheTrain.Events
{
    public class EventStaticDataBase : ScriptableObject, IEventStaticData
    {
        public int HashCode => GetHashCode();
        public EventId Id => _id;
        public int ActionPointPrice => _actionPointPrice;
        public virtual EventType Type => EventType.None;
        public int Chance => _chance;
        public IReadOnlyList<RewardId> RewardIds => _rewardIds.AsReadOnly();
        public GameObject EventPrefab => _eventPrefab;
        public IReadOnlyCollection<IConditionStaticData> ConditionsToComplete => _conditionsToComplete.AsReadOnly();
        public IReadOnlyCollection<IConditionStaticData> ConditionsToStart => _conditionsToStart.AsReadOnly();

        public Information Info => _info;


        [SerializeField, Min(0)]
        private EventId _id;
        [SerializeField, Min(0)]
        private int _actionPointPrice;
        [SerializeField, Min(0)]
        private int _chance;
        [SerializeField, Min(0)]
        private List<RewardId> _rewardIds;
        [SerializeField]
        private List<ConditionBase> _conditionsToComplete;
        [SerializeField]
        private List<ConditionBase> _conditionsToStart;
        [SerializeField]
        private GameObject _eventPrefab;
        [SerializeField]
        private Information _info;
    }
}