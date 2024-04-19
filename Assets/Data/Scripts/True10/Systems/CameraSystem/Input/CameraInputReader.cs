using UnityEngine;
using UnityEngine.InputSystem;

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

        private PlayerInput _playerInput;

        private InputAction _zoomAction;
        private InputAction _moveAction;
        private InputAction _rightMouseButtonAction;
        private InputAction _mouseMovementDeltaAction;

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
        }
    }
}
