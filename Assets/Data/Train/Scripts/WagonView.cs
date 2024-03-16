using DontStopTheTrain.Events;
using DontStopTheTrain.MiniGames;
using DontStopTheTrain.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;
using Zenject;

namespace DontStopTheTrain.Train
{
    public sealed class WagonView : BasicView
    {
        public List<WagonEventViewer> EventViewers => _eventViewers;//надо ли?
        public IWagon WagonData => _wagonData;

        [Inject]
        private UIController _uiController;
        [Inject]
        private WagonsFabric _fabric;

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

        private IWagon _wagonData;

        public override void OnExitHandler()
        {
            _cameraHolder.TurnOff();
            _boxCollider.enabled = true;
            _uiController.MainGamePlay.Show();
            //_eventViewers.ForEach(viewer => viewer.IsClickable = false);
            _systemViewers.ForEach(viewer => viewer.IsClickable = false);
        }

        public override void OnMouseOverExitHandler()
        {
            _uiController.WagonInfoPopup.Hide();
        }

        public override void OnMouseOverEnterHandler()
        {
            _uiController.WagonInfoPopup.Show(_wagonData, transform);
        }

        public override void OnEnterHandler()
        {
            _boxCollider.enabled = false;
            _uiController.Wagon.Show(this);
            _uiController.MainGamePlay.Hide();
            _uiController.WagonInfoPopup.Hide();
            //_eventViewers.ForEach(viewer => viewer.IsClickable = true);
            _systemViewers.ForEach(viewer => viewer.IsClickable = true);
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
            _boxCollider ??= GetComponent<BoxCollider>();
            _wagonData = _fabric.Create(_wagonStaticData);
            _wagonData.Initialize();
            //добавить вагон в менеджер
        }

        private void OnDestroy()
        {
            _wagonData.Dispose();
        }

        public override void OnInitialize()
        {
            _eventViewers.ForEach(viewer => viewer.OnSetEvent += OnSetEvent);
        }

        public override void OnDispose()
        {
            _eventViewers.ForEach(viewer => viewer.OnSetEvent -= OnSetEvent);
        }
    }
   
}
