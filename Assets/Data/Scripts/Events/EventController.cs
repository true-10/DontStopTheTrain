using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Zenject;

namespace DontStopTheTrain.Events
{
    public sealed class EventController
    {
        [Inject]
        private EventInitDataManager _eventInitDataManager;

        public Action<IEvent> OnStart { get; set; }
        public Action<IEvent> OnComplete { get; set; }

        public void StartEvent(IEvent gameEvent)
        {
            var missionData = _eventInitDataManager.GetInitData(gameEvent);
            gameEvent.Initialize(missionData);
            gameEvent.OnComplete += OnEventComplete;
            OnStart?.Invoke(gameEvent);
        }

        private void OnEventComplete(IEvent gameEvent)
        {
            OnComplete?.Invoke(gameEvent);
            gameEvent.OnComplete -= OnEventComplete;
        }
    }
    /* public interface IEventFabric
     {
         IEvent CreateEvent(IEventStaticData staticData);
     }

      public class EventFabric : IEventFabric
      {
          public IEvent CreateEvent(IEventStaticData staticData)
          {
              var eventType = staticData.Type;
              switch (eventType)
              {
                  default: return new BaseGameEvent() 
                  { 
                      StaticData = staticData,
                      Status = EventStatus.None                     
                  };
              }
          }
      }

      public class GameEventController_ : MonoBehaviour//, IGameEventController
      {
          [SerializeField]
          private MonoDataEventManager dataEventManager;

          private List<IEvent> allGameEvents => dataEventManager.GameEvents;
          private List<IEvent> activeGameEvents = new();

          public Action<IEvent> OnChangeEvent { get; set; }
          public Action<IGameEventCallback> OnChangeEventStatus { get; set; }
          public Action OnInit { get; set; }



          void Start()
          {

          }

          void Update()
          {

          }

          private void OnEventChangeStatus(IEvent gameEvent)
          {
              // OnChangeEventStatus?.Invoke(gameEvent);
              OnChangeEvent?.Invoke(gameEvent);
          }

          public IEvent GetGameEventById(int id)
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
          public void AddEventToProcessor(IEvent gameEvent)
          {
              var processor = EventStaticProcessorFabric.GetProcessor(gameEvent.StaticData.Type);
              if (processor != null)
              {
                  processor.AddEvent(gameEvent);
              }
              else
              {
                  Debug.LogError(
                      $"[QuestController] - ��� ���������� ��� ������� [{gameEvent.StaticData.Id}] �� ���� [{gameEvent.StaticData.Type}]");
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
          public bool IsEventTheMostHeaviest(IEvent gameEvent)//, int type = 0)//0 - ���� �����
          {
              return false;
          }
      }*/
}

