using DontStopTheTrain.Train;
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
        [Inject]
        private EventsManager _eventManager;

        private Queue<IEvent> _eventsToReset = new();
        private List<AbstractEventViewer> _usedViewers = new();

        private int _overallWeight = 0;
        private int noEventChance = 80;


        public void Initialize()
        {
            _turnBasedController.OnTurnStart += TryToStartEvents;
            _turnBasedController.OnTurnEnd += TryToResetEvents;
            _eventController.OnComplete += OnEventComplete;
        }

        public void Dispose()
        {
            _turnBasedController.OnTurnStart -= TryToStartEvents;
            _turnBasedController.OnTurnEnd -= TryToResetEvents;
            _eventController.OnComplete -= OnEventComplete;
            
            _usedViewers.Clear();
            _eventsToReset.Clear();
        }

        public bool TryToStartRandomWagonEvent(float threshold, 
            IReadOnlyCollection<WagonEventType> wagonEventTypes, 
            Action<IEvent> onGetEvent) // , IWagonSystem initiator)
        {
            int chance = GenerateChance(threshold);
            if (chance < noEventChance)
            {
                //Debug.Log($"No Chance [{chance}] To Start");
                onGetEvent?.Invoke(null);
                return false;

            }
            //var maxPosibleEventsCount = _eventViewersManager.Items.Where(v => v.IsFree).Count();
            //var events = _eventGenerator.GetEvents();
            var events = _eventManager.GetAllFreeEvents();
            events = events
                .Where(eventData => wagonEventTypes.Contains((eventData.StaticData as IWagonEventStaticData).WagonEventType))
                .ToList();
            if (events.Count == 0)
            {
                Debug.Log($"No Events To Start");//. maxPosibleEventsCount = {maxPosibleEventsCount}");
              //  _turnBasedController.StartTurn();
                onGetEvent?.Invoke(null);
                return false;
            }

            var eventToStart = GetRandomWeightedEvent(events);

            if (eventToStart != null)
            {                
                onGetEvent?.Invoke(eventToStart);
                _eventController.Start(eventToStart);
                return true;
            }

            onGetEvent?.Invoke(null);
            return false;
        }
                
        private IEvent GetRandomWeightedEvent(List<IEvent> wagonEvents)
        {
            wagonEvents = wagonEvents
                .OrderByDescending(ev => ev.Chance)
                .ToList();

            int total = wagonEvents.Sum(ev => ev.Chance) + noEventChance;

            int randomPoint = UnityEngine.Random.Range(0, total);
            var overallWeight = 0;
            overallWeight += noEventChance;
            if (overallWeight >= randomPoint)
            {
              /*  _overallWeight -= noEventChance;
                if (_overallWeight < 0)
                {
                    _overallWeight = 0;
                }*/
                return null;
            }
            // randomPoint = 99
            // 80 50 40 30 20 10
            for (int i = 0; i < wagonEvents.Count; i++)
            {
                var chance = wagonEvents[i].Chance;
                overallWeight += chance;
                if (overallWeight >= randomPoint)
                {
                    return wagonEvents[i];
                }
            }
            return null;
        }

        private int GenerateChance(float threshold)
        {
            var thresholdChance = Mathf.RoundToInt(threshold * 100f);
            var randomChance = UnityEngine.Random.Range(-5, 15);
            var minValue = 1 + thresholdChance + randomChance;
            var maxValue = 101;
            minValue = Mathf.Clamp(minValue, 1, maxValue);
            var chance = UnityEngine.Random.Range(minValue, 101);
           // chance = 100 - chance;
            //Debug.Log($"thresholdChance = {thresholdChance} randomChance = {randomChance}  minValue = {minValue} chance = {chance} ");
            return chance;
        }

        private void TryToStartEvents(ITurnCallback callback)
        {
            if (callback.Number < 1)
            {
                _turnBasedController.StartTurn();
                return;
            }
            var maxPosibleEventsCount = _eventViewersManager.Items.Where(v => v.IsFree).Count();
                        
            //var events = _eventGenerator.GetEvents();
            var events = _eventManager.GetAllFreeEvents();

            if (events.Count == 0)
            {
                Debug.Log($"No Events To Start. maxPosibleEventsCount = {maxPosibleEventsCount}");
                _turnBasedController.StartTurn();
                return;
            }

       /*     var wagonEvents = events
                .Where(eventData => eventData.StaticData.Type == EventType.Wagon)
                .ToList();
            TryToStartWagonEvents(wagonEvents);
       */
            var viewEvents = events
                .Where(eventData => eventData.StaticData.Type == EventType.View)
                .ToList();
            TryToStartViewEvents(viewEvents);
            _turnBasedController.StartTurn();
        }

        private void TryToResetEvents(ITurnCallback callback)
        {
            if (_eventsToReset.Count > 0)
            {
                var eventToReset = _eventsToReset.Dequeue();
                _eventManager.Reset(eventToReset);
            }
        }

        private void OnEventComplete(IEvent eventData)
        {
            _eventsToReset.Enqueue(eventData);
            /*
            _overallWeight -= eventData.Chance;
            if (_overallWeight < 0)
            {
                _overallWeight = 0;
            }*/
        }

        private IEvent GetRandomEventByChance(List<IEvent> events, float threshold, WagonEventViewer view)
        {
            var chance = GenerateChance(threshold);
            var wagonEvents = events
                .Where(eventData => eventData.StaticData.Type == EventType.Wagon)
                .Where(eventData => eventData.Chance > chance)
                //.Where(eventData => eventData.StaticData.Type == EventType.Wagon && eventData.Chance <= chance)
                .ToList();

            var eventToStart = wagonEvents
                .FirstOrDefault(eventData => view.WagonEventTypes.Contains((eventData.StaticData as IWagonEventStaticData).WagonEventType));
            return eventToStart;
        }

        private void TryToStartWagonEvents(List<IEvent> wagonEvents)
        {
            _usedViewers.Clear();
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

                if (view != null && _usedViewers.Contains(view) == false)
                {
                    view.TryToSetEventData(eventToStart);
                    _usedViewers.Add(view);
                    _eventController.Start(eventToStart);
                }
            }
        }

        private void TryToStartViewEvents(List<IEvent> viewEvents)
        {
            Debug.Log($"TryToStartViewEvents: FAK YO");
           /* var eventViewers = _eventViewersManager.Items.Where(viewer => viewer.Type == EventType.View);

            foreach (var eventToStart in viewEvents)
            {
                _eventController.Start(eventToStart);
            }*/
        }

    }
    public sealed class TrainEventStarter
    {

    }
    public sealed class WagonEventStarter
    {
        public WagonEventStarter()
        {

        }
        private WagonData _wagonData;
        //знаем список систем
        //смотрим какая более изношенная или рандомно выбираем и вызываем ивент генерат
        private EventGenerator _eventGenerator;
        private TurnBasedController _turnBasedController;

        public void Initialize()
        {
            _turnBasedController.OnTurnStart += OnTurnStart;
        }


        public void Dispose()
        {
            _turnBasedController.OnTurnStart -= OnTurnStart;

        }
        private void TryToStartEvents()
        {
            //var events = _eventGenerator.GetEvents();
           // var events = _eventManager.GetAllFreeEvents();
        }

        private void OnTurnStart(ITurnCallback callback)
        {
            TryToStartEvents();
        }

    }
}

