using System.Collections.Generic;
using True10.TriggerSystem;
using UnityEngine;
using Zenject;

namespace True10.TriggerSystem
{



    public class SequenceAction : AbstractTriggerActivatorMonoActionObject
    {
        [SerializeField]
        public List<AbstractTriggerActivatorMonoActionObject> actions = new();

        public override int TriggerType => 0;

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
