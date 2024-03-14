using System.Collections.Generic;
using UnityEngine;

namespace DontStopTheTrain
{
    [CreateAssetMenu(fileName = "QuestStaticDataBase", menuName = "DST/Quests/QuestStaticDataBase")]
    public class QuestStaticDataBase : ScriptableObject, IQuestStaticData
    {
        public virtual QuestType Type => _type;
        public IReadOnlyList<RewardId> RewardIds => _rewardIds.AsReadOnly();
        public IReadOnlyCollection<IConditionStaticData> ConditionsToComplete => _conditionsToComplete.AsReadOnly();
        public Information Info => _info;


        [SerializeField, Min(0)]
        private QuestType _type = QuestType.Unknown;
        [SerializeField, Min(0)]
        private List<RewardId> _rewardIds;
        [SerializeField]
        private List<ConditionBase> _conditionsToComplete;
        [SerializeField]
        private Information _info;
    }
}