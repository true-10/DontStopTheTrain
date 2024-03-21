using DontStopTheTrain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using True10.Extentions;
using True10.UI;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace DontStopTheTrain
{

    public class UIAlarmController : MonoBehaviour
    {
        [Inject]
        private EventController eventController;
        [Inject]
        private EventViewersManager _eventViewersManager;

        [SerializeField]
        private List<UIAlarmIconElement> _alarmIcons;
        [SerializeField]
        private Image _alarmIconPointer; //    
        [SerializeField]
        private SetWorldPosition _alarmSetWorldPosition; //при наведении на иконки событий указывать иконкой на view

        private Dictionary<UIAlarmIconElement, IEvent> dictionaryIconEvent = new();
        public void Initialize()
        {
            _alarmSetWorldPosition.gameObject.SetActive(false);

            _alarmIcons.ForEach(x =>
            {
                dictionaryIconEvent.TryAdd(x, null);
                x.gameObject.SetActive(false);
            });
            eventController.OnStart += OnEventStart;
        }

        public void Dispose()
        {
            dictionaryIconEvent.Clear();
            eventController.OnStart -= OnEventStart;
            _alarmIcons.ForEach(element =>  element.OnMouseOverElement -= OnMouseOverIcon);
        }

        public void ShowAlarm(IEvent eventData)
        {
            var element = GetRandomFreeElement();
            if (element == null)
            {
                return;
            }
            dictionaryIconEvent[element] = eventData;
            element.Initialize(eventData);
            element.OnMouseOverElement += OnMouseOverIcon;
            eventData.OnComplete += OnEventComplete;
        }

        private void OnMouseOverIcon(IEvent eventData)
        {
            if (eventData == null)
            {
                _alarmSetWorldPosition.gameObject.SetActive(false);
                return;
            }
            _alarmSetWorldPosition.gameObject.SetActive(true);
            _alarmIconPointer.sprite = eventData.StaticData.Info.Icon;

            var viewer = _eventViewersManager.Items.FirstOrDefault(viewer => viewer.ActiveEvent == eventData);
            if (viewer != null)
            {
                _alarmSetWorldPosition.SetPosition(viewer.transform);
            }
        }

        private void OnEventStart(IEvent eventData)
        {
            ShowAlarm(eventData);
        }

        private void OnEventComplete(IEvent eventData)
        {
            eventData.OnComplete -= OnEventComplete;
            var element = dictionaryIconEvent.FirstOrDefault(x => x.Value == eventData).Key;
            if (element == null)
            {
                return;
            }
            if (dictionaryIconEvent.ContainsKey(element))
            {
                dictionaryIconEvent[element] = null;
            }
            element.gameObject.SetActive(false);
            element.OnMouseOverElement -= OnMouseOverIcon;
        }

        private UIAlarmIconElement GetRandomFreeElement()
        {
            return dictionaryIconEvent
                .Where(x => x.Value == null)
                .GetRandomElement()
                .Key;
        }

        private void OnEnable()
        {
            Initialize();
        }
        private void OnDisable()
        {
            Dispose();
        }
    }
}
