using System.Collections.Generic;

namespace DontStopTheTrain
{
    public interface ICondition
    {
        IConditionStaticData StaticData { get; }
        bool IsMet();
    }


    public interface IConditionStaticData
    {
      //  ConditionId Id { get; }
        ConditionType Type { get; }
    }
}
