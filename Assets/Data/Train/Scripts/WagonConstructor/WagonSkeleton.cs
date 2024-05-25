using System;
using UnityEngine;

namespace DontStopTheTrain.Train.Constructor
{
    [Obsolete]
    public class WagonSkeleton : MonoBehaviour
    {
        [SerializeField]
        private Transform _rampHolder;

        [SerializeField, Header("Rear Carts")]
        private Transform _rearCart_3x;
        [SerializeField]
        private Transform _rearCart_2x_A;
        [SerializeField]
        private Transform _rearCart_2x_B;

        [SerializeField, Header("Front Carts")]
        private Transform _frontCart_3x;
        [SerializeField]
        private Transform _frontCart_2x_A;
        [SerializeField]   
        private Transform _frontCart_2x_B;
    }
}
