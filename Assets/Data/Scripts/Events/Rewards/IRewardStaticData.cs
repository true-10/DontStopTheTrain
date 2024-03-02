using UnityEngine;

namespace DontStopTheTrain.Events
{
    public interface IRewardStaticData
    {
        ItemId ItemId { get; }
        int Count { get;}
    }
}
