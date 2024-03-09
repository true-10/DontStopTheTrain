using DontStopTheTrain.UI;
using System;
using System.Collections.Generic;
using True10;
using UnityEngine;
using Zenject;


namespace DontStopTheTrain.Events
{
    public class WagonEventViewer : AbstractEventViewer
    {
        public override EventType Type => EventType.Wagon;
        public IReadOnlyCollection<WagonEventType> WagonEventTypes => _wagonEventTypes.AsReadOnly();

        public bool IsClickable { get; set; } = false;

        [Inject]
        private UIController _uiController;

        [SerializeField]
        private List<WagonEventType> _wagonEventTypes;
        [SerializeField]
        private Transform _eventPrefabRoot;
        [SerializeField]
        private ClickOnObject _clicker;

        private GameObject _eventPrefabGO;
        private int _wagonNumber;

        public void SetWagonNumber(int wagonNumber)
        {
            _wagonNumber = wagonNumber;
        }

        private void OnEventClick()
        {
            //на ПКМ попап меню показывать вместо полноэкранного?
            //при наведении показывать описание проблемы и требования для починки?
            if (IsFree || IsClickable == false)
            {
                return;
            }

            _uiController.WagonEvent.Show(_eventData);
            _uiController.Wagon.Hide();
        }

        private void SpawnPrefab()
        {
            var prefab = _eventData.StaticData.EventPrefab;
            if (prefab == null)
            {
                Debug.Log($"No event prefab found");
                return;
            }
            _eventPrefabGO = Instantiate(prefab, _eventPrefabRoot);
            _eventPrefabGO.transform.localPosition = Vector3.zero;
        }

        private void ClearAll()
        {
            if (_eventPrefabGO != null)
            {
                Destroy(_eventPrefabGO);
            }
            _eventData = null;
        }

        protected override void OnStartEvent(IEvent eventData)
        {
            //if (eventData.StaticData.Type != Type || IsFree == false)
            if (eventData != _eventData)
            {
                return;
            }
            SpawnPrefab();
        }

        protected override void OnCompleteEvent(IEvent eventData)
        {
            //if (eventData.StaticData.Type != Type || IsFree)
            if (eventData != _eventData)
            {
                return;
            }
            ClearAll();
        }

        private void OnEnable()
        {
            _clicker.OnClick += OnEventClick;
        }

        private void OnDisable()
        {
            _clicker.OnClick -= OnEventClick;
        }
    }
}
