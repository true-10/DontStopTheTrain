using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using True10.AnimationSystem;
using UnityEngine;
using UnityEngine.Rendering;

namespace True10.DayLightSystem
{

    [System.Serializable]
    public class DayLightSettings
    {
        public SunSettings SunData;
        public VolumeSettings VolumeData;

    }    
    
    [System.Serializable]
    public class SunSettings
    {
        public FloatAnimationData Intensity;

    }    

    [System.Serializable]
    public class VolumeSettings
    {
        //public VolumeProfile VolumeProfile;
        [Header("HDRi sky")]
        public FloatAnimationData DesiredLuxValue;
        [Header("Exposure")]
        public FloatAnimationData FixedExposure;

    }
}
