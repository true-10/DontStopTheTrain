using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamData : MonoBehaviour
{
    #region fields

    [SerializeField] private LayerMask _cullingMask;
    [SerializeField] private GameObject _objActivateOnEnable;
    //параметры виртуальной камеры
    //сдвиг, фов и прочее
    #endregion
        /*
    public void OnActivate()
    {
        _objActivateOnEnable.SetActive(true);
    }

    public void OnDeactivate()
    {
        _objActivateOnEnable.SetActive(false);

    }
    */
}
