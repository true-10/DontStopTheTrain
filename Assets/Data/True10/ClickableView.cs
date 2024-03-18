using System;
using True10.CameraSystem;
using UnityEngine;

namespace True10
{
    public class ClickableView : MonoBehaviour
    {
        public Action OnClick { get; set; }
       // public Action OnEnterView { get; set; }
        public Action OnExitView { get; set; }
        public Action OnMouseOverEnter { get; set; }
        public Action OnMouseOverExit { get; set; }
       // public Action OnInitialize { get; set; }
        //public Action OnDispose { get; set; }
        public bool IsClickable { get; set; } = true;

       // public ICameraHolder CameraHolder => _cameraHolder;

        [SerializeField]
        private ClickOnObject _clicker;
        [SerializeField]
        private MouseOverObject _mouseOver;
       // [SerializeField]
        //private CameraHolder _cameraHolder;

        public void ExitView()
        {
            IsClickable = true;
          //  _cameraHolder.TurnOnPrevious(); 
            OnExitView?.Invoke();
        }

        private void OnViewClick()
        {
            if (IsClickable == false)
            {
                return;
            }
            IsClickable = false;
          //  _cameraHolder.TurnOn();
            OnClick?.Invoke();
        }

        private void MouseOverExit()
        {
            if (IsClickable == false)
            {
                return;
            }
            OnMouseOverExit?.Invoke();
        }

        private void MouseOverEnter()
        {
            if (IsClickable == false)
            {
                return;
            }
            OnMouseOverEnter?.Invoke();
        }

        public void Initialize()
        {
            _clicker.OnClick += OnViewClick;
            _mouseOver.OnEnter += MouseOverEnter;
            _mouseOver.OnExit += MouseOverExit;
            IsClickable = true;
        //    OnInitialize?.Invoke();
        }

        public void Dispose()
        {
            _clicker.OnClick -= OnViewClick;
            _mouseOver.OnEnter -= OnMouseOverEnter;
            _mouseOver.OnExit -= OnMouseOverExit;
            IsClickable = true;
         //   OnDispose?.Invoke();
        }

        private void OnEnable()
        {
            Initialize();
        }

        private void OnDisable()
        {
            Dispose();
        }

        private void OnValidate()
        {
            _clicker ??= GetComponent<ClickOnObject>();
            _mouseOver ??= GetComponent<MouseOverObject>();
        }
    }
   
}
