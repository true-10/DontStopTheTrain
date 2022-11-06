using Dreamteck.Splines;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using True10.TriggerSystem;
using DontStopTheTrain.TriggerSystem;
using static DontStopTheTrain.TriggerSystem.LevelTriggerTest;

namespace DontStopTheTrain.Gameplay
{
    /// <summary>
    /// повторяем изгиб сплайна, не меняя координату Z
    /// </summary>
    public class SplineSnapper : AbstractTriggerMonoObject
    {
        [SerializeField] private SplineProjector splineProjector;
        //[SerializeField] private SplineComputer splineComputer;
        [SerializeField] private TriggerTypeEnum triggerType = TriggerTypeEnum.General;

        public override int TriggerType => throw new System.NotImplementedException();

        public override void OnEnterAction(IOnTriggerCallback callback)
        {

            if (callback == null)
            {
                return;
            }
            if (callback.TriggetType != (int)triggerType)
            {
                if (splineProjector != null)
                {
                    splineProjector.spline = null;
                }

                return;
            }

            var splineCallBack = callback as OnSplineTriggerCallback;

            if (splineCallBack == null)
            {
                return;
            }
            splineProjector.spline = splineCallBack.SplineComputer;
            Debug.Log("SplineSnapper Hello new chunk");
        }

        public override void OnExitAction(IOnTriggerCallback callback)
        {
          /*  if (callback == null)
            {
                return;
            }
            if (callback.TriggetType != (int)triggerType)
            {
                return;
            }
            splineProjector.spline = null ;*/
        }

        public override void OnStayAction(IOnTriggerCallback callback)
        {

        }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }

}
