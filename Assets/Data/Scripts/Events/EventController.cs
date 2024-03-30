using System;
using System.Collections;

namespace DontStopTheTrain.Events
{
    public sealed class EventController
    {
        public Action<IEvent> OnStart { get; set; }
        public Action<IEvent> OnComplete { get; set; }
        public Action<IEvent> OnFocus { get; set; }

        public void Start(IEvent gameEvent)
        {
            gameEvent.Start();
            gameEvent.OnComplete += OnEventComplete;
            gameEvent.OnFocus += OnFocusEvent;
            OnStart?.Invoke(gameEvent);
        }      

        private void OnEventComplete(IEvent gameEvent)
        {
            OnComplete?.Invoke(gameEvent);
            gameEvent.OnComplete -= OnEventComplete;
            gameEvent.OnFocus -= OnFocusEvent;
        }

        private void OnFocusEvent(IEvent gameEvent)
        {
            OnFocus?.Invoke(gameEvent);
        }
    }
}

