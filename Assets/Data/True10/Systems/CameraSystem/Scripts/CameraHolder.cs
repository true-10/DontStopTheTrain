
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using Zenject;


namespace True10.CameraSystem
{

    public class CameraHolder : MonoBehaviour, ICameraHolder
    {

        public string CameraName => gameObject.name;
        public int HashCode => gameObject.GetHashCode();//
        public int Group => _group;//
        public int Priority { get => _cinemachineVirtualCamera.m_Priority; set => _cinemachineVirtualCamera.m_Priority = value; }
        public bool IsDisabled { get => _isDisabled; set => _isDisabled = value; }
        public Transform Follow { get => _cinemachineVirtualCamera.Follow; set => _cinemachineVirtualCamera.Follow = value; }
        public Transform LookAt { get => _cinemachineVirtualCamera.LookAt; set => _cinemachineVirtualCamera.LookAt = value; }
        public CameraRig CameraRig { get => _cameraRig; set => _cameraRig = value; }
        public int Weight => _weight;

        [Inject]
        private ICameraController _cameraController;
        [Inject]
        private CamerasManager _camerasManager;

        [SerializeField]
        private CinemachineVirtualCamera _cinemachineVirtualCamera;
        [SerializeField]
        private bool _isDisabled = false;
        [SerializeField]
        private int _group = 0;
        [SerializeField]
        private CameraRig _cameraRig;
        [SerializeField]
        private List<ICameraTargetController> _cameraTargetControllers;
        [SerializeField]
        private float _defaultFOV = 60;
        [SerializeField]
        private int _weight = 60;

        public void InitCustomCameraController()
        {
            foreach (var controller in _cameraTargetControllers)
            {
                controller.Initialize();
            }
            SetFOV(_defaultFOV);
        }

        public void SwitchToThisCamera()
        {
            _cameraController.SwitchToCamera(this);
        }

        public void SwitchToDefaultCamera()
        {
            _cameraController.SwitchToDefaultCamera();
        }

        public void SwitchToPreviousCamera()
        {
            _cameraController.SwitchToPreviousCamera();
        }

        public void ShakeControl()
        {
            //тут не место?
        }

        public void SetFOV(float fov)
        {
            _cinemachineVirtualCamera.m_Lens.FieldOfView = fov;
        }

        private void OnValidate()
        {
            _cinemachineVirtualCamera ??= GetComponent<CinemachineVirtualCamera>();
        }

        private void Start()
        {
            _cinemachineVirtualCamera ??= GetComponent<CinemachineVirtualCamera>();
        }

        private void OnEnable()
        {
            _camerasManager.TryToAdd(this);
        }

        private void OnDisable()
        {
            _camerasManager.TryToRemove(this);
        }

        private void OnDestroy()
        {
            _camerasManager.TryToRemove(this);

        }
    }
}
