using System;
using UnityEngine;


namespace DontStopTheTrain.Events
{
    public class WagonEventViewer : AbstractEventViewer
    {
        public override EventType Type => EventType.Wagon;

        protected override void OnStartEvent(IEvent eventData)
        {
            Debug.Log("HELLO");
            //отображаем 
        }

        protected override void OnCompleteEvent(IEvent eventData)
        {
            Debug.Log("GOODBYE");
        }

    }
}
