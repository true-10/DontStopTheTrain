using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace True10.TriggerSystem
{
    public interface IOnTriggerCallback
    {
        //AbstractTriggerMonoObject TriggerObject { get; }
        int TriggetType { get; set; }
      //  List<GameObject> DataObjects { get; set; }
    }

    public class OnTriggerCallback : IOnTriggerCallback
    {
       // public AbstractTriggerMonoObject TriggerObject { get; }
        public int TriggetType { get; set; }
       // public List<GameObject> DataObjects { get; set; }
    }

    public class LevelTrigger : MonoBehaviour
    {
        public Action<IOnTriggerCallback> OnEnter { get; set; }
        public Action<IOnTriggerCallback> OnExit { get; set; }
        public Action<IOnTriggerCallback> OnStay { get; set; }

        //[SerializeField] private TriggerTypeEnum triggerType = TriggerTypeEnum.General;
        [SerializeField, Min(0)] 
        protected int triggerType = 0;
        [SerializeField]
        protected UnityEvent onEnterEvent;
        [SerializeField]
        protected UnityEvent onExitEvent;
        [SerializeField]
        protected UnityEvent onStayEvent;
        [SerializeField] 
        protected List<AbstractTriggerActivatorMonoActionObject> actions;

        private void OnTriggerEnter(Collider other)
        {
            var triggerObject = other.GetComponent<AbstractMonoTriggerActivator>();
            if (triggerObject == null)
            {
                return;
            }
            Debug.Log($"LevelTrigger: OnTriggerEnter ({triggerObject.name} )");
            var callback = GetTriggerCallback();
            triggerObject.OnEnterAction(callback);

            actions.ForEach(x => x.OnEnterAction(callback));

            OnEnter?.Invoke(callback);
            onEnterEvent?.Invoke();
        }

        private void OnTriggerExit(Collider other)
        {
            var triggerObject = other.GetComponent<AbstractMonoTriggerActivator>();

            if (triggerObject == null)
            {
                return;
            }

            var callback = GetTriggerCallback();

            triggerObject.OnExitAction(callback);

            actions.ForEach(x => x.OnExitAction(callback));

            OnExit?.Invoke(callback);
            onExitEvent?.Invoke();
        }

        private void OnTriggerStay(Collider other)
        {
            var triggerObject = other.GetComponent<AbstractMonoTriggerActivator>();

            if (triggerObject == null)
            {
                return;
            }

            var callback = GetTriggerCallback();

            triggerObject.OnStayAction(callback);

            actions.ForEach(x => x.OnStayAction(callback));

            OnStay?.Invoke(callback);
            onStayEvent?.Invoke();
        }


        protected virtual IOnTriggerCallback GetTriggerCallback()
        {
            var callback = new OnTriggerCallback()
            {
                TriggetType = triggerType,
               // DataObjects = actions
            };
            return callback;
        }
    }



}
