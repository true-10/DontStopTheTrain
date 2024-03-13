﻿namespace DontStopTheTrain
{
    public interface IConditionLevelRequireStaticData : IConditionStaticData
    {
        int LevelMin { get; }
        int LevelMax { get; }
        bool IsMet(int level);
    }
}