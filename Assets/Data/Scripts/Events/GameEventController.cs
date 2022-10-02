using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace DontStopTheTrain.Events
{
    public interface EventProcessorFabric
    {
        AbstractEventProccessor CreateProccessor(int eventType);
    }

    public class AbstractEventProccessor
    {
        public Action<IGameEvent> OnChangeEvent { get; set; }
        //public Action<IGameEventCallback> OnChangeEventStatus { get; set; }

        public void AddEvent()
        {

        }
    }

    public class GameEventController : MonoBehaviour, IGameEventController
    {
        public Action<IGameEvent> OnChangeEvent { get; set; }
        public Action<IGameEventCallback> OnChangeEventStatus { get; set; }
        public Action OnInit { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void FireEvent(IGameEvent gameEvent)
        {
            //var callback = new GameEventCallback();

          //  OnChangeEventStatus?.Invoke(callback);
        }

        public void AddEventToProcessor(IGameEvent gameEvent)
        {
            throw new NotImplementedException();
        }

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

