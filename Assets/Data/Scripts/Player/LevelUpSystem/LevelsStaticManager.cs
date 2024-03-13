using System.Linq;
using True10.StaticData;

namespace DontStopTheTrain
{
    public sealed class LevelsStaticManager : StaticManager<LevelStaticData>
    {
        public override void Initialize()
        {
            var data = StaticDataLoader<LevelsStaticStorage>.LoadStaticData(Constants.StaticDataPaths.LEVELS_PATH);
            Datas = data.Datas.OrderByDescending(x => x.Expo).ToList() ;
            
        }
    }
}
