using DG.Tweening;
using DontStopTheTrain.Events;
using DontStopTheTrain.Train;
using ModestTree;
using System.Collections.Generic;
using True10.AnimationSystem;
using True10.LevelScrollSystem;
using UniRx;
using UnityEngine;
using Zenject;

namespace DontStopTheTrain
{
    public class Locomotive : MonoBehaviour, IWagon
    {
        [SerializeField]
        private float mult = 1f;

        public float SpeedMultiplayer => mult;

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
        private Tween speedTween = null;

        public void SetSpeed(float speed)
        {
            speedTween?.Complete();
            speedTween = DOTween.To(() => _currentSpeed, x => _currentSpeed = x, speed, 1f)
                .OnUpdate( () => _levelScroller.SetSpeed(_currentSpeed))
                .OnComplete(() => _levelScroller.SetSpeed(_currentSpeed));
                //.SetEase(mult.Ease);
        }

        public void Dispose()
        {
            _wagonsManager.TryToRemove(this);
        }

        public void Initialize()
        {
            _levelScroller.SetSpeed(0f);
            _wagonsManager.TryToAdd(this);
            SetSpeed(100f);
        }


        void Start()
        {
            Initialize();
        }

    }
}
