using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace True10.TriggerSystem
{
    public interface ITriggerActivator
    {
        int TriggerType { get;}
        void OnEnterAction(IOnTriggerCallback callback);
        void OnExitAction(IOnTriggerCallback callback);
        void OnStayAction(IOnTriggerCallback callback);


    }
    
    /// <summary>
    /// этот объект заходит в триггер зону.
    /// </summary>

    [RequireComponent(typeof(Rigidbody))]
    public abstract class AbstractMonoTriggerActivator: MonoBehaviour, ITriggerActivator
    {
        public abstract int TriggerType { get; }//TriggerTypelist?
        public abstract void OnEnterAction(IOnTriggerCallback callback);

        public abstract void OnExitAction(IOnTriggerCallback callback);

        public abstract void OnStayAction(IOnTriggerCallback callback);
    }
}
