using System.Collections;
using System.Collections.Generic;
using True10.CameraSystem;
using UnityEngine;
using Zenject;

namespace DontStopTheTrain.Gameplay.CameraComponents
{

    [CreateAssetMenu(fileName = "MousePannerControllerCompoment", menuName = "DST/CameraControllerComponentSO/MousePanner")]
    public class MousePannerControllerCompoment : CameraControllerComponent
    {
        [SerializeField] protected float moveSpeed = 10f;
        private Transform cachedTransform;
        private bool dragEnabled = false;
        private Vector3 prevPosition = Vector3.zero;

        public override void Init(CameraHolder cameraHolder)
        {
            this.cameraHolder = cameraHolder;
            cachedTransform = cameraHolder.CameraRig.Root;

        }
        public override void Update()
        {
            int middleMouseButton = 2;
            dragEnabled = Input.GetMouseButton(middleMouseButton);
            if (dragEnabled == false)
            {
                prevPosition = Input.mousePosition;
                return;
            }
            Pan(Input.mousePosition);
        }

        public void Pan(Vector3 InputPos)
        {
            if (dragEnabled == false)
            {
                return;
            }
            //Debug.Log($"{name} OnDrag eventData.delta.x = {eventData.delta.x} ");
            var xDelta = InputPos.x - prevPosition.x;
            var yDelta = InputPos.y - prevPosition.y;
            var move = 0f;
            var hValue = xDelta;
            var vValue = yDelta;

            prevPosition = InputPos;
            //Debug.Log($"{name} hValue = {hValue} vValue = {vValue}");

            var direction = new Vector3(-hValue, 0f, -vValue);
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
    }
}