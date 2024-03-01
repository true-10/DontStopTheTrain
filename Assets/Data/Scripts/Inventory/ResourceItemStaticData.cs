using UnityEngine;

namespace DontStopTheTrain
{
    [CreateAssetMenu(fileName = "ResourceItemStaticData", menuName = "DST/Items/ResourceItemStaticData")]
    public class ResourceItemStaticData : ItemStaticDataBase, IResourceItemStaticData
    {
        public override ItemType Type => ItemType.Resource;
        public ResourceType ResourceType => _resourceType;

        [SerializeField, Min(0)]
        private ResourceType _resourceType = ResourceType.Regular;
    }

    public interface IResourceItemStaticData : IItemStaticData
    {
        ResourceType ResourceType { get; }
    }

    public enum ResourceType
    {
        Regular = 0,
        Rare = 1,
        SuperRare = 2
    }
}
