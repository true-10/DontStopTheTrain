using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace True10.Characters
{
    [System.Serializable]
    public class MovementCharacterControlBased : IMovable
    {
        [SerializeField]
        private CharacterController characterController;
        [SerializeField]
        private Transform groundChecker;

        [SerializeField]
        private float speed = 12f;
        [SerializeField]
        private float gravity = -9.81f;
        [SerializeField]
        private float jumpHeight = 1f;

        [SerializeField]
        private float groundDist = 0.4f;
        [SerializeField]
        private LayerMask groundMask;

        private Vector3 velocity;
        private bool isGrounded;

        public MovementCharacterControlBased(CharacterController characterController, Transform groundChecker)
        {
            this.characterController = characterController;
            this.groundChecker = groundChecker;
        }

        public void Move(Vector3 direction)
        {
            isGrounded = Physics.CheckSphere(groundChecker.position, groundDist, groundMask);
            if (isGrounded)
            {
                if (velocity.y < 0)
                {
                    velocity.y -= 2f;
                }

                if (Input.GetButtonDown("Jump"))// && isGrounded
                {
                    velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
                }
            }
            float x = direction.x;
            float z = direction.z;
            Vector3 right = characterController.gameObject.transform.right;
            Vector3 forward = characterController.gameObject.transform.forward;

            Vector3 move = right * x + forward * z;

            velocity.y += gravity * Time.deltaTime;

            characterController.Move((velocity + move * speed ) * Time.deltaTime);
        }

        public void Rotate(Vector3 angles)
        {
            //use MouseLook component
        }

    }
}
