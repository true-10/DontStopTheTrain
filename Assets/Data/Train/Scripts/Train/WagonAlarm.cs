using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DontStopTheTrain.Train
{
    public class WagonAlarm : MonoBehaviour
    {
        [SerializeField]
        private AudioSource _alarmSource;
        [SerializeField]
        private GameObject _alarmObject;//лампочка
                                       
        void Start()
        {
            AlarmOff();
        }


        public void AlarmOn()
        {
            _alarmObject.SetActive(true);
            _alarmSource.Play();
        }

        public void AlarmOff()
        {
            _alarmObject.SetActive(false);
            _alarmSource.Stop();
        }
    }
}
