using UnityEngine;

namespace DontStopTheTrain
{
    public class ItemStaticDataBase : ScriptableObject, IItemStaticData
    {
        public ItemId Id => _id;
        public virtual ItemType Type => ItemType.None;
        public Information Info => _info;
        public bool IsVisible => _isVisible;

        [SerializeField, Min(0)]
        private ItemId _id;
        [SerializeField]
        private Information _info;
        [SerializeField]
        private bool _isVisible = true;
    }
}
