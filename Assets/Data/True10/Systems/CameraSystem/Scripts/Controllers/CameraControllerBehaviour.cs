using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

namespace True10.CameraSystem
{

    public class CameraControllerBehaviour : MonoBehaviour, ICameraController
    {     
        public Action<ICameraCallback> OnCameraOn { get; set; }
        public Action<ICameraCallback> OnCameraOff { get; set; }

        [SerializeField] 
        private CameraHolder _defaultCameraInit;

        private Dictionary<int, ICameraHolder> _cameras;
        private ICameraHolder _currentCamera;
        private ICameraHolder _defaultCamera;
        private List<int> _cameraHashesList;
        private int _currentCameraIndex = 0;
        private bool _isDisable = false;

        private ICameraHolder _previousCamera;
        public void SwitchToPreviousCamera()
        {
            if (_isDisable || _previousCamera == null)
            {
                return;
            }
            SwitchToCamera(_previousCamera);
        }

        public void SwitchToDefaultCamera()
        {
            if (_isDisable || _defaultCamera == null)
            {
                return;
            }
            SwitchToCamera(_defaultCamera);
        }

        public void AddCamera(ICameraHolder cameraHolder)
        {
            if (_cameras == null)
            {
                _cameras = new Dictionary<int, ICameraHolder>();
            }

            if (_cameras.ContainsKey(cameraHolder.HashCode)) return;

            _cameras.Add(cameraHolder.HashCode, cameraHolder);

            if (_cameraHashesList == null)
            {
                _cameraHashesList = new List<int>();
            }

            if (_cameraHashesList.Contains(cameraHolder.HashCode)) return;

            _cameraHashesList.Add(cameraHolder.HashCode);
        }

        public void RemoveCamera(ICameraHolder cameraHolder)
        {
            if (_cameras == null)
            {
                return;
            }

            if (_cameras.ContainsKey(cameraHolder.HashCode))
            {
                return;
            }

            _cameras.Remove(cameraHolder.HashCode);
        }

        public void SwitchToCamera(ICameraHolder cameraHolder)
        {
            SwitchToCamera(cameraHolder.HashCode);
        }

        public void SwitchToCamera(int hash)
        {
            if (_isDisable) return;
            DisableAllCameras();
            _previousCamera = _currentCamera;
            _currentCamera = _cameras[hash];

            CameraCallback cameraCalback = new CameraCallback(_currentCamera);

            OnCameraOn?.Invoke(cameraCalback);
            _currentCamera.Priority = Constants.MAX_PRIORITY;        
        }

        public ICameraHolder GetCurrentCamera()
        {
            return _currentCamera;
        }

        public void SetTargetToCamera(int hash, Transform follow, Transform lookAt)
        {
            //if (isDisable) return;
            var camera = _cameras[hash];

            camera.Follow = follow;
            camera.LookAt = lookAt;
        }

        private void InitDefaultCamera()
        {
            if (_isDisable || _defaultCameraInit == null)
            {
                return;
            }
            _defaultCamera = _defaultCameraInit;
            ResetAllCameras();
            _currentCamera = _cameras[_defaultCamera.HashCode];
            _currentCamera.Priority = Constants.MAX_PRIORITY;
        }

        private void CameraUpdate()
        {
            if (_cameraHashesList == null)
            {
                Debug.Log($"CameraController: Update() (cameraNamesList == null)");
                return;

            }
            if (_cameraHashesList.Count == 0)
            {
                Debug.Log($"CameraController: Update() (cameraNamesList.Count == 0)");
                return;

            }

            _currentCameraIndex++;
            if (_currentCameraIndex > _cameraHashesList.Count - 1)
            {
                _currentCameraIndex = 0;
            }

            var camHash = _cameraHashesList[_currentCameraIndex];
            SwitchToCamera(camHash);
        }

        private void DisableAllCameras()
        {
            if (_isDisable) return;
            foreach (var camera in _cameras)
            {
                if (camera.Value.Priority != 0)
                {
                    CameraCallback cameraCalback = new CameraCallback(camera.Value);

                    camera.Value.Priority = Constants.MIN_PRIORITY;
                    OnCameraOff?.Invoke(cameraCalback);
                }
            }
        }
        
        private void ResetAllCameras()
        {
            foreach (var camera in _cameras)
            {
                camera.Value.Priority = Constants.MIN_PRIORITY;
            }
        }

        private void Start()
        {
            InitDefaultCamera();
        }

        public void SetDefaultCamera(ICameraHolder cameraHolder)
        {
            _defaultCamera = cameraHolder;
        }
    }

}

