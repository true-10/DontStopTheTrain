using System;
using UnityEngine;
using Zenject;

namespace DontStopTheTrain.Events
{
    public sealed class EventStarter : IInitializable, IDisposable
    {
        [Inject]
        private TurnBasedController _turnBasedController;
        //[Inject]
        //private Player _player;
        [Inject]
        private EventController _eventController;
        [Inject]
        private EventGenerator _eventGenerator;

      // private int _playerLevel => _player.Level.Value;

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
            if (callback.Number < 2)
            {
                return;
            }
            var events = _eventGenerator.GetEvents(3);
            if (events.Count == 0)
            {
                Debug.Log($"No Events To Start");
            }
            foreach (var eventToStart in events)
            {
                _eventController.StartEvent(eventToStart);
            }
        }

    }
}

