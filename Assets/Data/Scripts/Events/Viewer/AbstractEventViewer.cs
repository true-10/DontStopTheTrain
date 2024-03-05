using UnityEngine;
using Zenject;

namespace DontStopTheTrain.Events
{
    public abstract class AbstractEventViewer : MonoBehaviour
    {
        public virtual EventType Type => EventType.None;

        [Inject]
        private EventController _eventController;

        private void Start()
        {
            _eventController.OnStart += OnStartEvent;
            _eventController.OnComplete += OnCompleteEvent;
        }

        private void OnDestroy()
        {
            _eventController.OnStart -= OnStartEvent;
            _eventController.OnComplete -= OnCompleteEvent;
        }

        protected abstract void OnStartEvent(IEvent @event);

        protected abstract void OnCompleteEvent(IEvent @event);
    }
}
