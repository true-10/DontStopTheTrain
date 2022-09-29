using System;
using True10.CameraSystem;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;


namespace DontStopTheTrain.Gameplay
{
    public class CameraYTargetMouseRotator : MonoBehaviour, ICameraTargetController
    {
        [Inject] private ICameraController cameraController;
        [SerializeField] float rotationSpeed = 10f;
        [SerializeField] CameraHolder cameraHolder;
        [SerializeField] MouseDragController mouseDragController;
        private Transform cachedTransform;

        public Action OnInit { get; set; }

        // Start is called before the first frame update
        void Start()
        {
            cachedTransform = GetComponent<Transform>();

        }

        private void OnEnable()
        {
            // cameraController.OnCameraOff += OnCameraOffHandler;

            mouseDragController.OnDragCallback += OnDragHandler;
        }

        private void OnDisable()
        {
            //cameraController.OnCameraOff -= OnCameraOffHandler;
            mouseDragController.OnDragCallback -= OnDragHandler;
        }

        private void OnCameraOffHandler(ICameraCallback callback)
        {
            var camHolder = callback.camHolder;
            if (camHolder.HashCode == cameraHolder.HashCode)
            {
                return;
            }
            /*   
               var pos = cachedTransform.position;
               if ((camHolder as MonoBehaviour).TryGetComponent(out Transform transform))
               {
                   pos.z = transform.position.z;
               }
               cachedTransform.position = pos;
            */
        }


        private bool dragEnabled = false;
        void Update()
        {
            var move = 0f;
            int rightMouseButton = 1;
            dragEnabled = Input.GetMouseButton(rightMouseButton);
        }

        public void RotateAroundY(float move)
        {
            var angle = move / rotationSpeed;// /* rotationSpeed*/ * Time.deltaTime;

            cachedTransform.Rotate(Vector3.up * angle, Space.World);
        }

        public void OnDragHandler(PointerEventData eventData)
        {
            if (dragEnabled == false)
            {
                return;
            }
            Debug.Log($"{name} OnDrag eventData.delta.x = {eventData.delta.x} ");
            RotateAroundY(eventData.delta.x);// / rotationSpeed);
        }

        public void Init()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
