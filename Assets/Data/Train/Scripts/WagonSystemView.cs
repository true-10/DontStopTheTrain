using DontStopTheTrain.Events;
using DontStopTheTrain.Train;
using DontStopTheTrain.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace DontStopTheTrain
{
    public class WagonSystemView : BasicView
    {
        public IEvent ActiveEvent { get; private set; }
        public IWagonSystem WagonSystem { get; private set; }

        [Inject]
        private UIController _uiController;
        [Inject]
        private WagonSystemsFabric _fabric;

        [SerializeField]
        private List<WagonEventType> _wagonEventTypes;
        [SerializeField]
        private WagonEventViewer _wagonEventViewer;
        [SerializeField]
        private Transform _lookAtTransform;
        [SerializeField]
        private WagonSystemStaticDataBase _wagonSystemStaticDataBase;

        private void OnSetEvent(IEvent eventData)
        {
            ActiveEvent = eventData;
            if (eventData == null)
            {
                if (_wagonEventViewer.IsFree)
                {
                   // _wagonEventViewer.
                }
            }
        }

        public override void OnMouseOverEnterHandler()
        {
            if (ActiveEvent != null)
            {
                if (_uiController.EventInfoPopup.IsAnchored == false)
                {
                    _uiController.EventInfoPopup.Show(ActiveEvent, _lookAtTransform);
                }
            }
            else 
            {
                if (_uiController.SystemInfoPopup.IsAnchored == false)
                {
                    _uiController.SystemInfoPopup.Show(WagonSystem, _lookAtTransform);//, this);
                }
            }
        }

        public override void OnMouseOverExitHandler()
        {
            if (ActiveEvent != null)
            {
                if (_uiController.EventInfoPopup.IsAnchored == false)
                {
                    _uiController.EventInfoPopup.CloseView();
                }
                ActiveEvent = null;
            }
            else
            {
                if (_uiController.SystemInfoPopup.IsAnchored == false)
                {
                    _uiController.SystemInfoPopup.CloseView();
                }
            }
        }

        public override void OnEnterHandler()
        {
            if (ActiveEvent != null)
            {
                _uiController.EventInfoPopup.AnchorIt();
            }
            else
            {
                _uiController.SystemInfoPopup.AnchorIt();
            }
        }

        public override void OnExitHandler()
        {
            _cameraHolder.TurnOnPrevious();
            if (ActiveEvent != null)
            {
                _uiController.EventInfoPopup.CloseView();
            }
            else
            {
                _uiController.SystemInfoPopup.CloseView();
            }
            ActiveEvent = null;
        }

        public override void OnInitialize()
        {
            _wagonEventViewer.OnSetEvent += OnSetEvent;
        }

        public override void OnDispose()
        {
            _wagonEventViewer.OnSetEvent -= OnSetEvent;
        }

        private void Start()
        {
            WagonSystem = _fabric.Create(_wagonSystemStaticDataBase);
            WagonSystem.Initialize();
            //добавить вагон в менеджер
        }

        private void OnDestroy()
        {
            WagonSystem.Dispose();
        }
    }
}
