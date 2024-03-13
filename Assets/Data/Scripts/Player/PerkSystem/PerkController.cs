using DontStopTheTrain.Events;
using System.Collections.Generic;
using System.Linq;
using Zenject;

namespace DontStopTheTrain
{
    public sealed class PerkController
    {
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
            var perks = _perkManager.Items
                .Where(perk => perk.StaticData.Type == perkType)
                .Where(perk => perk.AvailableForPlayer)
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
        [Inject]
        private PerksStaticManager _perkStaticManager;
        [Inject]
        private ConditionFabric _conditionFabric;

        public bool IsReadyToUpgrade(IPerk perkToUpgrade)
        {
            var conditions = perkToUpgrade.StaticData.UnlockConditions;
            //if (conditions.All(condition => condition.IsMet()))
            {
                return true;
            }
            return false;
        }

        public List<IPerkStaticData> GettAvailablePerks()
        {
            return null;
        }
    }
    public sealed class PerkGiver
    {

    }
}
