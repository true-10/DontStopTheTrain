using DontStopTheTrain.Events;
using DontStopTheTrain.Train;
using DontStopTheTrain.UI;
using System.Collections;
using System.Collections.Generic;
using True10;
using True10.Interfaces;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace DontStopTheTrain
{
    public abstract class BasicView : MonoBehaviour
    {
        public abstract void Enter();
    }

    public class WagonSystemView : MonoBehaviour, IGameLifeCycle// BasicView
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
        [Inject]
        private EventController _eventController;

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

            _eventController.OnFocus += OnEventFocus;
        }

        public void Dispose()
        {
            WagonSystem.Dispose();

            _clickableView.OnClick -= OnClickViewHandler;
            _clickableView.OnExitView -= OnExitViewHandler;
            _clickableView.OnMouseOverEnter -= OnMouseOverEnterHandler;
            _clickableView.OnMouseOverExit -= OnMouseOverExitHandler;

            _wagonEventViewer.OnSetEvent -= OnSetEvent;
            _eventController.OnFocus -= OnEventFocus;
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

        private void OnEventFocus(IEvent eventData)
        {
            if (ActiveEvent == null)
            {
                return;
            }
            if (eventData == ActiveEvent)
            {
                _uiController.EventInfoPopup.AnchorIt();
            }
        }

        private void OnClickViewHandler()
        {
            if (ActiveEvent != null)
            {
                ActiveEvent.TryToFocus();
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
