using UnityEngine;

namespace DontStopTheTrain.Events
{
    [CreateAssetMenu(fileName = "RewardStaticData", menuName = "DST/Events/Rewards/RewardStaticData")]
    public sealed class RewardStaticData : ScriptableObject, IRewardStaticData
    {
        public RewardId RewardId => _rewardId;
        public ItemId ItemId => _itemId;
        public int Count => _count;
        public bool IsVisible => _isVisible;
        public Sprite Icon => _icon;//зачем? у айтем есть иконка же

        [SerializeField, Min(0)]
        private RewardId _rewardId;
        [SerializeField, Min(0)]
        private ItemId _itemId;
        [SerializeField, Min(0)]
        private int _count = 10;
        [SerializeField]
        private bool _isVisible = true;
        [SerializeField]
        private Sprite _icon;

    }
}
