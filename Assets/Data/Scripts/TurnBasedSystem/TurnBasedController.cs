using DontStopTheTrain.Events;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DontStopTheTrain
{
    public class TurnBasedController : MonoBehaviour, ITurnBasedController
    {
        public Action<ITurnCallback> OnTurnEnd { get; set; }
        public Action<ITurnCallback> OnTurnStart { get; set; }
        public Action<ITurnCallback> OnTurnTick { get; set; }

        public int CurrentTurn { get; private set; }

        private Coroutine _turnLoopCoroutine = null;

        private bool _turnIsComleted = false;
        private bool _continueAfterStart = false;


        void Start()
        {
            InitCallbacks();
            _turnLoopCoroutine = StartCoroutine( TurnLoopCoroutine() );
        }


        private IEnumerator TurnLoopCoroutine()
        {
            CurrentTurn = 0;


            //����� �������

            while (true)
            {
                _turnIsComleted = false;
                _continueAfterStart = false;
                int groupId = GetTurnGroup(CurrentTurn); //������ ������, ��� ���
                TurnCallback callback = new(CurrentTurn, groupId)
                {
                     //- ����� ���-�� ����� ��� ������ Index � ������
                                   //turnGroup - ������ ����. ��� ������ � ��� ������, ��� � �����
                };

                OnTurnStart?.Invoke(callback);


                yield return new WaitUntil( () => _continueAfterStart);
                while (_turnIsComleted == false)
                {
                    OnTurnTick?.Invoke(callback);
                    yield return null;
                }

                yield return null;

                //���� ������� �� ���������, �� ��������� �����

                OnTurnEnd?.Invoke(callback);
                CurrentTurn++;
                yield return null;
                //����� �������
                //�������� �� ����� ��, ���� ��, �� �������� ����?
                yield return null;
            }
            //turnLoopCoroutine = StartCoroutine(TurnLoopCoroutine());
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
    /// ���������� � ������� �������� ��� (���� ���� �������� �� ��������)
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
