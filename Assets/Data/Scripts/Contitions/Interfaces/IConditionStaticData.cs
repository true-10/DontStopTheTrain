using UnityEngine;

namespace DontStopTheTrain
{
    public interface IConditionStaticData
    {
        int HashCode { get; }
       // ConditionId Id { get; }
        ConditionType Type { get; }
    }

  /*  public enum ConditionId
    {
        None = 0,

    }*/
}
