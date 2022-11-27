using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DontStopTheTrain.Events
{
    [System.Serializable]
    public class GameEventStaticData
    {
        public string Name;
       // public string Comment;
        public int Id;
        public int EventType;
        public int ActionPointPrice;

    }

    [CreateAssetMenu(fileName = "EventsList", menuName = "DST/EventsListScriptableObject")]
    public class EventsListScriptableObject : ScriptableObject
    {
        public List<GameEventStaticData> events;

    }
}
