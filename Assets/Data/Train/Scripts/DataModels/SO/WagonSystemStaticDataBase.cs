using DontStopTheTrain.Events;
using System.Collections.Generic;
using UnityEngine;

namespace DontStopTheTrain.Train
{
    [CreateAssetMenu(fileName = "WagonSystemStaticDataBase", menuName = "DST/Train/Systems/WagonSystemStaticDataBase")]
    public class WagonSystemStaticDataBase : ScriptableObject, IWagonSystemStaticData
    {
        public WagonSystemType Type => _type;
        public Information Info => _info;
        public int BaseEnergyConsumption => _baseEnergyConsumption;
        public int Weight => _weight;
        public IReadOnlyCollection<WagonEventType> WagonEventTypes => _wagonEventTypes;

        [SerializeField]
        private WagonSystemType _type = WagonSystemType.None;
        [SerializeField]
        private Information _info;
        [SerializeField]
        private int _baseEnergyConsumption = 1;
        [SerializeField, Min(0)]
        private int _weight = 10;
        [SerializeField]
        private List<WagonEventType> _wagonEventTypes;
    }
}

