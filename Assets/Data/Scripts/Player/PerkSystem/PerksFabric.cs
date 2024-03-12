using Zenject;

namespace DontStopTheTrain
{
    public class PerksFabric
    {
        [Inject]
        private Inventory _inventory;
        [Inject]
        private Player _player;

        public IPerk GetPerk(IPerkStaticData staticData)
        {
            switch (staticData.Type)
            {
                case PerkType.ActionPoint:
                //  return new ConditionResourceRequire(staticData as IConditionResourceRequireStaticData, _inventory);
                case PerkType.Experience:
                case PerkType.Credits:
                case PerkType.Score:
                case PerkType.Seller:
                default:
                    UnityEngine.Debug.Log($"The type [{staticData.Type}] is not found");
                    return null;

            }
        }
    }
}
