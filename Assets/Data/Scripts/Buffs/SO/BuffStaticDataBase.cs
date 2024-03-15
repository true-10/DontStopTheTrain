using True10.Enums;
using UnityEngine;

namespace DontStopTheTrain
{
    [CreateAssetMenu(fileName = "Buff", menuName = "DST/Player/Buffs/Buff")]
    public class BuffStaticDataBase : ScriptableObject, IBuffStaticData
    {
        public BuffId Id => _buffId;
        public PositiveStatus PositiveStatus => _positiveStatus;

        public Information Info => _info;

        public int Time => _time;

        public int BaseValue => _value;

        public PerkType Type => _type;

        [SerializeField]
        private BuffId _buffId;
        [SerializeField]
        private PositiveStatus _positiveStatus;
        [SerializeField]
        private int _value = 1;
        [SerializeField]
        private int _time = 1;
        [SerializeField]
        private PerkType _type = PerkType.None;
        [SerializeField]
        private Information _info;
    }
}
