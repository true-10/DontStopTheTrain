using System.Collections;
using System.Collections.Generic;
using True10.AnimationSystem;
using True10.DayLightSystem;
using True10.LevelScrollSystem;
using True10.LevelScrollSystem.ESC;
using True10.TriggerSystem;
using UnityEngine;
using Zenject;

namespace DontStopTheTrain.TriggerSystem
{
    public class SpeedSetterAction : AbstractOnTriggerEnterActionBehaviour
    {
        [SerializeField]
        private float power = 1000;
        [SerializeField]
        private FloatAnimationData speedMult;


        public override void OnEnterAction(Collider collider)
        {
          /*  if (collider.TryGetComponent<EngineBehaviour>(out var engine))
            {

                engine.SetCurrentPower(power);
            }*/
        }

    }
}

