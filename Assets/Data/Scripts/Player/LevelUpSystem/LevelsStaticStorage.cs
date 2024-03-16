using System.Linq;
using True10.StaticData;
using UnityEngine;

namespace DontStopTheTrain
{
    [CreateAssetMenu(fileName = "LevelsStorage", menuName = "DST/Player/Levels/LevelsStorage", order = 0)]
    public sealed class LevelsStaticStorage : StaticStorage<LevelStaticData>
    {
        private void OnValidate()
        {
            _datas = _datas.OrderByDescending(item => item.Level).ToList();
        }
    }

}
