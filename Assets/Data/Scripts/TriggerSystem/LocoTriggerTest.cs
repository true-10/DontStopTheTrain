using System.Collections;
using System.Collections.Generic;
using True10.TriggerSystem;
using UnityEngine;

namespace DontStopTheTrain.Gameplay
{
    public enum TriggerTypeEnum
    {
        General,
        StartChunk,
        EndChunk,
    }

    [RequireComponent(typeof(Rigidbody))]
    public class LocoTriggerTest : AbstractTriggerMonoObject
    {
        [SerializeField] private TriggerTypeEnum triggerType = TriggerTypeEnum.General;
        [SerializeField] private Locomotiv loco;

        public override int TriggerType { get => (int)triggerType;}

        public override void OnEnterAction(IOnTriggerCallback callback)
        {
            if (callback == null)
            {
                return;
            }
            if (callback.TriggetType != (int)triggerType)
            {
                return;
            }
            Debug.Log("Hello new chunk");
        }

        public override void OnExitAction(IOnTriggerCallback callback)
        {

        }

        public override void OnStayAction(IOnTriggerCallback callback)
        {

        }
    }
}
