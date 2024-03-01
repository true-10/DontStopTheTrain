namespace DontStopTheTrain.Events
{
    public interface IConditionResourceRequireStaticData : IConditionStaticData
    {
        int ResourceId { get; }

        int Count { get; }
    }
}
