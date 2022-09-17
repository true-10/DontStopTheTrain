using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraManager : MonoBehaviour
{
    #region fields
    public static CameraManager Singleton;
    [SerializeField] List<CinemachineVirtualCamera> _cameras;
    private CinemachineVirtualCamera _currentCam;
    #endregion

    private void Awake()
    {
        if(Singleton == null)
        {
            Singleton = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        _cameras.AddRange(FindObjectsOfType<CinemachineVirtualCamera>());
    }

    void ResetAllCameras()
    {
        foreach(CinemachineVirtualCamera vc in _cameras)
        {
            vc.Priority = 0;
        }
    }

    public void AddCamera(CinemachineVirtualCamera cam)
    {
        if (cam == null) return;
        _cameras.Add(cam);
    }

    public void SetMainCamera(CinemachineVirtualCamera cam)
    {
        if( _currentCam != null ) _currentCam.Priority = 0;
        _currentCam = cam;
        _currentCam.Priority = 10;
    }
}
