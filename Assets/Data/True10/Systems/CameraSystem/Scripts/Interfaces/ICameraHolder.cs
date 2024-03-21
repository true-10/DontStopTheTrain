using UnityEngine;

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
        CameraRig CameraRig { get;}
        int Weight { get;}

        /// <summary>
        /// start script for control camera (move target and aim around)
        /// </summary>
        void InitCustomCameraController();
        void TurnOn();
        void TurnOff(); 
        void TurnOnPrevious();
        void SetFOV(float fov);
    }
}
