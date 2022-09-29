using System;
using True10.CameraSystem;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;


namespace DontStopTheTrain.Gameplay
{
    public class CameraTargetMousePanner : CameraTargetFreeMover
    {

        [SerializeField] MouseDragController mouseDragController;
        private bool dragEnabled = false;

        void Start()
        {
            cachedTransform = GetComponent<Transform>();

        }

        private void OnEnable()
        {
            mouseDragController.OnDragCallback += OnDragHandler;
        }

        private void OnDisable()
        {
            mouseDragController.OnDragCallback -= OnDragHandler;
        }

        void Update()
        {
            int middleMouseButton = 2;
            dragEnabled = Input.GetMouseButton(middleMouseButton);
        }

        public void OnDragHandler(PointerEventData eventData)
        {
            if (dragEnabled == false)
            {
                 return;
            }
            //Debug.Log($"{name} OnDrag eventData.delta.x = {eventData.delta.x} ");
            var move = 0f;
            var hValue = eventData.delta.x;
            var vValue = eventData.delta.y;

            //Debug.Log($"{name} hValue = {hValue} vValue = {vValue}");

            var direction = new Vector3(-hValue, 0f, -vValue);
            Move(direction);
        }
    }
}
