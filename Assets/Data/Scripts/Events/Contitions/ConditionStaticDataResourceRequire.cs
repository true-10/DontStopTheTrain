using UnityEngine;

namespace DontStopTheTrain.Events
{
    [CreateAssetMenu(fileName = "ResourceRequire", menuName = "DST/Events/Conditions/ResourceRequire")]
    public class ConditionStaticDataResourceRequire : ConditionBase, IConditionResourceRequireStaticData
    {
        public override ConditionType Type => ConditionType.ResourceRequire;
        public ItemId ResourceId => _resourceId;

        public int Count => _count;

        [SerializeField]
        private ItemId _resourceId;
        [SerializeField]
        private int _count;
    }
}
