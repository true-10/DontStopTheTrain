using UnityEngine;

namespace DontStopTheTrain.Events
{
    public sealed class EventInitDataManager : MonoBehaviour
    {
        //[SerializeField]
        //private GatherObjectsData gatherObjectsData;
        //[SerializeField]
        //private KillNightmaresData killNightmaresData;

        public IEventInitData GetInitData(IEvent gameEvent)
        {
            switch (gameEvent.StaticData.Type)
            {
                case EventType.None:
                default:
                    return null;
            }
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
                      $"[QuestController] - нет процессора для события [{gameEvent.StaticData.Id}] по типу [{gameEvent.StaticData.Type}]");
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
          public bool IsEventTheMostHeaviest(IEvent gameEvent)//, int type = 0)//0 - всех типов
          {
              return false;
          }
      }*/
}

