using System.Collections.Generic;
using True10.Enums;

namespace DontStopTheTrain
{
    public interface IBuffStaticData
    {
        BuffId Id { get; }
        PositiveStatus PositiveStatus { get; }
        Information Info { get; }
        int Time { get; }//сколько ходов действует
        int BaseValue { get; }
        PerkType Type { get; }
       // IReadOnlyCollection<IConditionStaticData> StopConditions { get; }
    }

    public enum BuffId
    {
        None = 0,
        Dismorality = 1,

    }

    /*
     * низкая мораль - уменьшает кол-во очков действия
     * 
     */
}
