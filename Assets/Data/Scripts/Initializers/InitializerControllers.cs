using DontStopTheTrain.Events;
using UnityEngine;
using Zenject;

namespace DontStopTheTrain
{
    public class InitializerControllers : MonoBehaviour
    {
        [Inject]
        private Inventory _inventory;
        [Inject]
        private Player _player;
        [Inject]
        private RewardController _rewardController;
        [Inject]
        private EventStarter _eventStarter;
        [Inject]
        private PerkController _perkController;

        [SerializeField]
        private InventoryStarterPackStorage _inventoryStartItemsStorage;

        public void Initialize()
        {
            _perkController.Initialize();
            _player.Initialize();
            _rewardController.Initialize();
            _inventory.Initialize(_inventoryStartItemsStorage.GetStartItems());

            _eventStarter.Initialize();
        }

        public void Dispose()
        {
            _player.Dispose();
            _rewardController.Dispose();
            //_inventory.Dispose();

            _eventStarter.Dispose();
            _perkController.Dispose();
        }
    }
}