using UnityEngine;

namespace DontStopTheTrain.Events
{
    [CreateAssetMenu(fileName = "WagonFire", menuName = "DST/Events/Wagon/Fire")]
    public class WagonFireStaticData : EventStaticDataBase, IWagonEventStaticData
    {
        public override EventType Type => EventType.Wagon;
        public WagonEventType WagonEventType => _wagonEventType;

        [SerializeField]
        private WagonEventType _wagonEventType;
    }
}