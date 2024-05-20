using UnityEngine;

namespace DontStopTheTrain.Train.Constructor
{
    public class WagonSystemConstructor : MonoBehaviour
    {
        public WagonPartStaticData StaticData => _staticData;

        [SerializeField]
        private WagonPartStaticData _staticData;
    }
}
