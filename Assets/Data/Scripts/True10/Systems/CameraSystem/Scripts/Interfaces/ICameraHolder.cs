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
        Transform CameraRigStartPosiition { get; }
        CameraRig CameraRig { get;}
        int Weight { get;}

        void SwitchToThisCamera();
        void SwitchToDefaultCamera(); 
        void SwitchToPreviousCamera();
        void SetFOV(float fov);

        void SetRig(CameraRig rig);
    }
}
