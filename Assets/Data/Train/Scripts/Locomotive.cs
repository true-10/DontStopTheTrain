using DG.Tweening;
using DontStopTheTrain.Events;
using DontStopTheTrain.Train;
using System.Collections;
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
        private LevelScrollController _levelScrollController;
        [Inject]
        private WagonsManager _wagonsManager;

        private float _currentSpeed;

        Tween speedTween = null;

        public void SetSpeed(float speed)
        {
            speedTween?.Complete();

            speedTween = DOTween.To(() => _currentSpeed, x => _currentSpeed = x, speed, 1f)
                .OnUpdate( () => _levelScrollController.SetSpeed(_currentSpeed))
                .OnComplete(() => _levelScrollController.SetSpeed(_currentSpeed));
                //.SetEase(mult.Ease);
        }

        public void Dispose()
        {
            _wagonsManager.TryToRemove(this);
        }

        public void Initialize()
        {
            _levelScrollController.SetSpeed(0f);
            _wagonsManager.TryToAdd(this);
            SetSpeed(100f);
        }


        void Start()
        {
            Initialize();
        }

    }
}
