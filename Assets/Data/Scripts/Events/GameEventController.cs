using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace DontStopTheTrain.Events
{
    public class GameEventController : MonoBehaviour, IGameEventController
    {

        public Action<IGameEventCallback> OnChangeEventStatus { get; set; }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void FireEvent(IGameEvent gameEvent)
        {
            var callback = new GameEventCallback();

            OnChangeEventStatus?.Invoke(callback);
        }
    }
}

