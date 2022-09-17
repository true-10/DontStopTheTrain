using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StationStopTrigger : MonoBehaviour
{
    #region fields
    [SerializeField] private bool _isActive = false;
    //[SerializeField] private float _speed = 30f;
    [SerializeField] private float _duration = 1f;
    #endregion

    private void OnTriggerEnter(Collider other)
    {
        if (!_isActive) return;
        TrainManager tm = other.GetComponent<TrainManager>();
        if (tm == null) return;

        tm.StopTrain(_duration);// SetSpeedBy(0f, _duration);
        //loco.SetSpeedBy(0f, _duration);
        //сообщаем гейм менеджеру что мы остановились

    }
    public void Activate(bool active)
    {
        _isActive = active;
    }
}
