using System.Collections;
using System.Collections.Generic;
using True10.TriggerSystem;
using UnityEngine;
using static DontStopTheTrain.TriggerSystem.LevelTriggerTest;

namespace DontStopTheTrain.TriggerSystem
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

            var splineCallBack = callback as OnSplineTriggerCallback;

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
