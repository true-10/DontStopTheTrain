using Zenject;

namespace DontStopTheTrain
{
    public sealed class ConditionFabric: IFabric<ICondition, IConditionStaticData>
    {
        [Inject]
        private Inventory _inventory;
        [Inject]
        private Player _player;

        public ICondition Create(IConditionStaticData staticData)
        {
            switch (staticData.Type)
            {
                case ConditionType.ResourceRequire:                    
                    return new ConditionResourceRequire(staticData as IConditionResourceRequireStaticData, _inventory);
                case ConditionType.LevelRequire:                    
                    return new ConditionLevelRequire(staticData as IConditionLevelRequireStaticData, _player);
                case ConditionType.PerkRequire:
                //case ConditionType.:

                default:
                    UnityEngine.Debug.Log($"The type [{staticData.Type}] is not found");
                    return null;

            }
        }
    }
}

