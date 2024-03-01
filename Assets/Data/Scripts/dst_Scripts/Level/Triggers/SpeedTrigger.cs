using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class SpeedTrigger : MonoBehaviour
{
    #region fields
    [SerializeField] private bool _setDefaultSpeed = false;
    [SerializeField] private float _speed = 30f;
    [SerializeField] private float _duration = 1f;
    [SerializeField] private CinemachineVirtualCamera _cam;
    #endregion

    private void OnTriggerEnter(Collider other)
    {
        TrainManager tm = other.GetComponent<TrainManager>();
        if (tm == null) return;
        if ( _setDefaultSpeed )
        {
            tm.SetDefaultSpeed(_duration);
        }
        else
        {
            tm.SetSpeedBy(_speed, _duration);
        }
        if(_cam != null )
        {
           // CameraManager.Singleton.SetMainCamera(_cam);
        }
        
    }
}
