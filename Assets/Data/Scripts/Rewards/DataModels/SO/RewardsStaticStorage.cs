using System.Linq;
using True10.StaticData;
using UnityEngine;

namespace DontStopTheTrain.Events
{
    [CreateAssetMenu(fileName = "RewardsStorage", menuName = "DST/Events/Rewards/Storage", order = 0)]
    public sealed class RewardsStaticStorage : StaticStorage<RewardStaticData>
    {
    }
}
