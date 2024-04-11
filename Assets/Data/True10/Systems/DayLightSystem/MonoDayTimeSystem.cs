
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using DG.Tweening;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;
using UniRx;
/*
namespace True10.DayLightSystem
{
    public class MonoDayTimeSystem : MonoBehaviour
    {
        [Inject]
        private ITurnController turnController;

        [SerializeField]
        private Gradient directionalLightGradient;
        [SerializeField]
        private Gradient ambientLightGradient;
        [SerializeField]
        private Light sun;
        [SerializeField, Range(0f, 3600f)]
        private float dayTimeInSeconds;
        [SerializeField]
        private float timeProgress;


        private Vector3 defaultAngle;

        private void Start()
        {
            defaultAngle = sun.transform.localEulerAngles;
        }
                
        private void SetSunValues(float progress)
        {
            sun.color = directionalLightGradient.Evaluate(progress);
            sun.transform.localEulerAngles = new Vector3(360f * progress - 90f, defaultAngle.x, defaultAngle.z);
        }

        private void SetAmbientColor(float progress)
        {
            //sun.color = ambientLightGradient.Evaluate(progress);
        }
    }
}*/
