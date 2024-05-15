using System;
using DG.Tweening;
using UniRx;
using UnityEngine;

namespace DontStopTheTrain.UI
{
    public class UIFader : UIScreen
    {
        [SerializeField]
        private CanvasGroup _canvasGroup;
        [SerializeField]
        private float _fadeAwaitInSeconds = 1f;
        [SerializeField]
        private float _fadeDurationInSeconds = 2f;

        private IDisposable fadeOutInterval;
        private Action _onCompleteCallback = null;
        private float _targetAlpha = 1f;

        public void FadeIn(float fadeAfterSeconds = 1f, Action onComplete = null)
        {
            Show(); 
            FadeTo(1f, fadeAfterSeconds, onComplete);
        }

        public void FadeOut(float fadeAfterSeconds = 1f, Action onComplete = null)
        {
            FadeTo(0f, fadeAfterSeconds, onComplete);
        }

        public void FadeTo(float alpha = 1f, float hideAfterSeconds = 3f, Action onComplete = null)
        {
            _targetAlpha = alpha;
            _onCompleteCallback = onComplete;
            FadeToAfter(hideAfterSeconds);
        }

        private void FadeToAfter(float seconds)
        {
            fadeOutInterval?.Dispose();
            fadeOutInterval = null;
            fadeOutInterval = Observable.Timer(TimeSpan.FromSeconds(seconds))
                .Subscribe(x =>
                {
                    FadeAnimation(_fadeDurationInSeconds);
                }
                ).AddTo(this);
        }

        private void OnMessageComplete()
        {
            if (_targetAlpha == 0)
            {
                Hide();
            }
            _onCompleteCallback?.Invoke();
        }

        private void FadeAnimation(float seconds)
        {
            _canvasGroup.DOFade(_targetAlpha, seconds)
                .OnComplete(() => OnMessageComplete());
        }

        private void Start()
        {
            Show();
            //_targetAlpha = 1f; 
            //FadeAnimation(0f);
            FadeOut(_fadeAwaitInSeconds);
        }

        private void OnValidate()
        {
            transform.SetAsLastSibling();
        }
    }
}

