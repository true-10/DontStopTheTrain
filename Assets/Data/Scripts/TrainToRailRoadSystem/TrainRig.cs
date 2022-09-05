using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;


namespace DontStopTheTrain.TrainToRailRoadSystem
{

    public class TrainRig : MonoBehaviour
    {
        [SerializeField] private PathCreator pathCreator;
        [SerializeField] private TrainAxle frontAxle;
        [SerializeField] private TrainAxle rearAxle;
        [SerializeField] private float speed = 10f;
      //  [SerializeField] private Vector2 YAngleMinMax = new Vector2(-10f, 10f);

        private Transform rigTransform;


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

        }


        private void SetAxlesToPathAtDistance(float distance)
        {

            var axleDistance = distance + frontAxle.CachedTransform.localPosition.z;
            SetAxleToPathAtDistance(frontAxle, axleDistance);
            axleDistance = distance + rearAxle.CachedTransform.localPosition.z;
            SetAxleToPathAtDistance(rearAxle, axleDistance);
        }

        private void SetAxleToPathAtDistance(TrainAxle axle, float distance) 
        {
            axle.CachedTransform.position = pathCreator.path.GetPointAtDistance(distance);
            axle.CachedTransform.rotation = pathCreator.path.GetRotationAtDistance(distance);

        }
    }
}