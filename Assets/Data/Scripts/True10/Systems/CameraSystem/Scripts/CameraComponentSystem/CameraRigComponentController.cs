using System;
using System.Collections.Generic;
using True10.Interfaces;
using UnityEngine;
using Zenject;

namespace True10.CameraSystem
{
    public class CameraRigComponentController : AbstractGameLifeCycleBehaviour
    {
        [Inject]
        private ICameraController _cameraController;

        [SerializeField] 
        private CameraGroup _cameraGroup;        
        [SerializeField] 
        private List<AbstractCameraRigComponent> _components;
        [SerializeField] 
        private CameraInputReader _inputReader;
        [SerializeField] 
        private CameraRig _cameraRig;        
        [SerializeField] 
        private TransformPositionLimiter _transformPositionLimiter;

        // [SerializeField] 
        //private ICameraHolder _cameraHolder;
        private bool _isActive = false;

        public override void Initialize()
        {
            /*foreach (AbstractCameraRigComponent component in _components)
            {
                component.Initialize(_cameraHolder, _inputReader);
            }*/
            _cameraController.OnCameraOn += OnCameraOn;
            _cameraController.OnCameraOff += OnCameraOff;
        }

        private void InitializeComponents(ICameraHolder cameraHolder)
        {
            cameraHolder.SetRig(_cameraRig);
            cameraHolder.Follow = _cameraRig.Follow;
            cameraHolder.LookAt = _cameraRig.LookAt;

            if (cameraHolder.CameraRigStartPosiition != null)
            {
                _cameraRig.SetPosition(cameraHolder.CameraRigStartPosiition.position);
                _transformPositionLimiter?.SetCenterTransform(cameraHolder.CameraRigStartPosiition);
            }
            foreach (AbstractCameraRigComponent component in _components)
            {
                component.Initialize(cameraHolder, _inputReader);
            }
            _isActive = true;
        }

        public override void Dispose()
        {
            _cameraController.OnCameraOn -= OnCameraOn;
            _cameraController.OnCameraOff -= OnCameraOff;
        }

        private bool IsItCorrectGroup(int group)
        {
            return group == (int)_cameraGroup;
        }

        private void OnCameraOn(ICameraCallback callback)
        {
            if (IsItCorrectGroup(callback.CameraHolder.Group)== false) 
            {
                if (_isActive)
                {
                    _isActive = false;
                }
                return;
            }
            InitializeComponents(callback.CameraHolder);
        }

        private void OnCameraOff(ICameraCallback callback)
        {
            if (IsItCorrectGroup(callback.CameraHolder.Group) == false)
            {
                return;
            }
            _isActive = false;
        }

        private void Update()
        {
            if (_isActive == false)
            {
                return;
            }
            foreach (AbstractCameraRigComponent component in _components)
            {
                component.UpdateRig();
            }
        }

        private void OnValidate()
        {
            _cameraRig ??= GetComponent<CameraRig>();
        }
    }

}
