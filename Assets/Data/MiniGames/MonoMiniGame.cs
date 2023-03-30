using UnityEngine;

namespace DontStopTheTrain.MiniGames
{
    public class MonoMiniGame : MonoBehaviour, IMiniGame
    {
        public virtual void StartMiniGame() { }
        public virtual void StopMiniGame() { }
    }
}
