using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleDoor : Door
{
    #region fields
    [SerializeField] private Transform _doorTransform;
    private Vector3 _doorClosePos;
    private Vector3 _doorOpenPos;
    #endregion

    private void Start()
    {
        _doorClosePos = _doorTransform.localPosition;
        _doorOpenPos = _doorTransform.localPosition + _doorTransform.right * _distance;
        CloseTheDoor();
    }
    public override void OpenTheDoor()
    {
        MoveLocalTransform(_doorTransform, _doorOpenPos);
    }

    public override void CloseTheDoor()
    {
        MoveLocalTransform(_doorTransform, _doorClosePos);
    }
}
