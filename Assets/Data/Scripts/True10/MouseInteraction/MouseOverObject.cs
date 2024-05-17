using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace True10
{

    /// <summary>
    /// Don't forget to put PhysicsRaycaster on camera
    /// </summary>
   // [RequireComponent(typeof(BoxCollider))]
    public class MouseOverObject : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        public Action OnEnter { get; set; }
        public Action OnExit { get; set; }

        public void OnPointerEnter(PointerEventData eventData)
        {
          //  Debug.Log("OnPointerEnter");
            OnEnter?.Invoke();
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            //Debug.Log("OnPointerExit");
            OnExit?.Invoke();
        }
    }

}
