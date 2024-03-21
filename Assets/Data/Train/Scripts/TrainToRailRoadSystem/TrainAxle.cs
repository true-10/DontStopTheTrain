using System.Collections;
using System.Collections.Generic;
using True10.AnimationSystem;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Splines;

namespace DontStopTheTrain.TrainToRailRoadSystem
{

    public class TrainAxle : MonoBehaviour
    {
        [SerializeField]
        protected SplineServiceBehaviour _splineServiceBehaviour;

        [SerializeField]
        protected List<ObjectRotation> _wheels;
        [SerializeField]
        protected float _speedRotation;

        protected Transform _cachedTransform;
        protected Rigidbody _rb;
        public Transform CachedTransform { get => _cachedTransform; }

        protected void Awake()
        {
            _cachedTransform = GetComponent<Transform>();
        }

        protected void OnValidate()
        {
            _cachedTransform ??= GetComponent<Transform>();
            _rb ??= GetComponent<Rigidbody>();
        }

        // Start is called before the first frame update
        protected void Start()
        {
            _cachedTransform ??= GetComponent<Transform>();
            _rb ??= GetComponent<Rigidbody>();
            _wheels.ForEach(wheel => wheel.SetSpeedRotation(x: _speedRotation));
        }

        public void SetSpeed(float newSpeed)
        {
            _wheels.ForEach(wheel => wheel.SetSpeedRotation(x: newSpeed));
            // splineFollower.followSpeed = newSpeed;
        }

        public void SetFollow(bool isFollow)
        {
            //splineFollower.follow = isFollow;
        }

        public void SetPosition(float distance)
        {
          //  splineFollower.SetDistance(distance);
            //Debug.Log($"{name}: SetPosition() newPercent = {newPercent}");
          //  UpdateAxle();
        }

        
        protected virtual void UpdateAxle()
        {
          /*  if (splineServiceBehaviour.TryToGetTransformDataFrom(cachedTransform.position, out var newPos, out var quaternion, out var t))
            {
                cachedTransform.position = newPos;
                cachedTransform.rotation = quaternion;
            }*/
        }

       
    }

}
