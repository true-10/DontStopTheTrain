using DontStopTheTrain.Events;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DontStopTheTrain.Gameplay
{

    /// <summary>
    /// ���������� � ������� �������� ��� (���� ���� �������� �� ��������)
    /// </summary>
    public interface ITurnController
    {

        Action OnTurnEnd { get; set; }
        Action OnTurnStart { get; set; }
    }

    public class TurnController : MonoBehaviour, ITurnController
    {
        public Action OnTurnEnd { get; set; }
        public Action OnTurnStart { get; set; }


        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        void OnEventComplete(IGameEventCallback callback)
        {
            //��� ��������� ���� �������� �� �����
        }
    }

}
