using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    #region fields
    public bool _disable = false;
    public float m_sensitivity = 100f;
    [SerializeField] private bool _invertX = false;
    [SerializeField] private bool _invertY = false;
    [SerializeField] private bool _hideCursor = false;
    [SerializeField] private Vector2 _xRotationLimits = new Vector2(-90f, 90f);
    [SerializeField] private float _xRotationOffset = 90f;
    private float _signX = 1f;
    private float _signY = 1f;
    public Transform m_body;
    float m_xRotation = 0;
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        if( _hideCursor) Cursor.lockState = CursorLockMode.Locked;
        if (_invertX) _signX = -1f;
        if (_invertY) _signY = -1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (_disable) return;
        float mouseX = Input.GetAxis("Mouse X") * m_sensitivity * GTime.gDeltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * m_sensitivity * GTime.gDeltaTime;

        m_xRotation -= _signX * mouseY;
        m_xRotation = Mathf.Clamp(m_xRotation, _xRotationOffset + _xRotationLimits.x, _xRotationOffset + _xRotationLimits.y);

        transform.localRotation = Quaternion.Euler(m_xRotation, 0f, 0f);
        m_body.Rotate(Vector3.up * mouseX * _signY);
    }
}
