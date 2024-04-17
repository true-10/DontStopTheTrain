using System.Collections.Generic;
using True10.AnimationSystem;
using UnityEngine;

namespace DontStopTheTrain.Train
{
    public class TrainCartBehaviour : MonoBehaviour
    {
        [SerializeField]
        private float _rotationSpeed = 1000f;
        [SerializeField]
        private List<ObjectRotation> objectsRotation;

        public void SetSpeedRotation(float speed)
        {
            foreach (var item in objectsRotation)
            {
                item.SetSpeedRotation(x: speed);
            }
        }

        private void Start()
        {
            SetSpeedRotation(_rotationSpeed);
        }
    }
}
