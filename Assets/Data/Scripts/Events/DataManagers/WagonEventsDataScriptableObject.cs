using DontStopTheTrain.Train;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DontStopTheTrain.Events.DataManagers
{
    public class WagonEventsDataScriptableObject : ScriptableObject
    {

        public List<WagonEventData> events;
    }

    public class WagonEventData : IWagonEvent
    {
        public int Id => throw new NotImplementedException();

        public GameEventStatus Status { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public int ActionPointPrice => throw new NotImplementedException();

        public int EventType => throw new NotImplementedException();

        public Action Fire { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Action OnComplete { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public IWagonType WagonType => throw new NotImplementedException();

        IWagonType IWagonEvent.WagonType => throw new NotImplementedException();

        Action IGameEvent.Fire { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        Action IGameEvent.OnComplete { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
