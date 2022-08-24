using UnityEngine;

public abstract class AbstractManager : MonoBehaviour, IGameLifeCycle
{
    private bool IsInit;
    public abstract void OnInit();
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
