using System;
using System.Linq;
using True10.CameraSystem;
using True10.Extentions;
using True10.Interfaces;
using Zenject;

namespace DontStopTheTrain.Events
{
    public class EventObjectsController : IGameLifeCycle
    {
        [Inject]
        private EventObjectsManager _eventObjectsManager;
        [Inject]
        private TurnBasedController _turnBasedController;
        [Inject]
        private CameraSwitcher _cameraSwitcher;

        public void PlayNextEventAnimation()
        {
            var eventsAnimtaions = _eventObjectsManager.Items
                .Where(eventObject => eventObject.IsStartAnimationCompleted == false)
                .ToList();
            if (eventsAnimtaions.Count == 0)
            {
                _turnBasedController.StartTurn();
                _cameraSwitcher.SwitchToDefaultCamera();
               // var cam = _cameraSwitcher.GetNextCamera();
                //cam.SwitchToThisCamera();
                return;
            }
            var eventObject = eventsAnimtaions.GetRandomElement();
            if (eventObject != null)
            {
                eventObject.PlayStartAnimation();
            }
        }

        public void Initialize()
        {
            _eventObjectsManager.OnItemAdded += OnEventObjectAdded;
            _eventObjectsManager.OnItemRemoved += OnEventObjectRemoved;
            _turnBasedController.OnTurnStart += OnTurnStarted;
        }

        private void OnTurnStarted(ITurnCallback callback)
        {
            PlayNextEventAnimation();
        }

        public void Dispose()
        {
            _eventObjectsManager.OnItemAdded -= OnEventObjectAdded;
            _eventObjectsManager.OnItemRemoved -= OnEventObjectRemoved;
            _turnBasedController.OnTurnStart -= OnTurnStarted;
        }

        private void OnEventObjectRemoved(AbstractEventObject eventObject)
        {
            eventObject.OnStartAnimationPlayed -= OnStartAnimationPlayed;
        }

        private void OnEventObjectAdded(AbstractEventObject eventObject)
        {
            eventObject.OnStartAnimationPlayed += OnStartAnimationPlayed;
        }

        private void OnStartAnimationPlayed(AbstractEventObject @object)
        {
            PlayNextEventAnimation();
        }
    }
}
