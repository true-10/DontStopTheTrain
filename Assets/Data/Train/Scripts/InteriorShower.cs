using DontStopTheTrain.Events;
using System;
using True10;
using UnityEngine;
using Zenject;

namespace DontStopTheTrain.Train
{
    public class InteriorShower : MonoBehaviour
    {
        [Inject]
        private EventController _eventController;

        [SerializeField]
        private ClickableView _clickableView;
        [SerializeField]
        private GameObject _frontWall;

        private void OnExitWagonView()
        {
            _frontWall.SetActive(true);
        }

        private void OnEnterWagonView()
        {
            _frontWall.SetActive(false);
        }

        private void OnEnable()
        {
            _clickableView.OnClick += OnEnterWagonView;
            _clickableView.OnExitView += OnExitWagonView;
            _eventController.OnFocus += OnEventFocus;
        }

        private void OnDisable()
        {
            _clickableView.OnClick -= OnEnterWagonView;
            _clickableView.OnExitView -= OnExitWagonView;
            _eventController.OnFocus -= OnEventFocus;
        }

        private void OnEventFocus(IEvent eventData)
        {
            OnEnterWagonView();

        }
    }
}
