using True10.Extentions;
using UnityEngine;

namespace True10.CameraSystem
{
    [CreateAssetMenu(fileName = "CameraRigComponentZoom", menuName = "True10/CameraSystem/RigComponents/Zoom")]
    public sealed class CameraRigComponentZoom : AbstractCameraRigComponent
    {
        [SerializeField]
        private float _zoomSpeed = 10f;
        [SerializeField]
        private Vector2 minMax = new Vector2(-30f, -3f);

        private Transform target;

        public void ZoomTargetAlongZ(float value)
        {
            var zValue = target.localPosition.z;
            zValue += value * _zoomSpeed * Time.deltaTime;
            zValue = Mathf.Clamp(zValue, minMax.x, minMax.y);
            target.localPosition = target.localPosition.With(z: zValue) ;
        }

        public override void Init(ICameraHolder cameraHolder, ICameraInputReader cameraInputReader)
        {
            base.Init(cameraHolder, cameraInputReader);
            target = _cameraHolder.Follow;
            ZoomTargetAlongZ(0f);
        }

        public override void UpdateRig()
        {
            ZoomTargetAlongZ(_cameraInputReader.Zoom);
        }
    }
}
