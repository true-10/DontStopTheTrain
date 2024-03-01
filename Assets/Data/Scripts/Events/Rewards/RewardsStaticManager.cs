using System.Collections.Generic;
using True10.StaticData;
using UnityEngine;

namespace DontStopTheTrain.Events
{
    public sealed class RewardsStaticManager
    {
        public IReadOnlyCollection<IRewardStaticData> RewardsStaticData { get; private set; }

        public void Initialize()
        {
            var data = StaticDataLoader<RewardsStaticStorage>.LoadStaticData(Constants.StaticDataPaths.REWARDS_PATH);
            RewardsStaticData = data.Datas;
        }
    }
}