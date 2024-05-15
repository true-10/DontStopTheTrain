using UnityEngine;

namespace DontStopTheTrain
{
    public class SpeedSetterTrigger : AbstractOnTriggerEnter
    {
        [SerializeField]
        private float _speed;
        [SerializeField]
        private float _duration = 1f;

        public override void OnEnter(Collider collider)
        {
            if (collider.TryGetComponent<Locomotive>(out var loco))
            {
                loco.SetSpeed(_speed, _duration);
            }
        }
    }
}
