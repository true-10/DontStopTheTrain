using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace True10.TriggerSystem
{
    /// <summary>
    /// этот объект выполняется левелтриггером
    /// </summary>
    public abstract class AbstractTriggerActivatorMonoActionObject : MonoBehaviour, ITriggerActivator
    {
        [SerializeField]
        protected bool IsEnable = true;
        public abstract int TriggerType { get; }//TriggerTypelist?
        public abstract void OnEnterAction(IOnTriggerCallback callback);

        public abstract void OnExitAction(IOnTriggerCallback callback);

        public abstract void OnStayAction(IOnTriggerCallback callback);
    }
}
