using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DontStopTheTrain.Events
{
    public class MonoDataEventGenerator : MonoBehaviour
    {
        [SerializeField] 
        private MonoDataEventManager dataEventManager;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        /// <summary>
        /// generating event for current turn?
        /// </summary>
        /// <param name="turn"></param>
        /// <returns></returns>
        public IGameEvent GenerateEvent(int turn)
        {

            return null;
        }
    }
}
