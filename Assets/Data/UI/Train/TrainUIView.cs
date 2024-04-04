using DontStopTheTrain.Gameplay;
using System.Collections;
using System.Collections.Generic;
using True10.CameraSystem;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace DontStopTheTrain.UI
{

    public class TrainUIView : MonoBehaviour
    {
        [Inject] private ICameraController cameraController;
        [Inject] private TurnBasedController turnController;


        [SerializeField] private Button endTurnButton;
        [SerializeField] private Button locoCamButton;
        [SerializeField] private CameraHolder locoCameraHolder;


        private void OnEnable()
        {
            endTurnButton.onClick.AddListener(OnEndTurnButtonClick);
            locoCamButton.onClick.AddListener(OnLocoCamButtonClick);
        }

        private void OnDisable()
        {
            endTurnButton.onClick.RemoveListener(OnEndTurnButtonClick);
            locoCamButton.onClick.RemoveListener(OnLocoCamButtonClick);
        }

        private void OnEndTurnButtonClick()
        {
            //ВЫ УВЕРЕНЫ? или нафиг?
            turnController.CompleteTurn();
        }

        private void OnLocoCamButtonClick()
        {
            cameraController.SwitchToCamera(locoCameraHolder);
        }

    }

}
