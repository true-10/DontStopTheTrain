using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public abstract class Door : MonoBehaviour
{

    #region fields
    [SerializeField] private float _duration;
    [SerializeField] protected float _distance;
    #endregion

    public abstract void OpenTheDoor();
    public abstract void CloseTheDoor();

    protected void MoveLocalTransform(Transform tr, Vector3 targetPos)
    {
        tr.DOLocalMove(targetPos, _duration);
    }

    private void OnTriggerEnter(Collider other)
    {
        OpenTheDoor();
    }

    private void OnTriggerExit(Collider other)
    {
        CloseTheDoor();
    }

}
