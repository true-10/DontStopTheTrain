using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace True10.TriggerSystem
{
    /// <summary>
    /// этот объект выполняется левелтриггером
    /// </summary>
    public abstract class AbstractOnTriggerActionBehaviour : MonoBehaviour, IOnTriggerEnter, IOnTriggerExit, IOnTriggerStay
    {
        public bool IsEnable { get; private set; } = true;

        public abstract void OnEnterAction(Collider collider);
        public abstract void OnExitAction(Collider collider);
        public abstract void OnStayAction(Collider collider);
    }

    public abstract class AbstractOnTriggerEnterActionBehaviour : MonoBehaviour, IOnTriggerEnter
    {
        public bool IsEnable { get; private set; } = true;

        public abstract void OnEnterAction(Collider collider);
    }

    public abstract class AbstractOnTriggerExitActionBehaviour : MonoBehaviour, IOnTriggerExit
    {
        public bool IsEnable { get; private set; } = true;

        public abstract void OnExitAction(Collider collider);
    }

    public abstract class AbstractOnTriggerStayActionBehaviour : MonoBehaviour, IOnTriggerStay
    {
        public bool IsEnable { get; private set; } = true;

        public abstract void OnStayAction(Collider collider);
    }

    public interface IOnTriggerEnter
    {
        void OnEnterAction(Collider collider);
    }

    public interface IOnTriggerExit
    {
        void OnExitAction(Collider collider);
    }

    public interface IOnTriggerStay
    {
        void OnStayAction(Collider collider);
    }
}
