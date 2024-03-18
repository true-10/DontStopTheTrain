using UnityEngine;
using UnityEngine.Rendering.HighDefinition;
using UnityEngine.Rendering;
using Zenject;
using DontStopTheTrain;

namespace True10.DayLightSystem
{
    public class DayNightController : MonoBehaviour
    {
        [Inject]
        private TurnBasedController _turnBasedController;
        [SerializeField]
        private Volume _volume;
        [SerializeField]
        private Light _sun;
        [SerializeField]
        private Vector2 _intensitySkyMinMax = new Vector2(4, 15);
        [SerializeField]
        private Vector2 _intensitySunMinMax = new Vector2(4, 15);
        [SerializeField]
        private AnimationCurve _intensityCurve;
        [SerializeField]
        private float _sunsetSpeed = 1f;

        private VolumeProfile _volumeProfile;
        private HDRISky _sky;
        private float t = 2;

        private void DayNightSkyDayTransition(float t)
        {
            float delta = _intensitySkyMinMax.y - _intensitySkyMinMax.x;
            var newIntensity = _intensitySkyMinMax.x + (1f - _intensityCurve.Evaluate(t)) * delta;
            //Debug.Log($" _sky.exposure.value = {_sky.exposure.value} newIntensity = {newIntensity}");
            _sky.exposure.value = newIntensity;
        }

        private void DayNightSunDayTransition(float t)
        {
            float delta = _intensitySunMinMax.y - _intensitySunMinMax.x;
            var newIntensity = _intensitySunMinMax.x + (1f - _intensityCurve.Evaluate(t)) * delta;
           // Debug.Log($"_sun.intensity = {_sun.intensity} newIntensity = {newIntensity}");
            _sun.intensity = newIntensity;
        }

        private void OnTurnEnd(ITurnCallback callback)
        {
            t = 0f;
        }

        private void Start()
        {
            _volumeProfile = _volume.profile;
            if (_volumeProfile.TryGet<HDRISky>(out _sky))
            {
            }
            _turnBasedController.OnTurnEnd += OnTurnEnd;
        }

        private void OnDestroy()
        {
            _sky = null;
            _turnBasedController.OnTurnEnd -= OnTurnEnd;
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
