using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DontStopTheTrain.Events
{
    public class MonoDataEventManager : MonoBehaviour
    {
        [SerializeField] 
        private EventsListScriptableObject eventsScriptableObject;

        public List<IGameEvent> GameEvents => gameEvents;
        public List<IGameEvent> gameEvents = new();
        //  public List<IGameEventStaticData> gameEventDatas = new();

        private EventFabric eventFabric = new();

        public void Init()
        {
            gameEvents.Clear();
            foreach (var e in eventsScriptableObject.events)
            {
                GameEventStaticData gameEventStaticData = new GameEventStaticData()
                {
                    Id = e.Id,
                    ActionPointPrice = e.ActionPointPrice,
                    EventType = e.EventType,
                };

                var newGameEvent = eventFabric.CreateEvent(gameEventStaticData);
                gameEvents.Add(newGameEvent);

            }
        }

        private void Awake()
        {
            Init();
        }
    }
}
