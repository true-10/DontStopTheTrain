using System;
using System.Collections.Generic;
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

        //private Dictionary<int, ICameraHolder> _cameras;
        private ICameraHolder _currentCamera;
        private ICameraHolder _defaultCamera;
        private ICameraHolder _previousCamera;
       // private List<int> _cameraHashesList;
        private int _currentCameraIndex = 0;
        private bool _isDisable = false;

        public void SwitchToPreviousCamera()
        {
            if (_isDisable || _previousCamera == null)
            {
                return;
            }
            SwitchToCamera(_previousCamera.HashCode);
        }

        public void SetDefaultCamera(ICameraHolder cameraHolder)
        {
            _defaultCamera = cameraHolder;
        }

        /*public void AddCamera(ICameraHolder cameraHolder)
        {
            _cameras ??= new Dictionary<int, ICameraHolder>();
            _cameraHashesList ??= new List<int>();

            if (_cameras.ContainsKey(cameraHolder.HashCode)) 
            {
                return;
            }

            _cameras.Add(cameraHolder.HashCode, cameraHolder);


            if (_cameraHashesList.Contains(cameraHolder.HashCode))
            {
                return;
            }

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
        */
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
            _currentCamera = _camerasManager.Items.FirstOrDefault(camHolder => camHolder.HashCode == hash);// _cameras[hash];

            CameraCallback cameraCalback = new CameraCallback(_currentCamera);

            OnCameraOn?.Invoke(cameraCalback);
            _currentCamera.Priority = Constants.MAX_PRIORITY;
        }

        public void SwitchToCamera(ICameraHolder cameraHolder)
        {
            SwitchToCamera(cameraHolder.HashCode);
        }

        public void SwitchToDefaultCamera()
        {
            if (_isDisable || _defaultCamera == null)
            {
                return;
            }
            SwitchToCamera(_defaultCamera.HashCode);
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

