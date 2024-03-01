using System;
using UnityEngine;

public abstract class AbstractManager : MonoBehaviour, IGameLifeCycle
{
    private bool IsInit;
    public Action OnInit { get; set; }

    public virtual void Init()
    {
        if (!IsInit)
        {
            IsInit = true;
            OnInit();
        }
    }

    public virtual void Dispose()
    {
        throw new System.NotImplementedException();
    }
}
