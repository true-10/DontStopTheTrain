using True10.StaticData;

namespace DontStopTheTrain
{
    public sealed class PerksStaticManager : StaticManager<IPerkStaticData>
    {
        public override void Initialize()
        {
            var data = StaticDataLoader<PerksStaticStorage>.LoadStaticData(Constants.StaticDataPaths.PERKS_PATH);
            Datas = data.Datas;
        }
    }
}
