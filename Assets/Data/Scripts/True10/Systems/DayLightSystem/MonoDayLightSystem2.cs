
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using DG.Tweening;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;
using UniRx;
/*
namespace True10.DayLightSystem
{
    public class MonoDayLightSystem2 : MonoBehaviour
    {
        [Inject]
        private ITurnController turnController;

        [SerializeField]
        private float duration = 1f;
        [SerializeField]
        private Volume volume;
        [SerializeField]
        private DayLightSettingsScriptableObject daySettings;
        [SerializeField]
        private DayLightSettingsScriptableObject nightSettings;
        [SerializeField, Space]
        private Light light;

        public Action OnChange { get; set; }

        private Tween lightTween = default(Tween);
        private Tween exposureTween = default(Tween);
        private Tween desiredLuxValuTween = default(Tween);

        void Start()
        {
            turnController.OnTurnEnd += OnTurnEndHandler;
            SetDayLightSettings(daySettings.data);
        }

        private void OnTurnEndHandler(ITurnCallback callback)
        {
            int turnNumber = callback.Index;
            var settings = daySettings.data;

            if (turnNumber % 2 == 0)
            {
                settings = nightSettings.data;
                SetNightLightSettings(settings);
            }
            else
            {
                SetDayLightSettings(settings);
            }
            OnChange?.Invoke();
        }

        private void SetNightLightSettings(DayLightSettings settings)
        {
            SetLightSettings(settings, true);
        }

        private void SetDayLightSettings(DayLightSettings settings)
        {
            SetLightSettings(settings, false);
        }

        private void SetLightSettings(DayLightSettings settings, bool IsNight)
        {
            lightTween?.Kill();
            exposureTween?.Kill();
            desiredLuxValuTween?.Kill();
            if (settings.SunData.Intensity.IsEnable)
            {
                lightTween = light
                    .DOIntensity(settings.SunData.Intensity.Value, settings.SunData.Intensity.Duration)
                    .SetEase(settings.SunData.Intensity.Ease);
            }

            var volumeProfile = volume.profile;// = settings.VolumeData.VolumeProfile;
            if (settings.VolumeData.FixedExposure.IsEnable)
            {
                if (volumeProfile.TryGet<Exposure>(out var exposure))
                {
                    exposureTween = DOTween
                        .To(() => exposure.fixedExposure.value, x => exposure.fixedExposure.value = x, settings.VolumeData.FixedExposure.Value, settings.VolumeData.FixedExposure.Duration)
                        .SetEase(settings.VolumeData.FixedExposure.Ease);
                }
            }

            if (settings.VolumeData.DesiredLuxValue.IsEnable)
            {
                if (volumeProfile.TryGet<HDRISky>(out var sky))
                {
                    desiredLuxValuTween = DOTween
                        .To(() => sky.desiredLuxValue.value, x => sky.desiredLuxValue.value = x, settings.VolumeData.DesiredLuxValue.Value, settings.VolumeData.DesiredLuxValue.Duration)
                        .SetEase(settings.VolumeData.DesiredLuxValue.Ease);
                }
            }

        }
    }
        /*
        private void Update()
        {
            if (Input.GetKeyUp(KeyCode.R))
            {
                ExplosionTest();
            }
        }
        private void ExplosionTest()
        {
            var volumeProfile = volume.profile;// = settings.VolumeData.VolumeProfile;
            if (volumeProfile.TryGet<HDRISky>(out var sky))
            {
                DOTween.To(() => sky.desiredLuxValue.value, x => sky.desiredLuxValue.value = x, -1000000000f, duration);
            }
        }*/

//}
//*/
