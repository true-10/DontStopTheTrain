
using System;
using True10.Interfaces;
using UniRx;
using UnityEngine;

namespace True10.DayTimeSystem
{
    public class DayTimeSystem : IGameLifeCycle
    {
        public Action<DateTime> OnChange { get; set; }
        public DateTime DateTime { get => _dateTime; }
        public float ProgressOfTheDay => (float)(_dateTime.Hour * 60f + _dateTime.Minute) / (24f * 60f);

        private float _dayDurationInSeconds = 300f;
        private DateTime _dateTime = new();
        private IDisposable _interval = null;

        private float _readDayDurationInSeconds => 24f * 60f * 60f;

        public void RewindToNextDay()
        {

        }

        public void Initialize(float dayDurationInSeconds) 
        {
            _dayDurationInSeconds = dayDurationInSeconds;
            Initialize();
        }

        public void Initialize()
        {
            _interval?.Dispose();
            _interval = null;
            var intervalInSeconds = _dayDurationInSeconds / _readDayDurationInSeconds;
            _interval = Observable.Interval(TimeSpan.FromSeconds(intervalInSeconds))
                .Subscribe(_ => Update());
        }

        public void Dispose()
        {
            _interval?.Dispose();
            _interval = null;
        }

        private void Update()
        {
            _dateTime = _dateTime.AddMinutes(1);
            OnChange?.Invoke(_dateTime);
        }
    }
}
