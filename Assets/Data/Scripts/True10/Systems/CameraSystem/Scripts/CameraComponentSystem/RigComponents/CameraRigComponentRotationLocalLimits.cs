using UnityEngine;

namespace True10.CameraSystem
{
    [CreateAssetMenu(fileName = "CameraRigComponentRotationLocalLimits", menuName = "True10/CameraSystem/RigComponents/RotationLocalLimits")]
    public sealed class CameraRigComponentRotationLocalLimits : AbstractCameraRigComponent
    {
        [SerializeField]
        private RotationRigTarget _rotationTarget = RotationRigTarget.Root;
        [SerializeField]
        private bool _isLocal = true;
        [SerializeField]
        private Vector2 _xRotationLimits = new Vector2(-30f, 30f);
        [SerializeField]
        private Vector2 _yRotationLimits = new Vector2(-30f, 30f); 
        [SerializeField]
        private Vector2 _zRotationLimits = new Vector2(-30f, 30f); 
        
        private Transform cachedTransform;

        public override void Initialize(ICameraHolder cameraHolder, ICameraInputReader cameraInputReader)
        {
            base.Initialize(cameraHolder, cameraInputReader);
            cachedTransform = cameraHolder.CameraRig.LookAt;
            if (_rotationTarget == RotationRigTarget.Root)
            {
                cachedTransform = cameraHolder.CameraRig.Root;
            }
        }

        public override void UpdateRig()
        {            
            TryToLimit();
        }

        private void TryToLimit()
        {
            var eulers = cachedTransform.localEulerAngles;

            eulers.x = LocalAngleClamp(eulers.x, _xRotationLimits.x, _xRotationLimits.y);
            eulers.y = LocalAngleClamp(eulers.y, _yRotationLimits.x, _yRotationLimits.y);
            eulers.z = LocalAngleClamp(eulers.z, _zRotationLimits.x, _zRotationLimits.y);

            cachedTransform.localRotation = Quaternion.Euler( eulers);
        }


        //local angles between 0 and 360, that means angle always greater than zero
        private float LocalAngleClamp(float angle, float min, float max)
        {
            if (min > max || max < 0)
            {
                Debug.Log("LocalAngleClamp error: min value should be less than max or max below zero");
                return 0f;
            }
            if (min < 0)
            {
                if (angle > max && angle < (360 + min))
                {
                    var maxDifference = Mathf.Abs(angle - max);
                    var minDifference = Mathf.Abs(angle - (360 + min));
                    if (maxDifference > minDifference)
                    {
                        return min;
                    }
                    else
                    {
                        return max;
                    }
                }
            }
            else
            { 
                if (angle < min)
                {
                    return min;
                }
                if (angle > max)
                {
                    return max;
                }
            }
            return angle;
        }
    }
}
