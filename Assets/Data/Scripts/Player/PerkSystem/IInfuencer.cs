using System.Collections.Generic;

namespace DontStopTheTrain
{
    public interface IInfuencer : IPerk
    {//это тот же перк, только временный?
        //временный баф/дебаф
        IReadOnlyCollection<IConditionStaticData> StopConditions { get; }
        //количество ходов/дней
    }
}
