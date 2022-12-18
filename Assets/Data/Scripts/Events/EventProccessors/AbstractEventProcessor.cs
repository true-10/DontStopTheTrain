using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


namespace DontStopTheTrain.Events
{
    public interface IEventProcessor : IGameLifeCycle
    {
        Action<IGameEvent> OnEventChangeStatus { get; set; }
        //void SetQuestData(List<IQuestDynamic> listQuestsDynamic);
        void AddEvent(IGameEvent gameEvent);
        void RemoveEvent(IGameEvent gameEvent);
        //bool ActionButtonQuest(IGameEvent quest);
       // void RecalculateQuests();
    }

    public abstract class AbstractEventProcessor : IEventProcessor
    {
        public Action<IGameEvent> OnEventChangeStatus { get; set; }
        public Action OnInit { get; set; }

        protected List<IGameEvent> events;

        public void AddEvent(IGameEvent gameEvent)
        {
            if (events.Exists(x => x.StaticData.Id == gameEvent.StaticData.Id))
            {
                return;
            }

            events.Add(gameEvent);
            //OnQuestAdded(gameEvent);
        }

        protected void TryToCompleteEvent(IGameEvent gameEvent)
        {
            if (gameEvent.Status == GameEventStatus.Complete || gameEvent.Conditions.Any(x => x.IsMet() == false))
            {
                Debug.Log($"AbstractEventProcessor: TryToCompleteEvent({gameEvent.StaticData.Id}) fail");
                return;
            }

            gameEvent.Complete();
        }

        public void RemoveEvent(IGameEvent gameEvent)
        {

        }

        public void Init()
        {

        }

        public void Dispose()
        {

        }
    }


    public static class EventStaticProcessorFabric
    {
        private static IEventProcessor roadProcessor =
            new EventProcessorFabric(typeof(RoadEventProcessor)).Processor as IEventProcessor;

        private static IEventProcessor wagonProcessor =
            new EventProcessorFabric(typeof(WagonEventProcessor)).Processor as IEventProcessor;

        private static IEventProcessor stopageProcessor =
            new EventProcessorFabric(typeof(StopageEventProcessor)).Processor as IEventProcessor;



        public static List<IEventProcessor> GetAllProcessor()
        {
            return EventProcessorFabric.GetAll();
        }

        public static IEventProcessor GetProcessor(int eventType)
        {
            switch (eventType)
            {
                case 0:
                    {
                        return roadProcessor;
                    }
                case 1:
                    {
                        return wagonProcessor;
                    }
                case 2:
                    {
                        return stopageProcessor;
                    }
            }
            return default;
        }
      
        public static void Dispose()
        {
            foreach (var processor in GetAllProcessor())
            {
                processor.Dispose();
            }

            EventProcessorFabric.Dispose();
        }
    }

    class EventProcessorFabric
    {
        private static List<IEventProcessor> all = new List<IEventProcessor>();
        public IEventProcessor Processor { get; }

        public EventProcessorFabric(Type type)
        {
            var inst = ContainerManager.GetContainer().Instantiate(type);
            Processor = inst as IEventProcessor;
            all.Add(Processor);
        }

        public static List<IEventProcessor> GetAll() => all;

        public static void Dispose()
        {
            all = new List<IEventProcessor>();
        }
    }

    public class WagonEventProcessor : AbstractEventProcessor
    {


    }   

    public class StopageEventProcessor : AbstractEventProcessor
    {


    }

    public class RoadEventProcessor : AbstractEventProcessor
    {


    }
}
