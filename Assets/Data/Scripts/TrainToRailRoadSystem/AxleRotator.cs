using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace DontStopTheTrain.TrainToRailRoadSystem
{
    public class AxleRotator : MonoBehaviour
    {
        public static float speed = -3f;

        private Transform cachedTransform;
        // Start is called before the first frame update
        void Start()
        {
            cachedTransform = GetComponent<Transform>();
        }

        void LateUpdate()
        {
            cachedTransform.Rotate(Vector3.right * speed * 360f* Time.deltaTime);
        }
    }
}
