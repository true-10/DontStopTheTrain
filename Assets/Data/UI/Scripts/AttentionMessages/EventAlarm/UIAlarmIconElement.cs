using DontStopTheTrain.Events;
using System;
using True10;
using UnityEngine;
using UnityEngine.UI;

namespace DontStopTheTrain
{
    public class UIAlarmIconElement : MonoBehaviour
    {
        public Action<IEvent> OnClick { get; set; } 
        public Action<IEvent> OnMouseOverElement { get; set; } 

        [SerializeField]
        private Image _icon;
        [SerializeField]
        private MouseOverObject _mouseOverObject;
        [SerializeField]
        private Button _button;

        private IEvent _eventData;

        public void Initialize(IEvent eventData)
        {
            _eventData = eventData;
            _icon.sprite = eventData.StaticData.Info.Icon;
            gameObject.SetActive(true);
        }

        private void OnExit()
        {
            OnMouseOverElement?.Invoke(null);
        }

        private void OnEnter()
        {
            OnMouseOverElement?.Invoke(_eventData);
        }

        private void OnClickHandler()
        {
            OnClick?.Invoke(_eventData);
        }

        private void Start()
        {
            _mouseOverObject.OnEnter += OnEnter;
            _mouseOverObject.OnExit += OnExit;
            _button.onClick.AddListener(OnClickHandler);
        }

        private void OnDestroy()
        {
            _mouseOverObject.OnEnter -= OnEnter;
            _mouseOverObject.OnExit -= OnExit;
            _button.onClick.RemoveAllListeners();
        }

        private void OnValidate()
        {
            _icon ??= GetComponent<Image>();
            _mouseOverObject ??= GetComponent<MouseOverObject>();
            _button ??= GetComponent<Button>();
        }
    }
}
