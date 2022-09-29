
using System;
using System.Collections;
using System.Collections.Generic;
using True10.CameraSystem;
using UnityEngine;
using Zenject;

namespace DontStopTheTrain.Gameplay
{
    public class CameraTargetFreeMover : MonoBehaviour, ICameraTargetController
    {
        [Inject] protected ICameraController cameraController;
        [SerializeField] protected float moveSpeed = 10f;
        [SerializeField] protected CameraHolder cameraHolder;
        [SerializeField] protected string verticalAxis = "Vertical";
        [SerializeField] protected string horizontalAxis = "Horizontal";
        protected Transform cachedTransform;

        public Action OnInit { get; set; }

        // Start is called before the first frame update
        void Start()
        {
            cachedTransform = GetComponent<Transform>();

        }

        private void OnEnable()
        {
            cameraController.OnCameraOff += OnCameraOffHandler;
        }

        private void OnDisable()
        {
            cameraController.OnCameraOff -= OnCameraOffHandler;
        }

        private void OnCameraOffHandler(ICameraCallback callback)
        {
            var camHolder = callback.camHolder;
            if (camHolder.HashCode == cameraHolder.HashCode)
            {
                return;
            }
            if (cachedTransform == null)
            {
                cachedTransform = GetComponent<Transform>();
            }
            var pos = cachedTransform.position;
            if ((camHolder as MonoBehaviour).TryGetComponent(out Transform transform))
            {
                pos.z = transform.position.z;
            }
            cachedTransform.position = pos;
        }

        // Update is called once per frame
        void Update()
        {
            var move = 0f;
            var hValue = Input.GetAxis(horizontalAxis);
            var vValue = Input.GetAxis(verticalAxis);

            Debug.Log($"{name} hValue = {hValue} vValue = {vValue}");

            var direction = new Vector3 (hValue, 0f, vValue);
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

        public void Init()
        {

        }

        public void Dispose()
        {

        }
    }
}
