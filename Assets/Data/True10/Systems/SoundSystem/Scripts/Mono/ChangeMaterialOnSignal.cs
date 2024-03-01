using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace True10.SoundSysten
{
    public class ChangeMaterialOnSignal : MonoBehaviour
    {
        [SerializeField] private float threshold = 0.2f;
        [SerializeField] private float duration = .3f;
        [SerializeField] private Material material;
        [SerializeField] private float initial = 0f;
        [SerializeField] private float target = 5f;
        [SerializeField] private Color initialColor = Color.black;
        [SerializeField] private Color targetColor = Color.white;


        const string EMISSIVE_INTENSITY_KEY = "_EmissiveIntensity";
        const string EMISSIVE_COLOR_KEY = "_EmissiveColor";
        //const string COLOR_KEY = "_Color";
        void Start()
        {
            //initial = material.GetFloat(EMISSIVE_INTENSITY_KEY);
            //target = initial * intensityMultiplayer;
        }

        public void MaterialEmitIntensityOnSignal(float loudness)
        {
            if (loudness < threshold) return;

            // Debug.Log($"LightFlashOnSignal: loudness = {loudness}");
            var sequence = DOTween.Sequence();
            var tween1 = material.DOFloat(target, EMISSIVE_INTENSITY_KEY, duration);
            var tween2 = material.DOFloat(initial, EMISSIVE_INTENSITY_KEY, 0f);
            var tween3 = material.DOColor(targetColor, EMISSIVE_COLOR_KEY, 0f);
            var tween4 = material.DOColor(initialColor, EMISSIVE_COLOR_KEY, 0f);
            sequence
                .Append(tween1)
                .Join(tween3)
                .Append(tween2)
                .Join(tween4);

        }
    }
}
