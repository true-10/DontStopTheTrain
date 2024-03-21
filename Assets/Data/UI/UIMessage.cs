using TMPro;
using UnityEngine;
using DG.Tweening;
using UniRx;
using System;
namespace DontStopTheTrain
{

    public sealed class UIMessage : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI _messageText;
        [SerializeField]
        private CanvasGroup _canvasGroup;
        [SerializeField]
        private float _fadeDurationSeconds = 1f;
        [SerializeField]
        private ParticleSystem _showUpParticles;

        private IDisposable fadeOutInterval;

        private void Start()
        {
            _canvasGroup.gameObject.SetActive(false);
        }

        public void ShowMessage(string message, float hideAfterSeconds = 3f)
        {
            _messageText.text = message;
            _canvasGroup.gameObject.SetActive(true);
            _canvasGroup.alpha = 1f;
            FadeOutAfter(hideAfterSeconds);
        }

        private void FadeOutAfter(float seconds)
        {
            fadeOutInterval?.Dispose();
            fadeOutInterval = null;
            fadeOutInterval = Observable.Timer(TimeSpan.FromSeconds(seconds))
                .Subscribe(x =>
                {
                    _canvasGroup.DOFade(0f, _fadeDurationSeconds)
                        .OnComplete(() => OnMessageComplete());
                }
                ).AddTo(this);
        }

        private void OnMessageComplete()
        {
            _canvasGroup.gameObject.SetActive(false);
        }
    }

}
