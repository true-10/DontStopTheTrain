using DontStopTheTrain.Events;
using DontStopTheTrain.Train;
using System;
using System.Collections.Generic;
using True10;
using True10.Interfaces;
using UnityEngine;
using Zenject;
using static UnityEngine.InputSystem.PlayerInput;

namespace DontStopTheTrain
{
    public sealed class WagonSystemView : BaseClickableView
    {
        public IEvent ActiveEvent { get; private set; }
        public IWagonSystem WagonSystem { get; private set; }

        public bool IsClickable
        { 
            get
            {
                return _clickableView.IsClickable;
            }
            set
            {
                _clickableView.IsClickable = value;
            }
}

        [Inject]
        private WagonSystemsFabric _fabric;

        [SerializeField]
        private List<WagonEventType> _wagonEventTypes;
        [SerializeField]
        private WagonEventViewer _wagonEventViewer;
        [SerializeField]
        private Transform _lookAtTransform;
        [SerializeField]
        private WagonSystemUIOnClick _wagonSystemUIOnClick;
        [SerializeField]
        private WagonSystemStaticDataBase _wagonSystemStaticDataBase;

        public override void Initialize()
        {
            base.Initialize();
            WagonSystem = _fabric.Create(_wagonSystemStaticDataBase);
            WagonSystem.Initialize();
            (WagonSystem as BaseWagonSystem).SetViewer(_wagonEventViewer);
            //добавить систему в менеджер?
            _wagonSystemUIOnClick.SetSystem(WagonSystem);

            _wagonEventViewer.OnSetEvent += OnSetEvent;

        }

        public override void Dispose()
        {
            base.Dispose();
            WagonSystem.Dispose();


            _wagonEventViewer.OnSetEvent -= OnSetEvent;
        }

        private void OnSetEvent(IEvent eventData)
        {
            ActiveEvent = eventData;
            _wagonSystemUIOnClick.SetEvent(eventData);

        }

    }
}
