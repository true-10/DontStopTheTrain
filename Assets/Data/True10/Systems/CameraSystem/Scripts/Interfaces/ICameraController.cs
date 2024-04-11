﻿using System;
using UnityEngine;

namespace True10.CameraSystem
{
    public interface ICameraController
    {
        Action<ICameraCallback> OnCameraOn { get; set; }
        Action<ICameraCallback> OnCameraOff { get; set; }

        void SetDefaultCamera(ICameraHolder cameraHolder);
      //  void SwitchToCamera(int hash);
        void SwitchToCamera(ICameraHolder cameraHolder);
        void SwitchToDefaultCamera();
        void SwitchToPreviousCamera();
       // void SetTargetToCamera(int hash, Transform follow, Transform lookAt);
        
        ICameraHolder GetCurrentCamera();
    }

    public interface ICameraCallback
    {
        string Name { get; }
        ICameraHolder CameraHolder { get;}
    }
}

