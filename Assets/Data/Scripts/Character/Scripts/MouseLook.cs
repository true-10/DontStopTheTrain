using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace True10.Characters
{
    public class MouseLook : MonoBehaviour
    {
        public float sensitivity = 100f;

        public Transform m_body;
        float m_xRotation = 0;

        void Start()
        {
            //Cursor.lockState = CursorLockMode.Locked;
        }

        void Update()
        {
            float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

            m_xRotation -= mouseY;
            m_xRotation = Mathf.Clamp(m_xRotation, -90f, 90f);

            transform.localRotation = Quaternion.Euler(m_xRotation, 0f, 0f);
            m_body.Rotate(Vector3.up * mouseX);
        }
    }

}
