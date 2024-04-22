
using System;
using True10.Interfaces;
using True10.LevelScrollSystem;
using UnityEngine;
using Zenject;

namespace DontStopTheTrain
{
    public class PointOfInterest
    {
        public int TravelDays;//на какой день приедем
        public ChunkType ChunkType;
    }

    public class PointOfInterestController : IGameLifeCycle
    {
        public Action OnStationArrived { get; set; }
        public Action OnStationDepart { get; set; }

        [Inject]
        private PointOfInterestsManager _manager;
        [Inject]
        private PointOfInterestsGenerator _generator;

        public void Dispose()
        {

        }

        public void Initialize()
        {

        }

        //currentPath
    }
}
