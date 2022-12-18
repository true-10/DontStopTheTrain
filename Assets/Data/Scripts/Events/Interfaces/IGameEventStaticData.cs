using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DontStopTheTrain.Events
{
    public interface IGameEventStaticData
    {
        int Id { get; }
        int ActionPointPrice { get; }
        int EventType { get; }
        // int Weight { get; }
        int Chance { get; }

        //List<ICondition> Conditions;
    }

    public class GameEventStaticData : IGameEventStaticData
    {
        public int Id { get; set; }

        public int ActionPointPrice { get; set; }

        public int EventType { get; set; }
        public int Chance { get; set; }
    }

   
}
