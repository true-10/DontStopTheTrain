using True10.Managers;
using Zenject;

namespace DontStopTheTrain
{
    public sealed class PerkManager : DataManager<IPerk>
    {
        [Inject]
        private PerksFabric _fabric;
        [Inject]
        private PerksStaticManager _staticManager;

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
    }
}
