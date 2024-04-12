using DontStopTheTrain.Events;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DontStopTheTrain
{
    public class TurnBasedController : MonoBehaviour, ITurnBasedController
    {
        public Action<ITurnCallback> OnTurnStart { get; set; }
        public Action<ITurnCallback> OnTurnTick { get; set; }
        public Action<ITurnCallback> OnTurnEnd { get; set; }

        public int CurrentTurn { get; private set; }

        private Coroutine _turnLoopCoroutine = null;

        private bool _turnIsComleted = false;
        private bool _continueAfterStart = false;
        private bool _startNextTurn = false;


        void Start()
        {
            InitCallbacks();
            _turnLoopCoroutine = StartCoroutine( TurnLoopCoroutine() );
        }


        private IEnumerator TurnLoopCoroutine()
        {
            CurrentTurn = 1;


            //некое событие

            while (true)
            {
                _turnIsComleted = false;
                _continueAfterStart = false;
                _startNextTurn = false;
                int groupId = GetTurnGroup(CurrentTurn); //выдаем группу, чей ход
                TurnCallback callback = new(CurrentTurn, groupId)
                {
                     //- общее кол-во ходов или индекс Index с начала
                                   //turnGroup - группа хода. кто входит в эту группу, тот и ходит
                };

                OnTurnStart?.Invoke(callback);


                yield return new WaitUntil( () => _continueAfterStart);
                while (_turnIsComleted == false)
                {
                   // OnTurnTick?.Invoke(callback);
                    yield return null;
                }

                yield return null;

                //если события не выполнены, то применяем штраф (дебафф?)

                OnTurnEnd?.Invoke(callback);

               /* while (_startNextTurn == false)
                {
                    //пока событие обзора показывается
                    yield return null;
                }*/
                CurrentTurn++;
                yield return null;
            }
        }

        private void InitCallbacks()
        {

        }

        private int GetTurnGroup(int index)
        {

            return 0;
        }

        public void CompleteTurn()
        {
            _turnIsComleted = true;
        }

        public void StartTurn()
        {
            _continueAfterStart = true;
        }
        public void NextTurn()
        {
            _startNextTurn = true;
        }
    }


    public interface ITurnCallback
    {
          int Number { get; }
        //    int GroupId { get;}

    }

    public class TurnCallback : ITurnCallback
    {
        public int Number { get; private set; }
        public int GroupId { get; private set; }//TurnGroup
        public int Order { get; set; }

        public TurnCallback(int number, int groupId)
        {
            Number = number;
            GroupId = groupId;
        }

    }

    /// <summary>
    /// активность в течение игрового дня (пока очки действия не кончатся)
    /// </summary>
    public interface ITurnBasedController
    {
        Action<ITurnCallback> OnTurnEnd { get; set; }
        Action<ITurnCallback> OnTurnStart { get; set; }
        // Action<ITurnCallback> OnTurnTick { get; set; }

        void StartTurn();
        void CompleteTurn();
    }

    public enum TurnGroup
    {
        PlayerMove = 0,

    }
}
