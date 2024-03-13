using System.Collections.Generic;
using System.Linq;
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

        public List<ICondition> GetConditions(IReadOnlyCollection<IConditionStaticData> staticConditions)
        {
            var conditions = new List<ICondition>();
            foreach(var conditionStatic in staticConditions)
            {
                var condition = Items.FirstOrDefault(c => c.StaticData.HashCode == conditionStatic.HashCode);
                if (condition != null)
                {
                    conditions.Add(condition);
                }
            }
            return conditions;

        }
    }
}

