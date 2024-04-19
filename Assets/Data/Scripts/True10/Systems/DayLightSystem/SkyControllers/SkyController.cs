using UnityEngine;
using UnityEngine.Rendering.HighDefinition;
using UnityEngine.Rendering;
using True10.Interfaces;

namespace True10.DayLightSystem
{
    public class SkyController<SkyType> : AbstractIntensitable, IGameLifeCycle where SkyType: SkySettings
    {
        [SerializeField]
        private Volume _volume;

        private VolumeProfile _volumeProfile;
        private SkyType _sky;

        public void Dispose()
        {

        }

        public void Initialize()
        {
            if (_sky == null)
            {
                _volumeProfile = _volume.profile;
                _volumeProfile.TryGet<SkyType>(out _sky);
            }
        }

        public override void SetIntensity(float value)
        {
            Initialize();
            if (_sky != null)
            {
                _sky.exposure.value = value;
            }
        }
    }
}
