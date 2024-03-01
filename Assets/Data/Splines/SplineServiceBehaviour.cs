using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Splines;

//spline extruder
//spline mesh renderer

public class SplineServiceBehaviour : MonoBehaviour
{
    [SerializeField, Tooltip("The target spline to follow.")]
    private SplineContainer splineContainer;
    [SerializeField]
    private int resolution = 4;
    [SerializeField]
    private int iterations = 2;


   // private float length;

    private void OnValidate()
    {
        splineContainer ??= GetComponent<SplineContainer>();
    }

    void Start()
    {
        splineContainer ??= GetComponent<SplineContainer>();

     //   length = splineContainer.CalculateLength();

       // Debug.Log($"SnapToSpline: length = {length} ");
    }

    public bool TryToGetTransformDataFrom(Vector3 from, out Vector3 newPosition, out Quaternion newRotation, out float t/*, out float distance*/)
    {
        var native = new NativeSpline(splineContainer.Spline);
        var splinePos = splineContainer.transform.position;
        //splinePos.y = 0;

        float3 targetCurrentPosition = new float3(from - splinePos);
        var distance = SplineUtility.GetNearestPoint(native, targetCurrentPosition, 
            out var nearest, out t, 
            resolution: resolution, iterations: iterations);


        //Evaluate(t, out newPosition, out newRotation, out distance);
        newPosition.x = nearest.x;
        newPosition.y = nearest.y;
        newPosition.z = nearest.z;
        newPosition.z = from.z;
        //newPosition = new Vector3(nearest.x, nearest.y, from.z);

        var tangent = splineContainer.EvaluateTangent(t);

        var forward = Vector3.Normalize(tangent);
        var upVector = splineContainer.EvaluateUpVector(t);

        newRotation = Quaternion.LookRotation(forward, upVector);
        return true;
    }

    public void Evaluate(float t, out Vector3 newPosition, out Quaternion newRotation, out float distance)
    {
        splineContainer.Evaluate(t, out var nearest, out var tangent, out var upVector);
        newPosition = new Vector3(nearest.x, nearest.y, nearest.z);
        
        var splinePos = splineContainer.transform.position;
        newPosition += splinePos;
        
        distance = 0f;// GetDistance(t);
                      //Vector3 
        tangent = splineContainer.EvaluateTangent(t);

        var forward = Vector3.Normalize(tangent);
        //var up = splineContainer.EvaluateUpVector(t);

        newRotation = Quaternion.LookRotation(forward, upVector);
    }

    /*
    public Vector3 GetPoint(float t)
    {
        return Vector3.zero;
    }

    public float GetDistance(float t)
    {
        return length * t;
    }

    public float DelatT => 1f / length;

    public float GetTFromDistance(float distance)
    {
        return Mathf.Abs(distance) / length;
    }*/
}
