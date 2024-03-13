using DontStopTheTrain.Events;
using System.Collections.Generic;
using UnityEngine;

namespace DontStopTheTrain
{
    [CreateAssetMenu(fileName = "Perk", menuName = "DST/Player/Perks/Perk")]
    public class PerkStaticDataBase : ScriptableObject, IPerkStaticData
    {
        //public virtual PerkType Type => PerkType.None;
        public PerkType Type => _perkType;
        public IReadOnlyCollection<IConditionStaticData> UnlockConditions => _conditions;
        public Information Info => _info;

        public int Value => _value;

        public IReadOnlyCollection<InventoryItem> UpgradePrice => throw new System.NotImplementedException();

        [SerializeField]
        private int _value;
        [SerializeField]
        private PerkType _perkType;
        [SerializeField]
        private Information _info;
        [SerializeField]
        private List<ConditionBase> _conditions;

    }
}
