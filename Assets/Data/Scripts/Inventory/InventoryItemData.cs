using UnityEngine;

namespace DontStopTheTrain
{
    [CreateAssetMenu(fileName = "InventoryItemData", menuName = "DST/Items/InventoryItemData")]
    public class InventoryItemData : ScriptableObject
    {
        [SerializeField]
        private ItemStaticDataBase _itemStaticData;
        [SerializeField, Min(0)]
        private int _count;

        public InventoryItem GetInventoryItem()
        {
            return new InventoryItem(_itemStaticData, _count);
        }
    }
}
