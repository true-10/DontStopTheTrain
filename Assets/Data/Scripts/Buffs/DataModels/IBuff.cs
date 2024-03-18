using True10.Enums;

namespace DontStopTheTrain
{
    public interface IBuff
    {
        int Value { get; }
        IBuffStaticData StaticData { get; }
        ActiveStatus Status { get; }
        void Activate();
    }
}
