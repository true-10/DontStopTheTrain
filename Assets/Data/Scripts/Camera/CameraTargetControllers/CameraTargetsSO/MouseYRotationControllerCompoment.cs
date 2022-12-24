
using System.Collections;
using System.Collections.Generic;
using True10.CameraSystem;
using UnityEngine;
using Zenject;

namespace DontStopTheTrain.Gameplay.CameraComponents
{

    [CreateAssetMenu(fileName = "MouseYRotationControllerCompoment", menuName = "DST/CameraControllerComponentSO/MouseYRotation")]
    public class MouseYRotationControllerCompoment : CameraControllerComponent
    {
        [SerializeField] float rotationSpeed = 10f;
        private Transform cachedTransform;
        private Vector3 prevPosition = Vector3.zero;
        private bool dragEnabled = false;
        public override void Init(CameraHolder cameraHolder)
        {
            this.cameraHolder = cameraHolder;
            cachedTransform = cameraHolder.CameraRig.Root;

        }
        public override void Update()
        {
            int rightMouseButton = 1;
            dragEnabled = Input.GetMouseButton(rightMouseButton);
            if (dragEnabled == false)
            {
                prevPosition = Input.mousePosition;
                return;
            }
            UpdateTransform(Input.mousePosition);
        }

        private void UpdateTransform(Vector3 inputPosition)
        {
            var deltaX = inputPosition.x - prevPosition.x;
            RotateAroundY(deltaX);
            prevPosition = inputPosition;

        }
        public void RotateAroundY(float move)
        {
            var angle = move / rotationSpeed;

            cachedTransform.Rotate(Vector3.up * angle, Space.World);
        }

    }
}

