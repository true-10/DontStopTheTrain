using System;
using System.Collections;
using System.Collections.Generic;
using True10.CameraSystem;
using UnityEngine;
using Zenject;

namespace DontStopTheTrain.Gameplay
{
    public class CameraYTargetRotator : MonoBehaviour, ICameraTargetController
    {
        [Inject] private ICameraController cameraController;
        [SerializeField] float rotationSpeed = 10f;
        [SerializeField] CameraHolder cameraHolder;
        private Transform cachedTransform;

        public Action OnInit { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

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
         /*   
            var pos = cachedTransform.position;
            if ((camHolder as MonoBehaviour).TryGetComponent(out Transform transform))
            {
                pos.z = transform.position.z;
            }
            cachedTransform.position = pos;
         */
        }

        // Update is called once per frame
        void Update()
        {
            var move = 0f;
            if (Input.GetKey(KeyCode.Q))
            {
                move = 1f;
            }
            if (Input.GetKey(KeyCode.E))
            {
                move = -1f;
            }

            RotateAroundY(move);
        }

        public void RotateAroundY(float move)
        {
            var angle = move * rotationSpeed * Time.deltaTime;

            cachedTransform.Rotate(Vector3.up * angle, Space.World);
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
