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
            TryToLimit();
        }

        private void TryToLimit()
        {
            var eulers = cachedTransform.localEulerAngles;

            eulers.x = LocalAngleClamp(eulers.x, _xRotationLimits.x, _xRotationLimits.y);
           // eulers.y = LocalAngleClamp(eulers.y, _yRotationLimits.x, _yRotationLimits.y);
            //eulers.z = LocalAngleClamp(eulers.z, _zRotationLimits.x, _zRotationLimits.y);

            cachedTransform.localRotation = Quaternion.Euler( eulers);
            //cachedTransform.
            /* Debug.Log($"eulers = {eulers} rotation = {cachedTransform.rotation}");
             var lowerLimit = _xRotationLimits.x;
             var upperLimit = _xRotationLimits.y;
             var currentX = eulers.x;
             if (lowerLimit < 0)
             {
                 lowerLimit = 360f + _xRotationLimits.x;
             }
             if (upperLimit < 0)
             {
                 upperLimit = 360f + _xRotationLimits.y;
             }

             if (currentX > upperLimit && currentX < lowerLimit)
               {
                   eulers.x = _xRotationLimits.x;
               }
             else
             if (currentX < upperLimit && currentX > lowerLimit && currentX - lowerLimit)
             {
                 eulers.x = _xRotationLimits.y;
             }

             eulers.z = 0f;
             cachedTransform.localEulerAngles = eulers;*/
        }


        //local angles between 0 and 360
        private float LocalAngleClamp(float angle, float min, float max)
        {
            if (min > max)
            {
                Debug.Log("LocalAngleClamp error: min value should be less than max");
                return 0f;
            }
            var offset = 0f;
            if (min < 0f)
            {
                offset = min;
            }
            if (angle <= 0f)
            {
                ;
            }
            var returnAngle = angle - offset;
            var offsetedMin = min - offset;
            var offsetedMax = max - offset;
            if (returnAngle < offsetedMin)
            {
                returnAngle = offsetedMin;
            }
            if (returnAngle > offsetedMax)
            {
                returnAngle = offsetedMax;
            }
            return returnAngle + offset;
        }
    }
}
