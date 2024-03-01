using UnityEngine;

namespace DontStopTheTrain
{
    [CreateAssetMenu(fileName = "ToolItemStaticData", menuName = "DST/Items/ToolItemStaticData")]
    public class ToolItemStaticData : ItemStaticDataBase, IToolItemStaticData
    {
        public override ItemType Type => ItemType.Tools;
        public ToolType ToolType => _toolType;

        [SerializeField, Min(0)]
        private ToolType _toolType = ToolType.Hammer;
    }

    public interface IToolItemStaticData : IItemStaticData
    {
        ToolType ToolType { get; }
    }

    public enum ToolType
    {
        Hammer = 0,
    }
}
