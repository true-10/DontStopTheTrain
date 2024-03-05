using System;
using UnityEngine;


namespace DontStopTheTrain.Events
{
    public class WagonEventViewer : AbstractEventViewer
    {
        public override EventType Type => EventType.Wagon;
        
        [SerializeField]
        private Transform _eventPrefabRoot;

        private GameObject _eventPrefabGO;

        protected override void OnStartEvent(IEvent eventData)
        {
            SpawnPrefab(eventData);
        }

        protected override void OnCompleteEvent(IEvent eventData)
        {
            ClearAll();
        }

        private void SpawnPrefab(IEvent eventData)
        {
            Debug.Log("HELLO");
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
            Debug.Log("GOODBYE");
            if (_eventPrefabGO != null)
            {
                Destroy(_eventPrefabGO);
            }
        }


    }
}
