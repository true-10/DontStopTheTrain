using UnityEngine;
using DG.Tweening;

namespace DontStopTheTrain.Train
{
    [CreateAssetMenu(fileName = "LocalJump", menuName = "DST/Train/TrasformAnimation/LocalJump")]
    public sealed class TransformModifierLocalJump : AbstractTransformModifier
    {
        [SerializeField, Header("LocalJump")]
        private bool _snapping = true;
       // [SerializeField]
       // private float _jumpPower = 0.5f;
        [SerializeField]
        private int _numJumps = 3;

        private float _currentJumpPower;
        private float _currentDuration;
        private Vector3 _endPosition;

        protected override Tween Modify(Transform target, float multiplayer)
        {
            //  localPosition assign attempt is not valid
            return target.DOLocalJump(_endPosition, _currentJumpPower * multiplayer, _numJumps, _currentDuration, _snapping);
        }

        protected override void Init(Transform target, float multiplayer)
        {
            _endPosition = target.transform.position;
            _currentJumpPower *= (1f + Random.Range(-0.2f, 0.2f));
            _currentDuration *= (1f + Random.Range(-0.2f, 0.2f));
        }
    }
}




