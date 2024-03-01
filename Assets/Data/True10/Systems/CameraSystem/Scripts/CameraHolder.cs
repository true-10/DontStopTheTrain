
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using Zenject;


namespace True10.CameraSystem
{
    public interface ICameraHolder
    {
        string CameraName { get; }
        int HashCode { get; }
        int Group { get; }
        int Priority { get; set; }
        bool IsDisabled { get; set; }
        Transform Follow { get; set; }
        Transform LookAt { get; set; }
        CameraRig CameraRig { get; set; }
        int Weight { get; set; }

        /// <summary>
        /// start script for control camera (move target and aim around)
        /// </summary>
        void InitCustomCameraController();

        void SetFOV(float fov);
    }

    public class CameraHolder : MonoBehaviour, ICameraHolder
    {
        [Inject]
        private ICameraController _cameraController;

        public string CameraName => gameObject.name;
        public int HashCode => gameObject.GetHashCode();//
        public int Group => group;//

        public int Priority { get => _cinemachineVirtualCamera.m_Priority; set => _cinemachineVirtualCamera.m_Priority = value; }
        public bool IsDisabled { get => _isDisabled; set => _isDisabled = value; }
        public Transform Follow { get => _cinemachineVirtualCamera.Follow; set => _cinemachineVirtualCamera.Follow = value; }
        public Transform LookAt { get => _cinemachineVirtualCamera.LookAt; set => _cinemachineVirtualCamera.LookAt = value; }
        public CameraRig CameraRig { get => cameraRig; set => cameraRig = value; }
        public int Weight { get; set; }


        [SerializeField]
        private CinemachineVirtualCamera _cinemachineVirtualCamera;
        [SerializeField]
        private bool _isDisabled = false;
        [SerializeField]
        private int group = 0;
        [SerializeField]
        private CameraRig cameraRig;
        [SerializeField]
        private List<ICameraTargetController> _cameraTargetControllers;
        [SerializeField]
        private float _defaultFOV = 60;

        public void InitCustomCameraController()
        {
            foreach (var controller in _cameraTargetControllers)
            {
                controller.Init();
            }
            SetFOV(_defaultFOV);
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

        private void Awake()
        {
            _cameraController.AddCamera(this);
        }
    }
}
