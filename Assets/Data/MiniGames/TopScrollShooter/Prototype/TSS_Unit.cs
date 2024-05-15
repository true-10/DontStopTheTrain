using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TSS_Unit : MonoBehaviour
{
    [SerializeField]
    private Transform cachedTransform;
    [SerializeField]
    private Rigidbody rigidbody;
    [SerializeField]
    private float speed = 1000f;


    public void Move()
    {
        rigidbody.velocity = cachedTransform.forward * speed * Time.fixedDeltaTime;
    }

    private void FixedUpdate()
    {
        Move();
    }
}
