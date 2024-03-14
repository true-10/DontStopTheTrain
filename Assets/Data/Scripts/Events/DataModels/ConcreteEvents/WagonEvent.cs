using System;
using System.Collections.Generic;
using UnityEditor.MPE;

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

        public int HashCode => GetHashCode();

        public int ActionPointPrice => UnityEngine.Mathf.Clamp(_actionPointPrice, 0, StaticData.ActionPointPrice);
        public int Weight => 1;// StaticData.weig

        public IReadOnlyCollection<ICondition> ÑompleteConditions { get; private set; }

        public IEventStaticData StaticData { get; private set; }
        public EventStatus Status { get; private set; }

        
        public WagonEvent(IEventStaticData staticData, IReadOnlyCollection<ICondition> conditions, 
            EventsService eventsService, PerksController perksController)
        {
            StaticData = staticData;
            ÑompleteConditions = conditions;
            _eventsService = eventsService;
            _perksController = perksController;
        }

        private EventsService _eventsService;
        private PerksController _perksController;

        private int _actionPointPrice => StaticData.ActionPointPrice - _perksController.GetValue(PerkType.ReduceActionPointPrice);

        public void Initialize()
        {
          /*  Conditions = new();
            foreach (var conditionStatic in StaticData.Conditions)
            {
                Conditions.Add(_conditionFabric.Create(conditionStatic));
            }*/
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
            return true;
        }

        private void Dispose()
        {

        }
    }
}

