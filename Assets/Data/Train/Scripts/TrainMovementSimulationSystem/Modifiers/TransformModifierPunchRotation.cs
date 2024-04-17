using UnityEngine;
using DG.Tweening;

namespace DontStopTheTrain.Train
{
    [CreateAssetMenu(fileName = "PunchRotation", menuName = "DST/Train/TrasformAnimation/PunchRotation")]
    public sealed class TransformModifierPunchRotation : AbstractTransformModifier
    {
        [SerializeField, Header("PunchRotation")]
        private Vector3 _punchVector = Vector3.up;
        [SerializeField]
        private int _vibrato = 3;
        [SerializeField]
        private float _elasticity = 1f;
        [SerializeField]
        private bool shakeFadeOut = true;

        private Vector3 _currentPunchVector = Vector3.up;
        private float _punchDuration;

        protected override Tween Modify(Transform target, float multiplayer)
        {
            return target.DOPunchRotation(_currentPunchVector * multiplayer, _punchDuration, _vibrato, _elasticity);
        }

        protected override void Init(Transform target, float multiplayer)
        {
            _currentPunchVector = _punchVector * (1f + Random.Range(-0.2f, 0.2f));
            _punchDuration = _duration * (1f + Random.Range(-0.2f, 0.2f));
        }
    }
}




