using DontStopTheTrain.Events;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DontStopTheTrain.Gameplay
{

    public interface ITurnCallback
    {
        int Index { get; set; }
        int GroupId { get; set; }

    }

    public class TurnCallback : ITurnCallback
    {
        public int Index { get; set; }
        public int GroupId { get; set; }
        public int Order { get; set; }
    }

    /// <summary>
    /// активность в течение игрового дня (пока очки действия не кончатся)
    /// </summary>
    public interface ITurnController
    {

        Action<ITurnCallback> OnTurnEnd { get; set; }
        Action<ITurnCallback> OnTurnStart { get; set; }
        Action<ITurnCallback> OnTurnTick { get; set; }

        void CompleteTurn();
    }


    public class TurnController : MonoBehaviour, ITurnController
    {
        public Action<ITurnCallback> OnTurnEnd { get; set; }
        public Action<ITurnCallback> OnTurnStart { get; set; }
        public Action<ITurnCallback> OnTurnTick { get; set; }

        private Coroutine turnLoopCoroutine = null;

        private bool turnIsComleted = false;


        void Start()
        {
            InitCallbacks();
            turnLoopCoroutine = StartCoroutine( TurnLoopCoroutine() );
        }

        // Update is called once per frame
        void Update()
        {

        }

        private IEnumerator TurnLoopCoroutine()
        {
            int index = 0;
            TurnCallback callback = new()
            {
                //Index = index; //- общее кол-во ходов или индекс Index с начала
                //turnGroup - группа хода. кто входит в эту группу, тот и ходит
            };


            //некое событие

            while (true)
            {
                turnIsComleted = false;
                int groupId = GetTurnGroup(index); //выдаем группу, чей ход
                callback.Index = index;
                callback.GroupId = groupId;
                OnTurnStart?.Invoke(callback);


                yield return null;
                while (turnIsComleted == false)
                {
                    OnTurnTick?.Invoke(callback);
                    yield return null;
                }

                yield return null;


                OnTurnEnd?.Invoke(callback);
                index++;
                yield return null;
                //некое событие
                yield return null;
            }

            yield return null;

            //некое событие?

            yield return null;
            //turnLoopCoroutine = StartCoroutine(TurnLoopCoroutine());
        }

        private void InitCallbacks()
        {

        }

        void OnEventComplete(IGameEventCallback callback)
        {
            //тут списываем очки действия за ивент
        }

        private int GetTurnGroup(int index)
        {

            return 0;
        }

        public void CompleteTurn()
        {
            turnIsComleted = true;
        }
    }

}
