using System;
using True10.Interfaces;
using UnityEngine;
using Zenject;

namespace DontStopTheTrain.Events
{
    public interface IEventViewer
    {
        IEvent ActiveEvent { get; }
        Action<IEvent> OnSetEvent { get; set; }
        bool IsFree { get; }
        bool TryToSetEventData(IEvent eventData);
    }

    public abstract class AbstractEventViewer : MonoBehaviour, IEventViewer, IGameLifeCycle
    {
        public IEvent ActiveEvent => _eventData;
        public Action<IEvent> OnSetEvent { get; set; }
        public virtual EventType Type => EventType.None;
        public bool IsFree => _eventData == null;

        protected IEvent _eventData;
        [Inject]
        private EventController _eventController;
        [Inject]
        private EventViewersManager _eventViewersManager;

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
            OnSetEvent?.Invoke(null);
        }

        public void Initialize()
        {
            _eventViewersManager.TryToAdd(this);
            _eventController.OnStart += OnStartEvent;
            _eventController.OnComplete += OnCompleteEvent;
        }

        public void Dispose()
        {
            _eventViewersManager.TryToRemove(this);
            _eventController.OnStart -= OnStartEvent;
            _eventController.OnComplete -= OnCompleteEvent;
        }

        protected abstract void OnStartEvent(IEvent eventData);
        protected abstract void OnCompleteEvent(IEvent eventData);

        private void Start()
        {
            Initialize();
        }

        private void OnDestroy()
        {
            Dispose();
        }
    }
}
