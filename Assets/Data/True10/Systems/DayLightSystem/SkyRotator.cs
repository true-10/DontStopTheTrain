using DG.Tweening;
using UnityEngine;
using UnityEngine.Rendering.HighDefinition;
using UnityEngine.Rendering;
using UnityEngine.Rendering.LookDev;

namespace True10.DayLightSystem
{
    public class SkyRotator : MonoBehaviour
    {
        [SerializeField]
        private Volume _volume;

        private VolumeProfile _volumeProfile;
        private HDRISky _sky;

        private void Start()
        {
            _volumeProfile = _volume.profile;
            if (_volumeProfile.TryGet<HDRISky>(out _sky))
            {
            }
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
            _sky.rotation.value += Time.deltaTime;
            if (_sky.rotation.value >= 360f)
            {
                _sky.rotation.value = 0f;
            }
        }
    }

}
