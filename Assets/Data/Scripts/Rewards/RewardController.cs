using System.Linq;
using True10.Interfaces;
using Zenject;

namespace DontStopTheTrain.Events
{
    public class RewardController : IGameLifeCycle
    {
        [Inject]
        private EventController _eventController;//убрать и добавть колбеков?
        [Inject]
        private RewardsStaticStorage _rewardsStaticStorage;
        [Inject]
        private ItemsStaticStorage _itemsStaticManager;
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
            var rewardIds = eventData.StaticData.WinRewardIds;
            if (eventData.Status == True10.Enums.ProgressStatus.Fail)
            {
                rewardIds = eventData.StaticData.FailRewardIds;
            }
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
            var reward = _rewardsStaticStorage.Datas.FirstOrDefault(rewardStatic => rewardStatic.RewardId == rewardId);
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
