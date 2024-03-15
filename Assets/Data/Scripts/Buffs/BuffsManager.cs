using True10.Managers;
using Zenject;

namespace DontStopTheTrain
{
    public sealed class BuffsManager : DataManager<IBuff>
    {
        [Inject]
        private BuffFabric _fabric;
        [Inject]
        private BuffsStaticStorage _staticManager;
        [Inject]
        private PlayerBuffsManager _playerBuffsManager;

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

        public void Activate(IBuff buff)
        {
            _playerBuffsManager.TryToAdd(buff);
            buff.Activate();
        }

    }
}
