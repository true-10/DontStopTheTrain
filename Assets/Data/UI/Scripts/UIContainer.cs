using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace DontStopTheTrain.UI
{

    public class UIContainer : MonoBehaviour
    {
        public UIMessage Message => _message;
        public UIWagonInfoPopup WagonInfoPopup => _wagonInfoPopup;
        public UIEventInfoPopup EventInfoPopup => _eventInfoPopup;
        public UISystemInfoPopup SystemInfoPopup => _systemInfoPopup;

        [SerializeField, Header("Not UIScreens")] 
        private UIMessage _message;
        [SerializeField, Header("Info Popups")]
        private UIEventInfoPopup _eventInfoPopup;
        [SerializeField] 
        private UISystemInfoPopup _systemInfoPopup;
        [SerializeField]
        private UIWagonInfoPopup _wagonInfoPopup;

        [SerializeField, Header("UIScreens")]
        private List<UIScreen> _screens;

        private void OnValidate()
        {
            _screens = GetComponentsInChildren<UIScreen>().ToList();    
        }

        public void DisableAllScreens()
        {
            foreach (var screen in _screens)
            {
                screen.Hide();
            }
        }

        public UIScreen GetUIScreen(UIScreenID id)
        {
            return _screens.Where(screen => screen.ScreenID == id).FirstOrDefault();
        }

    }

    public enum UIScreenID
    {
        None = 0,
        SystemUpgrader,
        NewPerk,
        Wagon,
        Station,
        Fader,
        Gameplay,
        GameMenu,
        StartMenu,
        PlayerMenu,
        Constructor

    }
}
