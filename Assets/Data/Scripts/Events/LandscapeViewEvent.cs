using System;
using System.Collections;
using System.Collections.Generic;
using True10.CameraSystem;
using UnityEngine;
using Zenject;
using UniRx;

namespace DontStopTheTrain.Events
{
    public class LandscapeViewEvent : MonoBehaviour, IGameEvent
    {
        [Inject] private IGameEventController gameEventController;
        [Inject] private ICameraController cameraController;
       // [Inject] private IDispose 

        [SerializeField] private CameraHolder cameraHolder;

        public int Id => 1;

        public GameEventStatus Status { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public int ActionPointPrice => 0;

        public int EventType => 1;

        public Action Fire { get => FireEvent; set => throw new NotImplementedException(); }
        public Action OnComplete { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }


        void Start()
        {
            gameEventController.AddEventToProcessor(this);
        }


        void Update()
        {

        }

        private void FireEvent()
        {
            cameraController.SwitchToCamera(cameraHolder.HashCode);
            //завершить событие и сообщить об этом
            //разные контроллеры обрабатывают свои ивент тайпы
            //если

            var timer = Observable.
        }
    }
}
