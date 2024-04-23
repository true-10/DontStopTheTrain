namespace DontStopTheTrain
{
    public interface IConditionResourceRequireStaticData : IConditionStaticData
    {
        ItemId ResourceId { get; }
        int Count { get; }
    }
}
