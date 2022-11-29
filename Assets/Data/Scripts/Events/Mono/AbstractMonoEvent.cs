using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Zenject;

namespace DontStopTheTrain.Events
{
    /// <summary>
    /// подсасываемс€ к гейм»венту
    /// </summary>
    public abstract class AbstractMonoEvent : MonoBehaviour
    {
        [Inject]
        protected IGameEventController gameEventController;

        [SerializeField]
        protected int eventId = 0;

        [SerializeField] 
        protected UnityEvent OnEventStart;
        [SerializeField]
        protected UnityEvent OnEventEnd;

        protected IGameEvent gameEvent = null;

        void Start()
        {
            Init();
        }

        private void OnDestroy()
        {
            gameEventController.OnChangeEvent -= OnChangeEvent;
        }


        protected abstract void OnChangeEvent(IGameEvent gameEvent);
        protected abstract void OnComplete();
        protected abstract void OnStart();
        protected abstract void OnTick();

        protected virtual void Init()
        {
            gameEvent = gameEventController.GetGameEventById(eventId);
            if (gameEvent == null)
            {
                Debug.Log($"AbstractMonoEvent: gameEvent [{eventId}] not found");
                return;
            }
            gameEventController.OnChangeEvent += OnChangeEvent;
            gameEvent.OnComplete += OnComplete;
            gameEvent.OnStart += OnStart;
            gameEvent.OnTick += OnTick;
        }
    }
}
