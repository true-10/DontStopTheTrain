using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Zenject;
using True10.CameraSystem;
using System;
using DontStopTheTrain.Train;

namespace DontStopTheTrain.UI
{
    [System.Serializable]
    public class WagonUISwitchCameraButton
    {
        public Button SwitchToCameraButton;
        public CameraHolder CameraHolder;
    }

    public class WagonUIView : MonoBehaviour
    {
        [Inject] private ICameraController cameraController;
        
        [SerializeField] private List<WagonUISwitchCameraButton> buttons;
        [SerializeField] private TextMeshProUGUI numberText;
        [SerializeField] private Button switchToNextWagon;
        [SerializeField] private Button switchToPrevWagon;

        public Action<ICameraHolder> OnSwitchCameraButtonClick { get; set; }
        // Start is called before the first frame update
       /* public void Init(WagonData data)
        {
            switchToLocoFrontCamera.gameObject.SetActive(locoUI);
            switchToLocoTopFrontCamera.gameObject.SetActive(locoUI);
        }*/

        void Start()
        {
            switchToNextWagon.onClick.AddListener(SwitchToNextWagonHandler);
            switchToPrevWagon.onClick.AddListener(SwitchToPrevWagonHandler);

            foreach (var button in buttons)
            {
                button.SwitchToCameraButton.onClick.AddListener( () =>
                {
                    cameraController.SwitchToCamera(button.CameraHolder);
                });
            }
        }

        private void SwitchToNextWagonHandler()
        {

        }

        private void SwitchToPrevWagonHandler()
        {

        }

        private void SwitchToCameraHandler()
        {
        }
    }
}
