using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace DontStopTheTrain.Events
{
    public class MonoWagonEvent : AbstractMonoEvent
    {

        protected override void Init()
        {
            base.Init();
        }

        protected override void OnChangeEvent(IGameEvent gameEvent)
        {
            if (gameEvent.StaticData.Id != eventId)
            {
                return;
            }

        }

        protected override void OnComplete()
        {
            OnEventEnd?.Invoke();
        }

        protected override void OnStart()
        {
            OnEventStart?.Invoke();


        }

        protected override void OnTick()
        {

        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.N) )
            {
                if (gameEvent == null)
                {
                    return;
                }
                if (gameEvent.Status == GameEventStatus.Start)
                {
                    gameEvent.Complete();
                }
                else
                {
                    gameEvent.Start();
                }
            }
        }
    }
}
