using System;
using UnityEngine;

namespace True10.StaticData
{
    [Serializable]
    public class Information
    {
        public string Name => _name;
        public string Description => _description;
        public string Hint => _hint;
        public Sprite Icon => _icon;

        [SerializeField]
        private string _name;
        [SerializeField]
        private string _description;
        [SerializeField]
        private string _hint;
        [SerializeField]
        private Sprite _icon;
    }
}
