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

        [SerializeField]
        private InventoryStarterPackStorage _inventoryStartItemsStorage;

        public void Initialize()
        {
            _player.Initialize();
            _inventory.Initialize(_inventoryStartItemsStorage.GetStartItems());
        }
    }
}