﻿using Zenject;

namespace DontStopTheTrain
{
    public class PerksFabric : IFabric<IPerk, IPerkStaticData>
    {
        [Inject]
        private Inventory _inventory;
        [Inject]
        private Player _player;

        public IPerk Create(IPerkStaticData staticData)
        {
            return new Perk(staticData);

            switch (staticData.Type)
            {
                case PerkType.ActionPoint:
                case PerkType.Experience:
                case PerkType.Credits:
                case PerkType.Score:
                case PerkType.Seller:
                    return new Perk(staticData);
                default:
                    UnityEngine.Debug.Log($"The type [{staticData.Type}] is not found");
                    return null;

            }
        }
    }
}