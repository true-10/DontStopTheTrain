using DontStopTheTrain.MiniGames;
using System;
using System.Collections.Generic;
using True10.Enums;

namespace DontStopTheTrain.Events
{
    public class ViewEvent : IEvent
    {
        public Action<IEvent> OnFocus { get; set; }
        public Action<IEvent> OnComplete { get; set; }

        public int ActionPointPrice => 0;

        public int Chance => StaticData.Weight;

        public IEventStaticData StaticData { get; private set; }

        public int HashCode => GetHashCode();

        public IReadOnlyCollection<ICondition> СompleteConditions => throw new NotImplementedException();

        public ProgressStatus Status { get; private set; }

       // public IMiniGame MiniGame => throw new NotImplementedException();

        public ViewEvent(IEventStaticData staticData, TurnBasedController turnBasedController)
        {
            StaticData = staticData;
            _turnBasedController = turnBasedController;
        }
        
        private TurnBasedController _turnBasedController;

        public void TryToFocus()
        {
            OnFocus?.Invoke(this);
        }

        public bool TryToComplete()
        {
            return false;
        }
        public void Start()
        {
            Status = ProgressStatus.InProgress;
        }

        public void Reset()
        {
            Status = ProgressStatus.None;
        }
    }
}

