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

        public override void Init(ICameraHolder cameraHolder, ICameraInputReader cameraInputReader)
        {
            base.Init(cameraHolder, cameraInputReader);
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
            // direction = ClampDirection(direction);
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

        public Vector3 ClampDirection(Vector3 direction)
        {
            var dotProduct = Vector3.Dot(direction, Vector3.forward);
            Debug.Log($"CameraTargetFreeMover: dotProduct F = {dotProduct}");
            if (Mathf.Abs(dotProduct) > 0.8f)
            {
                direction = Vector3.forward;
                direction *= Mathf.Sign(dotProduct);
                return direction;
            }

            Debug.Log($"CameraTargetFreeMover: dotProduct R = {dotProduct}");
            dotProduct = Vector3.Dot(direction, Vector3.right);
            if (Mathf.Abs(dotProduct) > 0.8f)
            {
                direction = Vector3.right;
                direction *= Mathf.Sign(dotProduct);
                return direction;
            }
            return direction;
        }
    }
}
