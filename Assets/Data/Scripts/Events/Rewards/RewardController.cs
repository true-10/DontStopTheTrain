using System.Linq;
using Zenject;

namespace DontStopTheTrain.Events
{
    public class RewardController
    {
        [Inject]
        private EventController _eventController;
        [Inject]
        private RewardsStaticManager _rewardsStaticManager;
        [Inject]
        private ItemsStaticManager _itemsStaticManager;
        [Inject]
        private Inventory _inventory;

        public void Initialize()
        {
            _eventController.OnComplete += OnComplete;
        }

        public void Dispose()
        {
            _eventController.OnComplete -= OnComplete;
        }

        private void OnComplete(IEvent eventData)
        {
            var rewardIds = eventData.StaticData.RewardIds;
            foreach (var rewardId in rewardIds)
            {
                var newItem = CreateInventoryItem(rewardId);
                if (newItem == null)
                {
                    continue;
                }
                _inventory.TryToAdd(newItem);
            }
        }

        private InventoryItem CreateInventoryItem(RewardId rewardId)
        {
            var reward = _rewardsStaticManager.Datas.FirstOrDefault(rewardStatic => rewardStatic.RewardId == rewardId);
            if (reward == null)
            {
                return null;
            }
            var itemId = reward.ItemId;
            var itemCount = reward.Count;
            var itemStatic = _itemsStaticManager.Datas.FirstOrDefault(itemStatic => itemStatic.Id == itemId);
            if (itemStatic == null)
            {
                return null;
            }
            return new InventoryItem(itemStatic, itemCount);
        }
    }
}
