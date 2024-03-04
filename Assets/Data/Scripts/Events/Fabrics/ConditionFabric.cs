using Zenject;

namespace DontStopTheTrain.Events
{
    public class ConditionFabric
    {
        [Inject]
        private Inventory _inventory;

        public ICondition GetCondition(IConditionStaticData staticData)
        {
            switch (staticData.Type)
            {
                case ConditionType.ResourceRequire:                    
                    return new ConditionResourceRequire(staticData as IConditionResourceRequireStaticData, _inventory);
                default: 
                    return null;

            }
        }
    }
}

