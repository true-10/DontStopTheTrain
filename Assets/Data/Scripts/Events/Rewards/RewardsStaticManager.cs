using True10.StaticData;

namespace DontStopTheTrain.Events
{
    public sealed class RewardsStaticManager : StaticManager<IRewardStaticData>
    {
        public override void Initialize()
        {
            var data = StaticDataLoader<RewardsStaticStorage>.LoadStaticData(Constants.StaticDataPaths.REWARDS_PATH);
            Datas = data.Datas;
        }
    }
}