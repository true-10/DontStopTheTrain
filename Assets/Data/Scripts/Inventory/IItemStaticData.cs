using True10.StaticData;

namespace DontStopTheTrain
{
    public interface IItemStaticData
    {
        ItemId Id { get; }
        ItemType Type { get; }
        public Information Info { get; }
        bool IsVisible { get;}
    }
}
