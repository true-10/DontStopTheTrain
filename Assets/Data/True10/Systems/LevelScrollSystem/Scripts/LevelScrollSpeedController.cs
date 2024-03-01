using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using True10.DayLightSystem;
using True10.AnimationSystem;

namespace True10.LevelScrollSystem
{
    public interface ILevelScrollSpeedController
    {
        float Multilplayer { get; }
        void SetMultiplayer(FloatAnimationData multiplayer);
    }

    public class LevelScrollSpeedController : MonoBehaviour, ILevelScrollSpeedController
    {
        public float Multilplayer => multiplayer;

        private float multiplayer = 1f;

        Tween speedTween = null;

        public void SetMultiplayer(FloatAnimationData mult)
        {
            if (mult.IsEnable)
            {
                speedTween?.Kill();

                speedTween = DOTween.To(() => multiplayer, x => multiplayer = x, mult.Value, mult.Duration)
                    .SetEase(mult.Ease);
            }
        }
    }
}
