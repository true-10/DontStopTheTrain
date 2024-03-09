using System;
using UnityEngine;
using Zenject;

namespace DontStopTheTrain.Events
{
    public abstract class AbstractEventViewer : MonoBehaviour
    {
        public Action<IEvent> OnSetEvent { get; set; }
        public virtual EventType Type => EventType.None;

        public bool IsFree => _eventData == null;

        [Inject]
        private EventController _eventController;
        [Inject]
        private EventViewersManager _eventViewersManager;

        protected IEvent _eventData;

        public bool TryToSetEventData(IEvent eventData)
        {
            if (IsFree == false)
            {
                return false;
            }
            _eventData = eventData;
            OnSetEvent?.Invoke(eventData);
            return true;
        }

        public void RemoveEventData()
        {
            _eventData = null;
        }

        protected abstract void OnStartEvent(IEvent eventData);
        protected abstract void OnCompleteEvent(IEvent eventData);

        private void Start()
        {
            _eventViewersManager.TryToAddViewer(this);
            _eventController.OnStart += OnStartEvent;
            _eventController.OnComplete += OnCompleteEvent;
        }

        private void OnDestroy()
        {
            _eventViewersManager.TryToRemoveViewer(this);
            _eventController.OnStart -= OnStartEvent;
            _eventController.OnComplete -= OnCompleteEvent;
        }

    }
}
