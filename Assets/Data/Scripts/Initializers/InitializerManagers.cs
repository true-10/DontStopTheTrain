using Zenject;
using UnityEngine;
using DontStopTheTrain.Events;

namespace DontStopTheTrain
{
    public class InitializerManagers : MonoBehaviour
    {
        [Inject]
        private EventsManager _eventsManager;
        [Inject]
        private ConditionsManager _conditionsManager;
        [Inject]
        private PerksManager _perkManager;
        [Inject]
        private BuffsManager _buffsManager;
        [Inject]
        private PlayerPerksManager _playerPerksManager;
        [Inject]
        private PlayerBuffsManager _playerBuffsManager;

        public void Initialize()
        {
            _eventsManager.Initialize();
            _conditionsManager.Initialize();
            _perkManager.Initialize();
            _buffsManager.Initialize();
            _playerPerksManager.Initialize();
            _playerBuffsManager.Initialize();
        }

        public void Dispose()
        {
            _eventsManager.Dispose();
            _conditionsManager.Dispose();
            _playerPerksManager.Dispose();
            _playerBuffsManager.Dispose();
            _perkManager.Dispose();
            _buffsManager.Dispose();

        }
    }
}
