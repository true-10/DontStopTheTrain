using DontStopTheTrain;
using DontStopTheTrain.Events;
using DontStopTheTrain.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEditor.MPE;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class UIWagonEvent : MonoBehaviour
{
    [Inject]
    private EventsService _eventsService;
    [Inject]
    private UIController _uiController;

    [SerializeField]
    private GameObject _root;
    [SerializeField]
    private Button _completeEventButton;
    [SerializeField]
    private Button _closeEventButton;
    [SerializeField]
    private TextMeshProUGUI _conditionText;

    private IEvent _eventData;

    public void Show(IEvent eventData)
    {
        _eventData = eventData;
        UpdateConditionsText(eventData.Conditions, eventData.StaticData.ActionPointPrice);
        TryToActivateButton(eventData);
        _root.SetActive(true);
        
    }

    private void UpdateConditionsText(List<ICondition> conditions, int actionPoints)
    {
        string conditionsTexts = string.Empty;
        conditionsTexts += $"ActionPoints: {actionPoints} \n";
        foreach (var condition in conditions)
        {
            conditionsTexts += $"{ConditionToTextConverter.GetText(condition)}\n";
        }

        _conditionText.text = conditionsTexts;
    }

    private void TryToActivateButton(IEvent eventData)
    {
        var isAcive = _eventsService.IsAllConditionsAreMet(eventData) && _eventsService.IsEnoughActionPoints(eventData);
        _completeEventButton.gameObject.SetActive(isAcive);
    }

    private void OnCloseEventUI()
    {
        _uiController.MainGamePlay.Show(true);
        _root.SetActive(false);
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
        _root.SetActive(false);
    }

    private void OnEnable()
    {
        _completeEventButton.onClick.AddListener(OnCompleteEventClick);
        _closeEventButton.onClick.AddListener(OnCloseEventUI) ;
    }

    private void OnDisable()
    {
        _completeEventButton.onClick.RemoveAllListeners();
        _closeEventButton.onClick.RemoveAllListeners();
    }

}


public static class ConditionToTextConverter
{
    public static string GetText(ICondition condition)
    {
        switch (condition.StaticData.Type)
        {
            case ConditionType.ResourceRequire:
                return GetResourceRequireText(condition.StaticData as IConditionResourceRequireStaticData);
            default:
                return string.Empty;
        }
    }

    private static string GetResourceRequireText(IConditionResourceRequireStaticData staticData)
    {
        return $"resource: {staticData.ResourceId} count: { staticData.Count}";
    }
}
