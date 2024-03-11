using UnityEngine;

namespace DontStopTheTrain
{
    [CreateAssetMenu(fileName = "LevelStaticData", menuName = "DST/Player/Levels/LevelStaticData")]
    public class LevelStaticData : ScriptableObject
    {
        public int Level => _level;
        public int Expo => _exp;

        [SerializeField, Min(0)]
        private int _level;
        [SerializeField, Min(0)]
        private int _exp;
    }
}
