using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace True10.SoundSysten
{
    public class MonoLoudnessDetector : MonoBehaviour, ILoudnessDetector
    {
        [SerializeField] private AudioSource audioSource;
        [SerializeField] private float updateStep = 0.03f;
        [SerializeField] private int sampleDataLength = 1024;

        private LoudnessDetector loudnessDetector;

        [SerializeField] private UnityEvent<float> OnSignalEvent;
        public Action<float> OnSignal { get; set; }

        public void Init()
        {
            loudnessDetector.OnSignal += OnSignalHandler;
            
            loudnessDetector?.Init();
        }

        public void Tick(float deltaTime)
        {
            loudnessDetector?.Tick(deltaTime);
        }

        // Start is called before the first frame update
        void Start()
        {
            loudnessDetector = new LoudnessDetector(audioSource, updateStep, sampleDataLength);
            Init();
        }

        // Update is called once per frame
        void Update()
        {
            Tick(Time.deltaTime);
        }

        private void OnSignalHandler(float loudness)
        {
            //Debug.Log($"MonoLoudnessDetector: loudness = {loudness}");
            OnSignal?.Invoke(loudness);
            OnSignalEvent?.Invoke(loudness);


        }
    }
}
