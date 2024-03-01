using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Splines;

namespace True10.SplinesHelper
{
    public class SnapToSpline : MonoBehaviour
    {

        //[SerializeField]
       // protected SplineServiceBehaviour splineServiceBehaviour;
        [SerializeField]
        private Transform target;
        [SerializeField, Tooltip("The target spline to follow.")]
        private SplineContainer splineContainer;

        private GameObject splineContainerGO => splineContainer.gameObject;

        private Spline trackSpline => splineContainer.Spline;
        private float length;

        private void Start()
        {
            length = splineContainer.CalculateLength();

          //  Debug.Log($"SnapToSpline: length = {length} ");
        }

        public void SetSplineContainer(SplineContainer splineContainer)
        {
            //if(splineContainer == null)
            this.splineContainer = splineContainer;

            length = splineContainer.CalculateLength();
        }



        [NaughtyAttributes.Button("TrackToSpline")]
        public void TrackToSpline()
        {
            if (TryToGetTransformDataFrom(target.transform.position, out var newPos, out var newRot, out var distance))
            {
                target.transform.position = newPos;
                target.transform.rotation = newRot;
            }

        }
     /*   public void TrackToSpline(out float distance, SplineContainer splineContainer = null)
        {
            if (this.splineContainer == null)// || target.CanMove == false)
            {
                if (splineContainer == null)
                {
                    distance = 0f;
                    return;
                }
                SetSplineContainer(splineContainer);
            }
            if (TryToGetTransformDataFrom(target.transform.position, out var newPos, out var newRot, out distance))
            {
                target.transform.position = newPos;
                target.transform.rotation = newRot;
            }
        }*/


        public Vector3 GetPoint(float t)
        {
            return Vector3.zero;
        }

        public float GetDistance(float t)
        {
            return length * t;
        }

        public float GetTFromDistance(float distance)
        {
            return Mathf.Abs(distance) / length;
        }

        public bool TryToGetTransformDataFrom(Vector3 from, out Vector3 newPosition, out Quaternion newRotation, out float distance)
        {
            var native = new NativeSpline(trackSpline);
            var splinePos = splineContainerGO.transform.position;
            splinePos.y = 0;

            float3 targetCurrentPosition = new float3(from - splinePos);
            distance = SplineUtility.GetNearestPoint(native, targetCurrentPosition, out var nearest, out var t);
            Evaluate(t, out newPosition, out newRotation, out distance);
            newPosition.z = from.z;
            return true;
        }

        public void Evaluate(float t, out Vector3 newPosition, out Quaternion newRotation, out float distance)
        {
            splineContainer.Evaluate(t, out var nearest, out var tangent, out var upVector);
            newPosition = new Vector3(nearest.x, nearest.y, nearest.z);
            // newPos += splinePos;
            distance = GetDistance(t);
            //Vector3 tangent = splineContainer.EvaluateTangent(t);

            var forward = Vector3.Normalize(tangent);
            var up = splineContainer.EvaluateUpVector(t);

            newRotation = Quaternion.LookRotation(forward, upVector);
        }
    }
}
