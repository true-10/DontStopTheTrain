using UnityEngine;

namespace True10.CameraSystem
{
    public enum RotationRigTarget
    {
        Root,
        LookAt
    }

    [CreateAssetMenu(fileName = "CameraRigComponentMouseRotation", menuName = "True10/CameraSystem/RigComponents/MouseRotation")]
    public sealed class CameraRigComponentMouseRotation : AbstractCameraRigComponent
    {
        [SerializeField]
        private RotationRigTarget _rotationTarget = RotationRigTarget.Root;
        [SerializeField]
        private bool _isLocal = true;
        [SerializeField]
        private float _xRotationSpeed = 50f;
        [SerializeField]
        private float _yRotationSpeed = 50f;
      
        private Transform cachedTransform;

        public override void Init(ICameraHolder cameraHolder, ICameraInputReader cameraInputReader)
        {
            base.Init(cameraHolder, cameraInputReader);
            cachedTransform = cameraHolder.CameraRig.LookAt;
            if (_rotationTarget == RotationRigTarget.Root)
            {
                cachedTransform = cameraHolder.CameraRig.Root;
            }
        }

        public override void UpdateRig()
        {
            RotationUpdate();
        }

        private void RotationUpdate()
        {
            if (_cameraInputReader.IsRMBPressed == false)
            {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.Confined;
                return;
            }

            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            Space rotationSpace = _isLocal ? Space.Self : Space.World;
            var xRotation = -_xRotationSpeed * _cameraInputReader.MouseDelta.y;
            var yRotation = _yRotationSpeed * _cameraInputReader.MouseDelta.x;
            var eulers = new Vector3(xRotation, yRotation, 0f);

            cachedTransform.Rotate(Time.deltaTime * eulers, rotationSpace);
        }
    }
}
