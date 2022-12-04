using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Zenject;
using DontStopTheTrain.Gameplay;
using System;

namespace DontStopTheTrain.UI
{
    public class EventRadarUI : MonoBehaviour
    {
        [Inject] private ITurnController turnController;

        [SerializeField] private TextMeshProUGUI radarText;
        [SerializeField] private TextMeshProUGUI dayText;

        // Start is called before the first frame update
        void Start()
        {
            turnController.OnTurnStart = OnTurnStartHandler;
            turnController.OnTurnEnd = OnTurnEndHandler;
        }

        private void OnTurnStartHandler(ITurnCallback callback)
        {
            dayText.text = callback.Index.ToString();
        }

        private void OnTurnEndHandler(ITurnCallback callback)
        {

        }

        void UpdateRadar()
        {
            //������������ ������� - ��� �������
            //����� - ���-�� �������
        }
    }
}
