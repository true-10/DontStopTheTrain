using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DontStopTheTrain.MiniGames
{
    public interface IMiniGame
    {

    }

    public class MiniGameFabric
    {

        public IMiniGame CreateMiniGame(int type)
        {
            return null;
        }
    }
}
