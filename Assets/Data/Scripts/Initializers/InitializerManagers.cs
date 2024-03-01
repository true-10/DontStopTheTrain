using Zenject;
using UnityEngine;
using DontStopTheTrain.Events;

namespace DontStopTheTrain
{

    public class InitializerManagers : MonoBehaviour
    {
        [Inject]
        private EventInitDataManager _eventDataManager;
        [Inject]
        private EventsManager _eventsManager;

        public void Initialize()
        {
            // _rewardsStaticManager.Initialize();
            //_eventsStaticManager.Initialize();
        }
    }
}
