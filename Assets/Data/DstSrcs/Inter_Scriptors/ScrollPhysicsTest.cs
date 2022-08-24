using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ScrollPhysicsTest : MonoBehaviour
{
    [SerializeField] private Rigidbody target;
    [SerializeField] private Vector3 scrollDirection;
    [SerializeField] private float scrollSpeed = 300f;
    [SerializeField] private float implulsePower = 5f;
    [SerializeField] private Vector3 implulseDirection = Vector3.up;
    [SerializeField] private Vector3 torque;

    //  const float scrollSpeed = 9.81f;
    private Vector3 impulse;
    private Vector3 startTorque;
    private Vector3 startPosition;
    private Quaternion startRotation;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = target.position;
        startRotation = target.rotation;
        startTorque = torque;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            TurnOn();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            ResetObject();
        }
    }

    private void TurnOn()
    {

        target.isKinematic = false;
        impulse = implulseDirection * implulsePower;
        DOTween.To( () => impulse, x => impulse = x, Vector3.zero, 0.01f);
        DOTween.To( () => torque, x => torque = x, Vector3.zero, 0.01f);

    }

    private void ResetObject()
    {
        target.isKinematic = true;
        target.position = startPosition;
        target.rotation = startRotation;
        torque = startTorque;
        target.velocity = Vector3.zero;        
    }

    [SerializeField] ForceMode impulseForce = ForceMode.Impulse;
    [SerializeField] ForceMode torqueForce = ForceMode.Acceleration;
    private void FixedUpdate()
    {
       // if (target == null) return;
       // if (target.isKinematic == false) return;

        var overallForce = scrollSpeed * scrollDirection + impulse;
        overallForce *= target.mass;

        target.AddForce(overallForce, impulseForce);
        target.AddTorque(torque * target.mass * 1000f, torqueForce);
    }
}
