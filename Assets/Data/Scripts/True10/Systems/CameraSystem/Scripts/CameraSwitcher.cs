using System;
using System.Collections.Generic;
using System.Linq;
using True10.Extentions;
using True10.Interfaces;
using Zenject;

namespace True10.CameraSystem
{
    public enum SwitchMode
    {
        Line = 0,
        Random = 1,
        Weighted = 2,
    }
    public class CameraSwitcher : IGameLifeCycle
    {
        [Inject]
        private CamerasManager _camerasManager;
        [Inject]
        private ICameraController _cameraController;

        private List<ICameraHolder> _cameras => _camerasManager.Items
            .Where(camHolder => camHolder.Group == 1)
            .ToList();
        private ICameraHolder _currentCamera;


        public void SwitchToDefaultCamera()
        {
            _currentCamera = _cameraController.GetCurrentCamera();
            _cameraController.SwitchToDefaultCamera();
        }

        public ICameraHolder GetNextCamera(SwitchMode switchMode = SwitchMode.Weighted)
        {
            switch (switchMode)
            {
                case SwitchMode.Random:
                    return _cameras.GetRandomElement();
                case SwitchMode.Weighted:
                    return GetRandomWeightedCamera();
                case SwitchMode.Line:
                    {
                        if (_currentCamera == null)
                        {
                            return _cameras.FirstOrDefault();
                        }
                        var index = _cameras.IndexOf(_currentCamera);
                        index++;
                        if (index > _cameras.Count - 1)
                        {
                            index = 0;
                        }
                        return _cameras[index];
                    }
            }
            return GetRandomWeightedCamera();
        }

        public void Initialize()
        {
            //_currentCamera = GetNextCamera();
            //_currentCamera.SwitchToThisCamera();
            SwitchToDefaultCamera();
        }

        public void Dispose()
        {

        }

        private ICameraHolder GetRandomWeightedCamera()
        {
            var cameras = _cameras
                .OrderByDescending(holder => holder.Weight)
                .ToList();

            int total = cameras.Sum(holder => holder.Weight);

            int randomPoint = UnityEngine.Random.Range(0, total);
            var overallWeight = 0;

            for (int i = 0; i < cameras.Count; i++)
            {
                var chance = cameras[i].Weight;
                overallWeight += chance;
                if (overallWeight >= randomPoint)
                {
                    return cameras[i];
                }
            }
            return null;
        }
    }
}
