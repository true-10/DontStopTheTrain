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

        [SerializeField]
        private List<WagonEventType> _wagonEventTypes;
        [SerializeField]
        private Transform _eventPrefabRoot;

        private GameObject _eventPrefabGO;
        private int _wagonNumber;

        private void SpawnPrefab()
        {
            var prefab = _eventData.StaticData.EventPrefab;

            if (prefab == null)
            {
                Debug.Log($"No event prefab found");
                return;

            }

            _eventPrefabGO = Instantiate(prefab, _eventPrefabRoot);
            if (_eventPrefabGO.TryGetComponent<AbstractEventObject>(out var eventObject) )
            {
                eventObject.SetEvent(_eventData);
            }
        }

        private void ClearAll()
        {
            if (_eventPrefabGO != null)
            {
                if (_eventPrefabGO.TryGetComponent<AbstractEventObject>(out var eventObject))
                {
                    eventObject.Dispose();
                }
                Destroy(_eventPrefabGO);
            }
            _eventData = null;
            OnSetEvent?.Invoke(null);
        }

        protected override void OnStartEvent(IEvent eventData)
        {
            if (eventData != _eventData)
            {
                return;
            }
            SpawnPrefab();
        }

        protected override void OnCompleteEvent(IEvent eventData)
        {
            if (eventData != _eventData)
            {
                return;
            }
            ClearAll();
        }
    }
}
