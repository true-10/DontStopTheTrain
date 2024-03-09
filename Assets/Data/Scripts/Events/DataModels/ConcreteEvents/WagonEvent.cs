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

        public int HashCode => throw new NotImplementedException();

        public int Weight => 1;// StaticData.weig

        public List<ICondition> Conditions { get; private set; }

        public IEventStaticData StaticData { get; private set; }
        public EventStatus Status { get; private set; }

        
        public WagonEvent(IEventStaticData staticData, ConditionFabric conditionFabric, EventsService eventsService)
        {
            StaticData = staticData;
            _conditionFabric = conditionFabric;
            _eventsService = eventsService;
        }
        
        private ConditionFabric _conditionFabric;
        private EventsService _eventsService;

        public void Initialize()
        {
            Conditions = new();
            foreach (var conditionStatic in StaticData.Conditions)
            {
                Conditions.Add(_conditionFabric.GetCondition(conditionStatic));
            }
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

