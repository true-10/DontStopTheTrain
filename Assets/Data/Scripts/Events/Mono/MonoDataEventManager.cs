using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DontStopTheTrain.Events
{
    public class MonoDataEventManager : MonoBehaviour
    {
        [SerializeField] private EventsListScriptableObject eventsScriptableObject;

        public List<GameEventStaticData> GameEventDatas => eventsScriptableObject.events;

    }
}
