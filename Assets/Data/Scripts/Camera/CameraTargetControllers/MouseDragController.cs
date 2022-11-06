using System;
using System.Collections;
using System.Collections.Generic;
using True10.CameraSystem;
using UnityEngine;
using UnityEngine.EventSystems;

namespace DontStopTheTrain.Gameplay
{
    public interface IMouseDragController: IBeginDragHandler, IEndDragHandler, IDragHandler
    {
        Action<PointerEventData> OnDragCallback { get; set; }
    }

    public class MouseDragController : MonoBehaviour, IMouseDragController
    {
        public Action<PointerEventData> OnDragCallback { get; set; }


        public void OnBeginDrag(PointerEventData eventData)
        {
         //   Debug.Log($"{name} OnBeginDrag");
        }

        public void OnEndDrag(PointerEventData eventData)
        {
         //   Debug.Log($"{name} OnEndDrag");
        }

        public void OnDrag(PointerEventData eventData)
        {
            OnDragCallback(eventData);
        }
    }
}
