using UnityEngine;

namespace DontStopTheTrain
{
    public interface IBuffItemStaticData : IItemStaticData
    {
        IBuffStaticData BuffStaticData { get; }
    }


    [CreateAssetMenu(fileName = "PerkItemStaticData", menuName = "DST/Items/PerkItemStaticData")]
    public class BuffItemStaticData : ItemStaticDataBase, IBuffItemStaticData
    {
        public override ItemType Type => ItemType.Buff;

        public IBuffStaticData BuffStaticData => _buffStaticDataBase;

        [SerializeField, Min(0)]
        private BuffStaticDataBase _buffStaticDataBase;
    }
}
