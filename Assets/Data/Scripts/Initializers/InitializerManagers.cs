using Zenject;
using UnityEngine;

namespace DontStopTheTrain
{
    public class InitializerManagers : MonoBehaviour
    {
        [Inject]
        private ConditionsManager _conditionsManager;
        [Inject]
        private PerksManager _perkManager;
        [Inject]
        private PlayerPerksManager _playerPerksManager;

        public void Initialize()
        {
            _conditionsManager.Initialize();
            _perkManager.Initialize();
            _playerPerksManager.Initialize();
        }

        public void Dispose()
        {
            _conditionsManager.Dispose();
            _playerPerksManager.Dispose();
            _perkManager.Dispose();

        }
    }
}
