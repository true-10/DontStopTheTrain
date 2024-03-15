using System;
using Zenject;

namespace DontStopTheTrain
{
    public sealed class BuffAndPerksService
    {
        public Action OnChange { get; set; }
        [Inject]
        private PerksController _perksController;
        [Inject]
        private BuffsController _buffsController;
        [Inject]
        private PlayerPerksManager _playerPerksManager;
        [Inject]
        private PlayerBuffsManager _playerBuffssManager;

        public void Initialize()
        {
            _playerPerksManager.OnItemAdded += OnPerksChanged;
            _playerPerksManager.OnItemRemoved += OnPerksChanged;
            _playerBuffssManager.OnItemAdded += OnBuffsChanged;
            _playerBuffssManager.OnItemRemoved += OnBuffsChanged;
        }


        public void Dispose()
        {
            _playerPerksManager.OnItemAdded -= OnPerksChanged;
            _playerPerksManager.OnItemRemoved -= OnPerksChanged;
            _playerBuffssManager.OnItemAdded -= OnBuffsChanged;
            _playerBuffssManager.OnItemRemoved -= OnBuffsChanged;
        }

        public int GetValue(PerkType perkType)
        {
            var perksValue = _perksController.GetValue(perkType);
            var buffsValue = _buffsController.GetValue(perkType);

            return perksValue + buffsValue;
        }

        private void OnBuffsChanged(IBuff buff)
        {
            OnChange?.Invoke();
        }

        private void OnPerksChanged(IPerk perk)
        {
            OnChange?.Invoke();
        }
    }
}
