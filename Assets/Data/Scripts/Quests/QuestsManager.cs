using True10.Managers;
using Zenject;

namespace DontStopTheTrain
{
    public sealed class QuestsManager : DataManager<IQuest>
    {
        [Inject]
        private QuestsFabric _fabric;
        [Inject]
        private QuestStaticManager _staticManager;

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