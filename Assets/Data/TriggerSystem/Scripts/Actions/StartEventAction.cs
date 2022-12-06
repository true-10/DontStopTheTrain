using DontStopTheTrain.Events;
using System.Collections;
using System.Collections.Generic;
using True10.TriggerSystem;
using UnityEngine;
using Zenject;

namespace True10.TriggerSystem
{

    public class StartEventAction : AbstractTriggerMonoActionObject
    {
        [Inject]
        protected IGameEventController gameEventController;

        [SerializeField]
        private int gameEventId = 0;
        private IGameEvent gameEvent = null;
        public override int TriggerType => 0;

        private void Start()
        {
            gameEvent = gameEventController.GetGameEventById(gameEventId);
        }
        public override void OnEnterAction(IOnTriggerCallback callback)
        {
            if (IsEnable == false)
            {
                return;
            }
            Debug.Log($"gameEvent?.Start();");
            gameEvent?.Start();
        }

        public override void OnExitAction(IOnTriggerCallback callback)
        {

        }

        public override void OnStayAction(IOnTriggerCallback callback)
        {

        }
    }
}
