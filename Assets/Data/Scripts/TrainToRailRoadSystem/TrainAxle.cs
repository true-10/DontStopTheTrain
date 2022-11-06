using Dreamteck.Splines;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DontStopTheTrain.TrainToRailRoadSystem
{

    public class TrainAxle : MonoBehaviour
    {

        [SerializeField] private SplineFollower splineFollower;

        private Transform cachedTransform;
        public Transform CachedTransform { get => cachedTransform; }

        private void Awake()
        {
            cachedTransform = GetComponent<Transform>();
        }

        private void OnValidate()
        {
            if (cachedTransform == null)
            {
                cachedTransform = GetComponent<Transform>();
            }
        }

        // Start is called before the first frame update
        void Start()
        {

        }

        private void LateUpdate()
        {
            //UpdateAxle();
        }

        public void SetSpeed(float newSpeed)
        {
            splineFollower.followSpeed = newSpeed;
        }

        public void SetFollow(bool isFollow)
        {
            splineFollower.follow = isFollow;
        }

        public void SetPosition(float distance)
        {
            splineFollower.SetDistance(distance);
            //Debug.Log($"{name}: SetPosition() newPercent = {newPercent}");
            UpdateAxle();
        }

        void UpdateAxle()
        {
            var percent = splineFollower.result.percent;

            var splineSample = splineFollower.Evaluate(percent);
            cachedTransform.position = splineSample.position;
            cachedTransform.rotation = splineSample.rotation;
        }
    }

}
