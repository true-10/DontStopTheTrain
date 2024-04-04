using System;
using True10.CameraSystem;
using UniRx;
using UnityEngine;

namespace DontStopTheTrain.Events
{
    public class FireEventObject : AbstractEventObject
    {
        [SerializeField]
        private ParticleSystem _startParticleSystem;
        [SerializeField]
        private ParticleSystem _particleSystem;
        [SerializeField]
        private ParticleSystem _сompleteParticleSystem;
        [SerializeField]
        private CameraHolder _cameraHolder;
        [SerializeField]
        private float _animationTimeSeconds = 1f;

        private IDisposable _timer = null;

        public override void PlayStartAnimation()
        {
            _cameraHolder?.SwitchToThisCamera();
            _startParticleSystem?.Play();
            _particleSystem?.Play();
            CompleteStartAnimationAfter(_animationTimeSeconds);
        }

        public override void PlayCompleteAnimation()
        {
            _startParticleSystem.Play();
            _particleSystem.Stop();
        }

        private void CompleteStartAnimationAfter(float seconds)
        {
            _timer?.Dispose();
            _timer = null;
            _timer = Observable.Timer(TimeSpan.FromSeconds(seconds))
                .Subscribe(x =>
                {
                    IsStartAnimationCompleted = true;
                    OnStartAnimationPlayed?.Invoke(this);
                }
                ).AddTo(this);
        }

        public override void Initialize()
        {
            base.Initialize();
            _startParticleSystem?.Stop();
            _particleSystem?.Stop();
            if (_сompleteParticleSystem != null)
            {
                _сompleteParticleSystem.Stop();
            }
        }

        public override void Dispose()
        {
            base.Dispose();

            _timer?.Dispose();
            _timer = null;
        }
    }
}
