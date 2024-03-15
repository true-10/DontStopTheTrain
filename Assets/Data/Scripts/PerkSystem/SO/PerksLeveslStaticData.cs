using System.Collections.Generic;
using UnityEngine;

namespace DontStopTheTrain
{
    [CreateAssetMenu(fileName = "PerkLevelStaticData", menuName = "DST/Player/Levels/PerkLevelStaticData")]
    public class PerksLeveslStaticData : ScriptableObject
    {
        public List<int> Levels => _levels;

        [SerializeField, Min(0)]
        private List<int> _levels;
    }
}
