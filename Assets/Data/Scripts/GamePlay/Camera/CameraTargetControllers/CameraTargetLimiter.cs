using System;
using System.Collections;
using System.Collections.Generic;
using True10.CameraSystem;
using UnityEngine;

namespace DontStopTheTrain.Gameplay
{

    public class CameraTargetLimiter : MonoBehaviour, ICameraTargetController
    {
        [SerializeField] private Transform minLimiter;
        [SerializeField] private Transform maxLimiter;

        private Transform cachedTransform;

        public Action OnInit { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        // Start is called before the first frame update
        void Start()
        {
            cachedTransform = GetComponent<Transform>();
        }

        // Update is called once per frame
        void LateUpdate()
        {
            CheckPosition();
        }

        private void CheckPosition()
        {
            var pos = cachedTransform.position;
            if (pos.z > maxLimiter.position.z)
            {
                pos.z = maxLimiter.position.z;
            }
            if (pos.z < minLimiter.position.z)
            {
                pos.z = minLimiter.position.z;
            }

            cachedTransform.position = pos;
        }

        public void Init()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
