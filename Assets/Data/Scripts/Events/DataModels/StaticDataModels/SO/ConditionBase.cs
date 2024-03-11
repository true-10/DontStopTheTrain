using UnityEngine;

namespace DontStopTheTrain.Events
{
    public class ConditionBase : ScriptableObject, IConditionStaticData
    {
        public virtual ConditionType Type => ConditionType.None;

        [SerializeField, Min(0)]
        private int _weight;
    }
}