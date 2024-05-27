using DontStopTheTrain.Events;
using DontStopTheTrain.Train;
using System;
using System.Collections.Generic;
using System.Linq;
using UniRx;
using UnityEngine.Rendering.VirtualTexturing;
using Zenject;

namespace DontStopTheTrain.Train
{

    public class WagonData : IWagon
    {
        public Action<IEvent, IWagonSystem> OnEventStarted { get; set; }
        public Action<SystemChangedCallback> OnSystemChanged { get; set; }
        public Action<IWagon> OnFocus { get; set; }
        //здесь мы отслеживаем состояние вагона
        // public int Number => 1;
        public IWagonStaticData StaticData => _staticData;
        public IReadOnlyCollection<IWagonSystem> Systems => _systems;
       // public int Price => 500;
        //public int EnergyConsumption => StaticData.BaseEnergyConsumption + Systems.Sum(sys => sys.EnergyConsumption);
        //public int DeteriorationSpeed => StaticData.BaseDeteriorationSpeed ;//+бафы перки
        //public int Weight => StaticData.Weight + Systems.Sum(sys => sys.Weight);
        //public IReadOnlyReactiveProperty<int> MaxHealth => _maxHealth;
        //public IReadOnlyReactiveProperty<int> Health => _health;
       // public int Next { get; set; }
        //public int Prev { get; set; }

        public IEvent ActiveEvent { get; private set; }

        public WagonData(IWagonStaticData wagonStaticData, TurnBasedController turnBasedController,
            BuffAndPerksService buffAndPerksService)
        {
            _staticData = wagonStaticData;
            //_turnBasedController = turnBasedController;
           // _buffAndPerksService = buffAndPerksService;
        }

       // private TurnBasedController _turnBasedController;
        //private BuffAndPerksService _buffAndPerksService;

        private IWagonStaticData _staticData;
        //private ReactiveProperty<int> _health;
        //private ReactiveProperty<int> _maxHealth;
        public List<IWagonSystem> _systems { get; private set; } = new();

        public void TryToFocus()
        {
            OnFocus?.Invoke(this);
        }

        public void Initialize()
        {
          //  _health = new(StaticData.MaxHealth);
            //_maxHealth = new(StaticData.MaxHealth);
           // _turnBasedController.OnTurnEnd += OnTurnEnd;
            foreach (var system in Systems)
            {                
                SubscribeSystem(system);
            }
        }

        public void Dispose()
        {
          /*  if (_turnBasedController != null)
            {
                _turnBasedController.OnTurnEnd -= OnTurnEnd;
            }
            _health.Dispose();
            _maxHealth.Dispose();*/
            foreach (var system in Systems)
            {
                UnSubscribeSystem(system);
            }
        }

        /* private void OnTurnEnd(ITurnCallback callback)
         {
             //считаем износ вагона
             //если есть незавершенные ивенты, то износ больше
             int repairServiceValue = _buffAndPerksService.GetValue(PerkType.RepairService);
             _health.Value -= DeteriorationSpeed + repairServiceValue;
             if (_health.Value < 0)
             {
                 _health.Value = 0;
             }
         }*/

        public void AddSystem(IWagonSystem newSystem)
        {
            _systems.Add(newSystem);
        }

        public void RemoveSystem(IWagonSystem newSystem)
        {
            if (_systems.Contains(newSystem) == false)
            {
                return;
            }
            _systems.Remove(newSystem);
        }

        private void SubscribeSystem(IWagonSystem system)
        {
            system.OnEventStarted -= OnEventStartedHandler;
            system.OnEventStarted += OnEventStartedHandler;
        }

        private void UnSubscribeSystem(IWagonSystem system)
        {
            system.OnEventStarted -= OnEventStartedHandler;
        }

        private void OnEventStartedHandler(IEvent eventData, IWagonSystem system)
        {
            OnEventStarted?.Invoke(eventData, system);
        }
    }   
}
