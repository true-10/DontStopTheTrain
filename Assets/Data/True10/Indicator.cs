using System;
using UniRx;
using UnityEngine;

namespace True10
{    public class Indicator : MonoBehaviour
    {
        [SerializeField]
        private float _seconds = 0.2f;
        [SerializeField]
        private TransformsSwitcher _transformsSwitcher;

        private IDisposable _timer = null;

        void Start()
        {
            _timer?.Dispose();
            _timer = null;
            _timer = Observable.Interval(TimeSpan.FromSeconds(_seconds))
                .Subscribe(x =>
                {
                    _transformsSwitcher.SwitchTransforms();
                }
                ).AddTo(this);
        }
    }
}
