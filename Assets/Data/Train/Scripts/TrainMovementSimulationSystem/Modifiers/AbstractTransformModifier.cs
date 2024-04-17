using UnityEngine;
using DG.Tweening;

namespace DontStopTheTrain.Train
{
    [System.Serializable]
    public abstract class AbstractTransformModifier: ScriptableObject
    {
        [SerializeField, Header("Common")]
        protected bool _isEnable = true;
        [SerializeField]
        protected LoopType _loopType = LoopType.Restart;
        [SerializeField]
        protected float _duration = 1f;

        protected Tween _tween = null;

        protected abstract Tween Modify(Transform target, float multiplayer);
        protected abstract void Init(Transform target, float multiplayer);

        public void Dispose()
        {
            _tween?.Complete();
            OnTweenComplete();
        }

        public void Do(Transform target, float multiplayer)
        {
            if (_isEnable == false)
            {
                return;
            }
            if (_tween != null)
            {
                return;
            }
            Init(target, multiplayer);
            _tween =  Modify(target, multiplayer).OnComplete(OnTweenComplete);
        }


        protected void OnTweenComplete()
        {
            _tween?.Kill();
            _tween = null;
        }
    }
}




