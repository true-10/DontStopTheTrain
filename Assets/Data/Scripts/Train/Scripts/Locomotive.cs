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
using Zenject;

namespace DontStopTheTrain
{
    public class Locomotive : AbstractGameLifeCycleBehaviour, IWagon
    {
        [SerializeField]
        private float _defaultSpeed = 100f;
        public float SpeedMultiplayer => _currentSpeed / 100f;

        public IReadOnlyCollection<IWagonSystem> Systems => throw new System.NotImplementedException();

        public IEvent ActiveEvent => throw new System.NotImplementedException();

        public IWagonSystemStaticData StaticData => throw new System.NotImplementedException();

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
            _levelScroller.SetSpeed(0f);
            StartMotion();
        }

        private void OnSpeedUpdate()
        {
            _levelScroller.SetSpeed(_currentSpeed);
        }
    }
}
