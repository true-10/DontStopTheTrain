using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BasicTrigger : MonoBehaviour
{
    #region fields

    [SerializeField] private string _activatorTag = "Player";

    public UnityEvent OnEnter;
    public UnityEvent OnExit;
    public UnityEvent OnStay;
    #endregion

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag(_activatorTag)) return;
        OnEnter.Invoke();
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag(_activatorTag)) return;
        OnExit.Invoke();

    }

    private void OnTriggerStay(Collider other)
    {
        if (!other.CompareTag(_activatorTag)) return;
        OnStay.Invoke();
    }
}
