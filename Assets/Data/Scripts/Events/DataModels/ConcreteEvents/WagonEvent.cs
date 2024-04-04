using System;
using System.Collections.Generic;
using True10.Enums;

namespace DontStopTheTrain.Events
{
    public interface IWagonEvent : IEvent
    {
        int WagonNumber { get; set; }

        void SetWagon(int number);
    }

    public class WagonEvent : IEvent
    {
        public Action<IEvent> OnFocus { get; set; }
        public Action<IEvent> OnComplete { get; set; }
        public int Chance => StaticData.Weight;
        public int HashCode => GetHashCode();
        public int ActionPointPrice => UnityEngine.Mathf.Clamp(_actionPointPrice, 0, StaticData.ActionPointPrice);
        public IReadOnlyCollection<ICondition> ÑompleteConditions { get; private set; }
        public IEventStaticData StaticData { get; private set; }
        public ProgressStatus Status { get; private set; }

        public WagonEvent(IEventStaticData staticData, IReadOnlyCollection<ICondition> conditions, 
            EventsService eventsService, BuffAndPerksService buffAndPerksService, TurnBasedController turnBasedController)
        {
            StaticData = staticData;
            ÑompleteConditions = conditions;
            _eventsService = eventsService;
            _buffAndPerksService = buffAndPerksService;
            _turnBasedController = turnBasedController;
        }

        private EventsService _eventsService;
        private BuffAndPerksService _buffAndPerksService;
        private TurnBasedController _turnBasedController;

        private int _actionPointPrice => StaticData.ActionPointPrice - _buffAndPerksService.GetValue(PerkType.ReducePriceActionPoint);
        private int timeToComplete = 0;

        public void Start()
        {
            Status = ProgressStatus.InProgress;
            timeToComplete = StaticData.Time;
           // _turnBasedController.OnTurnStart += OnTurnStart;
            _turnBasedController.OnTurnEnd += OnTurnEnd;
        }

        public void Reset()
        {
            Status = ProgressStatus.None;
        }

        public void TryToFocus()
        {
            OnFocus?.Invoke(this);
        }

        public bool TryToComplete()
        {
            if (StaticData.Time > 0 && timeToComplete == 0)
            {
                Complete(ProgressStatus.Fail);
                return true;
            }
            var isReadyToComplete = _eventsService.IsAllConditionsAreMet(this) && _eventsService.IsEnoughActionPoints(this);
            if (isReadyToComplete == false)
            {
                return false;
            }
            Complete(ProgressStatus.Complete);
            return true;
        }

        private void Complete(ProgressStatus newStatus)
        {
            _eventsService.TryToRemoveRequredItems(this);
            Status = newStatus;
           // _turnBasedController.OnTurnStart -= OnTurnStart;
            _turnBasedController.OnTurnEnd -= OnTurnEnd;
            OnComplete?.Invoke(this);
        }

        private void Dispose()
        {
           // _turnBasedController.OnTurnStart -= OnTurnStart;
            _turnBasedController.OnTurnEnd -= OnTurnEnd;
        }

    /*    private void OnTurnEnd(ITurnCallback callback)
        {
            throw new NotImplementedException();
        }*/

        private void OnTurnEnd(ITurnCallback callback)
        {
            if (StaticData.Time > 0)
            {
                if (timeToComplete == 0)
                {
                    TryToComplete();
                }
                timeToComplete--;
            }
        }
    }
}

