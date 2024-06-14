using DontStopTheTrain.Events;
using DontStopTheTrain.Train;
using TMPro;
using True10;
using True10.BattleSystem;
using UnityEngine;
using UnityEngine.UI;

namespace DontStopTheTrain.UI
{
    public class UISystemInfoPopup : UIBasePopup
    {
        [SerializeField]
        private Image _icon;
        [SerializeField]
        private TextMeshProUGUI _nameText;
        [SerializeField]
        private TextMeshProUGUI _descriptionText;
        [SerializeField]
        private Button _applyButton;
        [SerializeField]
        private Slider _healthSlider;

        private IWagonSystem _wagonSystem;
        private ClickAndMouseOverView _clickableView;

        public override void AnchorIt()
        {
            IsAnchored = true;
            ShowButtons(IsAnchored);
           // TryToActivateButton(_eventData);
        }

        public override void CloseView()
        {
            IsAnchored = false;
            _wagonSystem = null;
            ShowButtons(IsAnchored);
            _clickableView?.ExitView();
            Hide();
        }

        public void Show(IWagonSystem wagonSystem, Transform lookAt, ClickAndMouseOverView clickableView)
        {
            _wagonSystem = wagonSystem;
            _clickableView = clickableView;
            if(wagonSystem != null)
            {
                _nameText.text = wagonSystem.StaticData.Info.Name;
                _descriptionText.text = wagonSystem.StaticData.Info.Description;
                _icon.sprite = wagonSystem.StaticData.Info.Icon;
                _healthSlider.value = (float)wagonSystem.Health.Value / wagonSystem.MaxHealth.Value;
            }

            ShowButtons(IsAnchored);
            _worldPostionSetter.SetPosition(lookAt);
            Show();
        }

        private void ServiceIt()
        {
            CloseView();
        }

        public override void OnEnableHandler()
        {
            _applyButton.onClick.AddListener(ServiceIt);
        }

        public override void OnDisableHandler()
        {
            _applyButton.onClick.RemoveAllListeners();
        }

        private void Start()
        {
            Hide();
        }
    }

}
