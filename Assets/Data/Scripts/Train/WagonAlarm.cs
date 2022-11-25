using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DontStopTheTrain.Train
{
    public class WagonAlarm : MonoBehaviour
    {
        [SerializeField]
        private AudioSource alarmSource;
        [SerializeField]
        private GameObject alarmObject;//лампочка
                                       
        void Start()
        {

        }


        public void AlarmOn()
        {
            alarmObject.SetActive(true);
            alarmSource.Play();
        }
        public void AlarmOff()
        {
            alarmObject.SetActive(false);
            alarmSource.Stop();
        }
    }
}
