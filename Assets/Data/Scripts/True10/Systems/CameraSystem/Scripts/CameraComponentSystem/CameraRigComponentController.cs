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

        [SerializeField] private CameraHolder _cameraHolder;
        [SerializeField] private List<AbstractCameraRigComponent> _components;
        [SerializeField] private CameraInputReader _inputReader;

        private bool _isActive = true;

        public override void Initialize()
        {
            foreach (AbstractCameraRigComponent component in _components)
            {
                component.Init(_cameraHolder, _inputReader);
            }
            _cameraController.OnCameraOn += OnCameraOn;
            _cameraController.OnCameraOff += OnCameraOff;
        }

        public override void Dispose()
        {
            _cameraController.OnCameraOn -= OnCameraOn;
            _cameraController.OnCameraOff -= OnCameraOff;
        }

        private void OnCameraOn(ICameraCallback callback)
        {
            if (callback.CameraHolder.HashCode != _cameraHolder.HashCode)
            {
                if (_isActive)
                {
                    _isActive = false;
                }
                return;
            }
            _isActive = true;
        }

        private void OnCameraOff(ICameraCallback callback)
        {
            if (callback.CameraHolder.HashCode != _cameraHolder.HashCode)
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
    }

}
