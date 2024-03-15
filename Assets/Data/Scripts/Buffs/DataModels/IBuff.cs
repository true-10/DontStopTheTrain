using True10.Enums;

namespace DontStopTheTrain
{
    public interface IBuff
    {
        int Value { get; }
        IBuffStaticData StaticData { get; }
        AcitveStatus Status { get; }
        void Activate();
    }
}
