using DontStopTheTrain.Train;
using System;
using System.Collections.Generic;
using System.Linq;
using True10.Extentions;
using True10.Interfaces;
using UnityEngine;
using Zenject;

namespace DontStopTheTrain.Events
{
    public sealed class EventStarter : IGameLifeCycle
    {
        [Inject]
        private TurnBasedController _turnBasedController;
        [Inject]
        private EventController _eventController;
        [Inject]
        private EventGenerator _eventGenerator;
        [Inject]
        private EventViewersManager _eventViewersManager;
        [Inject]
        private EventsManager _eventManager;

        private Queue<IEvent> _eventsToReset = new();

        private int _overallWeight = 0;
        private int noEventChance = 80;


        public void Initialize()
        {
            _turnBasedController.OnTurnEnd += TryToResetEvents;
            _eventController.OnComplete += OnEventComplete;
        }

        public void Dispose()
        {
            _turnBasedController.OnTurnEnd -= TryToResetEvents;
            _eventController.OnComplete -= OnEventComplete;
            
            _eventsToReset.Clear();
        }


        public bool TryToStartViewEvents()
        {
            var view = _eventViewersManager
                .Items
                .Where(viewer => viewer.Type == EventType.View)
                .GetRandomElement();
            if (view == null)
            {
                return false;
            }
            var events = _eventManager.GetAllFreeEvents()
                .Where(eventData => eventData.StaticData.Type == EventType.View)
                .ToList(); 
            if (events.Count == 0)
            {
                return false;
            }

            return true;
        }
        public bool TryToStartRandomWagonEvent(float threshold, 
            IReadOnlyCollection<WagonEventType> wagonEventTypes, 
            Action<IEvent> onGetEvent)
        {
            int chance = GenerateChance(threshold);
            if (chance < noEventChance)
            {
                //Debug.Log($"No Chance [{chance}] To Start");
                onGetEvent?.Invoke(null);
                return false;

            }
            var events = _eventManager.GetAllFreeEvents();
            events = events
                .Where(eventData => wagonEventTypes.Contains((eventData.StaticData as IWagonEventStaticData).WagonEventType))
                .ToList();
            if (events.Count == 0)
            {
                Debug.Log($"No Events To Start");
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
                
        private IEvent GetRandomWeightedEvent(List<IEvent> events)
        {
            events = events
                .OrderByDescending(ev => ev.Chance)
                .ToList();

            int total = events.Sum(ev => ev.Chance) + noEventChance;

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
            for (int i = 0; i < events.Count; i++)
            {
                var chance = events[i].Chance;
                overallWeight += chance;
                if (overallWeight >= randomPoint)
                {
                    return events[i];
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
        }
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

