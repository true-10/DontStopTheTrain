using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DontStopTheTrain.Events
{
    [System.Serializable]
    public class GameEventScriptableStaticData//: IGameEventStaticData
    {
        public string Name;

        public int Id;// { get; private set; }

        public int ActionPointPrice;// { get; private set; }

        public int EventType;// { get; private set; }
                             // public string Comment;

    }

    [CreateAssetMenu(fileName = "EventsList", menuName = "DST/EventsListScriptableObject")]
    public class EventsListScriptableObject : ScriptableObject
    {
        public List<GameEventScriptableStaticData> events;



    }
}
