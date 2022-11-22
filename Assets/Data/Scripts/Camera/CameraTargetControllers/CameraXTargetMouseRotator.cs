using System;
using True10.CameraSystem;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;


namespace DontStopTheTrain.Gameplay
{

    public class CameraXTargetMouseRotator : MonoBehaviour, ICameraTargetController
    {
        [Inject] private ICameraController cameraController;

        [SerializeField] float rotationSpeed = 10f;
        [SerializeField] CameraHolder cameraHolder;
        [SerializeField] Transform target;

        private Transform cachedTransform;
        private Vector3 prevPosition = Vector3.zero;
        private bool dragEnabled = false;

        public Action OnInit { get; set; }


        void Start()
        {
            cachedTransform = target.GetComponent<Transform>();

        }

        private void OnEnable()
        {
            // cameraController.OnCameraOff += OnCameraOffHandler;

        }

        private void OnDisable()
        {
            //cameraController.OnCameraOff -= OnCameraOffHandler;
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


        void Update()
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
            var deltaY = inputPosition.y - prevPosition.y;
            RotateAroundX(-deltaY);
            prevPosition = inputPosition;

        }
        public void RotateAroundX(float move)
        {
            var angle = move / rotationSpeed;

            cachedTransform.Rotate(cachedTransform.right * angle, Space.World);
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
