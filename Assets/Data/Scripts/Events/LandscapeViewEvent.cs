using System;
using System.Collections;
using System.Collections.Generic;
using True10.CameraSystem;
using UnityEngine;
using Zenject;
using UniRx;
using DG.Tweening;

namespace DontStopTheTrain.Events
{
    public class EventByTimer : IGameEvent
    {
        public int Id => throw new NotImplementedException();

        public GameEventStatus Status { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public int ActionPointPrice => throw new NotImplementedException();

        public int EventType => throw new NotImplementedException();

        public Action Fire { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Action OnComplete { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }


    public class LandscapeViewEvent : MonoBehaviour, IGameEvent //EventByTimer
    {
       // [Inject] private IGameEventController gameEventController;
        [Inject] private ICameraController cameraController;
       // [Inject] private IDispose 

        [SerializeField] private CameraHolder eventCameraHolder;
        [SerializeField] private CameraHolder defaultCameraHolder;
        [SerializeField] private float duration;
        [SerializeField] private AudioSource audioSource;
        [SerializeField] private Transform startTransform;
        [SerializeField] private Transform endTransform;

        public int Id => 1;

        public GameEventStatus Status { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public int ActionPointPrice => 0;

        public int EventType => 1;

        public Action Fire { get => FireEvent; set => throw new NotImplementedException(); }
        public Action OnComplete { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }


        void Start()
        {
            //gameEventController.AddEventToProcessor(this);
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
            eventCameraHolder.transform.DOLocalMoveZ(endTransform.position.z, duration);
            cameraController.SwitchToCamera(eventCameraHolder.HashCode);
            //��������� ������� � �������� �� ����
            //������ ����������� ������������ ���� ����� �����
            //����

            var timer = Observable.Timer(TimeSpan.FromSeconds(duration))
                .Subscribe(x =>
               {
                   audioSource.Play();
                   cameraController.SwitchToCamera(defaultCameraHolder.HashCode);
               }
                );

        }
    }
}
