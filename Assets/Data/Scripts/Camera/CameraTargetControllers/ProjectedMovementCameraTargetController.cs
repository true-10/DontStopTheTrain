using System;
using System.Collections;
using System.Collections.Generic;
using True10.CameraSystem;
using UnityEngine;

namespace DontStopTheTrain.Gameplay
{
    public class ProjectedMovementCameraTargetController : MonoBehaviour, ICameraTargetController
    {
        [SerializeField] private float moveSpeed = 100f;
        [SerializeField] private Transform dragTarget;

        [SerializeField] string verticalAxis = "Vertical";
        [SerializeField] string horizontalAxis = "Horizontal";

        [SerializeField] Camera camera;


        public Action OnInit { get; set; }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Initialize()
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
            var hValue = Input.GetAxis(horizontalAxis);
            var vValue = Input.GetAxis(verticalAxis);

            Debug.Log($"{name} hValue = {hValue} vValue = {vValue}");

            var trainForward = Vector3.forward;
            var cameraForward = camera.transform.forward;
           /* 
            var mouseVectorMove = new Vector3(mouseX, 0f, mouseY);

            var dot = Vector3.Dot(trainForward, mouseVectorMove);

            var move = dot * moveSpeed * Time.deltaTime;
            MoveAlongTrain(dot);
           */
        }


        public void MoveAlongTrain(float move)
        {
            var position = dragTarget.position;
            position.z += move;
            dragTarget.position = position;
            //Debug.Log($"position = {position} move = {move}");
        }
    }
}
