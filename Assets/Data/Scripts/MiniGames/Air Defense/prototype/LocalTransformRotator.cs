using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalTransformRotator : MonoBehaviour
{
    [SerializeField] 
    float rotationSpeed = 10f;
    [SerializeField]
    private Vector3 rotationVector = Vector3.up;
    [SerializeField]
    private Transform cachedTransform;

    public void RotateAround(float move)
    {
        var angle = move * rotationSpeed;

        cachedTransform.Rotate(rotationVector * angle, Space.World);
    }
}
