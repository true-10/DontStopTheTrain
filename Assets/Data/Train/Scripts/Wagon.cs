using DontStopTheTrain.Events;
using DontStopTheTrain.MiniGames;
using DontStopTheTrain.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using True10;
using True10.CameraSystem;
using UnityEngine;
using UnityEngine.UIElements;
using Zenject;

namespace DontStopTheTrain.Train
{
    public sealed class Wagon : MonoBehaviour
    {
        public Action OnEnter { get; set; }
        public Action OnExit { get; set; }
        public List<WagonEventViewer> EventViewers => _eventViewers;//надо ли?
        public IWagon WagonData => _wagonData;

        public bool IsClickable { get; set; } = true;

        [Inject]
        private UIController _uiController;
        [Inject]
        private WagonsFabric _fabric;

        [SerializeField]
        private List<WagonEventViewer> _eventViewers;
        [SerializeField] 
        private WagonStaticDataBase _wagonStaticData;
        [SerializeField] 
        private CameraHolder _cameraHolder;
        [SerializeField] 
        private ClickOnObject _clicker;
        [SerializeField] 
        private BoxCollider _boxCollider;
        [SerializeField] 
        private WagonAlarm _alarm;
        [SerializeField] 
        private MouseOverObject _mouseOver;

        private IWagon _wagonData;

        public void Exit()
        {
            IsClickable = true;
            _cameraHolder.TurnOff();
            _boxCollider.enabled = true;
            _uiController.MainGamePlay.Show();
            _eventViewers.ForEach(viewer => viewer.IsClickable = false);
            OnExit?.Invoke();
        }

        private void OnMouseOverExit()
        {
            if (IsClickable == false)
            {
                return;
            }
            _uiController.WagonInfoPopup.Hide();
        }

        private void OnMouseOverEnter()
        {
            if (IsClickable == false)
            {
                return;
            }
            _uiController.WagonInfoPopup.Show(_wagonData, transform);
        }

        private void OnWagonClick()
        {
            if (IsClickable == false)
            {
                return;
            }
            IsClickable = false;
            _cameraHolder.TurnOn();
            _boxCollider.enabled = false;
            _uiController.Wagon.Show(this);
            _uiController.MainGamePlay.Hide();
            _uiController.WagonInfoPopup.Hide();
            _eventViewers.ForEach(viewer => viewer.IsClickable = true);
            OnEnter?.Invoke();
        }

        private void OnSetEvent(IEvent eventData)
        {
            if (eventData == null)
            {
                if (_eventViewers.All(viewer => viewer.IsFree))
                {
                    _alarm.AlarmOff();
                }
                return;
            }
            _alarm.AlarmOn();
        }

        private void OnEnable()
        {
            _clicker.OnClick += OnWagonClick;
            _eventViewers.ForEach(viewer => viewer.OnSetEvent += OnSetEvent);
            _mouseOver.OnEnter += OnMouseOverEnter;
            _mouseOver.OnExit += OnMouseOverExit;
        }

        private void OnDisable()
        {
            _clicker.OnClick -= OnWagonClick;
            _eventViewers.ForEach(viewer => viewer.OnSetEvent -= OnSetEvent);
            _mouseOver.OnEnter -= OnMouseOverEnter;
            _mouseOver.OnExit -= OnMouseOverExit;
        }

        private void OnValidate()
        {
            _boxCollider ??= GetComponent<BoxCollider>();
        }

        private void Start()
        {
            _boxCollider ??= GetComponent<BoxCollider>();
            _wagonData = _fabric.Create(_wagonStaticData);
            _wagonData.Initialize();
            //добавить вагон в менеджер
        }

        private void OnDestroy()
        {
            _wagonData.Dispose();
        }
    }
   
}
