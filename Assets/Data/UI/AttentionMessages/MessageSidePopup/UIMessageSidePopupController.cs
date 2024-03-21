using DontStopTheTrain.Events;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

namespace DontStopTheTrain
{

    /// - выезжающий UIмессадж сбоку. клик по нему - фокус на событии
    public class UIMessageSidePopupController : MonoBehaviour
    {
        [Inject]
        private EventController _eventController;

        [SerializeField]
        private List<UIMessage> _messages;
        [SerializeField]
        private float _timeToHide = 5f;

        public void Initialize()
        {
            foreach (var message in _messages)
            {
             //   message.
            }
            _eventController.OnStart += OnStartEvent;
        }

        public void Dispose()
        {
            _eventController.OnStart -= OnStartEvent;
        }

        private UIMessage GetFreeUIMessage()
        {
            return _messages.FirstOrDefault(message => message.gameObject.activeInHierarchy == false);
        }

        private void OnStartEvent(IEvent eventData)
        {
            var message = GetFreeUIMessage();
            if (message == null)
            {
                return;
            }
            message.transform.SetAsFirstSibling();
            var text = eventData.StaticData.Info.Name;
            message.ShowMessage(text, _timeToHide);
        }

        private void Start()
        {
            Initialize();
        }

        private void OnDestroy()
        {
            Dispose();
        }
    }

}
