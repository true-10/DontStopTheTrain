using True10.Managers;
using Zenject;

namespace DontStopTheTrain
{
    public sealed class ConditionsManager : DataManager<ICondition>
    {
        [Inject]
        private ConditionStaticManager _staticManager;
        [Inject]
        private ConditionFabric _fabric;

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

