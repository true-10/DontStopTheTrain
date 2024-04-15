using UnityEngine;
using UnityEngine.Rendering.HighDefinition;
using UnityEngine.Rendering;
using System;
using DG.Tweening;
using Zenject;

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
        private Volume _volume;
        [SerializeField]
        private Light _sun;
        [SerializeField]
        private float _transitionDuration = 2f;

        private DayNightSettings settingsTarget;

        private Tween _skyTween;
        private Tween _sunTween;
        private VolumeProfile _volumeProfile;
        private HDRISky _sky;

        public void SetIntenisities(float sunIntensity, float skyIntensity)
        {
            Initialize();
            if (_sky != null)
            {
                _sky.exposure.value = skyIntensity;
            }
            _sun.intensity = sunIntensity;
        }

        public void Initialize()
        {
            if (_sky == null)
            {
                _volumeProfile = _volume.profile;
                _volumeProfile.TryGet<HDRISky>(out _sky);
            }
        }

        public void Initialize(DayNightSettings settings)
        {
            Initialize();
            if (_sky != null)
            {
                _sky.exposure.value = settings.SkyIntensity;
            }
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
                DOTween.To(() => _sky.exposure.value, x => _sky.exposure.value = x, settingsTarget.SkyIntensity, _transitionDuration)
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
