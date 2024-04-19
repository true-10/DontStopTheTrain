using True10.TriggerSystem;
using UnityEngine;

namespace DontStopTheTrain
{
    public class LevelChunkTrigger : SimpleTrigger
    {
        private void OnTriggerEnter(Collider collider)
        {
            if (collider.TryGetComponent<Locomotive>(out var loco))
            {
                OnEnter?.Invoke(collider);
                onEnterEvent?.Invoke();
            }
        }

        private void OnTriggerExit(Collider collider)
        {
            if (collider.TryGetComponent<Locomotive>(out var loco))
            {
                OnExit?.Invoke(collider);
                onExitEvent?.Invoke();
            }
        }

        private void OnTriggerStay(Collider collider)
        {
            if (collider.TryGetComponent<Locomotive>(out var loco))
            {
                OnStay?.Invoke(collider);
                onStayEvent?.Invoke();
            }
        }
    }
}
