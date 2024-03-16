using System;
using True10;
using True10.CameraSystem;
using UnityEngine;

namespace DontStopTheTrain.Train
{
    public abstract class BasicView : MonoBehaviour
    {
        public Action OnEnter { get; set; }
        public Action OnExit { get; set; }

        public bool IsClickable { get; set; } = true;

        [SerializeField]
        protected ClickOnObject _clicker;
        [SerializeField]
        protected MouseOverObject _mouseOver;
        [SerializeField]
        protected CameraHolder _cameraHolder;


        public abstract void OnEnterHandler();
        public abstract void OnExitHandler();
        public abstract void OnMouseOverExitHandler();
        public abstract void OnMouseOverEnterHandler();
        public abstract void OnInitialize();
        public abstract void OnDispose();
        
        public void Exit()
        {
            IsClickable = true;
           // _cameraHolder.TurnOnPrevious(); 
            OnExitHandler();
            OnExit?.Invoke();
        }

        private void OnViewClick()
        {
            if (IsClickable == false)
            {
                return;
            }
            IsClickable = false;
            _cameraHolder.TurnOn();
            OnEnterHandler();
            OnEnter?.Invoke();
        }

        private void OnMouseOverExit()
        {
            if (IsClickable == false)
            {
                return;
            }
            OnMouseOverExitHandler();
        }

        private void OnMouseOverEnter()
        {
            if (IsClickable == false)
            {
                return;
            }
            OnMouseOverEnterHandler();
        }

        public void Initialize()
        {
            _clicker.OnClick += OnViewClick;
            // _eventViewers.ForEach(viewer => viewer.OnSetEvent += OnSetEvent);
            _mouseOver.OnEnter += OnMouseOverEnter;
            _mouseOver.OnExit += OnMouseOverExit;
            IsClickable = true;
            OnInitialize();
        }

        public void Dispose()
        {
            _clicker.OnClick -= OnViewClick;
            // _eventViewers.ForEach(viewer => viewer.OnSetEvent -= OnSetEvent);
            _mouseOver.OnEnter -= OnMouseOverEnter;
            _mouseOver.OnExit -= OnMouseOverExit;
            IsClickable = true;
            OnDispose();
        }

        private void OnEnable()
        {
            Initialize();
        }

        private void OnDisable()
        {
            Dispose();
        }
    }
   
}
