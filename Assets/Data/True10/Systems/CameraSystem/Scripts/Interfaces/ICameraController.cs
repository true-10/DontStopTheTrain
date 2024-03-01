using System;
using UnityEngine;

namespace True10.CameraSystem
{
    public interface ICameraController
    {
        Action<ICameraCallback> OnCameraOn { get; set; }
        Action<ICameraCallback> OnCameraOff { get; set; }

        void SwitchToCamera(int hash);
        void SwitchToCamera(ICameraHolder cameraHolder);
        void SwitchToDefaultCamera();
        void SetTargetToCamera(int hash, Transform follow, Transform lookAt);
        void AddCamera(ICameraHolder cameraHolder);

        ICameraHolder GetCurrentCamera();
    }

    public interface ICameraCallback
    {
        string Name { get; }
        ICameraHolder camHolder { get;}
    }
}

