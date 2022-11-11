using System;
using True10.CameraSystem;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;


namespace DontStopTheTrain.Gameplay
{
    public class CameraTargetMousePanner : CameraTargetFreeMover
    {

        private bool dragEnabled = false;
        private Vector3 prevPosition = Vector3.zero;

        void Start()
        {
            cachedTransform = GetComponent<Transform>();

        }

        private void OnEnable()
        {
           // mouseDragController.OnDragCallback += OnDragHandler;
        }

        private void OnDisable()
        {
            //mouseDragController.OnDragCallback -= OnDragHandler;
        }

        void Update()
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
    }
}
