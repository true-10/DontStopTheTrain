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
}
