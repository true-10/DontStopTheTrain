using System.Linq;
using True10.Managers;
using Zenject;

namespace DontStopTheTrain
{
    public sealed class PerksManager : DataManager<IPerk>
    {
        [Inject]
        private PerksFabric _fabric;
        [Inject]
        private PerksStaticStorage _staticManager;
        [Inject]
        private PlayerPerksManager _playerPerksManager;

        public override void Initialize()
        {
            var staticDatas = _staticManager.Datas;
            foreach (var staticData in staticDatas)
            {
                var item = _fabric.Create(staticData);
                TryToAdd(item);
            }
        }

        public override void Dispose()
        {
            Clear();
        }       

        public void SetPerkAvailable(IPerk perk)
        {
            _playerPerksManager.TryToAdd(perk);
        }
    }
}
