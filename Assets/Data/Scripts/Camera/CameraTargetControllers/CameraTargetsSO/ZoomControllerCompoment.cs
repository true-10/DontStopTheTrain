using System.Collections;
using System.Collections.Generic;
using True10.CameraSystem;
using UnityEngine;
using Zenject;

namespace DontStopTheTrain.Gameplay.CameraComponents
{
    
    [CreateAssetMenu(fileName = "ZoomControllerCompoment", menuName = "DST/CameraControllerComponentSO/Zoom")]
    public class ZoomControllerCompoment : CameraControllerComponent
    {
        [SerializeField] 
        float zoomSpeed = 10f;
        [SerializeField] 
        private Vector2 minMax = new Vector2(-30f, -3f);
        [SerializeField] 
        private bool useMouseScrollWheel = false;
        [SerializeField] 
        private KeyCode zoomInKey = KeyCode.W;
        [SerializeField] 
        private KeyCode zoomOutKey = KeyCode.S;

        private Transform target;
        public override void Init(CameraHolder cameraHolder)
        {
            this.cameraHolder = cameraHolder;
            target = cameraHolder.Follow;
            var pos = target.localPosition;
            pos.z = minMax.x;
            target.localPosition = pos;

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
            ZoomTargetAlongZ(move);
        }

        public void ZoomTargetAlongZ(float value)
        {
            var pos = target.localPosition;
            pos.z += value * zoomSpeed * Time.deltaTime;
            pos.z = Mathf.Clamp(pos.z, minMax.x, minMax.y);
            target.localPosition = pos;
        }
    }
}
