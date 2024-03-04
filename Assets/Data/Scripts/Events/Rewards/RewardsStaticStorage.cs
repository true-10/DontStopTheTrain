using System.Linq;
using True10.StaticData;
using UnityEngine;

namespace DontStopTheTrain.Events
{
    [CreateAssetMenu(fileName = "RewardsStorage", menuName = "DST/Events/Rewards/Storage")]
    public sealed class RewardsStaticStorage : StaticStorage<RewardStaticData>
    {

        /*
        private void OnValidate()
        {
            _datas = FindObjectsByType<RewardStaticData>().ToList();
        }*/
    }
}
