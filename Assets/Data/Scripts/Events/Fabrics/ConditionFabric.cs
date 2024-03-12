using Zenject;

namespace DontStopTheTrain
{
    public class ConditionFabric
    {
        [Inject]
        private Inventory _inventory;
        [Inject]
        private Player _player;

        public ICondition GetCondition(IConditionStaticData staticData)
        {
            switch (staticData.Type)
            {
                case ConditionType.ResourceRequire:                    
                    return new ConditionResourceRequire(staticData as IConditionResourceRequireStaticData, _inventory);
                case ConditionType.LevelRequire:                    
                    return new ConditionLevelRequire(staticData as IConditionLevelRequireStaticData, _player);
                case ConditionType.PerkRequire:

                default:
                    UnityEngine.Debug.Log($"The type [{staticData.Type}] is not found");
                    return null;

            }
        }
    }
}

