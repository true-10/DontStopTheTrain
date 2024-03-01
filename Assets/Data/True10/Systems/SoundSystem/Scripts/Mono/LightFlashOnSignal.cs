using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace True10.SoundSysten
{
    public class LightFlashOnSignal : MonoBehaviour
    {
        [SerializeField] private float threshold = 0.2f;
        [SerializeField] private float duration = .3f;
        [SerializeField] private Light light;
        [SerializeField] private float intensityMultiplayer = 1.5f;

        private float initial = 0f;
        private float target = 0f;

        void Start()
        {
            initial = light.intensity;
            target = initial * intensityMultiplayer;
        }

        public void LigthOnSignal(float loudness)
        {
            if (loudness < threshold) return;

           // Debug.Log($"LightFlashOnSignal: loudness = {loudness}");
            var sequence = DOTween.Sequence();
            var tween1 = light.DOIntensity(target, duration);
            var tween2 = light.DOIntensity(initial, 0f);
            sequence
                .Append(tween1)
                .Append(tween2);
           
        }
    }
}
