using UnityEngine;

namespace DontStopTheTrain.Train
{
    public class WagonConstructor : MonoBehaviour
    {
        [SerializeField]
        private WagonSkeleton _wagonSkeleton;


        public void AddRamp()
        {

        }
        public void AddCart()
        {

        }
        public void AddHull()
        {

        }

        public void SaveWagon()
        {

        }
        public void LoadWagon()
        {

        }
    }

    public class WagonSkeleton : MonoBehaviour
    {
        [SerializeField]
        private Transform _rampHolder;
    }
}
