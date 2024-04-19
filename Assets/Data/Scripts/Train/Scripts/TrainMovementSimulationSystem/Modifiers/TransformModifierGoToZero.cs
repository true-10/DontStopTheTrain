using UnityEngine;
using DG.Tweening;

namespace DontStopTheTrain.Train
{
    [CreateAssetMenu(fileName = "GoToZero", menuName = "DST/Train/TrasformAnimation/GoToZero")]
    public sealed class TransformModifierGoToZero : AbstractTransformModifier
    {
        [SerializeField, Header("GoToZero")]
        private bool _snapping = true;
        [SerializeField]
        private RotateMode _rotateMode = RotateMode.Fast;
        [SerializeField]
        private Vector3 _targetEulers = Vector3.zero;
        [SerializeField]
        private Vector3 _targetPosition = Vector3.zero;

        private Sequence sequence = null;

        protected override Tween Modify(Transform target, float multiplayer)
        {            
            sequence = DOTween.Sequence();

            sequence
                .Append(target.DOLocalMove(_targetPosition, _duration, _snapping))
                .Join(target.DOLocalRotate(_targetEulers, _duration, _rotateMode));

            return sequence;
        }

        protected override void Init(Transform target, float multiplayer)
        {

        }
    }
}




