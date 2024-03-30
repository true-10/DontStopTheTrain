using System;
using System.Collections;
using System.Collections.Generic;
using True10.Interfaces;
using UnityEngine;
using Zenject;

namespace DontStopTheTrain.Events
{

    public class ViewEventController: IGameLifeCycle
    {
        [Inject]
        private TurnBasedController _turnBasedController;
        [Inject]
        private EventViewersManager _eventViewersManager;
        [Inject]
        private EventStarter _eventStarter;

        public void Initialize()
        {
            //_turnBasedController.OnTurnStart += OnTu
            _turnBasedController.OnTurnEnd += OnTurnEnd;
        }

        public void Dispose()
        {
            _turnBasedController.OnTurnEnd -= OnTurnEnd;
        }

        private void TryToStartViewEvent()
        {
            if (_eventStarter.TryToStartViewEvents())
            {

            }
            else
            {
                _turnBasedController.NextTurn();
            }
        }
        private void OnTurnEnd(ITurnCallback callback)
        {
            TryToStartViewEvent();
        }

    }

}
