using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using Zenject;

namespace DontStopTheTrain
{
    ///
    public interface IUnlock
    {
        int Id { get; }
        int MinimalLevelPlayer { get; }//minimal user player for unlocking this perk 

    }

    public interface IPerk
    {
        int UnlockId { get; }

    }
    public interface IInfuencers
    {
        //временный баф/дебаф
    }

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

        private ReactiveProperty<int> _expo = new();
        private ReactiveProperty<int> _level = new();
        private ReactiveProperty<int> _actionPoints = new();
        private ReactiveProperty<int> _score = new();
        private ReactiveProperty<int> _credits = new();
        private ReactiveProperty<int> _days = new();
        private CompositeDisposable _disposables = new CompositeDisposable();

        private ActionPointsCalculator _actionPointsCalculator = new();
        private LevelUpCalculator _levelUpCalculator = new();

        public void Initialize()
        {
            //подписываемся на реворд контроллер? получаем награду
            _inventory.OnInventoryChanged += OnInventoryChanged;
            _turnBasedController.OnTurnStart += OnTurnStart;
            //_turnBasedController.OnTurnEnd += TryToLevelUp?;

            Expo.Subscribe(x => TryToLevelUp())
                .AddTo(_disposables);

            TryToLevelUp();

        }


        public void Dispose()
        {
            _inventory.OnInventoryChanged -= OnInventoryChanged;
            _turnBasedController.OnTurnStart -= OnTurnStart;

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
                    if(_inventory.TryGetCountById(callback.ItemStaticData.Id, out var itemCount))
                    {
                        if (callback.ItemStaticData is IPlayerItemStaticData)
                        {
                            var playerItemType = (callback.ItemStaticData as IPlayerItemStaticData).PlayerItemType;

                            switch (playerItemType)
                            {
                                case PlayerItemType.Expo:
                                    _expo.Value = itemCount;
                                    break;
                                case PlayerItemType.Credits:
                                    _credits.Value = itemCount;
                                    break;
                                case PlayerItemType.Score:
                                    _score.Value = itemCount;
                                    break;
                            }
                        }
                    }
                    break;
                
            }
        }

        private void TryToLevelUp()
        {
            _level.Value = _levelUpCalculator.GetLevel(Expo.Value);
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
