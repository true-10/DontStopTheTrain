using System;
using System.Collections;
using System.Collections.Generic;

namespace DontStopTheTrain.MiniGames
{
    public interface IMiniGame
    {
        Action<IMiniGame> OnComplete { get; set; }
        void StartMiniGame();
        void StopMiniGame();
    }

    public class MiniGameFabric
    {

        public IMiniGame CreateMiniGame(int type)
        {
            return null;
        }
    }
}
