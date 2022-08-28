using System;
using System.Collections;
using System.Collections.Generic;
using True10.CameraSystem;
using UnityEngine;

namespace DontStopTheTrain.Gameplay
{
    public class MouseLookTargetController : MonoBehaviour, ICameraTargetController
    {
        [SerializeField] private float sensitivity = 100f;
        [SerializeField] private Transform yRotationTransform;
        [SerializeField] private Transform xRotationTransform;
        [SerializeField] private Vector2 minMaxAngle = new Vector2(-30f, 30f);


        private float _signX = 1f;
        private float _signY = -1f;

        public Action OnInit { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Init()
        {
            throw new NotImplementedException();
        }

        void Start()
        {
        }

        const float RadToDegrees = 57.2958f;

        // Update is called once per frame
        void Update()
        {
            float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

            YRotationUpdate(mouseX);
            XRotationUpdate(mouseY);
        }

        private void YRotationUpdate(float mouseX)
        {
           // Debug.Log($"YRotationUpdate() mouseX = {mouseX}");
            yRotationTransform.Rotate(Vector3.up * mouseX * _signY, Space.World);
        }


        //“”“ √Œ¬ÕŒ  ¿ Œ≈ “Œ œ–Œ»—’Œƒ»“
        //–¿«Œ¡–¿“‹—ﬂ
        private void XRotationUpdate(float mouseY)
        {
            Debug.Log($"XRotationUpdate() mouseY = {mouseY} “”“ √Œ¬ÕŒ  ¿ Œ≈ “Œ œ–Œ»—’Œƒ»“");

            var xAngle = mouseY * _signX;
            var currentXRadians = xRotationTransform.localRotation.x;
            var currentAngle = currentXRadians * RadToDegrees;
            var minimum = minMaxAngle.x;
            var maximum = minMaxAngle.y;
            //“”“ √Œ¬ÕŒ  ¿ Œ≈ “Œ œ–Œ»—’Œƒ»“
            Debug.Log($"XRotationUpdate() xAngle = {xAngle} currentXRadians = {currentXRadians} currentAngle = {currentAngle}");
            if (currentAngle <= minimum)
            {
                //var x = currentAngle - minMaxAngle.x;
                var x = minimum - currentAngle;
                x *= _signX;
                if (x > xAngle)
                {
                    xAngle = x;
                }
            }

            if (currentAngle >= maximum)
            {
                // xAngle = minMaxAngle.y - currentAngle;
                var x = maximum - currentAngle;
                x *= _signX;
                if (x < xAngle)
                {
                    xAngle = x;
                }
            }
            Debug.Log($"XRotationUpdate() xAngle2 = {xAngle} currentAngle = {currentAngle}");
            xRotationTransform.Rotate(Vector3.right * xAngle, Space.Self);
        }
    }
}
