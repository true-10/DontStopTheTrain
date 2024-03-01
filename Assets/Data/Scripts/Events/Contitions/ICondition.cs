using System.Collections.Generic;

namespace DontStopTheTrain.Events
{
    public interface ICondition
    {
        IConditionStaticData StaticData { get; }
        bool IsMet();
    }


    public interface IConditionStaticData
    {
        int Id { get; }
        int Weight { get; }
        ConditionType Type { get; }
    }
}
