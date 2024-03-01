using UnityEngine;

namespace DontStopTheTrain.Events
{
    public class ConditionBase : ScriptableObject, IConditionStaticData
    {
        public int Id => _id;

        public int Weight => _weight;

        public virtual ConditionType Type => ConditionType.None;

        [SerializeField, Min(0)]
        private int _id;
        [SerializeField, Min(0)]
        private int _weight;
    }
}