using System;
using System.Collections.Generic;

namespace DontStopTheTrain.Events
{
    public interface IEvent
    {
        Action<IEvent> OnComplete { get; set; }
        EventId Id => StaticData.Id;
        int ActionPointPrice { get; }
        IEventStaticData StaticData { get; }

        int HashCode { get; }
        int Weight { get; }
        IReadOnlyCollection<ICondition> СompleteConditions { get; }
        EventStatus Status { get; }//??

        void Initialize();
        bool TryToComplete();
    }

    public enum EventStatus
    {
        None, //бездействующие
        Start,
        InProgress,
        Complete,
        Fail
    }
}