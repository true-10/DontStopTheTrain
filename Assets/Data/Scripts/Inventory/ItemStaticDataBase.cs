using UnityEngine;

namespace DontStopTheTrain
{

    public interface IItemStaticData
    {
        ItemId Id { get; }
        ItemType Type { get; }
        public Sprite Icon { get; }
        bool IsVisible { get;}
    }

    public enum ItemType
    {
        None = 0,
        Player = 1,
        Tools = 2,
        Resource = 3,
    }

    public class ItemStaticDataBase : ScriptableObject, IItemStaticData
    {
        public ItemId Id => _id;
        public virtual ItemType Type => ItemType.None;
        public Sprite Icon => _icon;
        public bool IsVisible => _isVisible;

        [SerializeField, Min(0)]
        private ItemId _id;
        [SerializeField]
        private Sprite _icon;
        [SerializeField]
        private bool _isVisible = true;
    }
}
