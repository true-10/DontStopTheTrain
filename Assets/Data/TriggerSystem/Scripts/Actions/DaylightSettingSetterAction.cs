using System.Collections;
using System.Collections.Generic;
using True10.DayLightSystem;
using UnityEngine;


namespace True10.TriggerSystem
{
    public class DaylightSettingSetterAction : AbstractTriggerMonoActionObject
    {
        [SerializeField]
        private DayLightSettingsScriptableObject data;


        public override int TriggerType => 0; //speedType?

        public override void OnEnterAction(IOnTriggerCallback callback)
        {

        }

        public override void OnExitAction(IOnTriggerCallback callback)
        {

        }

        public override void OnStayAction(IOnTriggerCallback callback)
        {

        }
    }
}