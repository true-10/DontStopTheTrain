namespace DontStopTheTrain
{
    public interface ICondition
    {
        IConditionStaticData StaticData { get; }
        bool IsMet();
    }
}
