using DG.Tweening;
using System.Collections;

namespace True10.AnimationSystem
{
    public interface IAnimation
    {
        void ResetAnimation();
        void StartAnimation();
        void StopAnimation();
        IEnumerator Animation();

    }

    [System.Serializable]
    public class FloatAnimationData//вынести в другой неймспейс по анимациям
    {
        public float Value;
        public bool IsEnable = true;
        public float Duration;
        //public float Delay;
        public Ease Ease;
        // public System.Action OnChange { get; set; }
    }

    public class TweenAnimationData<T>//вынести в другой неймспейс по анимациям
    {
        public T Value;
        public bool IsEnable;
        public float Duration;
        //public float Delay;
        public Ease Ease;
        // public System.Action OnChange { get; set; }
    }
}
