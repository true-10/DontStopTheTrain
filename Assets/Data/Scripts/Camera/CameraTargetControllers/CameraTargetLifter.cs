using System;
using System.Collections;
using System.Collections.Generic;
using True10.CameraSystem;
using UnityEngine;
using Zenject;

namespace DontStopTheTrain.Gameplay
{
    public class CameraTargetLifter : MonoBehaviour, ICameraTargetController
    {
        [SerializeField] float liftSpeed = 1f;
        [SerializeField] private Transform target;
        [SerializeField] private Vector2 minMax = new Vector2(1f, 13f);
        [SerializeField] CameraHolder cameraHolder;
        [SerializeField] private KeyCode liftUp = KeyCode.W;
        [SerializeField] private KeyCode liftDown = KeyCode.S;

        public Action OnInit { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Init()
        {
            throw new NotImplementedException();
        }

        public void LiftTargetAlongY(float value)
        {
            var pos = target.localPosition;
            pos.y += value;
            pos.y = Mathf.Clamp(pos.y, minMax.x, minMax.y);
            target.localPosition = pos;
        }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            var move = 0f;
            if (Input.GetKey(liftUp))
            {
                move = 1f;
            }
            if (Input.GetKey(liftDown))
            {
                move = -1f;
            }
            LiftTargetAlongY(move);
        }
    }
}
