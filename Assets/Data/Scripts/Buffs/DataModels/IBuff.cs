namespace DontStopTheTrain
{
    public interface IBuff
    {
        int Value { get; }
        IBuffStaticData StaticData { get; }
        AcitveStatus Status { get; }
        void Activate(int currenDay);
    }

    public enum AcitveStatus
    {
        Inactive = 0,
        Active = 1
    }
}
