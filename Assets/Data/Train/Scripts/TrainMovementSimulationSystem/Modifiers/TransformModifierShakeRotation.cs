using UnityEngine;
using DG.Tweening;

namespace DontStopTheTrain.Train
{
    [CreateAssetMenu(fileName = "ShakeRotation", menuName = "DST/Train/TrasformAnimation/ShakeRotation")]
    public sealed class TransformModifierShakeRotation : AbstractTransformModifier
    {
        [SerializeField, Header("ShakeRotation")]
        private float _shakeStrength = 0.2f;
        [SerializeField]
        private int _shakeVibrato = 5;
        [SerializeField]
        private float _shakeRandomness = 1000f;
        [SerializeField]
        private bool _shakeFadeOut = true;

        private float _shakeDuration;
        private float _randomness;

        protected override Tween Modify(Transform target, float multiplayer)
        {
            return target.DOShakeRotation(_shakeDuration, _shakeStrength * multiplayer, _shakeVibrato, _randomness, _shakeFadeOut);
        }

        protected override void Init(Transform target, float multiplayer)
        {
            _shakeDuration = _duration  * (1f + Random.Range(-0.2f, 0.2f));
            _randomness = _shakeRandomness * (1f + Random.Range(-0.2f, 0.2f));
        }
    }
}




