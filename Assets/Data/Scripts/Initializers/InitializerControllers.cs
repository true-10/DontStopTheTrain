using DontStopTheTrain.Events;
using True10.CameraSystem;
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
        private PerksController _perkController;
        [Inject]
        private BuffsController _buffsController;
        [Inject]
        private ICameraController _cameraController;
        [Inject]
        private BuffAndPerksService _buffAndPerksService;

        [SerializeField]
        private InventoryStarterPackStorage _inventoryStartItemsStorage;
        [SerializeField]
        private CameraHolder _defaultCameraHolder;

        public void Initialize()
        {
            _perkController.Initialize();
            _buffsController.Initialize();
            _buffAndPerksService.Initialize();
            _player.Initialize();
            _rewardController.Initialize();
            _inventory.Initialize(_inventoryStartItemsStorage.GetStartItems());

            _eventStarter.Initialize();
            _cameraController.SetDefaultCamera(_defaultCameraHolder);
        }

        public void Dispose()
        {
            _player.Dispose();
            _rewardController.Dispose();
            //_inventory.Dispose();

            _eventStarter.Dispose();
            _perkController.Dispose();
            _buffsController.Dispose();
            _buffAndPerksService.Dispose();
        }
    }
}