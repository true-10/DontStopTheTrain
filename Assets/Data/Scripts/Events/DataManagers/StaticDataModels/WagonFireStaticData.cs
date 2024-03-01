using UnityEngine;

namespace DontStopTheTrain.Events
{
    [CreateAssetMenu(fileName = "WagonFire", menuName = "DST/Events/WagonFire")]
    public class WagonFireStaticData : EventStaticDataBase
    {
        public override EventType Type => EventType.Wagon;
    }

    public enum WagonEventType
    {

    }
}