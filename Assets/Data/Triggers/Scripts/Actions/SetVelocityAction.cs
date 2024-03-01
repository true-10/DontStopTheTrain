using True10.TriggerSystem;
using UnityEngine;

namespace DontStopTheTrain.TriggerSystem
{
    public class SetVelocityAction : AbstractOnTriggerActionBehaviour
    {     
        [SerializeField]
        private Rigidbody cachedRigidbody;

        private CharacterController characterController;

        public override void OnEnterAction(Collider collider)
        {
            if (collider.CompareTag("Player"))
            {
                characterController = collider.GetComponent<CharacterController>();
            }
        }

        public override void OnExitAction(Collider collider)
        {
            if (collider.CompareTag("Player"))
            {
                characterController = null;
            }
        }

        public override void OnStayAction(Collider collider)
        {
            if (characterController == null)
            {
                return;
            }

            characterController.Move(cachedRigidbody.velocity * Time.deltaTime);
        }

      /*  private void FixedUpdate()
        {
            if (characterController == null)
            {
                return;
            }

            characterController.Move(cachedRigidbody.velocity * Time.fixedDeltaTime);            
        }*/
    }
}

