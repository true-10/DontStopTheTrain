using System;
using True10.CameraSystem;
using True10.Interfaces;
using UnityEngine;

namespace DontStopTheTrain.MiniGames
{
    public class MonoMiniGame : MonoBehaviour, IMiniGame
    {
        public Action<IMiniGame> OnComplete { get; set; }
        public virtual void StartMiniGame() { }
        public virtual void StopMiniGame() { }
    }

    public abstract class AbstractMiniGame : MonoBehaviour, IMiniGame, IGameLifeCycle
    {
        public Action<IMiniGame> OnComplete { get; set; }

        [SerializeField]
        protected CameraHolder _cameraHolder;

        public abstract void Initialize();
        public abstract void Dispose();

        public abstract void StartMiniGame();
        public abstract void StopMiniGame();

        private void Start()
        {
            Initialize();
        }

        private void OnDestroy()
        {
            Dispose();
        }
    }
}
