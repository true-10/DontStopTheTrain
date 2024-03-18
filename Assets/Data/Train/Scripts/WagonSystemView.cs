using DontStopTheTrain.Events;
using DontStopTheTrain.Train;
using DontStopTheTrain.UI;
using System.Collections;
using System.Collections.Generic;
using True10;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace DontStopTheTrain
{
    public class WagonSystemView : MonoBehaviour// BasicView
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
        private UIController _uiController;
        [Inject]
        private WagonSystemsFabric _fabric;

        [SerializeField]
        private ClickableView _clickableView;
        [SerializeField]
        private List<WagonEventType> _wagonEventTypes;
        [SerializeField]
        private WagonEventViewer _wagonEventViewer;
        [SerializeField]
        private Transform _lookAtTransform;
        [SerializeField]
        private WagonSystemStaticDataBase _wagonSystemStaticDataBase;

        public void Initialize()
        {
            WagonSystem = _fabric.Create(_wagonSystemStaticDataBase);
            WagonSystem.Initialize();
            (WagonSystem as BaseWagonSystem).SetViewer(_wagonEventViewer);
            //добавить систему в менеджер

            _clickableView.OnClick += OnClickViewHandler;
            _clickableView.OnExitView += OnExitViewHandler;
            _clickableView.OnMouseOverEnter += OnMouseOverEnterHandler;
            _clickableView.OnMouseOverExit += OnMouseOverExitHandler;

            _wagonEventViewer.OnSetEvent += OnSetEvent;
        }

        public void Dispose()
        {
            WagonSystem.Dispose();

            _clickableView.OnClick -= OnClickViewHandler;
            _clickableView.OnExitView -= OnExitViewHandler;
            _clickableView.OnMouseOverEnter -= OnMouseOverEnterHandler;
            _clickableView.OnMouseOverExit -= OnMouseOverExitHandler;

            _wagonEventViewer.OnSetEvent -= OnSetEvent;
        }

        private void OnSetEvent(IEvent eventData)
        {
            ActiveEvent = eventData;
        }

        private void OnMouseOverEnterHandler()
        {
            if (ActiveEvent != null)
            {
                if (_uiController.EventInfoPopup.IsAnchored == false)
                {
                    _uiController.EventInfoPopup.Show(ActiveEvent, _lookAtTransform, _clickableView);
                }
            }
            else 
            {
                if (_uiController.SystemInfoPopup.IsAnchored == false)
                {
                    _uiController.SystemInfoPopup.Show(WagonSystem, _lookAtTransform, _clickableView);
                }
            }
        }

        private void OnMouseOverExitHandler()
        {
            if (ActiveEvent != null)
            {
                if (_uiController.EventInfoPopup.IsAnchored == false)
                {
                    _uiController.EventInfoPopup.CloseView();
                }
            }
            else
            {
                if (_uiController.SystemInfoPopup.IsAnchored == false)
                {
                    _uiController.SystemInfoPopup.CloseView();
                }
            }
        }

        private void OnClickViewHandler()
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

        private void OnExitViewHandler()
        {
            //_cameraHolder.TurnOnPrevious();
        }

        private void Start()
        {
            Initialize();
        }

        private void OnDestroy()
        {
            Dispose();
        }
    }
}
