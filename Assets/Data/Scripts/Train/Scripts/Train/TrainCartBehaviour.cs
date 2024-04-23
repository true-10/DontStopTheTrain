using System.Collections.Generic;
using True10.AnimationSystem;
using True10.Interfaces;
using True10.LevelScrollSystem;
using UnityEngine;
using Zenject;

namespace DontStopTheTrain.Train
{
    public class TrainCartBehaviour : AbstractControllerBySpeed
    {
        [SerializeField]
        private float _rotationSpeed = 1000f;
        [SerializeField]
        private List<ObjectRotation> objectsRotation;

        public void SetSpeedRotation(float speed)
        {
            foreach (var item in objectsRotation)
            {
                item.SetSpeedRotation(x: -speed);
            }
        }

        public override void OnSpeedChange(float speed)
        {
            _locomotive ??= _wagonsManager.GetLocomotive();
            SetSpeedRotation(_rotationSpeed * _locomotive.SpeedMultiplayer);
        }
    }
}
