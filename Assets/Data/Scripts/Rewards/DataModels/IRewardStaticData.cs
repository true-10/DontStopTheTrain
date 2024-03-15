namespace DontStopTheTrain
{
    public interface IRewardStaticData
    {
        RewardId RewardId { get; }
        ItemId ItemId { get; }
        int Count { get;}
    }
}
