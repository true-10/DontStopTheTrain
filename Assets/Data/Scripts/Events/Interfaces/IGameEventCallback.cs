using System.Collections;
using System.Collections.Generic;
using True10.Enums;
using UnityEngine;


namespace DontStopTheTrain.Events
{

    public interface IGameEventCallback
    {
        int EventId { get; }
        //IGameEvent GameEvent { get; set; }
        ProgressStatus EventStatus { get;}
    }

    public class GameEventCallback : IGameEventCallback
    {
        public int EventId { get; }
        public ProgressStatus EventStatus { get;}
    }
}
