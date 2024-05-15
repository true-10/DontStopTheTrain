using DontStopTheTrain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using True10.Interfaces;
using UnityEngine;
using Zenject;

namespace DontStopTheTrain.UI
{

    /// - выезжающий UIмессадж сбоку. клик по нему - фокус на событии
    public class UIMessageSidePopupController : AbstractGameLifeCycleBehaviour
    {
        [Inject]
        private EventController _eventController;
      //  [Inject]
        //private BuffAndPerksService _buffAndPerksService;
        [Inject]
        private PlayerBuffsManager _playerBuffssManager;

        [SerializeField]
        private List<UIMessage> _messages;
        [SerializeField]
        private float _timeToHide = 5f;

        public override void Initialize()
        {
            foreach (var message in _messages)
            {
             //   message.
            }
            _eventController.OnStart += OnStartEvent;
            _eventController.OnComplete += OnCompleteEvent;
            _playerBuffssManager.OnItemAdded += OnBuffsAdded;
            _playerBuffssManager.OnItemRemoved += OnBuffsRemoved;
        }


        public override void Dispose()
        {
            _eventController.OnStart -= OnStartEvent;
            _eventController.OnComplete -= OnCompleteEvent;
            _playerBuffssManager.OnItemAdded -= OnBuffsAdded;
            _playerBuffssManager.OnItemRemoved -= OnBuffsRemoved;
        }


        private void OnBuffsAdded(IBuff buff)
        {
            //BuffToMessageConverter
            var text = $"{buff.StaticData.Info.Name} begins";
            TryToShowMessage(text);
        }

        private void OnBuffsRemoved(IBuff buff)
        {
            var text = $"{buff.StaticData.Info.Name} is ended";
            TryToShowMessage(text);
        }

        private void OnCompleteEvent(IEvent eventData)
        {
            if (eventData.Status == True10.Enums.ProgressStatus.Fail)
            {
                var text = $"{eventData.StaticData.Info.Name} failed =(";
                TryToShowMessage(text);
            }
        }

        private UIMessage GetFreeUIMessage()
        {
            return _messages.FirstOrDefault(message => message.gameObject.activeInHierarchy == false);
        }

        private void TryToShowMessage(string text)
        {
            var message = GetFreeUIMessage();
            if (message == null)
            {
                return;
            }
            message.transform.SetAsFirstSibling();
            message.ShowMessage(text, _timeToHide);
        }

        private void OnStartEvent(IEvent eventData)
        {
            var text = eventData.StaticData.Info.Name;
            TryToShowMessage(text);

        }
    }

}
