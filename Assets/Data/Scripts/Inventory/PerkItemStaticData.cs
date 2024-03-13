using UnityEngine;

namespace DontStopTheTrain
{
    public interface IPerkItemStaticData : IItemStaticData
    {
        IPerkStaticData PerkStaticData { get; }
    }

    [CreateAssetMenu(fileName = "PerkItemStaticData", menuName = "DST/Items/PerkItemStaticData")]
    public class PerkItemStaticData : ItemStaticDataBase, IPerkItemStaticData
    {
        public override ItemType Type => ItemType.Perk;

        public IPerkStaticData PerkStaticData => _perkStaticDataBase;

        [SerializeField, Min(0)]
        private PerkStaticDataBase _perkStaticDataBase;
    }
}
