﻿using DontStopTheTrain.Train;
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
       // public IWagonStaticData WagonStaticData { get; private set; }
        public IReadOnlyCollection<IWagonSystem> Systems { get; private set; }
        public int Price => 500;
        public int EnergyConsumption => StaticData.BaseEnergyConsumption + Systems.Sum(sys => sys.EnergyConsumption);
        public int DeteriorationSpeed => 10;
        public int Weight => StaticData.Weight + Systems.Sum(sys => sys.Weight);
        public IReadOnlyReactiveProperty<int> MaxHealth => _maxHealth;
        public IReadOnlyReactiveProperty<int> Health => _health;
        public int Next { get; set; }
        public int Prev { get; set; }


        public WagonData(IWagonStaticData wagonStaticData)
        {
            _staticData = wagonStaticData;
        }

        [Inject]
        private TurnBasedController _turnBasedController;
        [Inject]
        private BuffAndPerksService _buffAndPerksService;

        private IWagonStaticData _staticData;
        private ReactiveProperty<int> _health = new();
        private ReactiveProperty<int> _maxHealth = new();

        public void Initialize()
        {
            _health.Value = 1000;
            _turnBasedController.OnTurnEnd += OnTurnEnd;
        }

        public void Dispose()
        {
            _turnBasedController.OnTurnEnd -= OnTurnEnd;
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
