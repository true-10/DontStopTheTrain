using True10.Managers;
using Zenject;

namespace DontStopTheTrain
{
    public sealed class PlayerPerksManager : DataManager<IPerk>
    {
        [Inject]
        private PerksFabric _fabric;

        public override bool TryToAdd(IPerk newPerk)
        {
           // var newPerk = _fabric.Create(newItem.StaticData);
            _items.Add(newPerk);
            OnItemAdded?.Invoke(newPerk);
            return true;
        }

        public override bool TryToRemove(IPerk itemToRemove)
        {
            _items.Remove(itemToRemove);
            OnItemRemoved?.Invoke(itemToRemove);
            return true;
        }
        public override void Dispose()
        {
            Clear();
        }

        public override void Initialize()
        {

        }
    }
}
