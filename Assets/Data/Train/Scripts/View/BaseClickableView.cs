using True10;
using True10.Interfaces;
using UnityEditor;
using UnityEngine;

namespace DontStopTheTrain
{
    public class BaseClickableView : AbstractGameLifeCycleBehaviour
    {
        [SerializeField]
        protected ClickAndMouseOverView _clickableView;

        protected virtual void OnValidate()
        {
            _clickableView ??= GetComponent<ClickAndMouseOverView>();
            _clickableView ??= GetComponentInChildren<ClickAndMouseOverView>();            
        }

        public override void Dispose()
        {
            DisposeClickAndOver();
        }

        public override void Initialize()
        {
            InitializeClickAndOver();
        }

        private void DisposeClickAndOver()
        {
            _clickableView.OnClick -= OnClickViewHandler;
            _clickableView.OnExitView -= OnExitViewHandler;
            _clickableView.OnMouseOverEnter -= OnMouseOverEnterHandler;
            _clickableView.OnMouseOverExit -= OnMouseOverExitHandler;
        }

        private void InitializeClickAndOver()
        {
            _clickableView.OnClick += OnClickViewHandler;
            _clickableView.OnExitView += OnExitViewHandler;
            _clickableView.OnMouseOverEnter += OnMouseOverEnterHandler;
            _clickableView.OnMouseOverExit += OnMouseOverExitHandler;
        }

        protected virtual void OnClickViewHandler()
        {

        }

        protected virtual void OnExitViewHandler()
        {

        }

        protected virtual void OnMouseOverEnterHandler()
        {

        }

        protected virtual void OnMouseOverExitHandler()
        {

        }
    }
}
