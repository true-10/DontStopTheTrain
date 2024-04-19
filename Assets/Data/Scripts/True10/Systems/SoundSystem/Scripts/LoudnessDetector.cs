using System;
using System.Collections;
using System.Collections.Generic;
using True10.SignalsSystem;
using UnityEngine;

namespace True10.SoundSysten
{
    public interface ILoudnessDetector : ISignalEmitter //ISignalsSystem
    {
        Action<float> OnSignal { get; set; }
        void Init();
        void Tick(float deltaTime);
    }

    //�udioMeter
    public class LoudnessDetector: ILoudnessDetector
    {
        private AudioSource audioSource;

        private float updateStep = 0.03f;
        private int sampleDataLength = 1024;

        private float[] clipSampleData;

        private float currentUpdateTime = 0f;

        public Action<float> OnSignal { get; set; }

        public LoudnessDetector(AudioSource audioSource,
            float updateStep = 0.03f,
        int sampleDataLength = 1024
)
        {
            this.audioSource = audioSource;
            this.updateStep = updateStep;
            this.sampleDataLength = sampleDataLength;

        }

        public void Init()
        {
            clipSampleData = new float[sampleDataLength];
        }

        public void Tick(float deltaTime)
        {
            currentUpdateTime += deltaTime;
            if (currentUpdateTime >= updateStep)
            {
                currentUpdateTime = 0f;
                audioSource.clip.GetData(clipSampleData, audioSource.timeSamples); //I read 1024 samples, which is about 80 ms on a 44khz stereo clip, beginning at the current sample position of the clip.
                var clipLoudness = 0f;
                foreach (var sample in clipSampleData)
                {
                    clipLoudness += Mathf.Abs(sample);
                }
                clipLoudness /= sampleDataLength; //clipLoudness is what you are looking for
                OnSignal?.Invoke(clipLoudness);
            }

        }
    }

    /*public class Loudness : MonoBehaviour
    {
        public bool playAlone = false;
        public AudioSource audioSource;
        public float updateStep = 0.03f;
        public int sampleDataLength = 1024;

        private float currentUpdateTime = 0f;

        private float clipLoudness;
        private float[] clipSampleData;

       // public MyZoom zoom;
        //public MyFlash flash;
        //MyBeat[] cb;
        public float pitchEndValue;
        private float pitch;

        public List<AudioClip> songs;
        int songCount = 0;

        void Awake()
        {

            if (playAlone)
            {
                cb = FindObjectsOfType<MyBeat>();
                if (!audioSource)
                {
                    Debug.LogError(GetType() + ".Awake: there was no audioSource set.");
                }
                clipSampleData = new float[sampleDataLength];
            }
            NextSong();

        }
        // Update is called once per frame
        void Update()
        {
            currentUpdateTime += Time.deltaTime;
            if (currentUpdateTime >= updateStep)
            {
                currentUpdateTime = 0f;
                audioSource.clip.GetData(clipSampleData, audioSource.timeSamples); //I read 1024 samples, which is about 80 ms on a 44khz stereo clip, beginning at the current sample position of the clip.
                clipLoudness = 0f;
                foreach (var sample in clipSampleData)
                {
                    clipLoudness += Mathf.Abs(sample);
                }
                clipLoudness /= sampleDataLength; //clipLoudness is what you are looking for
                DOBeat(clipLoudness);
                DOFlash(clipLoudness);
                DOZoom(clipLoudness);
            }

            if (Input.GetMouseButtonDown(0))
            {
                audioSource.pitch = 1 - pitchEndValue;
            }
            else if (Input.GetMouseButtonDown(1))
            {
                audioSource.pitch = 1 + pitchEndValue;
            }
            else if (Input.GetMouseButtonUp(0) || Input.GetMouseButtonUp(1))
            {
                audioSource.pitch = 1;
            }
        }

        public void NextSong()
        {
            audioSource.enabled = false;
            if (songCount >= songs.Count)
            {
                songCount = 0;
            }
            audioSource.clip = songs[songCount];
            songCount++;
            audioSource.enabled = true;
        }

        void DOBeat(float v)
        {
            for (int i = 0; i < cb.Length; i++)
                cb[i].DoBeat(v);
        }

        void DOFlash(float v)
        {
            flash.DoFlash(v);
        }

        void DOZoom(float v)
        {
            zoom.DoZoom(v);
        }
    }*/
}