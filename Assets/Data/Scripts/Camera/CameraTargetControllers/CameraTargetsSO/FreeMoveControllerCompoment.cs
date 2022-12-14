using System.Collections;
using System.Collections.Generic;
using True10.CameraSystem;
using UnityEngine;
using Zenject;

namespace DontStopTheTrain.Gameplay.CameraComponents
{

    [CreateAssetMenu(fileName = "FreeMoveControllerCompoment", menuName = "DST/CameraControllerComponentSO/FreeMove")]
    public class FreeMoveControllerCompoment : CameraControllerComponent
    {
        [SerializeField] protected float moveSpeed = 10f;
        [SerializeField] protected string verticalAxis = "Vertical";
        [SerializeField] protected string horizontalAxis = "Horizontal";

        protected Transform cachedTransform;
        public override void Init(CameraHolder cameraHolder)
        {
            this.cameraHolder = cameraHolder;
            cachedTransform = cameraHolder.CameraRig.Root;

        }
        public override void Update()
        {
            var move = 0f;
            var hValue = Input.GetAxis(horizontalAxis);
            var vValue = Input.GetAxis(verticalAxis);

            // Debug.Log($"{name} hValue = {hValue} vValue = {vValue}");

            var direction = new Vector3(hValue, 0f, vValue);
            // direction = ClampDirection(direction);
            Move(direction);
        }

        public void Move(Vector3 direction)
        {
            var position = cachedTransform.position;
            var forward = cachedTransform.forward * direction.z;
            var rigth = cachedTransform.right * direction.x;
            position += (forward + rigth) * moveSpeed * Time.deltaTime;
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

        
         //вызывать в ComponentCameraController
        /*public void OnCameraOffHandler(ICameraCallback callback)
        {
            var camHolder = callback.camHolder;
            if (camHolder.HashCode == cameraHolder.HashCode)
            {
                return;
            }

            var pos = cachedTransform.position;
            if ((camHolder as MonoBehaviour).TryGetComponent(out Transform transform))
            {
                pos.z = transform.position.z;
            }
            cachedTransform.position = pos;
        }*/
    }
}

