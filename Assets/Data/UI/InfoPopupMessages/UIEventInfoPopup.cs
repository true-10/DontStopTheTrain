using DontStopTheTrain.Events;
using DontStopTheTrain.MiniGames;
using System.Linq;
using TMPro;
using True10;
using True10.UI;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace DontStopTheTrain
{
    public class UIEventInfoPopup : UIBasePopup
    {
        [Inject]
        private EventsService _eventsService;
        [Inject]
        private EventObjectsManager _eventObjectsManager;

        [SerializeField]
        private Image _icon;
        [SerializeField]
        private TextMeshProUGUI _nameText;
        [SerializeField]
        private TextMeshProUGUI _descriptionText;
        [SerializeField]
        private TextMeshProUGUI _conditionText;

        [SerializeField]
        private Button _fastFixButton;
        [SerializeField]
        private Button _playGameButton;

        private IEvent _eventData;
        private ClickableView _clickableView;
        private AbstractEventObject _eventObject;

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
            _eventObject = _eventObjectsManager.Items
                .Where(eventObject => eventObject.Event == eventData)
                .FirstOrDefault();


    }

        private void Start()
        {
            Hide();
        }

        private void FastFixHandler()
        {
            if (_eventData.TryToComplete())
            {
                CloseView();
            }
        }

        private void PlayMiniGameHandler()
        {
            if (_eventObject == null)
            {
                return;
            }
            var miniGame = _eventObject.MiniGame;
            if (miniGame == null)
            {
                Debug.Log($"Mini game is null");
                return;
            }
            Hide();
            miniGame.OnComplete += (mg) => { FastFixHandler(); };
            miniGame.StartMiniGame();
        }

        private void TryToActivateButton(IEvent eventData)
        {           
            var isFastFixAvailable = _eventsService.IsFastFixAvailable(eventData);
            var isAllConditionsAreMet = _eventsService.IsAllConditionsAreMet(eventData);
            var isEnoughActionPoints = _eventsService.IsEnoughActionPoints(eventData);
            var isAcive = isEnoughActionPoints && isAllConditionsAreMet;

            _fastFixButton.gameObject.SetActive(isAcive && isFastFixAvailable);
            _playGameButton.gameObject.SetActive(isAcive);
        }

        public override void OnEnableHandler()
        {
            _fastFixButton.onClick.AddListener(FastFixHandler);
            _playGameButton.onClick.AddListener(PlayMiniGameHandler);
        }

        public override void OnDisableHandler()
        {
            _fastFixButton.onClick.RemoveAllListeners();
            _playGameButton.onClick.RemoveAllListeners();
        }
    }

}
