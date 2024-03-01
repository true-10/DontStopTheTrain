using DontStopTheTrain.Events;
using System.Collections;
using System.Collections.Generic;
using True10.CameraSystem;
using True10.TriggerSystem;
using UnityEngine;
using Zenject;

namespace True10.TriggerSystem
{

    public class SwitchCameraAction : AbstractTriggerActivatorMonoActionObject
    {
        [Inject]
        private ICameraController cameraController;

        [SerializeField]
        private CameraHolder cameraHolderOnEnter;
        [SerializeField]
        private CameraHolder cameraHolderOnExit;

        public override int TriggerType => 0;

        public override void OnEnterAction(IOnTriggerCallback callback)
        {
            if (IsEnable == false)
            {
                return;
            }
            if (cameraHolderOnEnter != null)
            {
                cameraController?.SwitchToCamera(cameraHolderOnEnter.HashCode);
            }
        }

        public override void OnExitAction(IOnTriggerCallback callback)
        {
            if (IsEnable == false)
            {
                return;
            }
            if (cameraHolderOnExit != null)
            {
                cameraController?.SwitchToCamera(cameraHolderOnExit.HashCode);
            }
        }

        public override void OnStayAction(IOnTriggerCallback callback)
        {

        }
    }
}
