using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleDoor : Door
{
    #region fields
    [SerializeField] private Transform _doorTransform1;
    [SerializeField] private Transform _doorTransform2;
    private Vector3 _doorClosePos;
    private Vector3 _doorOpenPos;
    #endregion

    private void Start()
    {
        _doorClosePos = _doorTransform1.localPosition;
        _doorOpenPos = _doorTransform1.localPosition + _doorTransform1.right * _distance;
        CloseTheDoor();
    }
    public override void OpenTheDoor()
    {
        MoveLocalTransform(_doorTransform1, _doorOpenPos);
        MoveLocalTransform(_doorTransform2, -_doorOpenPos);
    }

    public override void CloseTheDoor()
    {
        MoveLocalTransform(_doorTransform1, _doorClosePos);
        MoveLocalTransform(_doorTransform2, -_doorClosePos);
    }
}
