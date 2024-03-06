using DontStopTheTrain.UI;
using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;


namespace DontStopTheTrain.Events
{
    public class WagonEventViewer : AbstractEventViewer
    {
        public override EventType Type => EventType.Wagon;

        public bool IsFree => _eventData == null;

        [Inject]
        private UIController _uiController;

        [SerializeField]
        private List<WagonEventType> _wagonEventType;
        [SerializeField]
        private Transform _eventPrefabRoot;
        [SerializeField]
        private ClickOnObject _clicker;

        private GameObject _eventPrefabGO;
        private IEvent _eventData;

        private void OnEventClick()
        {
            if (_eventData == null)
            {
                return;
            }

            _uiController.WagonEvent.Show(_eventData);
            _uiController.MainGamePlay.Show(false);
        }

        private void SpawnPrefab(IEvent eventData)
        {
            //Debug.Log("HELLO");
            var prefab = eventData.StaticData.EventPrefab;
            if (prefab == null)
            {
                Debug.Log($"No event prefab found");
                return;
            }
            _eventPrefabGO = Instantiate(prefab, _eventPrefabRoot);
        }

        private void ClearAll()
        {
            //Debug.Log("GOODBYE");
            if (_eventPrefabGO != null)
            {
                Destroy(_eventPrefabGO);
            }
            _eventData = null;
        }

        protected override void OnStartEvent(IEvent eventData)
        {
            _eventData = eventData;
            SpawnPrefab(eventData);
        }

        protected override void OnCompleteEvent(IEvent eventData)
        {
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
