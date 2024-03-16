using DontStopTheTrain.Events;
using MyBox;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using True10.Extentions;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace DontStopTheTrain
{

    public class UIAlarmController : MonoBehaviour
    {
        [Inject]
        private EventController eventController;
        [SerializeField]
        private List<Image> _icons;

        private Dictionary<Image, IEvent> dictionaryIconEvent = new();
        public void Initialize()
        {
            _icons.ForEach(x =>
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
        }


        public void ShowAlarm(IEvent eventData)
        {
            var image = GetRandomFreeImage();
            if (image == null)
            {
                return;
            }
            dictionaryIconEvent[image] = eventData;
            image.gameObject.SetActive(true);
            image.sprite = eventData.StaticData.Info.Icon;

            eventData.OnComplete += OnEventComplete;
        }

        private void OnEventStart(IEvent eventData)
        {
            ShowAlarm(eventData);
        }

        private void OnEventComplete(IEvent eventData)
        {
            var image = dictionaryIconEvent.FirstOrDefault(x => x.Value == eventData).Key;
            dictionaryIconEvent[image] = null;
            image.gameObject.SetActive(false);
            eventData.OnComplete -= OnEventComplete;
        }

        private Image GetRandomFreeImage()
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
