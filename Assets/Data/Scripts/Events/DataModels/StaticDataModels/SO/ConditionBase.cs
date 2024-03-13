using UnityEngine;

namespace DontStopTheTrain
{
    public class ConditionBase : ScriptableObject, IConditionStaticData
    {
        public int HashCode => GetHashCode();
        public virtual ConditionType Type => ConditionType.None;

    }
}