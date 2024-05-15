using DontStopTheTrain.Events;
using DontStopTheTrain.Train;
using DontStopTheTrain.UI;
using System.Collections.Generic;
using True10;
using True10.Interfaces;
using UnityEngine;
using Zenject;

namespace DontStopTheTrain
{
    public abstract class BasicView : MonoBehaviour
    {
        public abstract void Enter();
    }

    public class WagonSystemView : AbstractGameLifeCycleBehaviour
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
        private UIContainer _UIContainer;
        [Inject]
        private WagonSystemsFabric _fabric;

        [SerializeField]
        private ClickAndMouseOverView _clickableView;
        [SerializeField]
        private List<WagonEventType> _wagonEventTypes;
        [SerializeField]
        private WagonEventViewer _wagonEventViewer;
        [SerializeField]
        private Transform _lookAtTransform;
        [SerializeField]
        private WagonSystemStaticDataBase _wagonSystemStaticDataBase;

        public override void Initialize()
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

        public override void Dispose()
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
                if (_UIContainer.EventInfoPopup.IsAnchored == false)
                {
                    _UIContainer.EventInfoPopup.Show(ActiveEvent, _lookAtTransform, _clickableView);
                }
            }
            else 
            {
                if (_UIContainer.SystemInfoPopup.IsAnchored == false)
                {
                    _UIContainer.SystemInfoPopup.Show(WagonSystem, _lookAtTransform, _clickableView);
                }
            }
        }

        private void OnMouseOverExitHandler()
        {
            if (ActiveEvent != null)
            {
                if (_UIContainer.EventInfoPopup.IsAnchored == false)
                {
                    _UIContainer.EventInfoPopup.CloseView();
                }
            }
            else
            {
                if (_UIContainer.SystemInfoPopup.IsAnchored == false)
                {
                    _UIContainer.SystemInfoPopup.CloseView();
                }
            }
        }

        private void OnClickViewHandler()
        {
            if (ActiveEvent != null)
            {
                //ActiveEvent.TryToFocus();
                _UIContainer.EventInfoPopup.AnchorIt();
            }
            else
            {
                _UIContainer.SystemInfoPopup.AnchorIt();
            }
        }

        private void OnExitViewHandler()
        {
            //_cameraHolder.TurnOnPrevious();
        }
    }
}
