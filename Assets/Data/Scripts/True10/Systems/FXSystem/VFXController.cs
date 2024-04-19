using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

namespace True10.FXSystem
{

    public class VFXController : MonoBehaviour, IEffect
    {
        [SerializeField]
        private VisualEffect _visualEffect;

        public void Play()
        {
            _visualEffect.Play();
        }

        public void Stop()
        {
            _visualEffect.Stop();
        }
    }

}
