using DontStopTheTrain.Events;
using DontStopTheTrain.UI;
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
            UpdateConditionsText(eventData.�ompleteConditions, eventData.ActionPointPrice);
            TryToActivateButton(eventData);
            Show();
        }

        private void UpdateConditionsText(IReadOnlyCollection<ICondition> conditions, int actionPoints)
        {
            _conditionText.text = ConditionToTextConverter.GetText(conditions, actionPoints);
        }

        private void TryToActivateButton(IEvent eventData)
        {
            //TODO � ������� ������ ����� ��� � ����, � ����� ������� ������ ������ ����, �� ������� �� �����������
            var isAcive = _eventsService.IsAllConditionsAreMet(eventData) && _eventsService.IsEnoughActionPoints(eventData);
            _completeEventButton.gameObject.SetActive(isAcive);
        }

        private void OnCloseEventUI()
        {
            _UIContainer.Wagon.Show();
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
