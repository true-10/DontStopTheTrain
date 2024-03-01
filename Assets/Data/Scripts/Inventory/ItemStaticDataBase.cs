using UnityEngine;

namespace DontStopTheTrain
{
    public interface IItemStaticData
    {
        int Id { get; }
        ItemType Type { get; }
        public Sprite Icon { get; }
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
        public int Id => _id;
        public virtual ItemType Type => ItemType.None;
        public Sprite Icon => _icon;

        [SerializeField, Min(0)]
        private int _id;
        [SerializeField]
        private Sprite _icon;

    }
}
