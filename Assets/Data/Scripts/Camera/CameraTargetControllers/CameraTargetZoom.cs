using System;
using System.Collections;
using System.Collections.Generic;
using True10.CameraSystem;
using UnityEngine;
using Zenject;

namespace DontStopTheTrain.Gameplay
{
    public class CameraTargetZoom : MonoBehaviour, ICameraTargetController
    {
        [Inject] private ICameraController cameraController;
        [SerializeField] float zoomSpeed = 10f;
        [SerializeField] private Transform target;
        [SerializeField] private Vector2 minMax = new Vector2(-30f, -3f);
        [SerializeField] private bool useMouseScrollWheel = false;
        [SerializeField] private KeyCode zoomInKey = KeyCode.W;
        [SerializeField] private KeyCode zoomOutKey = KeyCode.S;
        [SerializeField] CameraHolder cameraHolder;

        public Action OnInit { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        // Start is called before the first frame update
        void Start()
        {
            var pos = target.localPosition;
            pos.z = minMax.x;
            target.localPosition = pos;
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
            ZoomTargetAlongZ(move);
        }

        public void ZoomTargetAlongZ(float value)
        {
            var pos = target.localPosition;
            pos.z += value * zoomSpeed;
            pos.z = Mathf.Clamp(pos.z, minMax.x, minMax.y);
            target.localPosition = pos;
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