using System;
using Zenject;

namespace DontStopTheTrain.Events
{
    public sealed class EventStarter : IInitializable, IDisposable
    {
        [Inject]
        private TurnBasedController _turnBasedController;
        [Inject]
        private Player _player;
        [Inject]
        private EventController _eventController;
       // [Inject]
        //private EventGenerator _eventGenerator;

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
           /* var events = _eventGenerator.GetEvents(_playerLevel, 3);

            foreach (var eventToStart in events)
            {
                _eventController.StartEvent(eventToStart);
            }*/
        }

    }
}

