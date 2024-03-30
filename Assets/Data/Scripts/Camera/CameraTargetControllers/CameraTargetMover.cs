using System;
using System.Collections;
using System.Collections.Generic;
using True10.CameraSystem;
using UnityEngine;
using Zenject;

namespace DontStopTheTrain.Gameplay
{
    public class CameraTargetMover : MonoBehaviour, ICameraTargetController
    {
        [Inject] private ICameraController cameraController;
        [SerializeField] float moveSpeed = 10f;
        [SerializeField] CameraHolder cameraHolder;
        [SerializeField] private KeyCode toTrainStartKey = KeyCode.A;
        [SerializeField] private KeyCode toTrainEndKey = KeyCode.D;
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
            if (Input.GetKey(toTrainEndKey))
            {
                move = 1f;
            }
            if (Input.GetKey(toTrainStartKey))
            {
                move = -1f;
            }

            MoveAlongTrain(move);
        }

        public void MoveAlongTrain(float move)
        {
            var position = cachedTransform.position;
            position.z += move * moveSpeed * Time.deltaTime;
            cachedTransform.position = position;
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
