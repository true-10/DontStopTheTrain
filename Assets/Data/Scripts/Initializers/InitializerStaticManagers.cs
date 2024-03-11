using Zenject;
using UnityEngine;
using DontStopTheTrain.Events;

namespace DontStopTheTrain
{
    public class InitializerStaticManagers : MonoBehaviour
    {
        [Inject]
        private ItemsStaticManager _itemsStaticManager;
        [Inject]
        private RewardsStaticManager _rewardsStaticManager;
        [Inject]
        private EventsStaticManager _eventsStaticManager;
        [Inject]
        private LevelsStaticManager _levelsStaticManager;
        [Inject]
        private PerkStaticManager _perkStaticManager;

        public void Initialize()
        {
            _itemsStaticManager.Initialize();
            _rewardsStaticManager.Initialize();
            _eventsStaticManager.Initialize();
            _levelsStaticManager.Initialize();
            _perkStaticManager.Initialize();
        }

        public void Dispose()
        {
            //_itemsStaticManager.Dispose();
            //_rewardsStaticManager.Dispose();
            //_eventsStaticManager.Dispose();
            //_levelsStaticManager.Dispose();
            //_perkStaticManager.Dispose();
        }
    }

}
