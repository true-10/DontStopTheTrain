using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DontStopTheTrain.Gameplay
{
    /// <summary>
    /// активность в течение игрового дня (пока очки действия не кончатся)
    /// </summary>
    public interface ITurnController
    {

        Action OnTurnEnd { get; set; }
        Action OnTurnStart { get; set; }
    }


    public class GameController : MonoBehaviour
    {
        private ITrainController trainController;
        private IGameEventsController gameEventsController;



    }
}
