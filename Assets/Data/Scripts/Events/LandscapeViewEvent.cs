using System;
using System.Collections;
using System.Collections.Generic;
using True10.CameraSystem;
using UnityEngine;
using Zenject;
using UniRx;
using DG.Tweening;
using DontStopTheTrain.Gameplay;

namespace DontStopTheTrain.Events
{
    public class EventByTimer //: IGameEvent
    {
        public int Id => throw new NotImplementedException();

        public GameEventStatus Status { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public int ActionPointPrice => throw new NotImplementedException();

        public int EventType => throw new NotImplementedException();

        public Action Fire { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Action OnComplete { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }


    public class LandscapeViewEvent : AbstractMonoEvent
    {
        [Inject] private IGameEventController gameEventController;
        [Inject] private ICameraController cameraController;
        [Inject] private ITurnController turnController;
        // [Inject] private IDispose 

        [SerializeField] private CameraHolder eventCameraHolder;
        [SerializeField] private CameraHolder defaultCameraHolder;
        [SerializeField] private float duration;
        [SerializeField] private AudioSource audioSource;
        [SerializeField] private Transform startTransform;
        [SerializeField] private Transform endTransform;

        public int Id => 1;



        void Start()
        {
            //gameEventController.AddEventToProcessor(this);
            turnController.OnTurnEnd += OnTurnEndHandler;
            eventCameraHolder.transform.position = startTransform.position;
        }

        private void OnTurnEndHandler(ITurnCallback callback)
        {
            FireEvent();
        }

            void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                FireEvent();
            }
        }

        private void FireEvent()
        {
            eventCameraHolder.transform.position = startTransform.position;
            eventCameraHolder.transform
                .DOLocalMoveZ(endTransform.position.z, duration)
                .SetEase(Ease.Linear);

            cameraController.SwitchToCamera(eventCameraHolder.HashCode);
            //завершить событие и сообщить об этом
            //разные контроллеры обрабатывают свои ивент тайпы
            //если

            var timer = Observable.Timer(TimeSpan.FromSeconds(duration))
                .Subscribe(x =>
               {
                   if (audioSource != null)
                   {
                       audioSource?.Play();
                   }
                   cameraController.SwitchToCamera(defaultCameraHolder.HashCode);
                   eventCameraHolder.transform.position = startTransform.position;
                  // OnComplete?.Invoke();
               }
                );

        }

        protected override void OnChangeEvent(IGameEvent gameEvent)
        {
            throw new NotImplementedException();
        }

        protected override void OnComplete()
        {
            throw new NotImplementedException();
        }

        protected override void OnStart()
        {
            throw new NotImplementedException();
        }

        protected override void OnTick()
        {
            throw new NotImplementedException();
        }
    }
}
