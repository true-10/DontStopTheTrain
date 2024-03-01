using UnityEngine;

namespace DontStopTheTrain.Events
{
    public interface IRewardStaticData
    {
        int ItemId { get; }
        int Count { get;}
        bool IsVisible { get;}
        Sprite Icon { get; }
    }
}
