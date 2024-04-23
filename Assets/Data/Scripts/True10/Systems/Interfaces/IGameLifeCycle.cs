using System;
using True10.GridSystem;
using UnityEngine;

namespace True10.Interfaces
{

    public interface IGameLifeCycle
    {
        // Action OnInit { get; set;}

        void Initialize();
        void Dispose();
    }

    public abstract class AbstractGameLifeCycleBehaviour : MonoBehaviour, IGameLifeCycle
    {
        public abstract void Dispose();
        public abstract void Initialize();

        protected virtual void Start()
        {
            Initialize();
        }

        protected virtual void OnDestroy()
        {
            Dispose();
        }

    }
}
