using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DontStopTheTrain.Events
{
    public interface IGameEventController : IGameLifeCycle
    {
        public Action<IGameEvent> OnChangeEvent { get; set; }
        //  Action<IGameEventCallback> OnChangeEventStatus { get; set; }
        // Action<IGameEventCallback> OnComplete { get; set; }
        void AddEventToProcessor(IGameEvent gameEvent);
        //void FireEvent(IGameEvent gameEvent);
        IGameEvent GetGameEventById(int id);
    }

}
