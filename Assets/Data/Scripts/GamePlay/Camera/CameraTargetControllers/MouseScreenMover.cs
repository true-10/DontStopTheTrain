using System;
using System.Collections;
using System.Collections.Generic;
using True10.CameraSystem;
using UnityEngine;
using UnityEngine.EventSystems;

namespace DontStopTheTrain.Gameplay
{
    public class MouseScreenMover : MonoBehaviour, ICameraTargetController, IMoveHandler
    {
        [SerializeField] float moveSpeed = 10f;
        [SerializeField] float sensitivity = 100f;
        //[SerializeField] CameraHolder cameraHolder;
        private Transform cachedTransform;
        public Action OnInit { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Init()
        {
            throw new NotImplementedException();
        }

        public void OnMove(AxisEventData eventData)
        {
            Debug.Log($"moveDir = {eventData.moveDir} moveVector = {eventData.moveVector}");
            MoveAlongTrain(0);
        }

        // Start is called before the first frame update
        void Start()
        {
            cachedTransform = GetComponent<Transform>();
        }

        // Update is called once per frame
        void Update()
        {

            if (IsMovementAvailable() == false)
            {
                return;
            }

            float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;
            var trainForward = Vector3.forward;
            var mouseVectorMove = new Vector3(mouseX, 0f, mouseY);
            //var cross = Vector3.Cross(()
            var dot = Vector3.Dot(trainForward, mouseVectorMove);
            MoveAlongTrain(dot);
        }

        private void MoveAlongTrain(float move)
        {
            var position = cachedTransform.position;
            position.z += move * moveSpeed * Time.deltaTime;
            cachedTransform.position = position;
        }

        private bool IsMovementAvailable()
        {
            var mousePos = Input.mousePosition;
            Debug.Log($"mousePos = {mousePos}");
            if (mousePos.x <= 0f)
            {
                return true;
            }        
            if (mousePos.x >= Screen.width)
            {
                return true;
            }          
            if (mousePos.y <= 0f)
            {
                return true;
            }        
            if (mousePos.y >= Screen.height)
            {
                return true;
            }

            return false;
        }
    }
}
