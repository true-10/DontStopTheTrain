using DontStopTheTrain.Events;
using System.Collections.Generic;
using System.Linq;
using Zenject;

namespace DontStopTheTrain
{
    public sealed class ConditionService
    {

        public bool IsMet(IConditionStaticData conditionStaticData)
        {
            var conditions = new List<ICondition>();
            return conditions.All(condition => condition.IsMet());
        }
    }
}

