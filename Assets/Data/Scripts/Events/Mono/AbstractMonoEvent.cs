using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


namespace DontStopTheTrain.Events
{
    public abstract class AbstractMonoEvent : MonoBehaviour
    {
        [SerializeField] protected UnityEvent OnEventStart;
        [SerializeField] protected UnityEvent OnEventEnd;
        void Start()
        {

        }


    }
}
