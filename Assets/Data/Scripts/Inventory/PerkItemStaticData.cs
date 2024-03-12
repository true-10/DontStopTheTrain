using UnityEngine;

namespace DontStopTheTrain
{
    public interface IPerkItemStaticData : IItemStaticData
    {

    }

    [CreateAssetMenu(fileName = "PerkItemStaticData", menuName = "DST/Items/PerkItemStaticData")]
    public class PerkItemStaticData : ItemStaticDataBase, IPerkItemStaticData
    {
        public override ItemType Type => ItemType.Perk;

       // [SerializeField, Min(0)]
        //private ToolType _toolType = ToolType.Hammer;
    }
}
