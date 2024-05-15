using UnityEngine;

namespace DontStopTheTrain.UI
{
    public enum CameraGroups
    {
        TRAIN_GROUP = 0,
        LOCO_GROUP = 1,
        WAGON_GROUP = 2,
        FRONT_GROUP = 3,
    }

    public class UIContainer : MonoBehaviour
    {
        public UIMessage Message => _message;
        public UIMainGamePlay MainGamePlay => _mainGamePlay;
        public UIWagon Wagon => _wagon;
        public UIWagonInfoPopup WagonInfoPopup => _wagonInfoPopup;
        public UIEventInfoPopup EventInfoPopup => _eventInfoPopup;
        public UISystemInfoPopup SystemInfoPopup => _systemInfoPopup;
        public UINewPerk NewPerk => _newPerk;
        public UIStation Station => _station;
        public UIStartMenu StartMenu => _startMenu;
        public UIGameMenu GameMenu => _gameMenu;
        public UIFader Fader => _fader;

        [SerializeField] 
        private UIMessage _message;
        [SerializeField] 
        private UIEventInfoPopup _eventInfoPopup;
        [SerializeField] 
        private UISystemInfoPopup _systemInfoPopup;
        [SerializeField] 
        private UIMainGamePlay _mainGamePlay;
        [SerializeField] 
        private UINewPerk _newPerk;
        [SerializeField] 
        private UIWagon _wagon;
        [SerializeField] 
        private UIStation _station;
        [SerializeField] 
        private UIWagonInfoPopup _wagonInfoPopup;
        [SerializeField] 
        private UIStartMenu _startMenu;
        [SerializeField] 
        private UIGameMenu _gameMenu;
        [SerializeField] 
        private UIFader _fader;
             
        public void DisableUI()
        {
            
        }

    }

}
