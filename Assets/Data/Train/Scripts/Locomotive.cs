using DG.Tweening;
using DontStopTheTrain.Events;
using DontStopTheTrain.Train;
using ModestTree;
using System;
using System.Collections.Generic;
using True10.AnimationSystem;
using True10.Interfaces;
using True10.LevelScrollSystem;
using UniRx;
using UnityEngine;
using UnityEngine.Rendering.VirtualTexturing;
using Zenject;

namespace DontStopTheTrain
{
    public class Locomotive : AbstractGameLifeCycleBehaviour, IWagon
    {
        public Action<SystemChangedCallback> OnSystemChanged { get; set; }
        public Action<IEvent, IWagonSystem> OnEventStarted { get; set; }

        [SerializeField]
        private float _defaultSpeed = 100f;
        public float SpeedMultiplayer => _currentSpeed / 100f;

        public IReadOnlyCollection<IWagonSystem> Systems => _systems;

        public IEvent ActiveEvent => throw new System.NotImplementedException();

        public IWagonStaticData StaticData => throw new System.NotImplementedException();

        public int Price => throw new System.NotImplementedException();

        public int EnergyConsumption => throw new System.NotImplementedException();

        public int DeteriorationSpeed => throw new System.NotImplementedException();

        public int Weight => throw new System.NotImplementedException();

        public IReadOnlyReactiveProperty<int> MaxHealth => throw new System.NotImplementedException();

        public IReadOnlyReactiveProperty<int> Health => throw new System.NotImplementedException();

        [Inject]
        private LevelScroller _levelScroller;
        [Inject]
        private WagonsManager _wagonsManager;

        private float _currentSpeed;
        private Sequence _speedSequence = null;

        public List<IWagonSystem> _systems { get; private set; }

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
        public void SetSpeed(float speed, float duration = 1f)
        {
            _speedSequence?.Complete();
            _speedSequence = DOTween.Sequence();
            _speedSequence.Append(DOSpeed(speed, duration))
                .OnUpdate( OnSpeedUpdate)
                .OnComplete(OnSpeedUpdate);
        }

        public void StartMotion()
        {
            _speedSequence?.Complete();
            _speedSequence = DOTween.Sequence();
            _speedSequence.Append(DOSpeed(2f, 3f))
                .Append(DOSpeed(10f, 5f))
                .Append(DOSpeed(40f, 5f))
                .Append(DOSpeed(_defaultSpeed, 8f))
                .OnUpdate(OnSpeedUpdate)
                .OnComplete(OnSpeedUpdate);

        }

        private Tween DOSpeed(float endValue, float duration)
        {
            return DOTween.To(() => _currentSpeed, x => _currentSpeed = x, endValue, duration);
        }

        public override void Dispose()
        {
            _wagonsManager.TryToRemove(this);
        }

        public override void Initialize()
        {
            _wagonsManager.TryToAdd(this);
            SetSpeed(0f, 0f);
            OnSpeedUpdate();
            //StartMotion();
        }

        private void OnSpeedUpdate()
        {
            _levelScroller.SetSpeed(_currentSpeed);
        }
    }
}
