using DontStopTheTrain.Events;
using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace DontStopTheTrain.UI
{
    [Obsolete]
    public class UIWagonEvent : UIScreen
    {
        public override UIScreenID ScreenID => UIScreenID.None;

        [Inject]
        private EventsService _eventsService;
        [Inject]
        private UIContainer _UIContainer;

        [SerializeField]
        private Button _completeEventButton;
        [SerializeField]
        private Button _closeButton;
        [SerializeField]
        private TextMeshProUGUI _conditionText;

        private IEvent _eventData;

        public void Show(IEvent eventData)
        {
            _eventData = eventData;
            UpdateConditionsText(eventData.СompleteConditions, eventData.ActionPointPrice);
            TryToActivateButton(eventData);
            Show();
        }

        private void UpdateConditionsText(IReadOnlyCollection<ICondition> conditions, int actionPoints)
        {
            _conditionText.text = ConditionToTextConverter.GetText(conditions, actionPoints);
        }

        private void TryToActivateButton(IEvent eventData)
        {
            //TODO в условии уровня стоит мин и макс, и когда уровень игрока больше макс, то условие не выполняется
            var isAcive = _eventsService.IsAllConditionsAreMet(eventData) && _eventsService.IsEnoughActionPoints(eventData);
            _completeEventButton.gameObject.SetActive(isAcive);
        }

        private void OnCloseEventUI()
        {
            var wagonUI = _UIContainer.GetUIScreen(UIScreenID.Wagon);
            wagonUI?.Show();
            Hide();
        }

        private void OnCompleteEventClick()
        {
            if (_eventData.TryToComplete())
            {
                OnCloseEventUI();
            }
        }

        private void Start()
        {
            Hide();
        }

        private void OnEnable()
        {
            _completeEventButton.onClick.AddListener(OnCompleteEventClick);
            _closeButton.onClick.AddListener(OnCloseEventUI);
        }

        private void OnDisable()
        {
            _completeEventButton.onClick.RemoveAllListeners();
            _closeButton.onClick.RemoveAllListeners();
        }
    }
}
