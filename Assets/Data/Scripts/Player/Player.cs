using DontStopTheTrain.Events;
using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using Zenject;

namespace DontStopTheTrain
{
    [System.Serializable]
    public sealed class Player: IInitializable, IDisposable
    {
        public IReadOnlyReactiveProperty<int> Days => _days;//дней в пути / кол-во ходов
        public IReadOnlyReactiveProperty<int> Expo => _expo;
        public IReadOnlyReactiveProperty<int> Level => _level;
        public IReadOnlyReactiveProperty<int> ActionPoints => _actionPoints;
        public IReadOnlyReactiveProperty<int> Score => _score; //сколько очков заработал
        public IReadOnlyReactiveProperty<int> Credits => _credits; //сколько денег
        public List<IPerk> Perks { get; private set; }

        [Inject]
        private Inventory _inventory;
        [Inject]
        private TurnBasedController _turnBasedController;
        [Inject]
        private LevelsStaticManager _levelsStaticManager;
        [Inject]
        private EventController _eventController;

        private ReactiveProperty<int> _expo = new();
        private ReactiveProperty<int> _level = new();
        private ReactiveProperty<int> _actionPoints = new();
        private ReactiveProperty<int> _score = new();
        private ReactiveProperty<int> _credits = new();
        private ReactiveProperty<int> _days = new();

        private CompositeDisposable _disposables = new CompositeDisposable();
        private ActionPointsCalculator _actionPointsCalculator = new();
        private LevelUpCalculator _levelUpCalculator;

        private int cachedItemCount = 0;

        public void Initialize()
        {
            _levelUpCalculator = new(_levelsStaticManager);

            _inventory.OnInventoryChanged += OnInventoryChanged;
            _turnBasedController.OnTurnStart += OnTurnStart;
            _turnBasedController.OnTurnEnd += OnTurnEnd;
            _eventController.OnComplete += OnEventComplete;
            //_turnBasedController.OnTurnEnd += TryToLevelUp?;

            Expo.Subscribe(x => TryToLevelUp())
                .AddTo(_disposables);

            TryToLevelUp();
        }

        public void Dispose()
        {
            _inventory.OnInventoryChanged -= OnInventoryChanged;
            _turnBasedController.OnTurnStart -= OnTurnStart;
            _turnBasedController.OnTurnEnd -= OnTurnEnd;
            _eventController.OnComplete -= OnEventComplete;

            _disposables.Clear();
        }

        public void AddPerk(IPerk newPerk)
        {
        }

        private void OnTurnStart(ITurnCallback callback)
        {
            _days.Value = callback.Number;
            ResetActionPoints();
        }

        private void OnTurnEnd(ITurnCallback callback)
        {
            // TryToLevelUp();
        }

        private void OnEventComplete(IEvent eventData)
        {
            _actionPoints.Value -= eventData.StaticData.ActionPointPrice;
        }

        private void ResetActionPoints()
        {
            _actionPoints.Value = _actionPointsCalculator.GetActionPointsCount();
        }

        private void OnInventoryChanged(InventoryCallback callback)
        {
            if (callback.OperationStatus == InventoryOperationStatus.Fail)
            {
                return;
            }

            switch (callback.ItemStaticData.Type)
            {
                case ItemType.Player:
                    if(_inventory.TryGetCountById(callback.ItemStaticData.Id, out cachedItemCount))
                    {
                        ProcessPlayerItem(callback);
                    }
                    break;
                
            }
        }

        private void ProcessPlayerItem(InventoryCallback callback)
        {
            var playerItemStaticData = callback.ItemStaticData as IPlayerItemStaticData;
            if (playerItemStaticData == null)
            {
                return;
            }
            switch (playerItemStaticData.PlayerItemType)
            {
                case PlayerItemType.Expo:
                    _expo.Value = cachedItemCount;
                    break;
                case PlayerItemType.Credits:
                    _credits.Value = cachedItemCount;
                    break;
                case PlayerItemType.Score:
                    _score.Value = cachedItemCount;
                    break;
            }
            
        }

        private void TryToLevelUp()
        {
            var newLevel = _levelUpCalculator.GetLevel(Expo.Value);
            if (newLevel > _level.Value)
            {
                _level.Value = newLevel;
            }            
        }

    }

    public static class PlayerDataLoader
    {
        public static Player LoadPlayerData()
        {
            //если есть сохранения, то загружаем их
            //если нет, то стартовые параметры
            return new Player();
        }
    }
}
