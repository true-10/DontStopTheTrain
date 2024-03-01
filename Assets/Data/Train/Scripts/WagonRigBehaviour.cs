using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ChainedWagonRigBehaviour : MonoBehaviour
{
    Rigidbody rb;
    ConfigurableJoint joint;

    ChainedWagonRigBehaviour nextRig;
}

[ExecuteInEditMode]
public class WagonRigBehaviour : MonoBehaviour
{
    [SerializeField]
    protected Transform axleFrontDefaultPosition;
    [SerializeField]
    protected Transform axleRearDefaultPosition;


    [field: SerializeField, Header("Axles")]
    public Transform AxleFrontTransform { get; private set; }
    [field: SerializeField]
    public Transform AxleRearTransform { get; private set; }
    [field: SerializeField]
    public float Length { get; private set; }// 
    public float VelocityForwardDotProdutct => Vector3.Dot(rb.velocity, WagonTransform.forward);

    [field: SerializeField]
    public Transform WagonTransform { get; private set; }
    [field: SerializeField]
    public Transform VelocityTargetTransform { get; private set; }


    protected Rigidbody rb;
    [SerializeField]
    public bool stayOnTrack = true;

    public Vector3 NormalizedDirection => (AxleFrontTransform.position - AxleRearTransform.position).normalized;

    public float DistanceBetweenAxes { get; private set; }// Length

    protected void OnValidate()
    {
        WagonTransform ??= GetComponent<Transform>();
        rb ??= GetComponent<Rigidbody>();
    }

    protected void Start()
    {
        WagonTransform ??= GetComponent<Transform>();
        rb ??= GetComponent<Rigidbody>();
        WagonTransform = rb.transform;//  GetComponent<Transform>();
        DistanceBetweenAxes = Vector3.Distance(AxleFrontTransform.position, AxleRearTransform.position);
        
    }


    public virtual void UpdateRig(Vector3 newPos, Quaternion quaternion)
    {
        if (stayOnTrack == false)
        {
            return;
        }

        targetPosition = newPos;
        targetRotation = quaternion;
        HardSetoTargetTransform();

        Vector3 engineForward = WagonTransform.forward;
        if (VelocityTargetTransform != null)
        {
            engineForward = (VelocityTargetTransform.position - WagonTransform.position).normalized;
        }

        if (VelocityForwardDotProdutct < 0)
        {
            engineForward *= -1f;
        }


        rb.velocity = engineForward * rb.velocity.magnitude;
        rb.angularVelocity = Vector3.zero;

      //  Debug.Log($"{name} velocity = {rb.velocity} angularVelocity = {rb.angularVelocity} magnitude = {rb.velocity.magnitude}");
        
    }

    public void UpdateAxlesTransforms(Action<Vector3, Transform> OnGetAxelTransform)
    {
        if (stayOnTrack == false)
        {
            return;
        }
        OnGetAxelTransform?.Invoke(axleFrontDefaultPosition.position, AxleFrontTransform);
        OnGetAxelTransform?.Invoke(axleRearDefaultPosition.position, AxleRearTransform);
    }


    Vector3 targetPosition;
    Quaternion targetRotation;

    public void LerpToTargetTransform()
    {
        WagonTransform.position = Vector3.Lerp(WagonTransform.position, targetPosition, Time.deltaTime);
        WagonTransform.rotation = Quaternion.Lerp(WagonTransform.rotation, targetRotation, Time.deltaTime);
    }


    private void HardSetoTargetTransform()
    {
        WagonTransform.position = targetPosition;
        WagonTransform.rotation = targetRotation;
    }
}
