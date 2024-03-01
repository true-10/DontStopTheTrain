using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Zenject;

namespace DontStopTheTrain.Events
{
    public sealed class EventController
    {
        [Inject]
        private EventInitDataManager _eventInitDataManager;

        public Action<IEvent> OnStart { get; set; }
        public Action<IEvent> OnComplete { get; set; }

        public void StartEvent(IEvent gameEvent)
        {
            var initData = _eventInitDataManager.GetInitData(gameEvent);
            StartEvent(gameEvent, initData);
        }      
        
        public void StartEvent(IEvent gameEvent, IEventInitData initData)
        {
            gameEvent.Initialize(initData);
            gameEvent.OnComplete += OnEventComplete;
            OnStart?.Invoke(gameEvent);
        }

        private void OnEventComplete(IEvent gameEvent)
        {
            OnComplete?.Invoke(gameEvent);
            gameEvent.OnComplete -= OnEventComplete;
        }
    }

    public sealed class EventStarter : IInitializable, IDisposable
    {
        [Inject]
        private TurnBasedController _turnBasedController;
        [Inject]
        private Player _player;
        [Inject]
        private EventController _eventController;
        [Inject]
        private EventGenerator _eventGenerator;

        private int _playerLevel => _player.Level.Value;

        public void Initialize()
        {
            _turnBasedController.OnTurnStart += TryToStartEvents;
        }


        public void Dispose()
        {
            _turnBasedController.OnTurnStart -= TryToStartEvents;
        }

        private void TryToStartEvents(ITurnCallback callback)
        {
            var events = _eventGenerator.GetEvents(_playerLevel, 3);

            foreach (var eventToStart in events)
            {
                _eventController.StartEvent(eventToStart);
            }
        }

    }
    public sealed class EventGenerator
    {
        public IEvent GetEvent(int level)
        {
            return null;
        }

        public List<IEvent> GetEvents(int level, int count)
        {
            return null;
        }
    }
}

