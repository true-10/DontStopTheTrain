
using DontStopTheTrain.UI;
using System;
using System.Linq;
using True10.Interfaces;
using True10.LevelScrollSystem;
using UniRx;
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
        public bool IsArrivalDay { get; private set; }

        [Inject]
        private PointOfInterestsManager _manager;
        [Inject]
        private PointOfInterestsGenerator _generator;
        [Inject]
        private Player _player;
        [Inject]
        private LevelScrollController _levelScrollController;
        [Inject]
        private UIContainer _UIContainer;

        private CompositeDisposable _disposables = new();

        public void Dispose()
        {
            _disposables.Dispose();
        }

        public void Initialize()
        {
            _player.Days
                .Subscribe(x => UpdatePointsOfInterest(x))
                .AddTo(_disposables);

            var lastDay = 1;
            for (int i = 0; i < 3; i++)
            {
                var poi = _generator.GeneratePoint(lastDay);
                _manager.TryToAdd(poi);
                lastDay = poi.TravelDays;
            }
        }


        private void UpdatePointsOfInterest(int currentDay)
        {
            TryToGetChunk(currentDay);
            TryToRemoveObsoletePoints(currentDay);
            GenerateNewPoints(currentDay);

            foreach (var item in _manager.Items)
            {
                Debug.Log($"arrival day: {item.TravelDays}");
            }
        }

        private void TryToGetChunk(int currentDay)
        {
            var pointOfInterest = _manager.Items.Where(x => x.TravelDays == currentDay).FirstOrDefault();
            if (pointOfInterest == null)
            {
                IsArrivalDay = false;
                return;
            }
            _levelScrollController.RequestForChunk(pointOfInterest.ChunkType);
            IsArrivalDay = true;
            _UIContainer.Message.ShowMessage("Arrival Day");
           // _UIContainer.Message.ShowMessage("Arrival Day", onHide: () => _UIContainer.MainGamePlay.Show());
        }

        private void TryToRemoveObsoletePoints(int currentDay)
        {
            var pointsOfInterest = _manager.Items.Where(x => x.TravelDays < currentDay).ToList();
            pointsOfInterest.ForEach(x => _manager.TryToRemove(x));
        }

        private void GenerateNewPoints(int currentDay)
        {
            if (_manager.Items.Count <= 1)
            {
                var poi = _generator.GeneratePoint(currentDay);
                _manager.TryToAdd(poi);
            }
        }
    }
}
