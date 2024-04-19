using System;
using System.Linq;
using UnityEngine;
using Zenject;

namespace True10.CameraSystem
{
    public class CameraController : ICameraController
    {
        public Action<ICameraCallback> OnCameraOn { get; set; }
        public Action<ICameraCallback> OnCameraOff { get; set; }

        [Inject]
        private CamerasManager _camerasManager;

        private ICameraHolder _currentCamera;
        private ICameraHolder _defaultCamera;
        private ICameraHolder _previousCamera;

        private int _currentCameraIndex = 0;
        private bool _isDisable = false;

        public void SwitchToPreviousCamera()
        {
            if (_isDisable || _previousCamera == null)
            {
                return;
            }
            SwitchToCamera(_previousCamera);
        }

        public void SetDefaultCamera(ICameraHolder cameraHolder)
        {
            _defaultCamera = cameraHolder;
        }

        public ICameraHolder GetCurrentCamera()
        {
            return _currentCamera;
        }

        public void SetTargetToCamera(int hash, Transform follow, Transform lookAt)
        {
          /*  if (_cameras.ContainsKey(hash) == false)
            {
                return;
            }
            var camera = _cameras[hash];
            
            camera.Follow = follow;
            camera.LookAt = lookAt;*/
        }

        public void SwitchToCamera(int hash)
        {
            if (_isDisable) return;
            DisableAllCameras();
            _previousCamera = _currentCamera;
            _currentCamera = _camerasManager.Items.FirstOrDefault(camHolder => camHolder.HashCode == hash);

            CameraCallback cameraCalback = new CameraCallback(_currentCamera);

            OnCameraOn?.Invoke(cameraCalback);
            _currentCamera.Priority = Constants.MAX_PRIORITY;
        }

        public void SwitchToCamera(ICameraHolder cameraHolder)
        {
            if (_isDisable) return;
            DisableAllCameras();
            _previousCamera = _currentCamera;
            _currentCamera = _camerasManager.Items.FirstOrDefault(camHolder => camHolder == cameraHolder);

            CameraCallback cameraCalback = new CameraCallback(_currentCamera);

            OnCameraOn?.Invoke(cameraCalback);
            _currentCamera.Priority = Constants.MAX_PRIORITY;
        }

        public void SwitchToDefaultCamera()
        {
            if (_isDisable || _defaultCamera == null)
            {
                return;
            }
            SwitchToCamera(_defaultCamera);
        }

        private void DisableAllCameras()
        {
            if (_isDisable) return;
            foreach (var camera in _camerasManager.Items)
            {
                if (camera.Priority != 0)
                {
                    CameraCallback cameraCalback = new CameraCallback(camera);

                    camera.Priority = Constants.MIN_PRIORITY;
                    OnCameraOff?.Invoke(cameraCalback);
                }
            }
        }
    }

}

