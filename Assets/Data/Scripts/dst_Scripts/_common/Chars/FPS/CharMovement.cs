using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//using Cinemachine;

public class CharMovement : MonoBehaviour
{
    #region fields
    [SerializeField] private CharacterController _controller;

    [SerializeField] private float _speed = 12f;
    [SerializeField] private float _gravity = -9.81f;
    [SerializeField] private float _jumpHeight = 2f;

    [SerializeField] private Transform _groundChecker;
    [SerializeField] private float _groundDist = 0.4f;
    [SerializeField] private LayerMask _groundMask;

    Vector3 _velocity;
    bool _isGrounded;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        
    }


    public void OnUpdate()
    {
        _isGrounded = Physics.CheckSphere(_groundChecker.position, _groundDist, _groundMask);

        if (_isGrounded && _velocity.y < 0)
        {
            _velocity.y -= 2f;
        }
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        _controller.Move(move * _speed * GTime.gDeltaTime);

        if(Input.GetButtonDown("Jump") )
        {
            _velocity.y = Mathf.Sqrt(_jumpHeight * -2f * _gravity);
        }

        _velocity.y += _gravity * GTime.gDeltaTime;
        _controller.Move(_velocity *  GTime.gDeltaTime);
    }
}
