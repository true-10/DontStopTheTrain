using DontStopTheTrain.Events;
using System;
using System.Buffers;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

namespace DontStopTheTrain
{    
    public sealed class Inventory
    {
        public Action<InventoryCallback> OnInventoryChanged { get; set; }

        [Inject]
        private ItemsStaticManager _itemsStaticManager;

        private Dictionary<int, InventoryItem> _idInventoryItems = new();
        //capacity?

        public void Initialize(List<InventoryItem> inventoryItems)
        {
            foreach (var inventoryItem in inventoryItems)
            {
                TryToAdd(inventoryItem);
            }
        }

        public void TryToAdd(InventoryItem inventoryItem)
        {
            TryToAdd(inventoryItem.StaticData, inventoryItem.Count);
        }

        public void TryToRemove(InventoryItem inventoryItem)
        {
            TryToRemove(inventoryItem.StaticData, inventoryItem.Count);
        }

        public void TryToAdd(IItemStaticData itemStatic, int count)
        {
            var itemId = itemStatic.Id;
            InventoryOperationStatus status = InventoryOperationStatus.Success;
            var newInventoryItems = new InventoryItem(itemStatic, count);
            if (_idInventoryItems.ContainsKey(itemId))
            {
                var newAmount = _idInventoryItems[itemId].Count + count;
                _idInventoryItems[itemId] = new InventoryItem(itemStatic, newAmount);
            }
            else
            {
                _idInventoryItems.Add(itemId, newInventoryItems);
            }
            //var itemStaticData = _itemsStaticManager.ItemStaticDatas.FirstOrDefault(item => item.Id == itemId);
            InventoryCallback callback = new(InventoryOperationType.Add, status,
                _idInventoryItems[itemId], count, itemStatic);
            OnInventoryChanged?.Invoke(callback);
        }

        public void TryToRemove(IItemStaticData itemStatic, int count)
        {
            var itemId = itemStatic.Id;
            InventoryOperationStatus status = InventoryOperationStatus.Success;

            if (_idInventoryItems.ContainsKey(itemId))
            {
                var newAmount = _idInventoryItems[itemId].Count - count;
                newAmount = newAmount < 0 ? 0 : newAmount;
                _idInventoryItems[itemId] = new InventoryItem(itemStatic, newAmount);
            }
            else
            {
                status = InventoryOperationStatus.Fail;
            }

            var itemStaticData = _itemsStaticManager.ItemStaticDatas.FirstOrDefault(item => item.Id == itemId);

            InventoryCallback callback = new(InventoryOperationType.Remove, status,
                null, count, itemStaticData);
            OnInventoryChanged?.Invoke(callback);
        }
       
        public bool IsEnough(int itemId, int count)
        {
            if (_idInventoryItems.ContainsKey(itemId) == false)
            {
                return false;
            }
            return _idInventoryItems[itemId].Count >= count;
        }

        public bool TryGetCountById(int itemId, out int count)
        {
            count = 0;
            if (_idInventoryItems.ContainsKey(itemId) == false)
            {
                return false;
            }
            count = _idInventoryItems[itemId].Count;
            return true;
        }
    }

    [Serializable]
    public sealed class InventoryItem
    {
        public IItemStaticData StaticData { get; private set; }
        public int Count { get; private set; }

        public InventoryItem(IItemStaticData staticData, int count)
        {
            StaticData = staticData;
            Count = count;
        }
    }

}
