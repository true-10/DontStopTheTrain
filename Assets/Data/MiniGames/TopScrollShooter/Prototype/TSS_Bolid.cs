using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TSS_Bolid : MonoBehaviour
{
    [SerializeField]
    private Transform cachedTransform;
    [SerializeField]
    private float speed;


    public void Move()
    {
        cachedTransform.position += cachedTransform.forward * speed * Time.deltaTime;
    }

    private void Update()
    {
        Move();
    }

    private void OnCollisionEnter(Collision collision)
    {
        var unit = collision.gameObject.GetComponent<TSS_Unit>();
        if (unit != null)
        {
            Destroy(unit.gameObject);
            Destroy(gameObject);
        }
    }
}
