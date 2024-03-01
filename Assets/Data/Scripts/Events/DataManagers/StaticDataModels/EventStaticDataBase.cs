using System.Collections.Generic;
using UnityEngine;

namespace DontStopTheTrain.Events
{
    public class EventStaticDataBase : ScriptableObject, IEventStaticData
    {
        public int Id => _id;

        public int ActionPointPrice => _actionPointPrice;

        public virtual EventType Type => EventType.None;

        public int Chance => _chance;
        public int RewardId => _rewardId;

        public IReadOnlyCollection<IConditionStaticData> Conditions => _conditions.AsReadOnly();

        [SerializeField, Min(0)]
        private int _id;
        [SerializeField, Min(0)]
        private int _actionPointPrice;
        [SerializeField, Min(0)]
        private int _chance;
        [SerializeField, Min(0)]
        private int _rewardId;
        [SerializeField]
        private List<ConditionBase> _conditions;
    }
}