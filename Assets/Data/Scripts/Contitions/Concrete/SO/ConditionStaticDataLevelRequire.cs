using UnityEngine;

namespace DontStopTheTrain
{
    [CreateAssetMenu(fileName = "LevelRequire", menuName = "DST/Conditions/LevelRequire")]
    public class ConditionStaticDataLevelRequire : ConditionBase, IConditionLevelRequireStaticData
    {
        public override ConditionType Type => ConditionType.LevelRequire;

        public int LevelMin => _levelMin;
        public int LevelMax => _levelMax;


        [SerializeField]
        private int _levelMin;
        [SerializeField]
        private int _levelMax;

        private void OnValidate()
        {

            if (_levelMin < 1)
            {
                _levelMin = 1;
            }

            if (_levelMax < 1)
            {
                _levelMax = 1;
            }
            if (_levelMin > _levelMax)
            {
                _levelMax++;
            }
        }

        public bool IsMet(int level)
        {
            return level >= LevelMin && level <= LevelMax;
        }
    }
}
