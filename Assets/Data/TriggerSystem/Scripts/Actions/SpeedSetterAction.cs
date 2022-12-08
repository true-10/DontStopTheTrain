using System.Collections;
using System.Collections.Generic;
using True10.Animation;
using True10.DayLightSystem;
using True10.LevelScrollSystem;
using True10.LevelScrollSystem.ESC;
using True10.TriggerSystem;
using UnityEngine;
using Zenject;

namespace True10.TriggerSystem
{
    public class SpeedSetterAction : AbstractTriggerActivatorMonoActionObject
    {
        [Inject]
        private ILevelScrollSpeedController levelScrollSpeedController;
        [SerializeField]
        private FloatAnimationData speedMult;


        public override int TriggerType => 0; //speedType?

        public override void OnEnterAction(IOnTriggerCallback callback)
        {
            if (IsEnable == false)
            {
                return;
            }
            //Debug.Log($"SpeedSetterAction: Pretending to change speed = {levelScrollSpeedController.Multilplayer} on enter");
            levelScrollSpeedController.SetMultiplayer(speedMult);
        }

        public override void OnExitAction(IOnTriggerCallback callback)
        {

        }

        public override void OnStayAction(IOnTriggerCallback callback)
        {

        }
    }
}

