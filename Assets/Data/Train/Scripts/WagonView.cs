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
    public sealed class WagonView : MonoBehaviour// BasicView
    {
        public List<WagonEventViewer> EventViewers => _eventViewers;//надо ли?
        public IWagon WagonData => _wagonData;

        [Inject]
        private UIController _uiController;
        [Inject]
        private WagonsFabric _fabric;

        [SerializeField]
        private ClickableView _clickableView;
        [SerializeField]
        private List<WagonEventViewer> _eventViewers;
        [SerializeField]
        private List<WagonSystemView> _systemViewers;
        [SerializeField] 
        private WagonStaticDataBase _wagonStaticData;
        [SerializeField] 
        private BoxCollider _boxCollider;
        [SerializeField] 
        private WagonAlarm _alarm;
        [SerializeField]
        private CameraHolder _cameraHolder;

        private IWagon _wagonData;

        public void Initialize()
        {
            _boxCollider ??= GetComponent<BoxCollider>();
            _wagonData = _fabric.Create(_wagonStaticData);
            _wagonData.Initialize();

            _clickableView.OnClick += OnClickViewHandler;
            _clickableView.OnExitView += OnExitViewHandler;
            _clickableView.OnMouseOverEnter += OnMouseOverEnterHandler;
            _clickableView.OnMouseOverExit += OnMouseOverExitHandler;

            _eventViewers.ForEach(viewer => viewer.OnSetEvent += OnSetEvent);
        }

        public void Dispose()
        {
            _wagonData.Dispose();

            _clickableView.OnClick -= OnClickViewHandler;
            _clickableView.OnExitView -= OnExitViewHandler;
            _clickableView.OnMouseOverEnter -= OnMouseOverEnterHandler;
            _clickableView.OnMouseOverExit -= OnMouseOverExitHandler;

            _eventViewers.ForEach(viewer => viewer.OnSetEvent -= OnSetEvent);
        }

        public void OnClickViewHandler()
        {
            _boxCollider.enabled = false;
            _uiController.Wagon.Show(_clickableView);
            _uiController.MainGamePlay.Hide();
            _uiController.WagonInfoPopup.Hide();
            //_eventViewers.ForEach(viewer => viewer.IsClickable = true);
            _systemViewers.ForEach(viewer => viewer.IsClickable = true);
            _cameraHolder?.TurnOn();
        }

        public void OnExitViewHandler()
        {
            _boxCollider.enabled = true;
            _uiController.MainGamePlay.Show();
            _cameraHolder?.TurnOff();
            //_eventViewers.ForEach(viewer => viewer.IsClickable = false);
            _systemViewers.ForEach(viewer => viewer.IsClickable = false);
        }

        public void OnMouseOverEnterHandler()
        {
            _uiController.WagonInfoPopup.Show(_wagonData, transform);
        }

        public void OnMouseOverExitHandler()
        {
            _uiController.WagonInfoPopup.Hide();
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

        private void OnValidate()
        {
            _boxCollider ??= GetComponent<BoxCollider>();
        }

        private void Start()
        {
            Initialize();
            //добавить вагон в менеджер
        }

        private void OnDestroy()
        {
            Dispose();
        }

    }
   
}
