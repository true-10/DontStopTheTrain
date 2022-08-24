using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TrainDroneCam : MonoBehaviour
{
    #region fields
    public bool _disable = false;
    public bool _disabled = false;
    private Transform _transform;
    [SerializeField] private Transform _droneSlot;
    [SerializeField] private Vector3 _droneSlotOffset;
    [SerializeField] private Transform _follow;
    [SerializeField] private Transform _aim;
    [SerializeField] private Transform _trainTransform;


    [SerializeField] private float _angle;
    [SerializeField] private Vector2 _angleLimits;
    [SerializeField] private float _speed;
    [SerializeField] private float _minSpeed;

    
    #endregion

    private void Start()
    {
        _transform = GetComponent<Transform>();
    }

    private void RotationUpdate()
    {
        float xRot = Input.GetAxis("Mouse X");
        float yRot = Input.GetAxis("Mouse Y");

        Quaternion rot = _aim.localRotation;
        Vector3 rotVec = rot.eulerAngles;// + Quaternion.EulerRotation( xRot * _angle, yRot * _angle, 0.0f);
        rotVec.x -= yRot * _angle * Time.deltaTime;
        rotVec.x = Mathf.Clamp(rotVec.x, /*_xRotationOffset + */_angleLimits.x, /*_xRotationOffset + */_angleLimits.y);


        rot.eulerAngles = rotVec;
        _aim.localRotation = rot;

        rot = _transform.localRotation;
        rotVec = rot.eulerAngles;
                                 
        rotVec.y += xRot * _angle * Time.deltaTime;


        rot.eulerAngles = rotVec;
        _transform.localRotation = rot;


    }

    private void ZoomUpdate()
    {

        float zoom = Input.GetAxis("Mouse ScrollWheel");
        Vector3 pos = _follow.localPosition;
        pos.z +=  zoom * 30f * _speed * Time.deltaTime;
       // pos.z = Mathf.Clamp(pos.z, -10f, -200f);
        //pos.z += Mathf.Sign( zoom )* 30f * _speed * Time.deltaTime;


        _follow.localPosition = pos;
    }

    private void PositionAlongTrainUpdate()
    {
        
        float mov = Input.GetAxis("Vertical");
        Vector3 pos = _transform.localPosition + mov * _speed * _trainTransform.forward * Time.deltaTime ;
       // Vector3 pos = _transform.localPosition + Mathf.Sign( mov )* _speed * _trainTransform.forward * Time.deltaTime ;
        _transform.localPosition = pos;
    }

    public void OnUpdate()
    {

        if (!_disable)
        {
            RotationUpdate();
            ZoomUpdate();
            PositionAlongTrainUpdate();
         //   Debug.Log("if (!_disable)");
        }
        else
        {
            if (_disabled) return;
            BackToDroneHolder();
            _disabled = true;
           // Debug.Log("if (!_disable) else");
        }

    }

    public void BackToDroneHolder()
    {
        Sequence seq = DOTween.Sequence();

        seq.Append(_follow.DOMove(_droneSlot.position + _droneSlotOffset, 5f))
            .Append(_follow.DOMove(_droneSlot.position, 2f));
    }

}
