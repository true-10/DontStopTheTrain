using Dreamteck.Splines;
using System.Collections;
using System.Collections.Generic;
using True10.TriggerSystem;
using UnityEngine;

namespace DontStopTheTrain.TriggerSystem
{
    public class LevelTriggerTest : LevelTrigger
    {
        [SerializeField, Min(1)] private SplineComputer splineComputer;

        public class OnSplineTriggerCallback : IOnTriggerCallback
        {
            public int TriggetType { get; set; }
            public SplineComputer SplineComputer { get; set; }

        }

        protected override IOnTriggerCallback GetTriggerCallback()
        {
            var callback = new OnSplineTriggerCallback()
            {
                TriggetType = triggerType,
                SplineComputer = splineComputer
            };
            return callback;
        }
    }
}
