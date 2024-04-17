using DontStopTheTrain.Events;
using DontStopTheTrain.Train;
using System.Collections.Generic;
using System.Linq;
using UniRx;
using Zenject;

namespace DontStopTheTrain.Train
{

    public class WagonData : IWagon
    {
        //здесь мы отслеживаем состояние вагона
        public int Number => 1;
        public IWagonSystemStaticData StaticData => _staticData;// { get; private set; }
        public IReadOnlyCollection<IWagonSystem> Systems { get; private set; }
        public int Price => 500;
        public int EnergyConsumption => StaticData.BaseEnergyConsumption + Systems.Sum(sys => sys.EnergyConsumption);
        public int DeteriorationSpeed => StaticData.BaseDeteriorationSpeed ;//+бафы перки
        public int Weight => StaticData.Weight + Systems.Sum(sys => sys.Weight);
        public IReadOnlyReactiveProperty<int> MaxHealth => _maxHealth;
        public IReadOnlyReactiveProperty<int> Health => _health;
        public int Next { get; set; }
        public int Prev { get; set; }

        public IEvent ActiveEvent { get; private set; }

        public WagonData(IWagonStaticData wagonStaticData, TurnBasedController turnBasedController,
            BuffAndPerksService buffAndPerksService)
        {
            _staticData = wagonStaticData;
            _turnBasedController = turnBasedController;
            _buffAndPerksService = buffAndPerksService;
        }

        private TurnBasedController _turnBasedController;
        private BuffAndPerksService _buffAndPerksService;

        private IWagonStaticData _staticData;
        private ReactiveProperty<int> _health;
        private ReactiveProperty<int> _maxHealth;

        public void Initialize()
        {
            _health = new(StaticData.MaxHealth);
            _maxHealth = new(StaticData.MaxHealth);
            _turnBasedController.OnTurnEnd += OnTurnEnd;
        }

        public void Dispose()
        {
            _turnBasedController.OnTurnEnd -= OnTurnEnd;
            _health.Dispose();
            _maxHealth.Dispose();
        }

        private void OnTurnEnd(ITurnCallback callback)
        {
            //считаем износ вагона
            //если есть незавершенные ивенты, то износ больше
            int repairServiceValue = _buffAndPerksService.GetValue(PerkType.RepairService);
            _health.Value -= DeteriorationSpeed + repairServiceValue;
            if (_health.Value < 0)
            {
                _health.Value = 0;
            }
        }
    }   
}
