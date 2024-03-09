using DontStopTheTrain.Events;
using DontStopTheTrain.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using True10;
using True10.CameraSystem;
using UnityEngine;
using Zenject;

namespace DontStopTheTrain.Train
{
    public sealed class Wagon : MonoBehaviour
    {
        public Action OnEnter { get; set; }
        public Action OnExit { get; set; }
        public List<WagonEventViewer> EventViewers => _eventViewers;//надо ли?
        public IWagon WagonData => _wagonData;

        [Inject]
        private UIController _uiController;
        [Inject]
        private EventController _eventController;

        [SerializeField]
        private List<WagonEventViewer> _eventViewers;
        [SerializeField] 
        private WagonData _wagonData;
        [SerializeField] 
        private CameraHolder _cameraHolder;
        [SerializeField] 
        private ClickOnObject _clicker;
        [SerializeField] 
        private BoxCollider _boxCollider;
        [SerializeField] 
        private WagonAlarm _alarm;
        
        public void Exit()
        {
            _cameraHolder.TurnOff();
            _boxCollider.enabled = true;
            _uiController.MainGamePlay.Show();
            _eventViewers.ForEach(viewer => viewer.IsClickable = false);
            OnExit?.Invoke();
        }

        private void OnWagonClick()
        {
            _cameraHolder.TurnOn();
            _boxCollider.enabled = false;
            _uiController.Wagon.Show(this);
            _uiController.MainGamePlay.Hide();
            _eventViewers.ForEach(viewer => viewer.IsClickable = true);
            OnEnter?.Invoke();
        }

        private void OnSetEvent(IEvent eventData)
        {
            //(eventData as IWagonEvent).SetWagon()
            _alarm.AlarmOn();
        }
        private void OnEventComplete(IEvent eventData)
        {
            if (_eventViewers.All(viewer => viewer.IsFree))
            {
                _alarm.AlarmOff();
            }
        }

        private void OnEnable()
        {
            _clicker.OnClick += OnWagonClick;
            _eventController.OnComplete += OnEventComplete;
            _eventViewers.ForEach(viewer => viewer.OnSetEvent += OnSetEvent);
        }

        private void OnDisable()
        {
            _clicker.OnClick -= OnWagonClick;
            _eventController.OnComplete -= OnEventComplete;
            _eventViewers.ForEach(viewer => viewer.OnSetEvent -= OnSetEvent);
        }

        private void OnValidate()
        {
            _boxCollider ??= GetComponent<BoxCollider>();
        }

        private void Start()
        {
            _boxCollider ??= GetComponent<BoxCollider>();
        }
    }
   
}
