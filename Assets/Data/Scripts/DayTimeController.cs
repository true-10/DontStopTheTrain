using System;
using True10.DayLightSystem;
using True10.DayTimeSystem;
using True10.Interfaces;
using UnityEngine;
using Zenject;

namespace DontStopTheTrain
{
    public class DayTimeController : MonoBehaviour, IGameLifeCycle
    {
        [Inject]
        private TurnBasedController _turnBasedController;
        [Inject]
        private DayTimeSystem _dayTimeSystem;

        [SerializeField]
        private int _dayStartsAtHour = 7;
        [SerializeField]
        private float _dayDurationInSeconds = 300f;
        [SerializeField]
        private DayNightController _dayNightController;
        [SerializeField]
        private DayNightSettings _daySettings;
        [SerializeField]
        private DayNightSettings _nightSettings;
        [SerializeField]
        private AnimationCurve _curve;
        [SerializeField, Header("Clouds")]
        private CloudLayerController _cloudLayerController;
        [SerializeField]
        private float _speed = 1f;
        [SerializeField]
        private float _rewindSpeed = 3f;

        private float _intervalPerSettings;
        private int currentSettingIndex = 0;

        public void Initialize()
        {
            _dayTimeSystem.OnChange += OnTimeChange;
            _dayTimeSystem.Initialize(_dayDurationInSeconds);
            SetLight(0.3f);

            if (_cloudLayerController != null)
            {
                _cloudLayerController.SetSpeed(_speed);
            }
            _dayTimeSystem.OnStartRewind += OnStartRewind;
            _dayTimeSystem.OnEndRewind += OnEndRewind;

        }
        private void OnStartRewind()
        {
            if (_cloudLayerController != null)
            {
                _cloudLayerController.SetSpeed(_rewindSpeed);
            }
        }

        private void OnEndRewind()
        {
            if (_cloudLayerController != null)
            {
                _cloudLayerController.SetSpeed(_speed);
            }
        }

        private void SetLight(float progress01)
        {
            var skyIntensity = Mathf.Lerp(_nightSettings.SkyIntensity, _daySettings.SkyIntensity, _curve.Evaluate(progress01));
            var sunIntensity = Mathf.Lerp(_nightSettings.SunIntensity, _daySettings.SunIntensity, _curve.Evaluate(progress01));

            _dayNightController.SetIntenisities(sunIntensity, skyIntensity);
        }

        public void Dispose()
        {
            _dayTimeSystem.OnChange -= OnTimeChange;
            _dayTimeSystem.OnStartRewind -= OnStartRewind;
            _dayTimeSystem.OnEndRewind -= OnEndRewind;
        }

        private void OnTimeChange(DateTime time)
        {
            var progress = _dayTimeSystem.ProgressOfTheDay;
            SetLight(progress);

            if (time.Hour == 0 && time.Minute == 0)
            {
                _turnBasedController.CompleteTurn();
            }
        }

        private void Start()
        {
            Initialize();
        }

        private void OnDestroy()
        {
            Dispose();
        }
    }
}

