using UnityEngine;
using System;
using DG.Tweening;
using Zenject;
using True10.GridSystem;

namespace True10.DayLightSystem
{

    [Serializable]
    public class DayNightSettings
    {
        public float SkyIntensity = 15f;
        public float SunIntensity = 85000f;
    }

    public class DayNightController : MonoBehaviour
    {
        [SerializeField]
        private Light _sun;
        [SerializeField]
        private AbstractIntensitable _sky;
        [SerializeField]
        private float _transitionDuration = 2f;

        private DayNightSettings settingsTarget;

        private Tween _skyTween;
        private Tween _sunTween;

        public void SetIntenisities(float sunIntensity, float skyIntensity)
        {
            _sun.intensity = sunIntensity;
            _sky.SetIntensity(skyIntensity);
        }

        public void Initialize(DayNightSettings settings)
        {
            _sky.SetIntensity(settings.SkyIntensity);
            _sun.intensity = settings.SunIntensity;
        }

        public void StartTransition(DayNightSettings settings)
        {
            settingsTarget = settings;
            DayNightSkyDayTransition();
            DayNightSunDayTransition();
        }

        private void DayNightSkyDayTransition()
        {
            _skyTween?.Complete();
            _skyTween =
                DOTween.To(() => _sky.Intensity, x => _sky.SetIntensity(x), settingsTarget.SkyIntensity, _transitionDuration)
                .SetEase(Ease.Linear);
        }

        private void DayNightSunDayTransition()
        {
            _sunTween?.Complete();
            _sunTween =
                DOTween.To(() => _sun.intensity, x => _sun.intensity = x, settingsTarget.SunIntensity, _transitionDuration)
                .SetEase(Ease.Linear);
        }

        private void OnDestroy()
        {
            _sky = null;
            _skyTween?.Complete();
            _skyTween = null;
            _sunTween?.Complete();
            _sunTween = null;
        }
    }
}
