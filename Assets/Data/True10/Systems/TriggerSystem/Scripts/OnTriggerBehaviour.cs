using System.Collections.Generic;
using UnityEngine;

namespace True10.TriggerSystem
{
    public sealed class OnTriggerBehaviour : MonoBehaviour
    {
        [SerializeField]
        private List<AbstractOnTriggerEnterActionBehaviour> onEnterActions;
        [SerializeField]
        private List<AbstractOnTriggerExitActionBehaviour> onExitActions;
        [SerializeField]
        private List<AbstractOnTriggerStayActionBehaviour> onStayActions;
        [SerializeField]
        private List<AbstractOnTriggerActionBehaviour> onTriggerActions;

        private void OnTriggerEnter(Collider collider)
        {
            onEnterActions.ForEach(action =>
            {
                if (action.IsEnable)
                {
                    action.OnEnterAction(collider);
                } 
            });
            onTriggerActions.ForEach(action =>
            {
                if (action.IsEnable)
                {
                    action.OnEnterAction(collider);
                } 
            });
        } 

        private void OnTriggerExit(Collider collider)
        {
            onExitActions.ForEach(action =>
            {
                if (action.IsEnable)
                {
                    action.OnExitAction(collider);
                }
            });
            onTriggerActions.ForEach(action =>
            {
                if (action.IsEnable)
                {
                    action.OnExitAction(collider);
                }
            });
        }

        private void OnTriggerStay(Collider collider)
        {
            onStayActions.ForEach(action =>
            {
                if (action.IsEnable)
                {
                    action.OnStayAction(collider);
                }
            });
            onTriggerActions.ForEach(action =>
            {
                if (action.IsEnable)
                {
                    action.OnStayAction(collider);
                }
            });
        }
    }
}
