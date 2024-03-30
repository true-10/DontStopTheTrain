using System;
using System.Collections;
using System.Collections.Generic;
using True10.GridSystem;
using True10.Interfaces;
using UnityEngine;
using Zenject;

namespace DontStopTheTrain.Events
{
    public abstract class AbstractEventObject : MonoBehaviour, IGameLifeCycle
    {
        public Action<AbstractEventObject> OnStartAnimationPlayed { get; set; }
        public bool IsStartAnimationCompleted { get; protected set; }

/*        [Inject]
        public void Construct(EventObjectsManager eventObjectsManager)
        {
            _eventObjectsManager = eventObjectsManager;
        }
*/
        [Inject]
        private EventObjectsManager _eventObjectsManager;

        public abstract void PlayStartAnimation();

        public abstract void PlayCompleteAnimation();

        public virtual void Initialize()
        {
            IsStartAnimationCompleted = false;
            _eventObjectsManager.TryToAdd(this);
        }

        public virtual void Dispose()
        {
            _eventObjectsManager.TryToRemove(this);
        }

       
        private void OnEnable()// Start()
        {
            Initialize();
        }

        private void OnDisable()// OnDestroy()
        {
            Dispose();
        }


       /* public class Factory : PlaceholderFactory<AbstractEventObject>
        {
        }*/
    }

    public class EventObjectsSpawner
    {

        public AbstractEventObject Spawn(GameObject prefab)
        {
            return null;
        }
    }
}
