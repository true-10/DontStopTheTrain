using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
namespace DontStopTheTrain.Events
{
    public interface IEventFabric
    {
        IGameEvent CreateEvent(IGameEventStaticData staticData);
    }

    public class EventFabric : IEventFabric
    {
        public IGameEvent CreateEvent(IGameEventStaticData staticData)
        {
            var eventType = staticData.EventType;
            switch (eventType)
            {
                default: return new BaseGameEvent() 
                { 
                    StaticData = staticData,
                    Status = GameEventStatus.None                     
                };
            }
        }
    }

    public interface IEventProcessorFabric
    {
        AbstractEventProccessor CreateProccessor(int eventType);
    }

    public abstract class AbstractEventProccessor
    {
        public Action<IGameEvent> OnChangeEvent { get; set; }
        //public Action<IGameEventCallback> OnChangeEventStatus { get; set; }

        public abstract void ProcessEvent(IGameEvent gameEvent);
/*
        public void AddEvent(IGameEvent gameEvent)//???надо ли?
        {

        }*/
    }

    public class GameEventController : MonoBehaviour, IGameEventController
    {
        [SerializeField]
        private MonoDataEventManager dataEventManager;

        private List<IGameEvent> allGameEvents => dataEventManager.GameEvents;
        private List<IGameEvent> activeGameEvents = new();

        public Action<IGameEvent> OnChangeEvent { get; set; }
        public Action<IGameEventCallback> OnChangeEventStatus { get; set; }
        public Action OnInit { get; set; }



        void Start()
        {

        }

        void Update()
        {

        }

        private void OnEventChangeStatus(IGameEvent gameEvent)
        {
            // OnChangeEventStatus?.Invoke(gameEvent);
            OnChangeEvent?.Invoke(gameEvent);
        }

        public IGameEvent GetGameEventById(int id)
        {
            return allGameEvents.FirstOrDefault(x => x.StaticData.Id == id);
            return activeGameEvents.FirstOrDefault(x => x.StaticData.Id == id);//?
        }
      
        public void Init()
        {
            foreach (var gameEvent in allGameEvents)
            {
                AddEventToProcessor(gameEvent);
            }

            foreach (var processor in EventStaticProcessorFabric.GetAllProcessor())
            {
                processor.OnEventChangeStatus += OnEventChangeStatus;
                processor.Init();
            }
        }
        public void Dispose()
        {
            foreach (var processor in EventStaticProcessorFabric.GetAllProcessor())
            {
                processor.OnEventChangeStatus -= OnEventChangeStatus;
            }

            EventStaticProcessorFabric.Dispose();
        }
        public void AddEventToProcessor(IGameEvent gameEvent)
        {
            var processor = EventStaticProcessorFabric.GetProcessor(gameEvent.StaticData.EventType);
            if (processor != null)
            {
                processor.AddEvent(gameEvent);
            }
            else
            {
                Debug.LogError(
                    $"[QuestController] - нет процессора дл€ событи€ [{gameEvent.StaticData.Id}] по типу [{gameEvent.StaticData.EventType}]");
            }
        }
        public void FireEvent(int gameEventId)
        {
            var gameEvent = GetGameEventById(gameEventId);
            if (gameEvent == null)
            {
                return;
            }

            activeGameEvents.Add(gameEvent);
        }
        public bool IsEventTheMostHeaviest(IGameEvent gameEvent)//, int type = 0)//0 - всех типов
        {
            return false;
        }
    }
}

