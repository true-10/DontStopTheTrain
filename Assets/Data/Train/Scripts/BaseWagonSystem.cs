using DontStopTheTrain.Events;
using System;
using UniRx;

namespace DontStopTheTrain.Train
{
    public class BaseWagonSystem : IWagonSystem
    {
        public Action<IEvent, IWagonSystem> OnEventStarted { get; set; }
        public IEvent ActiveEvent { get; private set; }
        public IWagonSystemStaticData StaticData => _staticData;
        public int Price { get; private set; }
        public int EnergyConsumption { get; private set; }
        public int DeteriorationSpeed => StaticData.BaseDeteriorationSpeed;
        public int Weight => StaticData.Weight;
        public IReadOnlyReactiveProperty<int> MaxHealth => _maxHealth;
        public IReadOnlyReactiveProperty<int> Health => _health;
        public float HealthRatio => _health.Value / _maxHealth.Value;

        public BaseWagonSystem(IWagonSystemStaticData staticData, TurnBasedController turnBasedController,
    BuffAndPerksService buffAndPerksService, EventStarter eventStarter)
        {
            _staticData = staticData;
            _turnBasedController = turnBasedController;
            _buffAndPerksService = buffAndPerksService;
            _eventStarter = eventStarter;
        }

        private TurnBasedController _turnBasedController;
        private BuffAndPerksService _buffAndPerksService;
        private EventStarter _eventStarter;
        private WagonEventViewer _viewer;
        public ReactiveProperty<int> _maxHealth;
        private IWagonSystemStaticData _staticData;

        private ReactiveProperty<int> _health;

        public void SetViewer(IEventViewer viewer)
        {
            _viewer = viewer as WagonEventViewer;
        }

        public void Initialize()
        {
            _health = new(StaticData.MaxHealth);
            _maxHealth = new(StaticData.MaxHealth);
            _turnBasedController.OnTurnEnd += OnTurnEnd;
        }

        public void Dispose()
        {
            if (_turnBasedController != null)
            {
                _turnBasedController.OnTurnEnd -= OnTurnEnd;
            }
            _health.Dispose();
            _maxHealth.Dispose();
        }

        private void OnTurnEnd(ITurnCallback callback)
        {
            //считаем износ вагона
            //если есть незавершенные ивенты, то износ больше (перк или дебафф на время действия ивента)
            int eventDebuff = 0;
            if (ActiveEvent != null)
            {
                eventDebuff = 10;
            }
            int repairServiceValue = _buffAndPerksService.GetValue(PerkType.RepairService) + eventDebuff;
            _health.Value -= DeteriorationSpeed + repairServiceValue;

            if (_viewer.IsFree)
            {
                //если _health ниже какого то порога, то риск события выше и можно вызвать событие?
                //для разных событий разные пороги? HealthRatio в качестве проверки порога?
                _eventStarter.TryToStartRandomWagonEvent(HealthRatio, 
                    _viewer.WagonEventTypes,
                    eventData =>
                    {
                        ActiveEvent = eventData;
                        if (_viewer.TryToSetEventData(ActiveEvent))
                        {
                            OnEventStarted?.Invoke(ActiveEvent, this);
                        }
                    });
            }

            if (_health.Value < 0)
            {
                _health.Value = 0;
            }
        }
    }
}
