﻿using System.Linq;

namespace DontStopTheTrain
{
    public sealed class LevelUpCalculator
    {
        public LevelUpCalculator(LevelsStaticManager staticManager)
        {
            _staticManager = staticManager;
        }

        private LevelsStaticManager _staticManager;

        public int GetLevel(int exp)
        {
            var level = _staticManager.Datas.FirstOrDefault(x => exp >= x.Expo);
            if (level == null)
            {
                return 1;
            }
            return level.Level;
        }
    }
}