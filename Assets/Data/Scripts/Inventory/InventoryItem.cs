using System;

namespace DontStopTheTrain
{
    [Serializable]
    public sealed class InventoryItem
    {
        public IItemStaticData StaticData { get; private set; }
        public int Count { get; private set; }

        public InventoryItem(IItemStaticData staticData, int count)
        {
            StaticData = staticData;
            Count = count;
        }
    }

}
