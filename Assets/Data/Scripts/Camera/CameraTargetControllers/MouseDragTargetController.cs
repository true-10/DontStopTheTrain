using System;
using System.Collections;
using System.Collections.Generic;
using True10.CameraSystem;
using UnityEngine;
using UnityEngine.EventSystems;

namespace DontStopTheTrain.Gameplay
{
    public interface IMouseDragTargetController: ICameraTargetController, IBeginDragHandler, IEndDragHandler, IDragHandler
    {

    }

    public class MouseDragTargetController : MonoBehaviour, IMouseDragTargetController
    {
        [SerializeField] private float moveSpeed = 100f;
        [SerializeField] private Transform dragTarget;

        public Action OnInit { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Init()
        {
            throw new NotImplementedException();
        }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }


        public void MoveAlongTrain(float move)
        {
            var position = dragTarget.position;
            position.z += move;
            dragTarget.position = position;
            Debug.Log($"position = {position} move = {move}");
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            Debug.Log($"{name} OnBeginDrag");
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            Debug.Log($"{name} OnEndDrag");
        }

        public void OnDrag(PointerEventData eventData)
        {
            Debug.Log($"{name} OnDrag");
            MoveAlongTrain(eventData.delta.x / moveSpeed);
        }
    }
}
