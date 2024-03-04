using System;
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

    public class WagonEventViewer : AbstractEventViewer
    {
        public override EventType Type => EventType.Wagon;

        protected override void OnCompleteEvent(IEvent @event)
        {
            throw new NotImplementedException();
        }

        protected override void OnStartEvent(IEvent @event)
        {
            throw new NotImplementedException();
        }
    }
}
