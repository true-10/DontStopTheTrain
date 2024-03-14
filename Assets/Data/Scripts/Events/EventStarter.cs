using System;
using System.Collections.Generic;
using System.Linq;
using True10.Extentions;
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
        [Inject]
        private EventViewersManager _eventViewersManager;


        List<AbstractEventViewer> usedViewers = new();

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
            if (callback.Number < 1)
            {
                _turnBasedController.StartTurn();
                return;
            }
            var maxPosibleEventsCount = _eventViewersManager.Items.Where(v => v.IsFree).Count();
                        
            var events = _eventGenerator.GetEvents();

            if (events.Count == 0)
            {
                Debug.Log($"No Events To Start. maxPosibleEventsCount = {maxPosibleEventsCount}");
                _turnBasedController.StartTurn();
                return;
            }

            var wagonEvents = events
                .Where(eventData => eventData.StaticData.Type == EventType.Wagon)
                .ToList();
            TryToStartWagonEvents(wagonEvents);

            var viewEvents = events
                .Where(eventData => eventData.StaticData.Type == EventType.View)
                .ToList();
            TryToStartViewEvents(viewEvents);
            _turnBasedController.StartTurn();
        }

        private void TryToStartWagonEvents(List<IEvent> wagonEvents)
        {
            usedViewers.Clear();
            var eventViewers = _eventViewersManager.Items
                .Where(viewer => viewer.Type == EventType.Wagon)
                .ToList();
            
            foreach (var eventToStart in wagonEvents)
            {
                var wagonEventStatic = eventToStart.StaticData as IWagonEventStaticData;
                var wagonEventType = wagonEventStatic.WagonEventType;
                var view = eventViewers
                    .Where(view => (view as WagonEventViewer).WagonEventTypes.Contains(wagonEventType))
                    .Where(view => view.IsFree)
                    .ToList()
                    .GetRandomElement();

                if (view != null && usedViewers.Contains(view) == false)
                {
                    view.TryToSetEventData(eventToStart);
                    usedViewers.Add(view);
                    _eventController.Start(eventToStart);
                }
            }
        }

        private void TryToStartViewEvents(List<IEvent> viewEvents)
        {
            var eventViewers = _eventViewersManager.Items.Where(viewer => viewer.Type == EventType.View);

            foreach (var eventToStart in viewEvents)
            {
                _eventController.Start(eventToStart);
            }
        }

    }
}

