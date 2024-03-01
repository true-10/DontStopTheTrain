using System;
using UnityEngine;

public abstract class MonoSingleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T _instance;
    private static object _lock = new object();
    private static bool isQuit;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = FindObjectOfType<T>();
        }
    }

    public static T Instance
    {
        get
        {
            lock (_lock)
            {
                if (isQuit) return null;
                if (_instance == null)
                {
                    _instance = FindObjectOfType<T>();
                    if (_instance == null)
                    {
                        var go = new GameObject($"[Singleton] {typeof(T).Name}");
                        _instance = go.AddComponent<T>();
                        (_instance as MonoSingleton<T>).Init();
                        DontDestroyOnLoad(go);
                    }
                }
                return _instance;
            }
        }
    }

    public abstract void Init();

    public virtual void OnDestroy()
    {
        isQuit = true;
    }
}