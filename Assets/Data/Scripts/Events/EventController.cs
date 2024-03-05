using System;
using System.Collections;
using System.Collections.Generic;
using Zenject;

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

    public sealed class EventGenerator
    {
        [Inject]
        private EventsStaticManager _eventsStaticManager;
        [Inject]
        private EventsManager _eventsManager;
        [Inject]
        private EventFabric _eventsFabric;
        [Inject]
        private Train.Train _train;

        public IEvent GetEvent(int level)
        {
            return null;
        }

        public List<IEvent> GetEvents(int level, int count)
        {
            //берем события по уровню
            //смотрим какие можем стартануть
            return null;
        }
    }
}

