using DontStopTheTrain.Events;
using TMPro;
using True10;
using True10.UI;
using UnityEditor.MPE;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace DontStopTheTrain
{
    public class UIEventInfoPopup : UIBasePopup
    {
        [Inject]
        private EventsService _eventsService;

        [SerializeField]
        private Image _icon;
        [SerializeField]
        private TextMeshProUGUI _nameText;
        [SerializeField]
        private TextMeshProUGUI _descriptionText;
        [SerializeField]
        private TextMeshProUGUI _conditionText;

        [SerializeField]
        private Button _applyButton;

        private IEvent _eventData;
        private ClickableView _clickableView;

        public override void AnchorIt()
        {
            IsAnchored = true;
            ShowButtons(IsAnchored);
            TryToActivateButton(_eventData);
        }

        public override void CloseView()
        {
            IsAnchored = false;
            _eventData = null;
            ShowButtons(IsAnchored);
            _clickableView?.ExitView();
            Hide();
        }

        public void Show(IEvent eventData, Transform lookAt, ClickableView clickableView)
        {
            _eventData = eventData;
            _clickableView = clickableView;
            _nameText.text = eventData.StaticData.Info.Name;
            _descriptionText.text = eventData.StaticData.Info.Description;
            _icon.sprite = eventData.StaticData.Info.Icon;
            _conditionText.text = ConditionToTextConverter.GetText(eventData.ÑompleteConditions, eventData.ActionPointPrice);
            _worldPostionSetter.SetPosition(lookAt);
            ShowButtons(IsAnchored);
            Show();
        }

        private void Start()
        {
            Hide();
        }

        private void Applay()
        {
            if (_eventData.TryToComplete())
            {
                CloseView();
            }
        }

        private void TryToActivateButton(IEvent eventData)
        {           
            var isAcive = _eventsService.IsAllConditionsAreMet(eventData) && _eventsService.IsEnoughActionPoints(eventData);
            _applyButton.gameObject.SetActive(isAcive);
        }

        public override void OnEnableHandler()
        {
            _applyButton.onClick.AddListener(Applay);
        }

        public override void OnDisableHandler()
        {
            _applyButton.onClick.RemoveAllListeners();
        }
    }

}
