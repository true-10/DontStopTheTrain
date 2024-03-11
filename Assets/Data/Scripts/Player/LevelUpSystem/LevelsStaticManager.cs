using System.Collections.Generic;
using System.Linq;
using True10.StaticData;

namespace DontStopTheTrain
{
    public sealed class LevelsStaticManager
    {
        public IReadOnlyCollection<LevelStaticData> LevelsStaticDatas { get; private set; }

        public void Initialize()
        {
            var data = StaticDataLoader<LevelsStaticStorage>.LoadStaticData(Constants.StaticDataPaths.LEVELS_PATH);
            LevelsStaticDatas = data.Datas.OrderByDescending(x => x.Expo).ToList() ;
            
        }
    }
}
