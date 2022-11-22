using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

namespace DontStopTheTrain.Gameplay
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

    [System.Serializable]
    public class PlayerDataModel
    {
        public ReactiveProperty<int> ActionPoint { get; }
        public ReactiveProperty<int> Days { get; }//дней в пути / кол-во ходов
        public int Expo { get; }
        public int Level { get; }
        public int Score { get; } //сколько очков заработал
        public List<IPerk> Perks { get; }
    }
}
