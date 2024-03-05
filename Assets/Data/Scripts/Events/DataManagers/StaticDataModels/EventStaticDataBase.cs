using System.Collections.Generic;
using UnityEngine;

namespace DontStopTheTrain.Events
{
    public class EventStaticDataBase : ScriptableObject, IEventStaticData
    {
        public EventId Id => _id;
        public int ActionPointPrice => _actionPointPrice;
        public virtual EventType Type => EventType.None;
        public int Chance => _chance;
        public IReadOnlyList<RewardId> RewardIds => _rewardIds.AsReadOnly();
        public GameObject EventPrefab => _eventPrefab;
        public IReadOnlyCollection<IConditionStaticData> Conditions => _conditions.AsReadOnly();

        [SerializeField, Min(0)]
        private EventId _id;
        [SerializeField, Min(0)]
        private int _actionPointPrice;
        [SerializeField, Min(0)]
        private int _chance;
        [SerializeField, Min(0)]
        private List<RewardId> _rewardIds;
        [SerializeField]
        private List<ConditionBase> _conditions;
        [SerializeField]
        private GameObject _eventPrefab;
    }
}