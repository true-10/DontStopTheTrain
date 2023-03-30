using System.Collections;
using System.Collections.Generic;

namespace DontStopTheTrain.MiniGames
{
    public interface IMiniGame
    {
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
