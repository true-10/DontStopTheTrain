using DontStopTheTrain.Events;
using True10.CameraSystem;
using True10.Interfaces;
using UnityEngine;
using Zenject;

namespace DontStopTheTrain
{
    public class InitializerControllers : MonoBehaviour, IGameLifeCycle
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
        private CameraSwitcher _cameraSwitcher;
        [Inject]
        private BuffAndPerksService _buffAndPerksService;
        [Inject]
        private EventObjectsController _eventObjectsController;
        [Inject]
        private PointOfInterestController _poiController;

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
            _eventObjectsController.Initialize();
            _cameraSwitcher.Initialize();
            _cameraController.SetDefaultCamera(_defaultCameraHolder);

            _poiController.Initialize();
        }

        public void Dispose()
        {
            _player.Dispose();
            _rewardController.Dispose();
            //_inventory.Dispose();

            _eventObjectsController.Dispose();
            _eventStarter.Dispose();
            _perkController.Dispose();
            _buffsController.Dispose();
            _buffAndPerksService.Dispose();
            _cameraSwitcher.Dispose();

            _poiController.Dispose();
        }
    }
}