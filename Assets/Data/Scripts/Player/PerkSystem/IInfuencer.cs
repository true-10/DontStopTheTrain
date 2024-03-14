using System.Collections.Generic;

namespace DontStopTheTrain
{
    public interface IBuff
    {

    }

    public interface IBuffStaticData
    {
        IReadOnlyCollection<IConditionStaticData> StopConditions { get; }
    }

    /*public interface IInfuencer : IPerk
    {//это тот же перк, только временный?
        //временный баф/дебаф
        IReadOnlyCollection<IConditionStaticData> StopConditions { get; }
        //количество ходов/дней
    }*/

    /*
     * низкая мораль - уменьшает кол-во очков действия
     * 
     */
}
