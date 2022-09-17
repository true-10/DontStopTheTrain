using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dreamteck.Splines;

namespace DontStopTheTrain.TrainToRailRoadSystem
{

    public class TrainRigSplineTest : MonoBehaviour
    {
        [SerializeField] private TrainAxle frontAxle;
        [SerializeField] private TrainAxle rearAxle;
        [SerializeField] private SplineComputer splineComputer;
        [SerializeField] private float speed = 10f;
        [SerializeField] private float length = 10f;
      // [SerializeField] private float scale = 7f;
        [SerializeField] private float offset = 15f;

        private Transform rigTransform;

        private void Awake()
        {
            rigTransform = GetComponent<Transform>();
        }
        private void OnValidate()
        {
            if (rigTransform == null)
            {
                rigTransform = GetComponent<Transform>();
            }
        }

        void Start()
        {
            SetSpeed();
            SetupAxles();
            SetFollow(true);
        }

        // Update is called once per frame
        void LateUpdate()
        {            
            UpdateRig();
        }

        [NaughtyAttributes.Button("UpdateRig")]
        private void UpdateRig()
        {
            var frontAxlePosition = frontAxle.CachedTransform.position;
            var frontAxleRotation = frontAxle.CachedTransform.rotation;
            var rearAxlePosition = rearAxle.CachedTransform.position;
            var rearAxleRotation = rearAxle.CachedTransform.rotation;
            var direction = frontAxle.CachedTransform.position - rearAxle.CachedTransform.position;
            var normalizedDirection = direction.normalized;
            var newRigPos = rearAxle.CachedTransform.position + normalizedDirection * length / 2f;
            //newRigPos += normalizedDirection * offset; 
            rigTransform.position = newRigPos;

            var newRigRot = Quaternion.LookRotation(normalizedDirection);

            rigTransform.rotation = newRigRot;

            frontAxle.CachedTransform.position = frontAxlePosition;
            frontAxle.CachedTransform.rotation = frontAxleRotation;
            rearAxle.CachedTransform.position = rearAxlePosition;
            rearAxle.CachedTransform.rotation = rearAxleRotation;
        }

        [NaughtyAttributes.Button("SetDummyOnRail")]
        private void SetupAxles()
        {
            float distance = offset - length / 2f ;

            frontAxle.SetPosition( distance);

            distance = offset + length / 2f;

            rearAxle.SetPosition( distance);

            UpdateRig();
        }

        public void SetSpeed()
        {
            frontAxle.SetSpeed(speed);
            rearAxle.SetSpeed(speed);
        }

        public void SetFollow(bool isFollow)
        {
            frontAxle.SetFollow(isFollow);
            rearAxle.SetFollow(isFollow);

        }
    }
}
