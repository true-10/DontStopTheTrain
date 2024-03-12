using System;
using System.Collections.Generic;

namespace DontStopTheTrain
{
    public sealed class PerkManager
    {
        public Action<IPerk> OnPerkAdded { get; set; }
        public Action<IPerk> OnPerkRemoved { get; set; }

        public IReadOnlyCollection<IPerk> Perks => _perks;

        private List<IPerk> _perks = new();

        public void Add(IPerk newPerk)
        {
            if (_perks.Contains(newPerk))
            {
                UnityEngine.Debug.Log($"Perk already added ");
                return;
            }
            _perks.Add(newPerk);
            OnPerkAdded?.Invoke(newPerk);
        }

        public void Remove(IPerk perkToRemove)
        {
            if (_perks.Contains(perkToRemove))
            {
                return;
            }
            _perks.Remove(perkToRemove);
            OnPerkRemoved?.Invoke(perkToRemove);
        }
    }
}
