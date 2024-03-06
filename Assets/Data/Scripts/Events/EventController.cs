using System;
using System.Collections;

namespace DontStopTheTrain.Events
{
    public sealed class EventController
    {
        public Action<IEvent> OnStart { get; set; }
        public Action<IEvent> OnComplete { get; set; }

        public void StartEvent(IEvent gameEvent)
        {
            gameEvent.Initialize();
            gameEvent.OnComplete += OnEventComplete;
            OnStart?.Invoke(gameEvent);
        }      

        private void OnEventComplete(IEvent gameEvent)
        {
            OnComplete?.Invoke(gameEvent);
            gameEvent.OnComplete -= OnEventComplete;
        }
    }
}

