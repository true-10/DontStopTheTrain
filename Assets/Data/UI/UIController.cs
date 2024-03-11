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
        public UIMessage Message => _message;
        public UIWagonEvent WagonEvent => _wagonEvent;
        public UIMainGamePlay MainGamePlay => _mainGamePlay;
        public UIWagon Wagon => _wagon;
        public UIEventInfoPopup EventInfoPopup => _eventInfoPopup;

        [SerializeField] 
        private UIMessage _message;
        [SerializeField] 
        private UIWagonEvent _wagonEvent;
        [SerializeField] 
        private UIEventInfoPopup _eventInfoPopup;
        [SerializeField] 
        private UIMainGamePlay _mainGamePlay;
        [SerializeField] 
        private UIWagon _wagon;

        void OnEnable()
        {
        }

        private void OnDisable()
        {
        }

     
        public void DisableUI()
        {
            
        }

    }

}
