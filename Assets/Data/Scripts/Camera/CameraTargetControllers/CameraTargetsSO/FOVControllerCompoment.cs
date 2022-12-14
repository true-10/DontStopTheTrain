using System.Collections;
using System.Collections.Generic;
using True10.CameraSystem;
using UnityEngine;
using Zenject;

namespace DontStopTheTrain.Gameplay.CameraComponents
{
    public abstract class CameraControllerComponent : ScriptableObject
    {
        [SerializeField] 
        private string ctName;
        [SerializeField, Multiline] 
        private string comment;

        protected CameraHolder cameraHolder;

       // public abstract void SetTarget(GameObject target);
        public abstract void Init(CameraHolder cameraHolder);
        public abstract void Update();
        public/* abstract*/ void OnCameraOffHandler(ICameraCallback callback) { }


    }
    
    [CreateAssetMenu(fileName = "FOVControllerCompoment", menuName = "DST/CameraControllerComponentSO/FOV")]
    public class FOVControllerCompoment : CameraControllerComponent
    {
        [SerializeField] 
        float zoomSpeed = 10f;
        [SerializeField] 
        private Vector2 minMax = new Vector2(30f, 80f);
        [SerializeField] 
        private bool useMouseScrollWheel = false;
        [SerializeField] 
        private bool useMouseScrollWheelReverse = true;
        [SerializeField] 
        private KeyCode zoomInKey = KeyCode.W;
        [SerializeField] 
        private KeyCode zoomOutKey = KeyCode.S;

        private float currentFov;

        public override void Init(CameraHolder cameraHolder)
        {
            this.cameraHolder = cameraHolder;
            currentFov = minMax.x;
        }
        public override void Update()
        {
            var move = 0f;
            if (useMouseScrollWheel)
            {
                move = Input.GetAxis("Mouse ScrollWheel") * 10f;
            }
            else
            {
                if (Input.GetKey(zoomInKey))
                {
                    move = 1f;
                }
                if (Input.GetKey(zoomOutKey))
                {
                    move = -1f;
                }
            }
            ChangeFOV(move);
        }

        public void ChangeFOV(float value)
        {
            if (cameraHolder == null)
            {
                return;
            }

            if (useMouseScrollWheelReverse)
            {
                value *= -1f;
            }
            currentFov += value * zoomSpeed;
            currentFov = Mathf.Clamp(currentFov, minMax.x, minMax.y);
            //currentFov = Mathf.Clamp(currentFov, minMax.y, minMax.x);
            cameraHolder.SetFOV(currentFov);

        }
    }
}
