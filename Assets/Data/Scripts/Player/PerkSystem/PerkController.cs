using DontStopTheTrain.Events;
using System.Linq;
using Zenject;

namespace DontStopTheTrain
{
    public sealed class PerkController
    {
        [Inject]
        private PerksFabric _perkFabric;
        [Inject]
        private PerkManager _perkManager;


        public void Initialize()
        {
        }

        public void Dispose()
        {
        }

        public int GetValue(PerkType perkType)
        {
            var perks = _perkManager.Perks
                .Where(perk => perk.StaticData.Type == perkType)
                .ToList();

            if (perks.Count == 0)
            {
                return 0;
            }

            return perks.Sum(perk => perk.Value);
        }
    }

    public sealed class PerkUpgrader
    {
        [Inject]
        private Inventory _inventory;

        public bool TryToUpgrade(IPerk perkToUpgrade)
        {
            return false;
        }
    }

    public sealed class PerkService
    {
        [Inject]
        private Inventory _inventory;

        public bool IsReadyToUpgrade(IPerk perkToUpgrade)
        {
            var conditions = perkToUpgrade.StaticData.UnlockConditions;
            //if (conditions.All(condition => condition.IsMet()))
            {
                return true;
            }
            return false;
        }
    }
    public sealed class PerkGiver
    {

    }
}
