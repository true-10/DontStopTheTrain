using System;
using System.Collections;
using System.Collections.Generic;
using True10.Interfaces;
using True10.TriggerSystem;
using UnityEngine;

namespace DontStopTheTrain
{
    public abstract class AbstractOnTriggerEnter : AbstractGameLifeCycleBehaviour
    {
        [SerializeField]
        protected SimpleTrigger _enterTrigger;

        public override void Initialize()
        {
            _enterTrigger.OnEnter += OnEnter;
        }

        public override void Dispose()
        {
            _enterTrigger.OnEnter -= OnEnter;
        }

        public abstract void OnEnter(Collider collider);
    }

    public class SpeedSetterTrigger : AbstractOnTriggerEnter
    {
        [SerializeField]
        private float _speed;

        public override void OnEnter(Collider collider)
        {
            if (collider.TryGetComponent<Locomotive>(out var loco))
            {
                loco.SetSpeed(_speed);
            }
        }
    }
}
