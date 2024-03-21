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
        public Action<IEvent> OnComplete { get; set; }
        public int Chance => StaticData.Chance;
        public int HashCode => GetHashCode();
        public int ActionPointPrice => UnityEngine.Mathf.Clamp(_actionPointPrice, 0, StaticData.ActionPointPrice);
        public IReadOnlyCollection<ICondition> ÑompleteConditions { get; private set; }
        public IEventStaticData StaticData { get; private set; }
        public ProgressStatus Status { get; private set; }

        public WagonEvent(IEventStaticData staticData, IReadOnlyCollection<ICondition> conditions, 
            EventsService eventsService, BuffAndPerksService buffAndPerksService)
        {
            StaticData = staticData;
            ÑompleteConditions = conditions;
            _eventsService = eventsService;
            _buffAndPerksService = buffAndPerksService;
        }

        private EventsService _eventsService;
        private BuffAndPerksService _buffAndPerksService;

        private int _actionPointPrice => StaticData.ActionPointPrice - _buffAndPerksService.GetValue(PerkType.ReducePriceActionPoint);

        public void Start()
        {
            Status = ProgressStatus.InProgress;
        }

        public void Reset()
        {
            Status = ProgressStatus.None;
        }

        public bool TryToComplete()
        {
            var isReadyToComplete = _eventsService.IsAllConditionsAreMet(this) && _eventsService.IsEnoughActionPoints(this);
            if (isReadyToComplete == false)
            {
                return false;
            }
            _eventsService.TryToRemoveRequredItems(this);
            OnComplete?.Invoke(this);
            Status = ProgressStatus.Complete;
            return true;
        }

        private void Dispose()
        {

        }
    }
}

