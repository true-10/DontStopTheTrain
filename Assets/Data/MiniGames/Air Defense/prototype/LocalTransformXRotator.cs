using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalTransformXRotator : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 10f;
    [SerializeField] Transform target;

    private Transform cachedTransform;
    float xRotation = 0;

    void Start()
    {
        cachedTransform = target.GetComponent<Transform>();

    }

    public void RotateAroundX(float move)
    {
        xRotation -= move;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        cachedTransform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        
    }

}
