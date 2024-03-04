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

        [SerializeField]
        private InventoryStarterPackStorage _inventoryStartItemsStorage;

        public void Initialize()
        {
            _player.Initialize();
            _rewardController.Initialize();
            _inventory.Initialize(_inventoryStartItemsStorage.GetStartItems());

            _eventStarter.Initialize();
        }
    }
}