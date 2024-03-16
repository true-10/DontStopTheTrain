using DontStopTheTrain.Train;
using System;
using System.Collections.Generic;
using System.Linq;
using True10.Extentions;
using Zenject;

namespace DontStopTheTrain.Events
{
    //TODO: перенести в системы? если они износились, то вызываем событие?
    //или проверяем через вьюверы состояние систем?
    public sealed class EventGenerator
    {
        [Inject]
        private EventsStaticStorage _eventsStaticManager;
        [Inject]
        private EventFabric _eventsFabric;
        [Inject]
        private EventsService _eventsService;       

        public IEvent GetEvent()
        {
            var availableEventForLevel = GetEventStaticDatasByLevel();
            var randomStatic = availableEventForLevel.GetRandomElement();
            var eventData = _eventsFabric.Create(randomStatic);
            return eventData;
        }

        public List<IEvent> GetEvents()
        {
            //есть лимит на события в день
            //и лимит активных событий
            var availableEventByLevel = GetEventStaticDatasByLevel();
            List<IEvent> events = new();
            foreach (var staticData in availableEventByLevel)
            {
                var eventData = _eventsFabric.Create(staticData);
                if (events.Contains(eventData))
                {
                    continue;
                }
                events.Add(eventData);
            }
            return events;
        }

        private List<IEventStaticData> GetEventStaticDatasByLevel()
        {
            return _eventsStaticManager
                .Datas
                .Select(eventData => eventData as IEventStaticData)
                .Where(eventData => _eventsService.IsAvailableForPlayerLevel(eventData))
                .ToList();// as List<IEventStaticData>;
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
            var events = _eventGenerator.GetEvents();
        }

        private void OnTurnStart(ITurnCallback callback)
        {
            TryToStartEvents();
        }

    }
}

