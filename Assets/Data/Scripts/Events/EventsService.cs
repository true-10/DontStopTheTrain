using System.Collections.Generic;
using System.Linq;
using Zenject;

namespace DontStopTheTrain.Events
{
    public sealed class EventsService
    {
        [Inject]
        private Player _player;
        [Inject]
        private ItemsStaticManager _itemsStaticManager;
        [Inject]
        private Inventory _inventory;

        public int ActionPoints => _player.ActionPoints.Value;

        public bool IsEnoughActionPoints(IEvent eventData)
        {
            return _player.ActionPoints.Value > eventData.StaticData.ActionPointPrice;
        }

        public bool IsAllConditionsAreMet(IEvent eventData)
        {
            return eventData.Conditions.All(condition => condition.IsMet());
        }

        public List<InventoryItem> GetResourceFromConditions(IEvent eventData)
        {
            List<InventoryItem> resourcesToRemove = new();
            foreach (var condition in eventData.Conditions)
            {
                if (condition is IConditionResourceRequire)
                {
                    var conditionResourceRequire = condition as IConditionResourceRequire;
                    var itemStatic = _itemsStaticManager.ItemStaticDatas.FirstOrDefault(item => item.Id == conditionResourceRequire.ResourceId);
                    if (itemStatic == null)
                    {
                        continue;
                    }
                    var inventoryItem = new InventoryItem(itemStatic, conditionResourceRequire.Count);
                    resourcesToRemove.Add(inventoryItem);
                }
            }
            return resourcesToRemove;
        }

        public void TryToRemoveRequredItems(IEvent eventData)
        {
            var items = GetResourceFromConditions(eventData);
            if (items.Count == 0)
            {
                return;
            }
            foreach (var item in items)
            {
                _inventory.TryToRemove(item);
            }
        }
    }
}

