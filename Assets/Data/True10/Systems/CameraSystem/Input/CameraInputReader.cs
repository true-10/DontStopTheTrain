using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static System.Collections.Specialized.BitVector32;

namespace True10.CameraSystem
{
    public interface ICameraInputReader
    {
        float Zoom { get; }
        Vector2 Move { get; }
        Vector2 MouseDelta { get; }
        bool IsRMBPressed { get; }
    }

    [RequireComponent(typeof(PlayerInput))]
    public class CameraInputReader : MonoBehaviour, ICameraInputReader
    {
        public float Zoom => _zoomAction.ReadValue<float>();
        public Vector2 Move => _moveAction.ReadValue<Vector2>().normalized;
        public Vector2 MouseDelta => _mouseMovementDeltaAction.ReadValue<Vector2>().normalized;
        public bool IsRMBPressed => _rightMouseButtonAction.ReadValue<float>() > 0.5f;
        /*  public Vector2 LookAtInput => lookAtAction.ReadValue<Vector2>();
          public bool IsUse => useAction.triggered;// ReadValue<float>() > 0.5f;
        */
        private PlayerInput _playerInput;

        private InputAction _zoomAction;
        private InputAction _moveAction;
        private InputAction _rightMouseButtonAction;
        private InputAction _mouseMovementDeltaAction;
        // private InputAction lookAtAction;
        //private InputAction useAction;

        private const string ZOOM = "Zoom";
        private const string MOVE = "Move";
        private const string RMB = "RMB";
        private const string MOUSE_DELTA = "Mouse Position";

        private void Start()
        {
            _playerInput = GetComponent<PlayerInput>();

            _zoomAction = _playerInput.actions[ZOOM];
            _moveAction = _playerInput.actions[MOVE];
            _rightMouseButtonAction = _playerInput.actions[RMB];
            _mouseMovementDeltaAction = _playerInput.actions[MOUSE_DELTA];
            //lookAtAction = _playerInput.actions["LookAt"];
            //useAction = _playerInput.actions["Use"];
            //functionsAction = _playerInput.actions["Functions"];
            //cancelAction = _playerInput.actions["Cancel"];
        }
    }
}
