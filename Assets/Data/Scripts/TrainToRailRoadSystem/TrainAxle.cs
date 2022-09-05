using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DontStopTheTrain.TrainToRailRoadSystem
{

    public class TrainAxle : MonoBehaviour
    {

        private Transform cachedTransform;
        public Transform CachedTransform { get => cachedTransform; }

        private void Awake()
        {
            cachedTransform = GetComponent<Transform>();
        }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }

}
