using DontStopTheTrain.MiniGames;
using System;
using System.Collections;
using System.Collections.Generic;
using True10.GridSystem;
using True10.Interfaces;
using UnityEngine;
using Zenject;

namespace DontStopTheTrain.Events
{
    public abstract class AbstractEventObject : AbstractGameLifeCycleBehaviour
    {
        public IEvent Event { get; private set; }
        public virtual IMiniGame MiniGame => null;
        public Action<AbstractEventObject> OnStartAnimationPlayed { get; set; }
        public bool IsStartAnimationCompleted { get; protected set; }

        [Inject]
        private EventObjectsManager _eventObjectsManager;


        public abstract void PlayStartAnimation();
        public abstract void PlayCompleteAnimation();
        
        public void SetEvent(IEvent eventData)
        {
            Event ??= eventData;
        }
        public override void Initialize()
        {
            IsStartAnimationCompleted = false;
            _eventObjectsManager.TryToAdd(this);
        }

        public override void Dispose()
        {
            _eventObjectsManager.TryToRemove(this);
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
