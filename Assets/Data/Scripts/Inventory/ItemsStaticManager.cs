using True10.StaticData;

namespace DontStopTheTrain
{
    public sealed class ItemsStaticManager: StaticManager<IItemStaticData>
    {
        public override void Initialize()
        {
            var data = StaticDataLoader<ItemsStaticStorage>.LoadStaticData(Constants.StaticDataPaths.ITEMS_PATH);
            Datas = data.Datas;
        }
    }
}
