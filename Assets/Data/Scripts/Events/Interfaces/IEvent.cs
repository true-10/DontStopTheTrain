using System;
using System.Collections.Generic;

namespace DontStopTheTrain.Events
{
    public interface IEvent
    {
        Action<IEvent> OnComplete { get; set; }
        EventId Id => StaticData.Id;
        IEventStaticData StaticData { get; }

        int HashCode { get; }
        int Weight { get; }
        List<ICondition> Conditions { get; }
        EventStatus Status { get; }//??

        void Initialize();
        bool TryToComplete();
    }
}