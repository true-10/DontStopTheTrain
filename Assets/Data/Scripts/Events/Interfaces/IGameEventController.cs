using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DontStopTheTrain.Events
{
    public interface IGameEventController
    {
        Action<IGameEventCallback> OnChangeEventStatus { get; set; }
       // Action<IGameEventCallback> OnComplete { get; set; }
        //Action<IGameEvent> OnChangeStatus { get; set; }
        void FireEvent(IGameEvent gameEvent);
    }

    public interface IGameEventsController
    {

    }
}
