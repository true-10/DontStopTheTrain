using True10.Interfaces;
using True10.LevelScrollSystem;
using UnityEngine;
using Zenject;

namespace DontStopTheTrain
{
    public class AudioControllerBySpeed : AbstractControllerBySpeed
    {
        [SerializeField]
        private AudioSource _audioSource;

        public override void OnSpeedChange(float speed)
        {
            _locomotive ??= _wagonsManager.GetLocomotive();
            _audioSource.pitch = _locomotive == null ? 1f : _locomotive.SpeedMultiplayer;
        }
    }

    public abstract class AbstractControllerBySpeed : AbstractGameLifeCycleBehaviour
    {
        [Inject]
        protected LevelScroller _levelScroller;
        [Inject]
        protected WagonsManager _wagonsManager;

        protected Locomotive _locomotive;

        public abstract void OnSpeedChange(float speed);

        public override void Initialize()
        {
            _locomotive = _wagonsManager.GetLocomotive();
            _levelScroller.OnSpeedChanged += OnSpeedChange;
        }

        public override void Dispose()
        {
            _levelScroller.OnSpeedChanged -= OnSpeedChange;
        }

    }
}
