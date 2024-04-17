
using System;
using UnityEngine;

namespace DontStopTheTrain
{
    public class Path
    {
        public int TravelDays;//
    }

    public class PathController
    {
        Action OnStationArrived { get; set; }
        Action OnStationDepart { get; set; }

        //currentPath
    }

    public class PathGenerator
    {

    }
}
