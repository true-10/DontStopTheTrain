using System;
using System.Collections.Generic;
using System.Linq;
using True10.Extentions;
using True10.Interfaces;
using Zenject;

namespace True10.CameraSystem
{
    public class CameraSwitcher : IGameLifeCycle
    {
        public enum SwitchMode
        {
            Line = 0,
            Random = 1,
            Weighted = 2,
        }

        // [Inject]
        //private TurnBasedController _turnBasedController;
        [Inject]
        private CamerasManager _camerasManager;
        //[SerializeField]
        private SwitchMode _switchMode = SwitchMode.Weighted;
        //[SerializeField]
        private List<ICameraHolder> _cameras => _camerasManager.Items.Where(camHolder => camHolder.Group == 1).ToList();

        private ICameraHolder _currentCamera;

        public void Initialize()
        {
            _currentCamera = GetNextCamera();
            _currentCamera.TurnOn();
            //  _turnBasedController.OnTurnStart += OnTurnStart;
        }

        public void Dispose()
        {
            //    _turnBasedController.OnTurnStart -= OnTurnStart;
        }

        /*
        private void OnTurnStart(ITurnCallback callback)
        {
           // _currentCamera = GetNextCamera();
            //_currentCamera.TurnOn();
        }
        */
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

        public ICameraHolder GetNextCamera()
        {
            switch (_switchMode)
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
        /*
        private void Start()
        {
            Initialize();
        }

        private void OnDestroy()
        {
            Dispose();
        }*/
    }
}
