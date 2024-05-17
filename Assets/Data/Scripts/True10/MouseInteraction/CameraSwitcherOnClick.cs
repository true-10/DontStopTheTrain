using DontStopTheTrain;
using True10.CameraSystem;
using True10.Interfaces;
using UnityEngine;
using static True10.CameraSwitcherOnClick;

namespace True10
{
    public class CameraSwitcherOnClick : BaseClickableView
    {
        public enum SwitchTypeOnExit
        {
            Default,
            Previous
        }

        [SerializeField]
        private CameraHolder _camera;
        [SerializeField]
        private SwitchTypeOnExit _switchTypeOnExit = SwitchTypeOnExit.Default;

        protected override void OnClickViewHandler()
        {
            _camera.SwitchToThisCamera();
        }

        protected override void OnExitViewHandler()
        {
            switch(_switchTypeOnExit)
            {
                case SwitchTypeOnExit.Previous:
                    _camera.SwitchToPreviousCamera();
                    break;
                case SwitchTypeOnExit.Default:
                default:
                    _camera.SwitchToDefaultCamera();
                    break;
            };
        }
    }
}
