using True10.Managers;

namespace DontStopTheTrain
{
    public sealed class PlayerBuffsManager : DataManager<IBuff>
    {
        public override bool TryToAdd(IBuff newBuff)
        {
            _items.Add(newBuff);
            OnItemAdded?.Invoke(newBuff);
            return true;
        }

        public override bool TryToRemove(IBuff itemToRemove)
        {
            _items.Remove(itemToRemove);
            OnItemRemoved?.Invoke(itemToRemove);
            return true;
        }
        public override void Dispose()
        {
            _items.Clear();
            _items = null;
        }

        public override void Initialize()
        {

        }
    }
}
