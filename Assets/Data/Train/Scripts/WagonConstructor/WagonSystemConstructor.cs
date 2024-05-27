using UnityEngine;

namespace DontStopTheTrain.Train.Constructor
{
    public class WagonSystemConstructor : MonoBehaviour
    {
        public WagonSystemVisualData StaticData => _staticData;

        [SerializeField]
        private WagonSystemVisualData _staticData;
    }
}
