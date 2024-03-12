using UnityEngine;

namespace DontStopTheTrain
{
    public class ConditionBase : ScriptableObject, IConditionStaticData
    {
        public virtual ConditionType Type => ConditionType.None;

    }
}