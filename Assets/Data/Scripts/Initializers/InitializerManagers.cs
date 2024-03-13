using Zenject;
using UnityEngine;

namespace DontStopTheTrain
{
    public class InitializerManagers : MonoBehaviour
    {
        [Inject]
        private ConditionsManager _conditionsManager;
        [Inject]
        private PerkManager _perkManager;

        public void Initialize()
        {
            _conditionsManager.Initialize();
            _perkManager.Initialize();
        }

        public void Dispose()
        {
            _conditionsManager.Dispose();
            _perkManager.Dispose();

        }
    }
}
