using System;
using System.Collections;
using System.Collections.Generic;
using True10.CameraSystem;
using UnityEngine;
using Zenject;

namespace DontStopTheTrain.Gameplay
{
    public class CameraTargetFOV : MonoBehaviour, ICameraTargetController
    {
        [Inject] private ICameraController cameraController;
        [SerializeField] float zoomSpeed = 10f;
        [SerializeField] private Transform target;
        [SerializeField] private Vector2 minMax = new Vector2(30f, 80f);
        [SerializeField] private bool useMouseScrollWheel = false;
        [SerializeField] private bool useMouseScrollWheelReverse = true;
        [SerializeField] private KeyCode zoomInKey = KeyCode.W;
        [SerializeField] private KeyCode zoomOutKey = KeyCode.S;
        [SerializeField] CameraHolder cameraHolder;

        private float currentFov;

        public Action OnInit { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        // Start is called before the first frame update
        void Start()
        {
            currentFov = minMax.x;
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
            var camHolder = callback.CameraHolder;
            if (camHolder.HashCode == cameraHolder.HashCode)
            {
                return;
            }

        }

        // Update is called once per frame
        void Update()
        {
            var move = 0f;
            if (useMouseScrollWheel)
            {
                move = Input.GetAxis("Mouse ScrollWheel") * 10f;
            }
            else
            {
                if (Input.GetKey(zoomInKey))
                {
                    move = 1f;
                }
                if (Input.GetKey(zoomOutKey))
                {
                    move = -1f;
                }
            }
            ChangeFOV(move);
        }

        public void ChangeFOV(float value)
        {
            if (useMouseScrollWheelReverse)
            {
                value *= -1f;
            }
            currentFov += value * zoomSpeed;
            currentFov = Mathf.Clamp(currentFov, minMax.x, minMax.y);
            //currentFov = Mathf.Clamp(currentFov, minMax.y, minMax.x);
            cameraHolder.SetFOV(currentFov);
            
        }

        public void Initialize()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}