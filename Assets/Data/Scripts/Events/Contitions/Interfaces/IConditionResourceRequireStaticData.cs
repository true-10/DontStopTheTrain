namespace DontStopTheTrain.Events
{
    public interface IConditionResourceRequireStaticData : IConditionStaticData
    {
        ItemId ResourceId { get; }
        int Count { get; }
    }
}
