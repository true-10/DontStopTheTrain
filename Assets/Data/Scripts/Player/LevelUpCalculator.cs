using System.Linq;

namespace DontStopTheTrain
{
    public sealed class LevelUpCalculator
    {
        public LevelUpCalculator(LevelsStaticManager levelsStaticManager)
        {
            _levelsStaticManager = levelsStaticManager;
        }

        private LevelsStaticManager _levelsStaticManager;

        public int GetLevel(int exp)
        {
            var level = _levelsStaticManager.LevelsStaticDatas.FirstOrDefault(x => exp >= x.Expo);
            if (level == null)
            {
                return 1;
            }
            return level.Level;
        }
    }
}
