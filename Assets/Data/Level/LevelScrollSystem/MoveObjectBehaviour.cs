using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObjectBehaviour : MonoBehaviour
{
    [SerializeField]
    private float speed = 10f;
    [SerializeField]
    private Vector3 direction = Vector3.back;


    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.localPosition;
        pos += direction * speed * Time.deltaTime;
        transform.localPosition = pos;
    }
}
