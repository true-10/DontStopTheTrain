using Zenject;
using UnityEngine;
using DontStopTheTrain.Events;

namespace DontStopTheTrain
{

    public class InitializerManagers : MonoBehaviour
    {
        [Inject]
        private EventsManager _eventsManager;

        public void Initialize()
        {

        }

        public void Dispose()
        {

        }
    }
}
