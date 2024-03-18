using UnityEngine;
using UnityEngine.Rendering.HighDefinition;
using UnityEngine.Rendering;

namespace True10.DayLightSystem
{
    public class SkyRotator : MonoBehaviour
    {
        [SerializeField]
        private Volume _volume;
        [SerializeField]
        private float _speed = 1f;

        private VolumeProfile _volumeProfile;
        private HDRISky _sky;

        private void Rotate()
        {
            _sky.rotation.value += _speed * Time.deltaTime;
            if (_sky.rotation.value >= 360f)
            {
                _sky.rotation.value = 0f;
            }
        }

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
            Rotate();
        }
    }
}
