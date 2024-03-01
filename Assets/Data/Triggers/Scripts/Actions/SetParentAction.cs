using True10.TriggerSystem;
using UnityEngine;

namespace DontStopTheTrain.TriggerSystem
{
    public class SetParentAction : AbstractOnTriggerActionBehaviour
    {
        [SerializeField]
        private Transform parentTransform;


        public override void OnEnterAction(Collider collider)
        {
            if (collider.CompareTag("Player"))
            {
                collider.gameObject.transform.SetParent(parentTransform);
            }
        }

        public override void OnExitAction(Collider collider)
        {
            if (collider.CompareTag("Player"))
            {
                collider.gameObject.transform.SetParent(null);
            }
        }

        public override void OnStayAction(Collider collider)
        {

        }
    }
}

