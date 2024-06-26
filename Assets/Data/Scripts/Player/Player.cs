using DontStopTheTrain.Events;
using System;
using System.Collections;
using System.Collections.Generic;
using True10.DayTimeSystem;
using True10.Interfaces;
using UniRx;
using UnityEngine;
using Zenject;

namespace DontStopTheTrain
{

    public enum Corporation
    {
        Oil = 0,
        Media,
        Justice,
        Atom,
        Anarhy,
        Church
    }

    [System.Serializable]
    public sealed class Player: IGameLifeCycle
    {
        public IReadOnlyReactiveProperty<int> Days => _days;//���� � ���� / ���-�� �����
        public IReadOnlyReactiveProperty<int> Expo => _expo;
        public IReadOnlyReactiveProperty<int> Level => _level;
        public IReadOnlyReactiveProperty<int> ActionPoints => _actionPoints;
        public IReadOnlyReactiveProperty<int> Score => _score; //������� ����� ���������
        public IReadOnlyReactiveProperty<int> Credits => _credits; //������� �����
        public IReadOnlyCollection<IPerk> Perks => _perks;

        [Inject]
        private Inventory _inventory;
        [Inject]
        private TurnBasedController _turnBasedController;
        [Inject]
        private DayTimeSystem _dayTimeSystem;
        [Inject]
        private LevelsStaticStorage _levelsStaticManager;
        [Inject]
        private EventController _eventController;
        [Inject]
        private BuffAndPerksService _buffAndPerksService;

        private ReactiveProperty<int> _expo = new();
        private ReactiveProperty<int> _level = new();
        private ReactiveProperty<int> _actionPoints = new();
        private ReactiveProperty<int> _score = new();
        private ReactiveProperty<int> _credits = new();
        private ReactiveProperty<int> _days = new();

        private List<IPerk> _perks;

        private CompositeDisposable _disposables = new CompositeDisposable();
        private ActionPointsCalculator _actionPointsCalculator;
        private LevelUpCalculator _levelUpCalculator;

        private int cachedItemCount = 0;

        public void Initialize()
        {
            _levelUpCalculator = new(_levelsStaticManager);
            _actionPointsCalculator = new(_buffAndPerksService);

            _actionPointsCalculator.Calculate();

            _inventory.OnInventoryChanged += OnInventoryChanged;
            _turnBasedController.OnTurnStart += OnTurnStart;
            _turnBasedController.OnTurnEnd += OnTurnEnd;
            _eventController.OnComplete += OnEventComplete;
            _buffAndPerksService.OnChange += OnPerkOrBuffChanged;
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
            _buffAndPerksService.OnChange -= OnPerkOrBuffChanged;

            _disposables.Clear();
            _expo.Dispose();
            _actionPoints.Dispose();
            _level.Dispose();
            _score.Dispose();
            _credits.Dispose();
            _days.Dispose();
        }

        private void OnPerkOrBuffChanged()
        {
            _actionPointsCalculator.Calculate();
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
            _actionPoints.Value -= eventData.ActionPointPrice;
        }

        private void ResetActionPoints()
        {
            _actionPoints.Value = _actionPointsCalculator.ActionPoints;
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
                case ItemType.Perk:
                    ProcessPerkItem(callback);
                    break;

            }
        }

        private void ProcessPerkItem(InventoryCallback callback)
        {
           // var perkItem = callback.
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
                    _expo.Value = cachedItemCount + Mathf.RoundToInt( cachedItemCount * (_buffAndPerksService.GetValue(PerkType.Experience) / 100f) );
                    break;
                case PlayerItemType.Credits:
                    _credits.Value = cachedItemCount + Mathf.RoundToInt(cachedItemCount * (_buffAndPerksService.GetValue(PerkType.Credits) / 100f));                    
                    break;
                case PlayerItemType.Score:
                    _score.Value = cachedItemCount + Mathf.RoundToInt(cachedItemCount * (_buffAndPerksService.GetValue(PerkType.Score) / 100f));                    
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
            //���� ���� ����������, �� ��������� ��
            //���� ���, �� ��������� ���������
            return new Player();
        }
    }
}
