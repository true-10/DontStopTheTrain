using DontStopTheTrain.Events;
using System.Collections.Generic;
using True10.StaticData;
using UnityEngine;

namespace DontStopTheTrain.Train
{
    [CreateAssetMenu(fileName = "WagonSystemStaticDataBase", menuName = "DST/Train/Systems/WagonSystemStaticDataBase")]
    public class WagonSystemStaticDataBase : ScriptableObject, IWagonSystemStaticData
    {
        public WagonSystemType Type => _type;
        public Information Info => _info;
        public int BaseEnergyConsumption => _baseEnergyConsumption;
        public int BaseDeteriorationSpeed => _baseDeteriorationSpeed;
        public int Weight => _weight;
        public int MaxHealth => _maxHealth;
        public IReadOnlyCollection<WagonEventType> WagonEventTypes => _wagonEventTypes;

        public IWagonSystemVisualData VisualData => _wagonPartStaticData;

        public IWagonSystemStaticData NextLevelStaticData => _nextLevelStaticData;
        public int Price => _price;
        public int UpgradePrice => _upgradePrice;

        [SerializeField]
        private WagonSystemType _type = WagonSystemType.None;
        [SerializeField]
        private Information _info;
        [SerializeField]
        private int _baseEnergyConsumption = 1;
        [SerializeField, Min(0)]
        private int _baseDeteriorationSpeed = 10;
        [SerializeField, Min(0)]
        private int _weight = 10;
        [SerializeField, Min(0)]
        private int _maxHealth = 1000;
        [SerializeField]
        private List<WagonEventType> _wagonEventTypes;
        [SerializeField]
        private WagonSystemVisualData _wagonPartStaticData;
        [SerializeField]
        private WagonSystemStaticDataBase _nextLevelStaticData;
        [SerializeField]
        private int _price;
        [SerializeField]
        private int _upgradePrice;
    }
}

