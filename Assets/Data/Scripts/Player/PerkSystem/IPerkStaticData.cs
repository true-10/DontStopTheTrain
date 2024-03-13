using System.Collections.Generic;

namespace DontStopTheTrain
{
    public interface IPerkStaticData
    {
        PerkType Type { get; }
        int Value { get; }
        IReadOnlyCollection<IConditionStaticData> UnlockConditions { get; }
        IReadOnlyCollection<InventoryItem> UpgradePrice { get; }

        Information Info { get; }

    }
}
