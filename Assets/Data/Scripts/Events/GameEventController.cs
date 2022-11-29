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


        public Action<IGameEvent> OnChangeEvent { get; set; }
        public Action<IGameEventCallback> OnChangeEventStatus { get; set; }
        public Action OnInit { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        private Dictionary<int, AbstractEventProccessor> processors = new();

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
        public IGameEvent GetGameEventById(int id)
        {
            return dataEventManager.GameEvents.FirstOrDefault(x => x.StaticData.Id == id);
        }
        public void FireEvent(IGameEvent gameEvent)
        {
            //var callback = new GameEventCallback();

          //  OnChangeEventStatus?.Invoke(callback);
        }

        /*public void AddEventToProcessor(IGameEvent gameEvent)
        {
            if (processors.ContainsKey(gameEvent.StaticData.EventType))
            {
                processors[gameEvent.StaticData.EventType].AddEvent();
            }
            else
            {

            }
        }*/

        public void Init()
        {
            /*  foreach (var processor in GetAllProcessor())
               {
                   processor.OnChangeEvent += OnChangeEventHandler;
                   processor.Init();
               }
            */
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }


        public void OnChangeEventHandler(IGameEvent gameEvent) 
        {


            OnChangeEvent.Invoke(gameEvent);
        }

    }
}

