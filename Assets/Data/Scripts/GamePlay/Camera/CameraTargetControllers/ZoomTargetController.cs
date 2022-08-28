using System;
using System.Collections;
using System.Collections.Generic;
using True10.CameraSystem;
using UnityEngine;
using UnityEngine.EventSystems;

namespace DontStopTheTrain.Gameplay
{
    public class ZoomTargetController : MonoBehaviour, IScrollHandler, ICameraTargetController
    {
        [SerializeField] private Transform target;
        [SerializeField] private Vector2 minMax = new Vector2(-30f, -3f);

        public Action OnInit { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Init()
        {
            throw new NotImplementedException();
        }

        public void OnScroll(PointerEventData eventData)
        {
            Debug.Log($"eventData.scrollDelta = {eventData.scrollDelta}");
            Zoom(eventData.scrollDelta.x);
        }

        void Start()
        {

        }

        void Zoom(float value)
        {
            var pos = target.localPosition;
            pos.z += value;
            pos.z = Mathf.Clamp(pos.z, minMax.x, minMax.y);
            target.localPosition = pos;
        }
    }
}
