using DontStopTheTrain.Events;
using System.Collections.Generic;
using System.Linq;
using Zenject;

namespace DontStopTheTrain
{
    public sealed class ConditionService
    {
        [Inject]
        private ConditionFabric _conditionFabric;

        public bool IsMet(IConditionStaticData conditionStaticData)
        {
            var conditions = new List<ICondition>();
            return conditions.All(condition => condition.IsMet());
        }
    }
}

