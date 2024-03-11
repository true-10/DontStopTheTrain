using DontStopTheTrain.Events;
using System.Collections.Generic;
using UnityEngine;

namespace DontStopTheTrain
{
    [CreateAssetMenu(fileName = "Perk", menuName = "DST/Player/Perks/Perk")]
    public class PerkStaticDataBase : ScriptableObject, IPerkStaticData
    {
        public virtual PerkType Type => PerkType.None;
        public IReadOnlyCollection<IConditionStaticData> UnlockConditions => _conditions;
        public Information Info => _info;

        [SerializeField]
        private Information _info;
        [SerializeField]
        private List<ConditionBase> _conditions;

    }
}
