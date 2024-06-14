using UnityEngine;
using UnityEngine.Rendering;
using True10.Interfaces;
using UnityEngine.Rendering.HighDefinition;
using UnityEngine.Rendering.LookDev;

namespace True10.DayLightSystem
{
    public class CloudLayerController : MonoBehaviour, IGameLifeCycle
    {
        [SerializeField]
        private Volume _volume;
        [SerializeField]
        private float _speed;

        private VolumeProfile _volumeProfile;
        private CloudLayer _cloudLayer;

        public void SetSpeed(float newSpeed)
        {
            _speed = newSpeed;
        }
        /*
        private void Rotate(CloudLayer.CloudMap layer, float progress)
        {
            layer.rotation.value = 360f * progress;
        }*/

        private void Rotate()
        {
            if (_cloudLayer == null)
            {
                return;
            }
            var layerA = _cloudLayer.layerA;
            Rotate(layerA);
        }
        private void Rotate(CloudLayer.CloudMap layer)
        {
            layer.rotation.value += _speed * Time.deltaTime;
            if (layer.rotation.value >= 360f)
            {
                layer.rotation.value = 0f;
            }
        }

        public void Initialize()
        {
            _volumeProfile = _volume.profile;
            _volumeProfile.TryGet<CloudLayer>(out _cloudLayer);
        }

        public void Dispose()
        {

        }

        private void Update()
        {
            Rotate();
        }

        private void OnEnable()
        {
            Initialize();
        }

        private void OnDisable()
        {
            Dispose();
        }
    }
}
