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
        [SerializeField] private bool x = false;
        [SerializeField] private bool y = false;
        [SerializeField] private bool z = false;

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
            CheckXPosition();
            CheckYPosition();
            CheckZPosition();
        }

        private void CheckXPosition()
        {
            if (x == false)
            {
                return;
            }
            var pos = cachedTransform.position;
            if (pos.x > maxLimiter.position.x)
            {
                pos.x = maxLimiter.position.x;
            }
            if (pos.x < minLimiter.position.x)
            {
                pos.x = minLimiter.position.x;
            }

            cachedTransform.position = pos;
        }

        private void CheckYPosition()
        {
            if (y == false)
            {
                return;
            }
            var pos = cachedTransform.position;
            if (pos.y > maxLimiter.position.y)
            {
                pos.y = maxLimiter.position.y;
            }
            if (pos.y < minLimiter.position.y)
            {
                pos.y = minLimiter.position.y;
            }

            cachedTransform.position = pos;
        }

        private void CheckZPosition()
        {
            if (z == false)
            {
                return;
            }
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

        public void Initialize()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
