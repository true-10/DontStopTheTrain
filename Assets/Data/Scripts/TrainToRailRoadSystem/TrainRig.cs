using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace DontStopTheTrain.TrainToRailRoadSystem
{

    public class TrainRig : MonoBehaviour
    {
        [SerializeField] private TrainAxle frontAxle;
        [SerializeField] private TrainAxle rearAxle;
        [SerializeField] private float speed = 10f;
        [SerializeField] private float length = 10f;
        [SerializeField] private float scale =  7f;
        [SerializeField] private float offset =  15f;
      //  [SerializeField] private Vector2 YAngleMinMax = new Vector2(-10f, 10f);

        private Transform rigTransform;

        private float distanceTraveled = 0;
        private void Awake()
        {
            rigTransform = GetComponent<Transform>();
        }

        // Start is called before the first frame update
        void Start()
        {
           // Debug.Log($"{}");
        }

        // Update is called once per frame
        void Update()
        {
            distanceTraveled += speed * Time.deltaTime;
            SetAxlesToPathAtDistance(distanceTraveled);
            UpdateRig(distanceTraveled);

        }

        private void UpdateRig(float distance)
        {
            var direction = frontAxle.CachedTransform.position - rearAxle.CachedTransform.position;
            var normalizedDirection = direction.normalized;
            var newRigPos = rearAxle.CachedTransform.position + normalizedDirection * length / 2f;
            //newRigPos += normalizedDirection * offset;
            rigTransform.position = newRigPos;

            var newRigRot = Quaternion.LookRotation(normalizedDirection);

            rigTransform.rotation = newRigRot;
        }

        private void SetAxlesToPathAtDistance(float distance)
        {
            var halfLength = length / scale / 2f;
            var scaledOffset = offset / scale / 2f;
            var axleDistance = distance + halfLength + scaledOffset;
            SetAxleToPathAtDistance(frontAxle, axleDistance);
            axleDistance = distance - halfLength + scaledOffset;
            SetAxleToPathAtDistance(rearAxle, axleDistance);
        }

        private void SetAxleToPathAtDistance(TrainAxle axle, float distance) 
        {
            Vector3 angleVector = Vector3.forward * 90f;
          //  axle.CachedTransform.position = pathCreator.path.GetPointAtDistance(distance) + Vector3.up * .1f;
            //axle.CachedTransform.rotation = pathCreator.path.GetRotationAtDistance(distance);
            axle.CachedTransform.Rotate(angleVector);

        }
    }
}