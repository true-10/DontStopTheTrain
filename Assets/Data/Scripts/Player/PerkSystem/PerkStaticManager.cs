using System.Collections.Generic;
using True10.StaticData;

namespace DontStopTheTrain
{
    public sealed class PerkStaticManager
    {
        public IReadOnlyCollection<IPerkStaticData> ItemStaticDatas { get; private set; }

        public void Initialize()
        {
            var data = StaticDataLoader<PerksStaticStorage>.LoadStaticData(Constants.StaticDataPaths.PERKS_PATH);
            ItemStaticDatas = data.Datas;
        }
    }
}
