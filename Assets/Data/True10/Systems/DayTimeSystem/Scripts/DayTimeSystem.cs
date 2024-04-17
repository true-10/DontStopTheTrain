using System;
using True10.Interfaces;
using UniRx;

namespace True10.DayTimeSystem
{
    public class DayTimeSystem : IGameLifeCycle
    {
        public Action OnStartRewind { get; set; }
        public Action OnEndRewind { get; set; }
        public Action<DateTime> OnChange { get; set; }
        public DateTime DateTime { get => _dateTime; }
        public float ProgressOfTheDay => (float)(_dateTime.Hour * 60f + _dateTime.Minute) / (24f * 60f);

        private float _dayDurationInSeconds = 300f;
        private DateTime _dateTime = new();
        private IDisposable _interval = null;

        private bool _isOnRewind = false;
        private bool _isPaused = false;
        private float _readDayDurationInSeconds => 24f * 3600f;

        public void Pause()
        {
            _isPaused = true;
        }

        public void UnPause()
        {
            _isPaused = false;
        }

        public void RewindToNextDay()
        {
            if (_isOnRewind)
            {
                return;
            }
            _isOnRewind = true;
            OnStartRewind?.Invoke();
            Initialize(UpdateRewind);
        }

        public void Initialize(float dayDurationInSeconds) 
        {
            _dayDurationInSeconds = dayDurationInSeconds;
            Initialize();
        }

        public void Initialize()
        {
            _isOnRewind = false;
            Initialize(Update);
        }

        public void Dispose()
        {
            _interval?.Dispose();
            _interval = null;
        }


        private void Initialize(Action actionForInteval)
        {
            _interval?.Dispose();
            _interval = null;
            var intervalInSeconds = _dayDurationInSeconds / _readDayDurationInSeconds;
            _interval = Observable.Interval(TimeSpan.FromSeconds(intervalInSeconds))
                .Subscribe(_ => actionForInteval?.Invoke());
        }

        private void Update()
        {
            if (_isPaused)
            {
                return;
            }
            _dateTime = _dateTime.AddMinutes(1);
            OnChange?.Invoke(_dateTime);
        }

        private void UpdateRewind()
        {
            if (_isPaused)
            {
                return;
            }
            if (_dateTime.Hour == 23)
            {
                if (_dateTime.Minute == 59)
                {
                    OnEndRewind?.Invoke();
                    Initialize();
                }
                else
                {
                    _dateTime = _dateTime.AddMinutes(1);
                }
            }
            else
            {
                _dateTime = _dateTime.AddHours(1);
            }
            OnChange?.Invoke(_dateTime);
        }
    }
}
