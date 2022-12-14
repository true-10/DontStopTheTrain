using System.Collections;
using System.Collections.Generic;
using True10.CameraSystem;
using UnityEngine;
using Zenject;


namespace DontStopTheTrain.UI
{
    public enum CameraGroups
    {
        TRAIN_GROUP = 0,
        LOCO_GROUP = 1,
        WAGON_GROUP = 2,
        FRONT_GROUP = 3,
    }

    public class UIController : MonoBehaviour
    {
        [Inject] private ICameraController cameraController;

        [SerializeField] private TrainUIView trainUIView;
        [SerializeField] private LocoUIView locoUIView;
        [SerializeField] private WagonUIView wagonUIView;
        [SerializeField] private GameObject FrontCameraUIView;
        // Start is called before the first frame update
        [SerializeField] private CameraHolder trainCameraHolder;

        private int currentGroup = 0;

        void OnEnable()
        {
            cameraController.OnCameraOn += OnCameraOnHandler;
            cameraController.OnCameraOff += OnCameraOffHandler;
        }

        private void OnDisable()
        {
            cameraController.OnCameraOn += OnCameraOnHandler;
            cameraController.OnCameraOff += OnCameraOffHandler;
        }

        // Update is called once per frame
        void Update()
        {
            /*if (Input.GetKey(KeyCode.Escape))
            {
                cameraController.SwitchToCamera(trainCameraHolder.HashCode);
            }*/
            if (Input.GetKeyDown(KeyCode.Tab))
            {
              var isShow = !trainUIView.gameObject.activeInHierarchy;
              trainUIView.gameObject.SetActive(isShow);
            }
        }

        private void DisableUI()
        {
            trainUIView.gameObject.SetActive(false);
            locoUIView.gameObject.SetActive(false);
            wagonUIView.gameObject.SetActive(false);
            FrontCameraUIView.gameObject.SetActive(false);
        }

        private void OnCameraOnHandler(ICameraCallback callback)
        {
            if (currentGroup == callback.camHolder.Group)
            {
                return;
            }
            currentGroup = callback.camHolder.Group;
            DisableUI();
            var group = (CameraGroups)callback.camHolder.Group;
            switch (group)
            {
                case CameraGroups.TRAIN_GROUP:
                    {
                        trainUIView.gameObject.SetActive(true);
                    }
                    break;
                case CameraGroups.LOCO_GROUP:
                    {

                        locoUIView.gameObject.SetActive(true);
                    }
                    break;
                case CameraGroups.WAGON_GROUP:
                    {
                        wagonUIView.gameObject.SetActive(true);
                    }
                    break;
                case CameraGroups.FRONT_GROUP:
                    {
                        FrontCameraUIView.SetActive(true);
                    }
                    break;
            }
        }

        private void OnCameraOffHandler(ICameraCallback callback)
        {
            const int UI_GROUP = 1;
            if (callback.camHolder.Group != UI_GROUP)
            {
                return;
            }

        }
    }

}
