using UnityEngine;

namespace True10.CameraSystem
{
    [CreateAssetMenu(fileName = "CameraRigComponentMove", menuName = "True10/CameraSystem/RigComponents/Move")]
    public sealed class CameraRigComponentMovement : AbstractCameraRigComponent
    {
        public enum MoveMode
        {
            Both,
            OnlyX,
            OnlyY
        }

        [SerializeField]
        private float _moveSpeed = 10f;
        [SerializeField]
        private MoveMode _moveMode = MoveMode.Both;

        private Transform cachedTransform;

        public override void Initialize(ICameraHolder cameraHolder, ICameraInputReader cameraInputReader)
        {
            base.Initialize(cameraHolder, cameraInputReader);
            cachedTransform = cameraHolder.CameraRig.Root;
        }

        public override void UpdateRig()
        {
            var hValue = _cameraInputReader.Move.x;
            var vValue = _cameraInputReader.Move.y;

            switch (_moveMode) 
            {
                case MoveMode.OnlyX:
                    vValue = 0f;
                    break;
                case MoveMode.OnlyY:
                    hValue = 0f;
                    break;
            }

            var direction = new Vector3(hValue, 0f, vValue);
            Move(direction);
        }

        public void Move(Vector3 direction)
        {
            var position = cachedTransform.position;
            var forward = cachedTransform.forward * direction.z;
            var right = cachedTransform.right * direction.x;
            position += (forward + right) * _moveSpeed * Time.deltaTime;
            cachedTransform.position = position;
        }
    }
}
