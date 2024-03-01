using UnityEngine;
using System.Collections.Generic;

namespace DontStopTheTrain
{
    [CreateAssetMenu(fileName = "ItemsStarterPack", menuName = "DST/Items/ItemsStarterPack")]
    public class InventoryStarterPackStorage : ScriptableObject
    {
        [SerializeField]
        private List<InventoryItemData> _items;

        public List<InventoryItem> GetStartItems()
        {
            List<InventoryItem> starterPack = new();
            foreach (var item in _items)
            {
                starterPack.Add(item.GetInventoryItem());
            }
            return starterPack;
        }
    }
}
