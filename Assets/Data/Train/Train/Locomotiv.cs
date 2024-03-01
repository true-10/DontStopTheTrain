using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Locomotiv : TrainPart//: MonoBehaviour
{
    #region fields
    [SerializeField] private LocomotivData _locomotiv_data; //переписать трайпартдата как наследник?
    [SerializeField] private Transform _endJoint;
    public Wagon _prev;

    //[SerializeField]
    private float _speed = 0f;
    [SerializeField] private float _defaultSpeed = 50f;
    private bool _isStoped = true;
    //двигатель
    //запас топлива

    private bool _isSpeedUp = false;//идет ли разгон?
    Sequence _sequence;
    #endregion

    public void Init()
    {
        _sequence = DOTween.Sequence();
        LandscapeScroller.Singleton.SetLoco(this);
     
    }

    public void OnUpdate()
    {

    }
    public void Depart()
    {
        Debug.Log("Locomotiv Depart");
        _isStoped = false;
        _isSpeedUp = true;
        _sequence.Append(DOTween.To(() => _speed, x => _speed = x, 2f, 3f))
            .Append(DOTween.To(() => _speed, x => _speed = x, 10f, 5f))
            .Append(DOTween.To(() => _speed, x => _speed = x, 37f, 5f))
            .Append(DOTween.To(() => _speed, x => _speed = x, _defaultSpeed, 8f))
            .AppendCallback(DepartSpeedUpIsComplete);
    }
    public void StopTrain(float duration)
    {
        _isStoped = true;
        SetSpeedBy(0f, duration);
    }
    public bool IsStoped()
    {
        return _isStoped && _speed < 0.1f;
    }

    void DepartSpeedUpIsComplete()
    {
        _isSpeedUp = false;
    }

    public void SetSpeedBy(float newSpeed, float duration)
    {
        if (_isSpeedUp) return;
        DOTween.To(() => _speed, x => _speed = x, newSpeed, duration);

       // _isStoped = false;
    }

    public void SetDefaultSpeed( float duration )
    {
        SetSpeedBy(_defaultSpeed, duration);
    }

    public float GetSpeed()
    {
        return _speed;
    }

    public void ReSetParams()
    {
        _speed = 0f;
        _isStoped = true;
        _isSpeedUp = false;
    }
}
