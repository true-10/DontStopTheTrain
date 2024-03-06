using System;
using UnityEngine;

namespace DontStopTheTrain
{
    [Serializable]
    public class Information
    {
        public string Name => _name;
        public string Description => _description;
        public Sprite Icon => _icon;

        [SerializeField]
        private string _name;
        [SerializeField]
        private string _description;
        [SerializeField]
        private Sprite _icon;
    }

    public interface IItemStaticData
    {
        ItemId Id { get; }
        ItemType Type { get; }
        public Information Info { get; }
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
