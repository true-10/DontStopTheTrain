using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace True10.TriggerSystem
{

    public class SimpleTrigger : MonoBehaviour
    {
        public Action<Collider> OnEnter { get; set; }
        public Action<Collider> OnExit { get; set; }
        public Action<Collider> OnStay { get; set; }

        [SerializeField]
        protected UnityEvent onEnterEvent;
        [SerializeField]
        protected UnityEvent onExitEvent;
        [SerializeField]
        protected UnityEvent onStayEvent;

        private void OnTriggerEnter(Collider collider)
        {
            OnEnter?.Invoke(collider);
            onEnterEvent?.Invoke();
        }

        private void OnTriggerExit(Collider collider)
        {
            OnExit?.Invoke(collider);
            onExitEvent?.Invoke();
        }

        private void OnTriggerStay(Collider collider)
        {
            OnStay?.Invoke(collider);
            onStayEvent?.Invoke();
        }

    }
}
