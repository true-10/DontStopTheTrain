using DontStopTheTrain.Events;

namespace DontStopTheTrain
{
    public interface IPerk
    {
        int Value { get; }
        int Level { get; }
        IPerkStaticData StaticData { get; }
    }
}
