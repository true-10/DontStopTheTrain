using DontStopTheTrain.Events;
using System.Collections.Generic;
using True10.StaticData;
using UnityEngine;

namespace DontStopTheTrain.Train
{
    [CreateAssetMenu(fileName = "WagonStaticDataBase", menuName = Constants.ContextMenuPaths.WAGON + "WagonStaticDataBase")]
    public class WagonStaticDataBase : ScriptableObject, IWagonStaticData
    {
        public int Id => _id;
        public Information Info => _info;
        public virtual WagonType WagonType => WagonType.Empty;
        public WagonSystemType Type => WagonSystemType.Сhassis;
        public int BaseEnergyConsumption => _baseEnergyConsumption;
        public int BaseDeteriorationSpeed => _baseDeteriorationSpeed;
        public int MaxHealth => _maxHealth;
        public int Weight => _weight;
        public IReadOnlyCollection<IWagonSystemStaticData> Systems => _systemsStatic.AsReadOnly();
        public IReadOnlyCollection<WagonEventType> WagonEventTypes => _wagonEventTypes;

        [SerializeField, Min(0)]
        private int _id;
        [SerializeField, Min(0)]
        private int _weight;
        [SerializeField, Min(0)]
        private int _maxHealth = 1000;
        [SerializeField]
        private Information _info;
        [SerializeField]
        private int _baseEnergyConsumption = 10;
        [SerializeField, Min(0)]
        private int _baseDeteriorationSpeed = 10;
        [SerializeField]
        private List<WagonEventType> _wagonEventTypes;
        [SerializeField]
        private List<WagonSystemStaticDataBase> _systemsStatic;
    }
}

