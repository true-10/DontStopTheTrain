using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TSS_Bolid : MonoBehaviour
{
    [SerializeField]
    private Transform cachedTransform;
    [SerializeField]
    private Rigidbody rigidbody;
    [SerializeField]
    private float speed;


    public void Move()
    {
        rigidbody.velocity = cachedTransform.forward * speed * Time.fixedDeltaTime;
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log($"TSS_Bolid: OnCollisionEnter collision = {collision.gameObject}");
        OnContact(collision.gameObject);
    }

   /* private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"TSS_Bolid: OnTriggerEnter other = {other.gameObject}");
        OnContact(other.gameObject);
    }*/

    private void OnContact(GameObject gameObject)
    {
        var unit = gameObject.GetComponent<TSS_Unit>();
        if (unit != null)
        {
            Destroy(unit.gameObject);
            Destroy(this.gameObject);
        }
    }
}
