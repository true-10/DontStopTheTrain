using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace DontStopTheTrain.Events
{

    public interface IGameEventCallback
    {
        int EventId { get; }
        //IGameEvent GameEvent { get; set; }
        GameEventStatus EventStatus { get;}
    }

    public class GameEventCallback : IGameEventCallback
    {
        public int EventId { get; }
        public GameEventStatus EventStatus { get;}
    }
}
