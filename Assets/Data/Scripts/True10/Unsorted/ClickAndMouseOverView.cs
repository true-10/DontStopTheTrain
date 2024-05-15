using System;
using True10.CameraSystem;
using True10.Interfaces;
using UnityEngine;

namespace True10
{
    public class ClickAndMouseOverView : MonoBehaviour, IGameLifeCycle
    {
        public Action OnClick { get; set; }
       // public Action OnEnterView { get; set; }
        public Action OnExitView { get; set; }
        public Action OnMouseOverEnter { get; set; }
        public Action OnMouseOverExit { get; set; }
        public bool IsClickable { get; set; } = true;

        [SerializeField]
        private ClickOnObject _clicker;
        [SerializeField]
        private MouseOverObject _mouseOver;

        public void ExitView()
        {
            IsClickable = true;
            OnExitView?.Invoke();
        }

        private void OnViewClick()
        {
            if (IsClickable == false)
            {
                return;
            }
            IsClickable = false;
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
        }

        public void Dispose()
        {
            _clicker.OnClick -= OnViewClick;
            _mouseOver.OnEnter -= OnMouseOverEnter;
            _mouseOver.OnExit -= OnMouseOverExit;
            IsClickable = true;
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
