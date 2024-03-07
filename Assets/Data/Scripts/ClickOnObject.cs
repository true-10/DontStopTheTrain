using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace DontStopTheTrain
{
    /// <summary>
    /// Don't forget to put PhysicsRaycaster on camera
    /// </summary>
    [RequireComponent(typeof(BoxCollider))]
    public class ClickOnObject : MonoBehaviour, IPointerClickHandler
    {
        public Action OnClick { get; set; }

        [SerializeField]
        private PointerEventData.InputButton _inputButton = PointerEventData.InputButton.Left;

        private BoxCollider _boxCollider;

        public void OnPointerClick(PointerEventData eventData)
        {
            var button = eventData.button;
            if (button == _inputButton)
            {
                OnClick?.Invoke();
            }                
        }
    }
}
