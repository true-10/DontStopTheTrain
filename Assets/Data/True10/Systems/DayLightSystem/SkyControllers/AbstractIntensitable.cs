using UnityEngine;

namespace True10.DayLightSystem
{
    public abstract class AbstractIntensitable : MonoBehaviour, IIntensitable
    {
        public float Intensity => _intensity;
        public abstract void SetIntensity(float value);

        protected float _intensity;
    }
}
