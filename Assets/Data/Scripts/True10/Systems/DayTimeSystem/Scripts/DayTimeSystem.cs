using System;
using True10.Interfaces;
using UniRx;

namespace True10.DayTimeSystem
{
    public class DayTimeSystem : IGameLifeCycle
    {
        public Action<bool> OnRewind { get; set; }
        public Action OnNewDay { get; set; }
        public Action<DateTime> OnChange { get; set; }
        public DateTime DateTime { get => _dateTime; }
        public float ProgressOfTheDay => (float)(_dateTime.Hour * 60f + _dateTime.Minute) / (24f * 60f);

        private float _dayDurationInSeconds = 300f;
        private int _dayStartsAtHour = 7;
        private DateTime _dateTime = new();
        private IDisposable _interval = null;

        private bool _isOnRewind = false;
        private bool _isPaused = false;
        private float _readDayDurationInSeconds => 24f * 3600f;

        public void SetStartedHour(int hour)
        {
            _dayStartsAtHour = hour;
        }
        public void Pause()
        {
            _isPaused = true;
        }

        public void UnPause()
        {
            _isPaused = false;
        }

        public void StopRewind()
        {
            if (_isOnRewind == false)
            {
                return;
            }
            _isOnRewind = false;
            OnRewind?.Invoke(_isOnRewind);
            Initialize();
        }

        public void RewindToNextDay()
        {
            if (_isOnRewind)
            {
                return;
            }
            _isOnRewind = true;
            OnRewind?.Invoke(_isOnRewind);
            double intervalInMilliSeconds = 1;
            Initialize(intervalInMilliSeconds, UpdateRewind);
        }

        public void Initialize(float dayDurationInSeconds)
        {
            _dateTime = _dateTime.AddHours(_dayStartsAtHour);
            _dayDurationInSeconds = dayDurationInSeconds;
            Initialize();
        }

        public void Initialize()
        {
            _isOnRewind = false;
            double intervalInMilliSeconds = (_dayDurationInSeconds / _readDayDurationInSeconds) * 1000f * 60f;
            Initialize(intervalInMilliSeconds, Update);
        }

        public void Dispose()
        {
            _interval?.Dispose();
            _interval = null;
        }

        private void Initialize(double intervalInMilliSeconds, Action actionForInteval)
        {
            _interval?.Dispose();
            _interval = null;
            _interval = Observable.Interval(TimeSpan.FromMilliseconds(intervalInMilliSeconds))
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

            if (_dateTime.Hour == _dayStartsAtHour && _dateTime.Minute == 0)
            {   
                OnNewDay?.Invoke();
                Initialize();                
            }
        }

        private void UpdateRewind()
        {
            if (_isPaused)
            {
                return;
            }
            if (_dateTime.Hour == _dayStartsAtHour - 1)
            {
                if (_dateTime.Minute == 59)
                {
                    StopRewind();
                }
                else
                {
                    _dateTime = _dateTime.AddMinutes(1);
                }
            }
            else
            {
                _dateTime = _dateTime.AddHours(1);
                if (_dateTime.Minute < 59)
                {
                    _dateTime = _dateTime.AddMinutes(1);
                }
            }
            OnChange?.Invoke(_dateTime);
        }
    }
}
