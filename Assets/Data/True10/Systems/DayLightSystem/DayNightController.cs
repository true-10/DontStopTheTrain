using UnityEngine;
using UnityEngine.Rendering.HighDefinition;
using UnityEngine.Rendering;
using System;

namespace True10.DayLightSystem
{
    [Serializable]
    public class DayNightSettings
    {
        public Vector2 IntensitySkyMinMax = new Vector2(4, 15);
        public Vector2 IntensitySunMinMax = new Vector2(9000, 85000);
    }

    public class DayNightController : MonoBehaviour
    {
        [SerializeField]
        private Volume _volume;
        [SerializeField]
        private Light _sun;
        [SerializeField]
        private float _sunsetSpeed = 1f;

        private Vector2 _intensitySkyMinMax = new Vector2(4, 15);
        private Vector2 _intensitySunMinMax = new Vector2(9000, 85000);

        private VolumeProfile _volumeProfile;
        private HDRISky _sky;
        private float t = 2;

        public void Initialize(DayNightSettings settings)
        {
            if (_sky == null)
            {
                _volumeProfile = _volume.profile;
                _volumeProfile.TryGet<HDRISky>(out _sky);
            }
            if (_sky != null)
            {
                _sky.exposure.value = settings.IntensitySkyMinMax.y;
            }
            _sun.intensity = settings.IntensitySunMinMax.y;
        }

        public void StartTransition(DayNightSettings settings)
        {
            t = 0;
            _intensitySkyMinMax = settings.IntensitySkyMinMax;
            _intensitySunMinMax = settings.IntensitySunMinMax;            
        }

        private void DayNightSkyDayTransition(float t)
        {
            float delta = _intensitySkyMinMax.y - _intensitySkyMinMax.x;
            var newIntensity = _intensitySkyMinMax.x + t * delta;
            _sky.exposure.value = newIntensity;
        }

        private void DayNightSunDayTransition(float t)
        {
            float delta = _intensitySunMinMax.y - _intensitySunMinMax.x;
            var newIntensity = _intensitySunMinMax.x + t * delta;
            _sun.intensity = newIntensity;
        }

        private void OnDestroy()
        {
            _sky = null;
        }

        private void Update()
        {
            if (_sky == null)
            {
                return;
            }
            if (t > 1)
            {
                return;
            }
            t += Time.deltaTime * _sunsetSpeed;
            DayNightSkyDayTransition(t);
            DayNightSunDayTransition(t);
        }
    }
}
