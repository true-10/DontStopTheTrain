using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

namespace True10.CameraSystem
{
    public class CameraCalback : ICameraCallback
    {
        //camera's info
        public string Name { get => camHolder.CameraName;}
        public ICameraHolder camHolder { get; }

        public CameraCalback(ICameraHolder camHolder)
        {
            this.camHolder = camHolder;
        }
    }
    public static class Constants
    {
        public const int MAX_PRIORITY = 10;
        public const int MIN_PRIORITY = 0;
    }

    public class CameraController : MonoBehaviour, ICameraController
    {     
        public Action<ICameraCallback> OnCameraOn { get; set; }
        public Action<ICameraCallback> OnCameraOff { get; set; }

        [SerializeField] 
        TMPro.TextMeshProUGUI cameraNameText;
        [SerializeField] 
        CameraHolder defaultCamera;

        private Dictionary<int, ICameraHolder> _cameras;
        private ICameraHolder _currentCamera;
        private List<int> _cameraHashesList;
        private int _currentCameraIndex = 0;
        private bool _isDisable = false;

        public void SwitchToDefaultCamera()
        {
            if (_isDisable || defaultCamera == null)
            {
                return;
            }
            SwitchToCamera(defaultCamera.HashCode);
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

        public void SwitchToCamera(ICameraHolder cameraHolder)
        {
            SwitchToCamera(cameraHolder.HashCode);
        }

        public void SwitchToCamera(int hash)
        {
            if (_isDisable) return;
            DisableAllCameras();
            _currentCamera = _cameras[hash];

            if (cameraNameText != null)
            {
                // cameraNameText.text = cameraName;
            }

            CameraCalback cameraCalback = new CameraCalback(_currentCamera);

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
            if (_isDisable || defaultCamera == null)
            {
                return;
            }

            ResetAllCameras();
            _currentCamera = _cameras[defaultCamera.HashCode];

            if (cameraNameText != null)
            {
                // cameraNameText.text = cameraName;
            }
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
                    CameraCalback cameraCalback = new CameraCalback(camera.Value);

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

        private void Update()
        {
#if !ENABLE_INPUT_SYSTEM

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                SwitchToDefaultCamera();
            }
#endif
        }
    }

}

