﻿using System;
using True10;
using True10.CameraSystem;
using UnityEngine;

namespace DontStopTheTrain.Train
{

    /*public abstract class BasicView : MonoBehaviour 
    { 

    }*/
    public abstract class BasicView : MonoBehaviour
    {
        public Action OnClick { get; set; }
        public Action OnExit { get; set; }
        public Action OnMouseOverEnter { get; set; }
        public Action OnMouseOverExit { get; set; }

        public bool IsClickable { get; set; } = true;

        [SerializeField]
        protected ClickOnObject _clicker;
        [SerializeField]
        protected MouseOverObject _mouseOver;
        [SerializeField]
        protected CameraHolder _cameraHolder;


        public abstract void OnClickViewHandler();
        public abstract void OnExitViewHandler();
        public abstract void OnMouseOverExitHandler();
        public abstract void OnMouseOverEnterHandler();
        public abstract void OnInitialize();
        public abstract void OnDispose();
        
        public void Exit()
        {
            IsClickable = true;
           // _cameraHolder.TurnOnPrevious(); 
            OnExitViewHandler();
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
            OnClickViewHandler();
            OnClick?.Invoke();
        }

        private void MouseOverExit()
        {
            if (IsClickable == false)
            {
                return;
            }
            OnMouseOverExitHandler(); 
            OnMouseOverEnter?.Invoke();
        }

        private void MouseOverEnter()
        {
            if (IsClickable == false)
            {
                return;
            }
            OnMouseOverEnterHandler();
            OnMouseOverExit?.Invoke();
        }

        public void Initialize()
        {
            _clicker.OnClick += OnViewClick;
            _mouseOver.OnEnter += MouseOverEnter;
            _mouseOver.OnExit += MouseOverExit;
            IsClickable = true;
            OnInitialize();
        }

        public void Dispose()
        {
            _clicker.OnClick -= OnViewClick;
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
