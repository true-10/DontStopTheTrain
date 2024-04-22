using System;
using System.Collections;
using System.Collections.Generic;
using True10.Interfaces;
using True10.TriggerSystem;
using UnityEngine;

namespace DontStopTheTrain
{

    public class StationStoppageTrigger : MonoBehaviour, IGameLifeCycle
    {
        [SerializeField]
        private SimpleTrigger _enterTrigger;

        public void Initialize()
        {
            _enterTrigger.OnEnter += OnEnter;
        }

        public void Dispose()
        {
            _enterTrigger.OnEnter -= OnEnter;
        }

        private void OnEnter(Collider collider)
        {
            if (collider.TryGetComponent<Locomotive>(out var loco))
            {
                loco.SetSpeed(0f);
                //включаем режим станции

            }
        }

        private void Start()
        {
            Initialize();
        }


        private void OnDestroy()
        {
            Dispose();
        }
    }
}
