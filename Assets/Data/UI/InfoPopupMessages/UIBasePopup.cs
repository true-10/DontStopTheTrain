using True10.UI;
using UnityEngine;
using UnityEngine.UI;

namespace DontStopTheTrain
{
    public abstract class UIBasePopup : UIScreen
    {
        public bool IsAnchored { get; protected set; }

        [SerializeField]
        protected Button _closeButton;
        [SerializeField]
        protected GameObject _buttonsRoot;
        [SerializeField]
        protected GameObject _hintText;
        [SerializeField]
        protected SetWorldPosition _worldPostionSetter;

        public abstract void AnchorIt();
        public abstract void CloseView();
        public abstract void OnEnableHandler();
        public abstract void OnDisableHandler();

        protected void ShowButtons(bool isActive)
        {
            _buttonsRoot.SetActive(isActive);
            _hintText.SetActive(!isActive);
        }

        private void OnEnable()
        {
            _closeButton.onClick.AddListener(CloseView);
            OnEnableHandler();
        }

        private void OnDisable()
        {
            _closeButton.onClick.RemoveAllListeners();
            OnDisableHandler();
        }
    }

}
