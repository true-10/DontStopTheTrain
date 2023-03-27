using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TSS_Unit : MonoBehaviour
{
    [SerializeField]
    private Transform cachedTransform;
    [SerializeField]
    private float speed;


    public void Move()
    {
        cachedTransform.position += Vector3.forward * speed * Time.deltaTime;
    }

    private void Update()
    {
        Move();
    }
}
