using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Splines;

namespace DontStopTheTrain.TrainToRailRoadSystem
{

    public class TrainAxle : MonoBehaviour
    {
        [SerializeField]
        protected SplineServiceBehaviour splineServiceBehaviour;

        protected Transform cachedTransform;
        protected Rigidbody rb;
        public Transform CachedTransform { get => cachedTransform; }

        protected void Awake()
        {
            cachedTransform = GetComponent<Transform>();
        }

        protected void OnValidate()
        {
            cachedTransform ??= GetComponent<Transform>();
            rb ??= GetComponent<Rigidbody>();
        }

        // Start is called before the first frame update
        protected void Start()
        {
            cachedTransform ??= GetComponent<Transform>();
            rb ??= GetComponent<Rigidbody>();
        }

        protected void FixedUpdate()
        {
        //    UpdateAxle();
        }

        public void SetSpeed(float newSpeed)
        {
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
