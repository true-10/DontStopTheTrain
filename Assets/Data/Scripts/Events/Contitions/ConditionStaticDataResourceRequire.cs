using UnityEngine;

namespace DontStopTheTrain.Events
{
    [CreateAssetMenu(fileName = "ResourceRequire", menuName = "DST/Events/Conditions/ResourceRequire")]
    public class ConditionStaticDataResourceRequire : ConditionBase, IConditionResourceRequireStaticData
    {
        public override ConditionType Type => ConditionType.ResourceRequire;
        public int ResourceId => _resourceId;

        public int Count => _count;

        [SerializeField]
        private int _resourceId;
        [SerializeField]
        private int _count;
    }
}
