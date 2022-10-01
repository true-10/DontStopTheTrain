using System;
using System.Collections;
using System.Collections.Generic;
using True10.CameraSystem;
using UnityEngine;
using Zenject;

namespace DontStopTheTrain.Events
{
    public class LandscapeViewEvent : MonoBehaviour, IGameEvent
    {
        [Inject] private ICameraController cameraController;

        [SerializeField] private CameraHolder cameraHolder;

        public int Id => 1;

        public GameEventStatus Status { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public int ActionPointPrice => 0;

        public int EventType => 1;

        public Action Fire { get => FireEvent; set => throw new NotImplementedException(); }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        private void FireEvent()
        {
            cameraController.SwitchToCamera(cameraHolder.HashCode);
            //завершить событие и сообщить об этом
            //разные контроллеры обрабатывают свои ивент тайпы
            //если
        }
    }
}
