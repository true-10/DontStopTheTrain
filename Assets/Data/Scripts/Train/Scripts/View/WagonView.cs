using DontStopTheTrain.Events;
using DontStopTheTrain.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using True10;
using True10.CameraSystem;
using True10.Interfaces;
using True10.LevelScrollSystem;
using UnityEngine;
using Zenject;

namespace DontStopTheTrain.Train
{
    public sealed class WagonView : AbstractGameLifeCycleBehaviour
    {
        public List<WagonEventViewer> EventViewers => _eventViewers;//надо ли?
        public IWagon WagonData => _wagonData;

        [Inject]
        private UIContainer _UIContainer;
        [Inject]
        private WagonsFabric _fabric;
        [Inject]
        private EventController _eventController;
        [Inject]
        private LevelScroller _levelScroller;

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

        public override void Initialize()
        {
            _boxCollider ??= GetComponent<BoxCollider>();
            _wagonData = _fabric.Create(_wagonStaticData);
            _wagonData.Initialize();

            _clickableView.OnClick += OnClickViewHandler;
            _clickableView.OnExitView += OnExitViewHandler;
            _clickableView.OnMouseOverEnter += OnMouseOverEnterHandler;
            _clickableView.OnMouseOverExit += OnMouseOverExitHandler;

            _eventController.OnFocus += OnEventFocus;
            _eventViewers.ForEach(viewer => viewer.OnSetEvent += OnSetEvent);
        }

        public override void Dispose()
        {
            _wagonData.Dispose();

            _clickableView.OnClick -= OnClickViewHandler;
            _clickableView.OnExitView -= OnExitViewHandler;
            _clickableView.OnMouseOverEnter -= OnMouseOverEnterHandler;
            _clickableView.OnMouseOverExit -= OnMouseOverExitHandler;

            _eventController.OnFocus -= OnEventFocus;
            _eventViewers.ForEach(viewer => viewer.OnSetEvent -= OnSetEvent);
        }

        public void OnClickViewHandler()
        {
            _boxCollider.enabled = false;
            _UIContainer.Wagon.Show(_clickableView);
            _UIContainer.MainGamePlay.Hide();
            _UIContainer.WagonInfoPopup.Hide();
            //_eventViewers.ForEach(viewer => viewer.IsClickable = true);
            _systemViewers.ForEach(viewer => viewer.IsClickable = true);
            _cameraHolder?.SwitchToThisCamera();
        }

        private void OnEventFocus(IEvent eventData)
        {
            if (_eventViewers.Any(viewer => viewer.ActiveEvent == eventData))
            {
                OnClickViewHandler();
            }
        }

        public void OnExitViewHandler()
        {
            _boxCollider.enabled = true;
            _UIContainer.MainGamePlay.Show();
            _cameraHolder?.SwitchToDefaultCamera();
            //_eventViewers.ForEach(viewer => viewer.IsClickable = false);
            _systemViewers.ForEach(viewer => viewer.IsClickable = false);
        }

        public void OnMouseOverEnterHandler()
        {
            _UIContainer.WagonInfoPopup.Show(_wagonData, transform);
        }

        public void OnMouseOverExitHandler()
        {
            _UIContainer.WagonInfoPopup.Hide();
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
    }
   
}
