using UnityEngine;

namespace DontStopTheTrain.TrainToRailRoadSystem
{
    public class TrainPowerAxle : TrainAxle
    {
        [SerializeField]
        protected float speed = 10f;

        protected override void UpdateAxle()
        {
          /*  if (splineServiceBehaviour.TryToGetTransformDataFrom(cachedTransform.position, out var newPos, out var quaternion))
            {
                cachedTransform.position = newPos;
                cachedTransform.rotation = quaternion;

                rb.velocity = transform.forward * speed;
            }*/
        }
    }

}
