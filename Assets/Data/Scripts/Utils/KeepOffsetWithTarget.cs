using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepOffsetWithTarget : MonoBehaviour
{
    [SerializeField]
    private Transform targetTransform;

    private Transform cachedTransform;

    private Vector3 offset;

    void OnValidate()
    {
        cachedTransform ??= GetComponent<Transform>();
    }

    void Start()
    {
        cachedTransform ??= GetComponent<Transform>();
        UpdateOffset();
    }

    public void UpdateOffset()
    {
        if (targetTransform == null)
        {
            return;
        }
        offset = cachedTransform.position - targetTransform.position;
        //offset.y = 0f;
        //rotation
    }


    void Update()
    {
        if (targetTransform == null)
        {
            return;
        }
        cachedTransform.position = targetTransform.position + offset;
    }
}
