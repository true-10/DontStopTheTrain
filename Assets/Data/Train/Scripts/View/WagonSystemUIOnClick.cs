using DontStopTheTrain.Events;
using DontStopTheTrain.Train;
using DontStopTheTrain.UI;
using UnityEngine;
using Zenject;

namespace DontStopTheTrain
{
    public sealed class WagonSystemUIOnClick : BaseClickableView
    {
        [Inject]
        private UIContainer _UIContainer;

        [SerializeField]
        private Transform _lookAtTransform;

        private IWagonSystem _wagonSystem;
        private IEvent _activeEvent;
        protected override void OnMouseOverEnterHandler()
        {
            if (_activeEvent != null)
            {
                if (_UIContainer.EventInfoPopup.IsAnchored == false)
                {
                    _UIContainer.EventInfoPopup.Show(_activeEvent, _lookAtTransform, _clickableView);
                }
            }
            else
            {
                if (_UIContainer.SystemInfoPopup.IsAnchored == false)
                {
                    _UIContainer.SystemInfoPopup.Show(_wagonSystem, _lookAtTransform, _clickableView);
                }
            }
        }

        protected override void OnMouseOverExitHandler()
        {
            if (_activeEvent != null)
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

        protected override void OnClickViewHandler()
        {
            if (_activeEvent != null)
            {
                //ActiveEvent.TryToFocus();
                _UIContainer.EventInfoPopup.AnchorIt();
            }
            else
            {
                _UIContainer.SystemInfoPopup.AnchorIt();
            }
        }

        protected override void OnExitViewHandler()
        {
            //_cameraHolder.TurnOnPrevious();
        }

        public void SetSystem(IWagonSystem wagonSystem)
        {
            _wagonSystem ??= wagonSystem;
        }

        public void SetEvent(IEvent eventData)
        {
            _activeEvent ??= eventData;
        }
    }
}
